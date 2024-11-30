using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.StationPages.OP40;
using DWZ_Scada.Pages.StationPages.OP60;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using TouchSocket.Core;

namespace DWZ_Scada.Pages.StationPages.OP70
{
    public class OP70MainFunc : MainFuncBase
    {
        public static bool IsInstanceNull => _instance == null;

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

        public event Action<string,string,bool> OP70FinalCodeFinished;

        public event EntryStateChanged OP70EntryStateChanged;

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP70MainFunc(plcConfig);
        }


        private string curEntrySN;

        public  event TestStateChanged OnVision1Finished;

        public OP70MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP70";
            StationCode = "OP70";
        }

        protected override string GetPLCIP()
        {
            return SystemParams.Instance.OP70_PlcIP;
        }

        protected override int GetPLCPort()
        {
            return SystemParams.Instance.OP70_PlcPort;
        }

        public override  void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            PLC?.Dispose();
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
            if (PLC.ReadInt16(OP70Address.VisionStart, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Debug("收到[OP70]视觉开始信号");
                //复位视觉完成
                PLC.WriteInt16(OP70Address.VisionStart, 0);
                PLC.Read(OP70Address.EntrySn, "string-8", out string sn);
                OnVision1Finished?.Invoke(sn, 0);
            }

            if (PLC.ReadInt16(OP70Address.VisionFinish, out short isFinish) && isFinish==1)
            {
                LogMgr.Instance.Debug("收到[OP70]画像检测完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP70Address.VisionFinish, 0);
                PLC.Read(OP70Address.EntrySn, "string-8", out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP70Address.VisionResult, out short result);
                OnVision1Finished?.Invoke(sn, result);
                bool visionResult = result == 1 ? true : false;
                //界面更新

                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    PassStationData = new OP70Vision1Data()
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
                PLC.WriteInt16(OP70Address.VisionOut,  result);
            }
        }

        private async Task HandleFinalCode()
        {
            if (PLC.ReadInt16(OP70Address.FinalCodeFinish, out short isFinish) && isFinish==1)
            {
                LogMgr.Instance.Debug("收到[OP70]最终码打印完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP70Address.FinalCodeFinish,  0);
                PLC.Read(OP70Address.FinalCodeInfo, "string-30", out string finalCode);
                LogMgr.Instance.Debug("读取最终码内容:" + finalCode);
                //最终码内容
                //PLC.Read(OP70Address.FinalCodeInfo, "string-20",out string finalCode);
                //最终码等级
                //解析最终码等级：
                //PLC.Read(OP70Address.FinalCodeType, "string-1", out string finalCodeType);
                //显示最终码和等级 结果
                string finalCodeType = AnalizeFinalType(finalCode);
                bool finalResult = CheckFinalCodeType(finalCodeType);
                OP70FinalCodeFinished?.Invoke(finalCode, finalCodeType,finalResult);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = curEntrySN,
                    WorkOrder = Global.WorkOrder,
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
                short result = (short)(finalResult ? 1 : 2);
                PLC.WriteInt16(OP70Address.FinalCodeResult, result);
            }
        }

        /// <summary>
        /// 解析最终码等级
        /// </summary>
        /// <param name="finalCode"></param>
        /// <exception cref="NotImplementedException"></exception>
        private string AnalizeFinalType(string finalCode)
        {
            string[] strings = finalCode.Split(":");
            if (strings.Length==2)
            {
                return strings[1];
            }
            else
            {
                return "ERR";
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
            if (PLC.ReadInt16(OP70Address.EntrySignal, out short isEntry) && isEntry==1)
            {
                PLC.WriteInt16(OP70Address.EntrySignal, 0);
                PLC.Read(OP70Address.EntrySn, "string-8", out string sn);
                OP70EntryStateChanged?.Invoke(sn, 0);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn, 
                    StationCode = StationCode, 
                    WorkOrder = Global.WorkOrder
                };
                curEntrySN = sn;
                (bool flag, string msg) = await EntryRequest(requestDto);

                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                OP70EntryStateChanged?.Invoke(sn, result, msg);
                LogMgr.Instance.Debug($"写进站结果{flag}:{result} :\n{msg}");
                PLC.WriteInt16(OP70Address.EntryResult, result);
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