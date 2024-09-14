using DWZ_Scada.DAL.Entity;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using LogTool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc : MainFuncBase, IDisposable
    {
        private static OP10Model myOp10Model = new OP10Model();

        public static string StationName = "OP10";
        //手持扫码枪 切换物料
        //输入物料
        //1.扫码枪
        //2.人工输入
        public static List<DeviceAlarmEntity> CurrentAlarmList = new List<DeviceAlarmEntity>();


        public override void PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            DateTime dt;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    //更新界面设备状态

                    //TODO 这样更新是OK的
                    //PageOP10.Instance.UpdateTempSN(myOp10Model.TempSN);
                    myOp10Model.TempSN = DateTime.Now.ToString("HH:mm:ss fff");
                    if (!IsPlc_Connected)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    #region 读取PLC状态
                    //判断是否点检模式
                    dt = DateTime.Now;
                    // 进站请求信号
                    //TODO 先读一个总的报警信号  如果有报警 再去读报警内容
                    // state状态 报警中 暂停中 运行中
                    //每次循环清一遍
                    CurrentAlarmList.Clear();
                    bool readFlag = PLC.ReadInt16(OP10Address.State, out state);
                    if (readFlag)
                    {
                        #region 循环读取PLC报警信息
                        //适用于少量地址 不连续
                        foreach (PLCAlarmData data in Global.PlcAlarmList)
                        {
                            //连续地址读取
                            string address = data.Address;
                            if (data.IsArray && data.AlarmList.Count > 0)
                            {
                                bool[] alarmArr = new bool[data.Length];
                                bool b = PLC.ReadAlarm(address, out alarmArr, data.Length);
                                if (b)
                                {
                                    for (int i = 0; i < alarmArr.Length; i++)
                                    {
                                        string alarmKey = data.AlarmList[i].Name;
                                        bool isAlarmActive = alarmArr[i];
                                        //假如是True 表示有报警
                                        if (isAlarmActive)
                                        {
                                            Global.IsDeviceAlarm = true;
                                            DeviceAlarmEntity alarmEntity = new DeviceAlarmEntity();
                                            alarmEntity.AlarmInfo = data.AlarmList[i].Name;
                                            alarmEntity.AlarmType = data.AlarmList[i].AlarmType;
                                            alarmEntity.DeviceName = StationName;
                                            alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                                            alarmEntity.AlarmTime = dt;
                                            CurrentAlarmList.Add(alarmEntity);
                                            if (ActiveAlarms.TryAdd(alarmKey, alarmEntity))
                                            {
                                               // ActiveAlarms.Add(alarmKey,new DeviceAlarmEntity());
                                                //TODO 上传报警信息到数据库
                                                // 将报警信息添加到队列中
                                                AlarmQueue.Enqueue(alarmEntity);
                                            }
                                        }
                                        else
                                        {
                                            if (ActiveAlarms.ContainsKey(alarmKey))
                                            {
                                                ActiveAlarms.Remove(alarmKey);
                                                //TODO 上传报警消除状态
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                //读取单个报警地址
                                bool b = PLC.ReadBool(address, out bool isAlarmActive);
                                if (b)
                                {
                                    string alarmKey = data.Name;
                                    if (isAlarmActive)
                                    {
                                        Global.IsDeviceAlarm = true;
                                        DeviceAlarmEntity alarmEntity = new DeviceAlarmEntity();
                                        alarmEntity.AlarmInfo = data.Name;
                                        alarmEntity.AlarmType = data.AlarmType;
                                        alarmEntity.DeviceName = StationName;
                                        alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                                        alarmEntity.AlarmTime = dt;
                                        CurrentAlarmList.Add(alarmEntity);
                                        if (ActiveAlarms.TryAdd(alarmKey, alarmEntity))
                                        {
                                            //TODO 上传新增报警到数据库
                                            AlarmQueue.Enqueue(alarmEntity);
                                        }
                                    }
                                    else
                                    {
                                        if (ActiveAlarms.ContainsKey(alarmKey))
                                        {
                                            ActiveAlarms.Remove(alarmKey);
                                            //TODO 上传报警消除记录

                                        }
                                    }
                                }
                            }


                        }
                        if (state == 2)
                        {
                            //传给Mes当前所有的报警信息
                            //当前设备报警中
                            PlcState = PlcState.Alarm;
                            DeviceState = 2;
                        }
                        else
                        {
                            PlcState = PlcState.Online;
                        }
                        #endregion

                        //获取到PLC的实时状态 上报Mes 
                        //读取报警信号
                        //判断设备当前有无报警
                        //报警信息存数据库 报警内容 时间 

                        //存报警到本地数据库
                        List<DeviceAlarmEntity> alarmList = new List<DeviceAlarmEntity>( CurrentAlarmList);
                        //DeviceControlPage.TriggerDeviceAlarmEvent(alarmList);

                        //界面初始化完成 再进行更新 就不会报错
                        if (DeviceControlPage.IsLoad)
                        {
                            DeviceControlPage.Instance.UpdateAlarm(alarmList);
                        }

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
                            PLC.ReadInt16(OP10Address.Collect, out int collectSignal);
                            if (collectSignal == 1)
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
                                        /*    Material = "物料信息AAA",
                                            VisionData1 = "4dwadwa",
                                            VisionData2 = "sw23435",
                                            VisionPicPath = "D:\\test",
                                            VisionResult = "OK"*/
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
                        IsPlc_Connected =false;
                        LogMgr.Instance.Error("读取PLC 信号异常");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    //IsPlc_Connected = false;
                }
                Thread.Sleep(500);
            }
        }

        private async Task Execute(string tempSN)
        {
            EntryRequestDTO requestDto = new EntryRequestDTO();
            requestDto.SnTemp = tempSN;
            requestDto.StationCode = "OP10";
            await MyClient.CheckIn(requestDto);

        }


        #region 后台监控线程

        #endregion

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            PLC?.Dispose();
        }

        public OP10MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {

        }
    }
}
