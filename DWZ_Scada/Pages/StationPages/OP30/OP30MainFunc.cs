﻿using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using System;
using System.Threading;
using System.Threading.Tasks;
using static DWZ_Scada.Pages.StationPages.MainFuncBase;

namespace DWZ_Scada.Pages.StationPages.OP30
{
    public class OP30MainFunc : MainFuncBase
    {
        public static bool IsInstanceNull => _instance == null;

        private static OP30MainFunc _instance;

        public static OP30MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP30MainFunc))
                    {
                        if (_instance == null)
                        {

                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP30MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP30MainFunc(plcConfig);
        }

        //public delegate void TestStateChanged(string sn, bool result);
        public  event EntryStateChanged OP30EntryStateChanged;

        public  event TestStateChanged OP30VisionFinished;

 
        public OP30MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP30";
            StationCode = "OP30";
        }

        protected override string GetPLCIP()
        {
            return SystemParams.Instance.OP30_PlcIP;
        }

        protected override int GetPLCPort()
        {
            return SystemParams.Instance.OP30_PlcPort;
        }

        public override void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            _cts?.Cancel();
            PLC?.Dispose();
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            int state = -1;
            Thread t1 = new Thread(() => VisionMonitor01(token));
            t1.Start();
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

                    await ProcessEntrySignal();

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }
                Thread.Sleep(1000);
            }
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
                        //处理画像检测结果
                        await HandleVisionResult();
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


        private async Task HandleVisionResult()
        {
            if (PLC.ReadInt16(OP30Address.Vision1Start, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Debug("收到视觉1开始信号");
                //复位视觉完成
                PLC.WriteInt16(OP30Address.Vision1Start, 0);
                PLC.ReadString(OP30Address.VisionSn, 8, out string sn);
                //界面更新
                OP30VisionFinished?.Invoke(sn, 0);
            }

            if (PLC.ReadInt16(OP30Address.VisionFinish, out short isFinish) && isFinish==1)
            {
                LogMgr.Instance.Debug("收到[OP30]视觉完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP30Address.VisionFinish,  0);
                PLC.ReadString(OP30Address.VisionSn, 8, out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP30Address.VisionResult, out short result);

                bool visionResult = result == 1 ? true : false;
                //界面更新
                OP30VisionFinished?.Invoke(sn, result);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    PassStationData = new OP30Vision1Data()
                    {
                        Vision1Result = visionResult,
                        Good = visionResult,
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadData(dto);
                if (res == false)
                {
                    LogMgr.Instance.Error("上传视觉过站数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result == 1 ? "OK" : "NG")}");
                PLC.WriteInt16(OP30Address.VisionOut, result);
            }
        }

        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            try
            {
                if (PLC.ReadInt16(OP30Address.EntrySignal, out short isEntry) && isEntry == 1)
                {
                    PLC.WriteInt16(OP30Address.EntrySignal, 0);
                    PLC.ReadString(OP30Address.EntrySn, 8, out string sn);
                    Logger.Debug($"读取进站二维码:[{sn}]");
                    OP30EntryStateChanged?.Invoke(sn, 0,"");
                    EntryRequestDTO requestDto = new()
                    {
                        SnTemp = sn,
                        StationCode = StationCode,
                        WorkOrder = Global.WorkOrder,
                    };
                    (bool flag, string msg) = await EntryRequest(requestDto);
                    short result = (short)(flag ? 1 : 2);

                    OP30EntryStateChanged?.Invoke(sn, result, msg);
                    LogMgr.Instance.Debug($"写进站结果{result}:{msg}");
                    PLC.WriteInt16(OP30Address.EntryResult, result);
                }
            }
            catch (Exception e)
            {
               LogMgr.Instance.Error("处理进站请求错误:"+e.StackTrace);
            }
         
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP30Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}