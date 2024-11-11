using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc : MainFuncBase, IDisposable
    {
        public static bool IsInstanceNull => _instance == null;

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
                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP10MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP10MainFunc(plcConfig);
        }

        public  event TestStateChanged OnVision1Finished;

        public  event TestStateChanged OnVision2Finished;

        public event EntryStateChanged OnEntryStateChanged;

        public OP10MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP10";
            StationCode = "OP10";
        }

        public override void Dispose()
        {
            base.Dispose();
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
            //await DeviceStateService.AddDeviceState(dto);
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

                    HandleAlarm();
                    // 处理设备状态

                    //这里判断设备是不是点检模式

                    // 处理进站信号
                    await ProcessEntrySignal();

                    ProcessVision1();

                    ProcessVision2();

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
            if (PLC.ReadInt16(OP10Address.Vision1Start, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Debug("收到视觉1开始信号");
                //复位视觉完成
                PLC.WriteInt16(OP10Address.Vision1Start, 0);
                PLC.Read(OP10Address.Vision1_Sn, "string-8", out string sn);

                //界面更新
                OnVision1Finished?.Invoke(sn, 0);
            }
            if (PLC.ReadInt16(OP10Address.Vision1Finish, out short isFinish) && isFinish == 1)
            {
                LogMgr.Instance.Debug("收到视觉1完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP10Address.Vision1Finish, 0);
                PLC.Read(OP10Address.Vision1_Sn, "string-8", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP10Address.Vision1Result, out short v1Result);

                //界面更新
                OnVision1Finished?.Invoke(sn, v1Result);
                bool result = v1Result == 1 ? true : false;
                //上传Mes测试数据

                if (IsSpotCheck)
                {
                    DeviceInspectDTO inspectDTO = new DeviceInspectDTO()
                    {
                        StationCode = StationCode,
                        SnTemp = sn,
                        WorkOrder = "MO202410210001",
                        PassStationData = new OP10Vision1Data()
                        {
                            Vision1Result = result,
                            Good = result,
                        },
                        isLastStep = false
                    };
                    (bool res, string msg) = await UploadSpotCheckData(inspectDTO);
                    if (res == false)
                    {
                        Mylog.Instance.Alarm("点检上传错误:" + msg);
                    }
                }
                else
                {
                    PassStationDTO dto = new PassStationDTO()
                    {
                        StationCode = StationCode,
                        SnTemp = sn,
                        WorkOrder = "MO202410210001",
                        PassStationData = new OP10Vision1Data()
                        {
                            Vision1Result = result,
                            Good = result,
                        },
                        isLastStep = false
                    };
                    (bool res, string msg) = await UploadStationData(dto);
                    if (res == false)
                    {
                        Mylog.Instance.Alarm("上传过站数据错误:" + msg);
                    }
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.Write(OP10Address.Vision1_Out, "Bool", result);
            }
        }

        private async void ProcessVision2()
        {
            if (PLC.ReadInt16(OP10Address.Vision2Start, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Debug("收到视觉2开始信号");
                //复位视觉完成
                PLC.WriteInt16(OP10Address.Vision2Start, 0);
                PLC.Read(OP10Address.Vision2_Sn, "string-8", out string sn);

                //界面更新
                OnVision2Finished?.Invoke(sn, 0);
            }
            if (PLC.ReadInt16(OP10Address.Vision2Finish, out short isFinish) && isFinish == 1)
            {
                LogMgr.Instance.Debug("收到视觉2完成信号");
                //复位视觉2完成
                PLC.WriteInt16(OP10Address.Vision2Finish, 0);

                PLC.Read(OP10Address.Vision2_Sn, "string-8", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP10Address.Vision2Result, out short v1Result);

                //界面更新
                OnVision2Finished?.Invoke(sn, v1Result);
                bool result = v1Result == 1 ? true : false;
                OnVision2Finished?.Invoke(sn, v1Result);
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    SnTemp = sn,
                    WorkOrder = "MO202410210001",
                    StationCode = StationCode,
                    PassStationData = new OP10Vision2Data()
                    {
                        Vision2Result = result,
                        Good = result,
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadStationData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传视觉2数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.Write(OP10Address.Vision2_Out, "Bool", result);

            }
        }


        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadInt16(OP10Address.EntrySignal, out short isEntry) && isEntry == 1)
            {
                //复位进站请求
                PLC.WriteInt16(OP10Address.EntrySignal, 0);
                LogMgr.Instance.Debug("收到进站请求信号");
                PLC.Read(OP10Address.EntrySn, "string-8", out string sn);
                LogMgr.Instance.Debug("读取进站条码内容:" + sn);
                OnEntryStateChanged?.Invoke(sn,0);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = "MO202410210001"
                };
                (bool flag, string msg) = await EntryRequest(requestDto);
               
                LogMgr.Instance.Debug($"写进站结果{flag}");
                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                OnEntryStateChanged?.Invoke(sn, result, msg);
                PLC.WriteInt16(OP10Address.EntryResult, result);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state = -1;
            bool readFlag = PLC.ReadInt16(OP10Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}