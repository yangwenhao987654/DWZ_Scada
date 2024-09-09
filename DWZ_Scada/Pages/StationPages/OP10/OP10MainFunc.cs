using AutoStation;
using CommunicationUtilYwh.Communication;
using CommunicationUtilYwh.Communication.PLC;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZC_DataAcquisition;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc:IDisposable
    {
        private static OP10MainFunc _instance;

        private static OP10Model myOp10Model;

        public static OP10MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP10MainFunc))
                    {
                        if (_instance == null)
                        {
                            _instance = new OP10MainFunc();
                        }
                    }
                }
                return _instance;
            }
        }

        public static bool IsPlc_Connected;

        public LogMgr Logger = LogMgr.Instance;

        public static MyPlc PLC = new KeyencePLC();

        private CancellationTokenSource _cts = new CancellationTokenSource();

        private static int DeviceState = -1;

        private static readonly object stateLock = new object();

        private Timer reportTimer ;


        public void Start(OP10Model op10Model)
        {
            myOp10Model = op10Model;
            //启动PLC监控线程
            Thread t = new Thread(()=>ConnStatusMonitor(_cts.Token));
            t.Start();
            Thread.Sleep(300);
            Thread t2 = new Thread(() => PLCMainWork(_cts.Token));
            t2.Start();
            reportTimer = new Timer(ReportDeviceState, null, 0, 1000);

        }

        /// <summary>
        /// 上报设备状态 1S 上报一次
        /// </summary>
        /// <param name="state"></param>
        private async void ReportDeviceState(object state)
        {
            int currentState;
            lock (stateLock)
            {
                currentState = DeviceState;
            }
            DeviceStateDTO dto = new DeviceStateDTO()
            {
                DeviceCode = "0001",
                DeviceName = "工站01",
            };
            switch (currentState)
            {
                case -1:
                    dto.Status = "停机";
                    break;
                case 1:
                    dto.Status = "运行中";
                    break;
                case 2:
                    dto.Status = "待机中";
                    break;
                default:
                    dto.Status = "错误";
                    break;
            }

            //如果有报警的话 需要带着报警信息

            //记录报警信息

            DeviceStateService stateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();
            await stateService.ReportState(dto);
        }

        private OP10MainFunc()
        {

        }

        //手持扫码枪 切换物料
        //输入物料
        //1.扫码枪
        //2.人工输入

        public static void PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    //TODO 这样更新是OK的
                    PageOP10.Instance.UpdateTempSN(myOp10Model.TempSN);
                    myOp10Model.TempSN = DateTime.Now.ToString("HH:mm:ss fff");
                    if (!IsPlc_Connected)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    #region 读取PLC状态
                    //判断是否点检模式
               
                    // 进站请求信号
                    bool readFlag = PLC.ReadInt16(OP10Address.State, out state);
                    if (readFlag)
                    {
                        //获取到PLC的实时状态 上报Mes 
                        //读取报警信号
                        //判断设备当前有无报警
                        //报警信息存数据库 报警内容 时间 
                        PLC.ReadAlarm(OP10Address.AlarmAddress, out bool[] alarms, 20);
                        for (int i = 0; i < alarms.Length; i++)
                        {
                            if (alarms[i]==true)
                            {
                                //有报警 记录报警信息
                                //报警内容 从Map里取
                                //获取到对应的报警类型

                            }
                        }
                        //存报警到本地数据库

                        lock (stateLock)
                        {
                            DeviceState = state;
                        }

                        PLC.ReadBool(OP10Address.EntrySignal, out isEntry);
                        if (isEntry)
                        {
                            //接受到产品进站请求
                            //读取产品sn码
                            PLC.Read(OP10Address.EntrySn, "string", out var sn);
                            //记录当前sn
                            //请求Mes产品进站
                            OP10EntryCommand entryCommand = new OP10EntryCommand(sn);
                            entryCommand.Execute();
                            //TODO 告诉PLC 能不能进站

                            //读取采集信号
                            PLC.ReadInt16(OP10Address.Collect,out int collectSignal);
                            if (collectSignal==1)
                            {
                                //读取到有采集信号 
                                //开始采集数据
                                //采集出站SN
                                //视觉检测结果

                                // 上传Mes过站数据
                                //采集完成
                                //出站数据
                                PassStationDTO dto = new PassStationDTO()
                                {
                                    StationCode = "OP10",
                                    SnTemp = "AQW12dswSAW",
                                    // PassStationData = n
                                    PassStationData = new OP10Data()
                                    {
                                        Material = "物料信息AAA",
                                        VisionData1 = "4dwadwa",
                                        VisionData2 = "sw23435",
                                        VisionPicPath = "D:\\test",
                                        VisionResult = "OK"
                                    }
                                };
                                MyClient.PassStationUploadTest(dto);
                            }
                        }
                    }
                    else
                    {
                        //读取PLC失败
                        //异常
                        //PLC连接断开 
                        LogMgr.Instance.Error("读取PLC 信号异常");
                    }
                    #endregion
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    IsPlc_Connected = false;
                }
            }
        }

        private  async Task Execute(string tempSN)
        {
            EntryRequestDTO requestDto = new EntryRequestDTO();
            requestDto.SnTemp = tempSN;
            requestDto.StationbCode = "OP10";
            await MyClient.CheckIn(requestDto);

        }


        #region 后台监控线程
        /// <summary>
        /// 后台线程，PLC重连策略
        /// </summary>
        private void ConnStatusMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!IsPlc_Connected)
                {
                    //全局PLC连接配置
                    Logger.Info("PLC连接中");
                    bool flag = PLC.Connect(SystemParams.Instance.OP10_PlcIP, SystemParams.Instance.OP10_PlcPort);
                    if (flag)
                    {
                        IsPlc_Connected = true;
                        Logger.Debug("PLC连接成功");
                    }
                    else
                    {
                        IsPlc_Connected = false;
                        Logger.Error("PLC连接失败:");
                    }
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            _cts.Cancel();
            //释放PLC连接
            PLC?.Dispose();
            reportTimer.Dispose();
        }
    }
}
