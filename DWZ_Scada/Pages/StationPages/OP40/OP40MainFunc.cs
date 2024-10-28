using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.Pages.StationPages.OP20;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP40
{
    public class OP40MainFunc : MainFuncBase, IDisposable
    {
        private static OP40MainFunc _instance;

        public static OP40MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP40MainFunc))
                    {
                        if (_instance == null)
                        {

                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP40MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP40MainFunc(plcConfig);
        }

        public delegate void OP40TestFinished(string sn, bool result);

        public static event OP40TestFinished OnVision1Finished;

        public static event OP40TestFinished OnWeldingFinished;

        public OP40MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP40";
            StationCode = "OP40";
        }

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
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
                DeviceName = StationName,
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

            DeviceStateService stateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();
            //await stateService.AddDeviceState(dto);
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            DateTime dt;
            OP40Model model = new OP40Model();
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!IsPlc_Connected)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    HandleAlarm();

                    // 处理进站信号
                    await ProcessEntrySignal();

                    //处理焊接流程 获取焊接数据
                    await HandleWelding();

                    //处理画像检测
                    await HandleVisionResult();

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }
                Thread.Sleep(1000);
            }
        }

        private async Task HandleWelding()
        {
            if (PLC.ReadBool(OP40Address.WeldingFinish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到[OP40]焊接完成信号");
                //复位视觉完成
                PLC.Write(OP40Address.WeldingFinish, "Bool", false);
                PLC.Read(OP40Address.WeldingSn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                //TODO 读取焊接数据数据
                //PLC.Read(OP40Address.WeldingDataStart, out int result);

                bool result = CheckWeldingData();
                //界面更新
                OnWeldingFinished?.Invoke(sn, result);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = SnTest,
                    WorkOrder = "MO202409110002",
                    PassStationData = new WeldingData()
                    {
                        WeldingResult = result,
                        Good = result,
                        GasA1 = "1.12",
                        GasA2 = "35.654",
                        GasA3 = "35.12",
                        GasA4 = "12.2",
                        GasA5 = "66.5",
                        GasA6 = "0.0",
                        GasB1 = "1201",
                        GasB2 = "12.2",
                        GasB3 = "16.6",
                        GasB4 = "785.5",
                        GasB5 = "78.5",
                        GasB6 = "78.415",
                        GasC1 = "3.23",
                        GasC2 = "5.415",
                        GasC3 = "1.563",
                        GasC4 = "8.453",
                        GasC5 = "4.56",
                        GasC6 = "6.46"
                    },
                    isLastStep = false
                };
                (bool res, string msg) = await UploadPassStationService.SendPassStationData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传焊接数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"焊接结果:{(result ? "OK" : "NG")}");
                PLC.Write(OP40Address.WeldingResult, "Bool", result);
            }
        }

        /// <summary>
        /// 判断绕线数据
        /// </summary>
        /// <returns></returns>
        private bool CheckWeldingData()
        {
            //判断绕线数据 是否正常
            return true;
        }

        private async Task HandleVisionResult()
        {
            if (PLC.ReadBool(OP40Address.VisionFinish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到[OP40]视觉完成信号");
                //复位视觉完成
                PLC.Write(OP40Address.VisionFinish, "Bool", false);
                PLC.Read(OP40Address.VisionSn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP40Address.VisionResult, out short result);

                bool visionResult = result == 1 ? true : false;
                //界面更新
                OnVision1Finished?.Invoke(sn, visionResult);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = SnTest,
                    WorkOrder = "MO202409110002",
                    PassStationData = new Vision1Data()
                    {
                        Vision1Result = visionResult,
                        Good = visionResult,
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadPassStationService.SendPassStationData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传视觉数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result == 1 ? "OK" : "NG")}");
                PLC.Write(OP30Address.VisionOut, "Bool", result);
            }
        }

        // 处理进站信号

        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadBool(OP40Address.EntrySignal, out bool isEntry) && isEntry)
            {
                PLC.Write(OP40Address.EntrySignal, "Bool", false);
                PLC.Read(OP40Address.EntrySn, "string-20", out string sn);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = SnTest,
                    StationCode = StationCode,
                    WorkOrder = "MO202409110002"
                };
                EntryRequestService entryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
                (bool flag, string msg) = await entryRequestService.CheckIn(requestDto);
                //
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                PLC.Write(OP40Address.EntryResult, "Bool", flag);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP40Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}