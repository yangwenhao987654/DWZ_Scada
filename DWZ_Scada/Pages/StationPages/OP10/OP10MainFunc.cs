using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc : MainFuncBase, IDisposable
    {
        public delegate void OP10VisionFinished(string sn, bool result);


        public static event OP10VisionFinished OnVision1Finished;

        public static event OP10VisionFinished OnVision2Finished;


        private static readonly OP10Model myOp10Model = PageOP10.Instance.op10Model;

        private const int AlarmState = 2;

        private const int RunningState = 1;

        /// <summary>
        /// 设备停止中
        /// </summary>
        private const int StopState = 3;

        /// <summary>
        /// PLC连接断开
        /// </summary>
        private const int OffState = -1;

        /// <summary>
        /// 在线状态
        /// </summary>
        private const int OnLineState = 0;

        //手持扫码枪 切换物料
        //输入物料
        //1.扫码枪
        //2.人工输入
        public static List<DeviceAlarmEntity> CurrentAlarmList = new();

        public static List<string> CurAlarmInfoVo = new();

        public string SNTest = "QAZXSWWXHNJJ";


        public OP10MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP10";
            StationCode = "OP10";
        }

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            PLC?.Dispose();
        }
        /// <summary>
        /// 上报设备状态 1S 上报一次
        /// </summary>
        /// <param name="state"></param>
        protected override async void ReportDeviceState(object state)
        {
            int currentState = -1;
            lock (stateLock)
            {
                currentState = DeviceState;
            }
            DeviceStateDTO dto = new DeviceStateDTO()
            {
                DeviceCode = StationCode,
                DeviceName = "OP10工站",
            };
            switch (currentState)
            {
                case -1:
                    dto.Status = "stop";
                    break;
                case 1:
                    dto.Status = "run";
                    break;
                case 2:
                    dto.Status = "run";
                    break;
                default:
                    dto.Status = "breakdown";
                    break;
            }

            //TODO 如果有报警 封装所有的报警信息给Mes

            //如果有报警的话 需要带着报警信息
            lock (alarmLock)
            {
                if (AlarmInfoList.Count > 0)
                {
                    string message = string.Join(";", AlarmInfoList);
                    dto.Message = message;
                }
            }
            await DeviceStateService.AddDeviceState(dto);
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            DateTime dt;
            //myOp10Model.ExitSN = "79898";
            while (!token.IsCancellationRequested)
            {
                try
                {
                    //更新界面设备状态
                    //UpdateDeviceStateUI(model);
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
                    CurAlarmInfoVo.Clear();
                    state = ReadPLCState();
                    UpdateDeviceState(state);
                    if (state != -1)
                    {
                        // 处理报警信息
                        //假如当前有报警 或者是上一次有报警
                        //TODO 上一次有报警 需要清除上一次的报警信息 
                        CurrentAlarmList.Clear();
                        if (state == AlarmState)
                        {
                            lock (alarmLock)
                            {
                                AlarmInfoList.Clear();
                                ProcessAlarms(dt);
                            }
                        }
                        //如果上一次报警了 
                        if (DeviceState == AlarmState && state != AlarmState)
                        {
                            //TODO 可以 foreach 遍历 获取所有报警消除记录
                            ActiveAlarms.Clear();
                        }
                        if (DeviceControlPage.IsLoad)
                        {
                            //DeviceControlPage.Instance.UpdateAlarm(new List<DeviceAlarmEntity>(CurrentAlarmList));
                            DeviceControlPage.Instance.UpdateAlarm(new List<string>(CurAlarmInfoVo));
                        }
                        // 处理设备状态

                        //这里判断设备是不是点检模式

                        // 处理进站信号
                        await ProcessEntrySignal();

                        ProcessVision1();

                        ProcessVision2();
                    }
                    else
                    {
                        HandlePLCReadError();
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }

                Thread.Sleep(1000);
            }
        }

        private async void ProcessVision1()
        {
            if (PLC.ReadBool(OP10Address.Vision1Finish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到视觉1完成信号");
                //复位视觉完成
                PLC.Write(OP10Address.Vision1Finish, "Bool", false);
                PLC.Read(OP10Address.Vision1_Sn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadBool(OP10Address.Vision1Result, out bool result);

                //界面更新
                OnVision1Finished?.Invoke(sn,result);

                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = SNTest,
                    WorkOrder = "MO202409110002",
                    PassStationData = new Vision1Data()
                    {
                        Vision1Result = result,
                        Good = true,
                    },
                    isLastStep = false
                };
                bool isSuccess = await UploadPassStationService.SendPassStationData(dto);
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.Write(OP10Address.Vision1_Out, "Bool", result);

            }
        }

        private async void ProcessVision2()
        {
            if (PLC.ReadBool(OP10Address.Vision2Finish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到视觉2完成信号");
                //复位视觉2完成
                PLC.Write(OP10Address.Vision2Finish, "Bool", false);

                PLC.Read(OP10Address.Vision2_Sn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadBool(OP10Address.Vision2Result, out bool result);

                OnVision2Finished?.Invoke(sn, result);
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    SnTemp = SNTest,
                    WorkOrder = "MO202409110002",
                    StationCode = StationCode,
                    PassStationData = new Vision2Data()
                    {
                        Vision2Result = result,
                        Good = result,
                    },
                    isLastStep = true
                };
                bool isSuccess = await UploadPassStationService.SendPassStationData(dto);
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.Write(OP10Address.Vision2_Out, "Bool", result);


            }
        }

        // 处理出战信号
        private async Task ProcessExitSignal()
        {
            if (PLC.ReadBool(OP10Address.ExitSignal, out bool isExit) && isExit)
            {
                LogMgr.Instance.Debug("收到出站请求信号");
                PLC.Read(OP10Address.ExitSn, "string", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                OP10EntryCommand entryCommand = new(sn);
                entryCommand.Execute();

                //
                LogMgr.Instance.Debug("写出站结果OK");
                PLC.Write(OP10Address.ExitResult, "Bool", true);

            }
        }

        // 更新设备状态到UI
        private void UpdateDeviceStateUI(OP10Model model)
        {
            model.ExitSN = "123";
            myOp10Model.ExitSN = DateTime.Now.ToString("HH:mm:ss fff");
            PageOP10.Instance.UpdateTempSN(myOp10Model.ExitSN);
        }

        private void ProcessAlarms(DateTime dt)
        {
            CurrentAlarmList.Clear();

            foreach (PLCAlarmData data in Global.PlcAlarmList)
            {
                if (data.IsArray && data.AlarmList.Count > 0)
                {
                    HandleArrayAlarm(data, dt);
                }
                else
                {
                    HandleSingleAlarm(data, dt);
                }
            }
            // 更新UI

        }

        // 处理数组形式的报警
        private void HandleArrayAlarm(PLCAlarmData data, DateTime dt)
        {
            bool[] alarmArr = new bool[data.Length];
            if (PLC.ReadAlarm(data.Address, out alarmArr, data.Length))
            {
                for (int i = 0; i < alarmArr.Length; i++)
                {
                    string alarmKey = data.AlarmList[i].Name;
                    bool isAlarmActive = alarmArr[i];
                    DeviceAlarmEntity alarmEntity = new();
                    alarmEntity.AlarmInfo = data.AlarmList[i].Name;
                    alarmEntity.AlarmType = data.AlarmList[i].AlarmType;
                    alarmEntity.DeviceName = StationName;
                    alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                    alarmEntity.AlarmTime = dt;
                    UpdateAlarmStatus(alarmKey, isAlarmActive, alarmEntity, dt);
                }
            }
        }

        // 处理单一报警
        private void HandleSingleAlarm(PLCAlarmData data, DateTime dt)
        {
            if (PLC.ReadBool(data.Address, out bool isAlarmActive))
            {
                string alarmKey = data.Name;
                DeviceAlarmEntity alarmEntity = new();
                alarmEntity.AlarmInfo = data.Name;
                alarmEntity.AlarmType = data.AlarmType;
                alarmEntity.DeviceName = StationName;
                alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                alarmEntity.AlarmTime = dt;
                UpdateAlarmStatus(alarmKey, isAlarmActive, alarmEntity, dt);
            }
        }

        private void HandlePLCReadError()
        {
            IsPlc_Connected = false;
            LogMgr.Instance.Error("读取PLC 信号异常");
        }

        // 更新报警状态
        private void UpdateAlarmStatus(string alarmKey, bool isActive, DeviceAlarmEntity alarmEntity, DateTime dt)
        {
            if (isActive)
            {
                Global.IsDeviceAlarm = true;
                CurAlarmInfoVo.Add($"{alarmEntity.AlarmTime:yyyy:MM:dd hh:mm:ss}:{alarmEntity.AlarmInfo}--{alarmEntity.AlarmType}");
                CurrentAlarmList.Add(alarmEntity);
                AlarmInfoList.Add(alarmEntity.AlarmInfo);
                if (ActiveAlarms.TryAdd(alarmKey, alarmEntity))
                {
                    AlarmQueue.Enqueue(alarmEntity);
                    // TODO: 上传报警信息到数据库
                }
            }
            else
            {
                if (ActiveAlarms.ContainsKey(alarmKey))
                {
                    ActiveAlarms.Remove(alarmKey);
                    // TODO: 上传报警消除记录
                }
            }
        }

        private void ClearAlarmState()
        {
            CurrentAlarmList = new List<DeviceAlarmEntity>();



        }

        /// <summary>
        /// 更新设备状态
        /// </summary>
        /// <param name="state"></param>
        private void UpdateDeviceState(int state)
        {
            if (state == AlarmState)
            {
                PlcState = PlcState.Alarm;
                //DeviceState = 2;
            }
            else if (state == RunningState)
            {
                PlcState = PlcState.Running;
            }
            else if (state == OffState)
            {
                PlcState = PlcState.OffLine;

            }
            else if (state == StopState)
            {
                PlcState = PlcState.Stop;
            }
            else
            {
                PlcState = PlcState.Online;
            }
            lock (stateLock)
            {
                DeviceState = state;
            }
        }


        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadBool(OP10Address.EntrySignal, out bool isEntry) && isEntry)
            {
                //复位进站请求
                PLC.Write(OP10Address.EntrySignal, "Bool", false);
                LogMgr.Instance.Debug("收到进站请求信号");
                PLC.Read(OP10Address.EntrySn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取进站条码内容:" + sn);
                //更新界面
                PageOP10.Instance.UpdateEnrtySN(sn);
                PageOP10.Instance.ClearEntryResult();

                EntryRequestDTO requestDto = new()
                {
                    SnTemp = SNTest,
                    StationCode = StationCode,
                    WorkOrder = "MO202409110002"
                };
                EntryRequestService entryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
                (bool flag, string msg) = await entryRequestService.CheckIn(requestDto);
                //
                PageOP10.Instance.UpdateEnrtyResult(flag,msg);
                LogMgr.Instance.Debug($"写进站结果{flag}");
                PLC.Write(OP10Address.EntryResult, "Bool", flag);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        private int ReadPLCState()
        {
            int state;
            bool readFlag = PLC.ReadInt16(OP10Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }

        private async Task Execute(string tempSN)
        {
            EntryRequestDTO requestDto = new();
            requestDto.SnTemp = tempSN;
            requestDto.StationCode = "OP10";
            EntryRequestService entryService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
            await entryService.CheckIn(requestDto);
        }
    }
}