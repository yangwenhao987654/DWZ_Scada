using AutoStation;
using CommunicationUtilYwh.Communication.PLC;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using LogTool;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc:IDisposable
    {
        private static OP10MainFunc _instance;

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

        public static KeyencePLC PLC = new KeyencePLC();

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public void Start()
        {
            //启动PLC监控线程
            Thread t = new Thread(()=>ConnStatusMonitor(_cts.Token));
            t.Start();
            Thread.Sleep(300);
            Thread t2 = new Thread(() => PLCMainWork(_cts.Token));
            t2.Start();
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
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!IsPlc_Connected)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    #region 读取PLC状态
                    // 进站请求信号
                    bool flag = PLC.ReadBool(OP10Address.EntrySignal,out isEntry);
                    if (flag)
                    {
                        if (isEntry)
                        {
                            //接受到产品进站请求
                            //读取产品sn码
                            PLC.Read(OP10Address.EntrySn, "string", out var sn);
                            //记录当前sn
                            //请求Mes产品进站
                            OP10EntryCommand entryCommand = new OP10EntryCommand(sn);
                            entryCommand.Execute();
                        }
                    }
                    else
                    {
                        //读取PLC失败
                        //异常
                        LogMgr.Instance.Error("读取PLC 信号异常");
                    }
                    #endregion
                    Thread.Sleep(100);
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
        }
    }
}
