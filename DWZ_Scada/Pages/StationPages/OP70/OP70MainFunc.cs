using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.HttpServices;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP70
{
    public class OP70MainFunc : MainFuncBase, IDisposable
    {
        private static OP70MainFunc _instance;

        public static OP70MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP70MainFunc))
                    {
                        if (_instance == null)
                        {

                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP70MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP70MainFunc(plcConfig);
        }

        public delegate void OP10VisionFinished(string sn, bool result);

        public static event OP10VisionFinished OnVision1Finished;

        public OP70MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP70";
            StationCode = "OP70";
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
            //await DeviceStateService.AddDeviceState(dto);
        }

        public override async void  PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            DateTime dt;
            OP70Model model = new OP70Model();
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
                     HandleAlarm();

                    await ProcessEntrySignal();

                    //1.处理画像检测
                    await HandleVisionResult();

                    //2.处理最终码
                    await HandleFinalCode();
                    #endregion
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }

                Thread.Sleep(1000);
            }
        }
        private async Task  HandleVisionResult()
        {
            if (PLC.ReadBool(OP70Address.VisionFinish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到[OP70]画像检测完成信号");
                //复位视觉完成
                PLC.Write(OP70Address.VisionFinish, "Bool", false);
                PLC.Read(OP70Address.EntrySn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP70Address.VisionResult, out short result);

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
                    PassStationData = new OP10Vision1Data()
                    {
                        Vision1Result = visionResult,
                        Good = visionResult,
                    },
                    isLastStep = false
                };
                (bool res, string msg) = await UploadStationData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传视觉数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result == 1 ? "OK" : "NG")}");
                PLC.Write(OP70Address.VisionOut, "Bool", result);
            }
        }

        private async Task HandleFinalCode()
        {
            if (PLC.ReadBool(OP70Address.FinalCodeFinish, out bool isFinish) && isFinish)
            {
                LogMgr.Instance.Debug("收到[OP70]最终码打印完成信号");
                //复位视觉完成
                PLC.Write(OP70Address.FinalCodeFinish, "Bool", false);
                PLC.Read(OP70Address.EntrySn, "string-20", out string sn);
                LogMgr.Instance.Debug("读取进站条码内容:" + sn);
                //最终码内容
                PLC.Read(OP70Address.FinalCodeInfo, "string-20",out string finalCode);
                //最终码等级
                PLC.Read(OP70Address.FinalCodeType, "string-10", out string finalCodeType);
             
                bool finalResult = CheckFinalCodeType(finalCodeType);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = SnTest,
                    WorkOrder = "MO202409110002",
                    PassStationData = new FinalCodeData()
                    {
                        Good = finalResult,
                        SN = finalCode,
                        Level = finalCodeType
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadStationData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传最终码数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"最终码等级:{finalCodeType} 结果:{finalResult}:");
                PLC.Write(OP70Address.FinalCodeResult, "Bool", finalResult);
            }
        }

        private bool CheckFinalCodeType(string finalCodeType)
        {
            bool result = false;
            switch (finalCodeType)
            {
                case "A":
                    result =true; 
                    break;
                case "B":
                    result =true; 
                    break;
                case "C":
                    result =false; 
                    break;
                default:
                    break;
            }
            return result;
        }

        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadBool(OP70Address.EntrySignal, out bool isEntry) && isEntry)
            {
                PLC.Write(OP70Address.EntrySignal, "Bool", false);
                PLC.Read(OP70Address.EntrySn, "string-20", out string sn);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = SnTest, StationCode = StationCode, WorkOrder = "MO202409110002"
                };
                EntryRequestService entryRequestService =
                    Global.ServiceProvider.GetRequiredService<EntryRequestService>();
                (bool flag, string msg) = await entryRequestService.CheckIn(requestDto);
                //
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                PLC.Write(OP70Address.EntryResult, "Bool", flag);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP70Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}