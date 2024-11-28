using CommunicationUtilYwh.Device;
using DWZ_Scada.ctrls;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10MainFunc : MainFuncBase
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

        public event TestStateChanged OnVision1Finished;

        public event TestStateChanged OnVision2Finished;

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

        public override async void PLCMainWork(CancellationToken token)
        {
            int state = -1;
            Thread t1 = new Thread(() => VisionMonitor01(token));
            t1.Start();

            Thread t2 = new Thread(() => VisionMonitor02(token));
            t2.Start();

          /*  Thread t3 = new Thread(() => TemperatureMonitor(token));
            t3.Start();*/
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

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }

                Thread.Sleep(1000);
            }
        }

        protected override string GetPLCIP()
        {
            return SystemParams.Instance.OP10_PlcIP;
        }

        protected override int GetPLCPort()
        {
            return SystemParams.Instance.OP10_PlcPort;
        }

      

        /// <summary>
        /// 画像检测流程
        /// </summary>
        /// <param name="token"></param>
        private async void VisionMonitor01(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        await ProcessVision1();
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("画像检测1线程错误:" + e.Message);
                }
            }
        }

        /// <summary>
        /// 画像检测流程2
        /// </summary>
        /// <param name="token"></param>
        private async void VisionMonitor02(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        await ProcessVision2();
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("画像检测2线程错误:" + e.Message);
                }
            }
        }

        private async Task ProcessVision1()
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
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    PassStationData = new OP10Vision1Data()
                    {
                        Vision1Result = result,
                        Good = result,
                    },
                    isLastStep = false
                };
                (bool res, string msg) = await UploadData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传过站数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.WriteInt16(OP10Address.Vision1_Out, v1Result);
            }
        }

        private async Task ProcessVision2()
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
                PLC.ReadInt16(OP10Address.Vision2Result, out short v2Result);

                //界面更新
                OnVision2Finished?.Invoke(sn, v2Result);
                bool result = v2Result == 1 ? true : false;
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    StationCode = StationCode,
                    PassStationData = new OP10Vision2Data()
                    {
                        Vision2Result = result,
                        Good = result,
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadData(dto);
                if (res == false)
                {
                    Mylog.Instance.Alarm("上传视觉2数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result ? "OK" : "NG")}");
                PLC.WriteInt16(OP10Address.Vision2_Out, v2Result);
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

                if (!CheckWorkOrderState(OnEntryStateChanged, sn))
                {
                    LogMgr.Instance.Error($"OP10 物料匹配失败，阻止进站 SN:[{sn}]");
                    return;
                }
                OnEntryStateChanged?.Invoke(sn, 0);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = Global.WorkOrder
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