﻿using CommonUtilYwh.Communication.ModbusTCP;
using DWZ_Scada.ctrls;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.DTO.OP20;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class OP20MainFunc : MainFuncBase
    {
        public static bool IsInstanceNull => _instance == null;

        private static OP20MainFunc _instance;
        public static OP20MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP20MainFunc))
                    {
                        if (_instance == null)
                        {
                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP20MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP20MainFunc(plcConfig);
        }

        public List<ModbusTCP> ModbusTcpList = new();

        public List<ModbusConnConfig> ModbusConnections = new List<ModbusConnConfig>();

        public event Action<int, int> OnWeldingStateChangedAction;

        public event Action<int, string, string> OnWeldingStart;

        public event EntryStateChanged OnEntryStateChanged01;

        public event EntryStateChanged OnEntryStateChanged02;

        public OP20MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP20";
            StationCode = "OP20";
        }

        protected override string GetPLCIP()
        {
            return SystemParams.Instance.OP20_PlcIP;
        }

        protected override int GetPLCPort()
        {
            return SystemParams.Instance.OP20_PlcPort;
        }

        public override void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            _cts?.Cancel();
            PLC?.Dispose();
            foreach (ModbusTCP modbusTcp in ModbusTcpList)
            {
                modbusTcp?.Dispose();
            }
        }

        public override void StartAsync()
        {
            base.StartAsync();
            List<string> w1 =new List<string>();
            List<string> w2 = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                w1.Add(i.ToString());
                w2.Add(i.ToString());
            }

            if (SystemParams.Instance.OP20_WuliaoList1==null)
            {
                SystemParams.Instance.OP20_WuliaoList1 = new List<string>();
                SystemParams.Instance.OP20_WuliaoList1.AddRange(w1);
            }
            if (SystemParams.Instance.OP20_WuliaoList2 == null)
            {
                SystemParams.Instance.OP20_WuliaoList2 = new List<string>();
                SystemParams.Instance.OP20_WuliaoList2.AddRange(w2);
            }

            for (int i = 0; i < SystemParams.Instance.OP20_WuliaoList1.Count; i++)
            {
                PageOP20.Instance.WindingCtrlList[i].Wuliao1 = SystemParams.Instance.OP20_WuliaoList1[i];
                PageOP20.Instance.WindingCtrlList[i].Wuliao2 = SystemParams.Instance.OP20_WuliaoList2[i];
            }
            //TODO 增加Modbus TCP 的连接
            Task.Run(() =>
            {
                try
                {
                    ModbusConnections = new List<ModbusConnConfig>
            {
                new (1,SystemParams.Instance.OP20_Winding1_IP, SystemParams.Instance.OP20_Winding1_Port, SystemParams.Instance.OP20_Winding1_StationNum),
                new (2,SystemParams.Instance.OP20_Winding2_IP, SystemParams.Instance.OP20_Winding2_Port, SystemParams.Instance.OP20_Winding2_StationNum),
                new (3,SystemParams.Instance.OP20_Winding3_IP, SystemParams.Instance.OP20_Winding3_Port, SystemParams.Instance.OP20_Winding3_StationNum),
                new (4,SystemParams.Instance.OP20_Winding4_IP, SystemParams.Instance.OP20_Winding4_Port, SystemParams.Instance.OP20_Winding4_StationNum),
                new (5,SystemParams.Instance.OP20_Winding5_IP, SystemParams.Instance.OP20_Winding5_Port, SystemParams.Instance.OP20_Winding5_StationNum),
                new (6,SystemParams.Instance.OP20_Winding6_IP, SystemParams.Instance.OP20_Winding6_Port, SystemParams.Instance.OP20_Winding6_StationNum),
                new (7,SystemParams.Instance.OP20_Winding7_IP, SystemParams.Instance.OP20_Winding7_Port, SystemParams.Instance.OP20_Winding7_StationNum),
                new (8,SystemParams.Instance.OP20_Winding8_IP, SystemParams.Instance.OP20_Winding8_Port, SystemParams.Instance.OP20_Winding8_StationNum),
                new (9,SystemParams.Instance.OP20_Winding9_IP, SystemParams.Instance.OP20_Winding9_Port, SystemParams.Instance.OP20_Winding9_StationNum),
                new (10,SystemParams.Instance.OP20_Winding10_IP, SystemParams.Instance.OP20_Winding10_Port, SystemParams.Instance.OP20_Winding10_StationNum),
                new (11,SystemParams.Instance.OP20_Winding11_IP, SystemParams.Instance.OP20_Winding11_Port, SystemParams.Instance.OP20_Winding11_StationNum),
                new(12,SystemParams.Instance.OP20_Winding12_IP, SystemParams.Instance.OP20_Winding12_Port, SystemParams.Instance.OP20_Winding12_StationNum)
            };
                    SystemParams.Instance.PropertyChanged += Instance_PropertyChanged;
                    int a = 0;
                    for (int i = 0; i < ModbusConnections.Count; i++)
                    {
                        int index = i;
                        var modbusTcp = new ModbusTCP();
                        var connection = ModbusConnections[index];
                        //modbusTcp.Open(connection.IP, connection.Port, connection.StationNum);
                        ModbusTcpList.Add(modbusTcp);
                        //假如绕线机禁用了
                        if (!SystemParams.Instance.OP20_WeldingEnableList[index])
                        {
                            OnWeldingStateChangedAction?.Invoke(index, WindingState.Disable);
                        }

                        Thread thread = new Thread(() => MonitorWindingMachine(_cts.Token, modbusTcp, index));
                        thread.Start();
                    }
                }
                catch (Exception e)
                {
                    UIMessageBox.ShowError($"启动绕线机连接错误:{e.Message},:异常堆栈:{e.StackTrace}");
                    LogMgr.Instance.Error($"启动绕线机连接错误:{e.Message},:异常堆栈:{e.StackTrace}");
                }
            });
        }

        private void Instance_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var pre = $"OP20_Winding";
            if (!e.PropertyName.StartsWith(pre))
            {
                return;
            }
            for (int i = 0; i < ModbusConnections.Count; i++)
            {
                var prefix = $"OP20_Winding{i + 1}_";
                if (e.PropertyName.StartsWith(prefix))
                {
                    var property = e.PropertyName.Replace(prefix, "");
                    var modbusProperty = typeof(ModbusConnConfig).GetProperty(property);
                    if (modbusProperty != null)
                    {
                        var modbusConnection = ModbusConnections[i];
                        var value = typeof(SystemParams).GetProperty(e.PropertyName)?.GetValue(SystemParams.Instance);
                        modbusProperty.SetValue(modbusConnection, value);
                    }
                    break;
                }
            }
        }

        // Generic method to monitor each winding machine
        private async Task MonitorWindingMachine(CancellationToken token, ModbusTCP modbusTcp, int index)
        {
            while (!token.IsCancellationRequested)
            {
                short state = -1;
                short workState = -1;
                try
                {
                    //假如绕线机启用了
                    if (SystemParams.Instance.OP20_WeldingEnableList[index])
                    {
                        if (modbusTcp.IsConnect)
                        {
                            //modbusTcp.ReadInt16(CoildAddress.CoilsState, out state);
                            modbusTcp.ReadInt16(CoildAddress.WorkState, out workState);
                            if (workState != 0)
                            {
                                if (workState == 1)
                                {
                                    //绕线中
                                    state = WindingState.Running;
                                }
                                else if (workState == 2)
                                {
                                    //绕线完成
                                    state = WindingState.Stop;
                                }
                            }

                            bool isAlarm = false;
                            modbusTcp.ReadInt16(CoildAddress.AlarmState, 3, out var alarmArr);
                            for (int i = 0; i < alarmArr.Length; i++)
                            {
                                if (alarmArr[i] != 0)
                                {
                                    isAlarm = true;
                                    LogMgr.Instance.Debug($"读取报警:[{i + 1}],值:[{alarmArr[i]}]");
                                }
                            }

                            if (isAlarm)
                            {
                                state = WindingState.Alarm;
                            }
                            await ReportDeviceState(index + 1, state);
                            /*bool flag = modbusTcp.ReadUInt16("2000", out ushort value);
                            modbusTcp.ReadInt16("2041", out short tension1);*/
                        }
                        else
                        {
                            (bool flag, string err) = modbusTcp.Open(
                                ModbusConnections[index].IP,
                                ModbusConnections[index].Port,
                                ModbusConnections[index].StationNum
                            );
                            if (!flag)
                            {
                                //state = 0;
                                await ReportDeviceState(index + 1, WindingState.OffLine);

                                LogMgr.Instance.Error($"ThreadId:{Thread.CurrentThread.ManagedThreadId}  Winding machine {index} connection failed: {err}");
                                LogMgr.Instance.Error($"Winding machine {index} IP:{ModbusConnections[index].IP} Port:{ModbusConnections[index].Port}");
                            }
                        }
                    }
                    else
                    {
                        modbusTcp.IsConnect = false;
                        modbusTcp.Close();
                        //Thread.Sleep(1000);
                        state = WindingState.Disable;
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"绕线机线程[{index + 1}]错误, {e.Message}\n{e.StackTrace}");
                }
                OnWeldingStateChangedAction?.Invoke(index, state);
                Thread.Sleep(1000);
            }
        }

        public async Task ReportDeviceState(int weldingMachineId, short state)
        {
            //short currentState = -1;
            DeviceStateDTO dto = new DeviceStateDTO();
            dto.DeviceName = "OP20绕线机" + weldingMachineId.ToString("D2");
            dto.DeviceCode = "OP20_" + weldingMachineId.ToString("D2");

            switch (state)
            {
                case WindingState.Stop:
                    dto.Status = "stop";
                    break;
                case WindingState.Alarm:
                    dto.Status = "breakdown";
                    break;
                case WindingState.Running:
                    dto.Status = "run";
                    break;
                default:
                    dto.Status = "stop";
                    break;
            }
            await DeviceStateService.AddDeviceState(dto);
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            //进站信号

            int state = -1;
            Thread t1 = new Thread(() => WindingMonitor(token));
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
                    #region 读取PLC状态
                    HandleAlarm();
                    #endregion

                    // 处理进站信号
                    await ProcessEntrySignal01();

                    await ProcessEntrySignal02();

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 绕线检查流程
        /// </summary>
        /// <param name="token"></param>
        private async void WindingMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        //获取绕线完成位置
                        //GetWindingPos();

                        //获取绕线开始信号
                        WindingStart();
                        WindingFinish();
                        Thread.Sleep(500);
                    }

                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("PLC绕线检查监控线程错误:" + e.Message);
                }
            }
        }

        private void WindingFinish()
        {
            //TODO 收到绕线开始信号  读取条码  采集绕线机测试数据
            //持续监控绕线机状态
            if (PLC.ReadInt16(OP20Address.Winding01Finish, 12, out short[] startArr))
            {
                for (var i = 0; i < startArr.Length; i++)
                {
                    if (startArr[i] == 1)
                    {
                        //绕线机开始
                        LogMgr.Instance.Info($"收到绕线[{i + 1}]完成...");
                        PLC.WriteInt16(OP20Address.WindingFinishList[i], 0);
                    }
                }
            }
        }

        private void WindingStart()
        {
            //TODO 收到绕线开始信号  读取条码  采集绕线机测试数据
            //持续监控绕线机状态
            if (PLC.ReadInt16(OP20Address.Winding01Start, 12, out short[] startArr))
            {
                for (var i = 0; i < startArr.Length; i++)
                {
                    if (startArr[i] == 1)
                    {
                        //绕线机开始
                        LogMgr.Instance.Info($"收到绕线[{i + 1}]开始...");

                        if (ModbusTcpList[i] == null)
                        {
                            Logger.Error("绕线机未连接");
                            return;
                        }
                        PLC.WriteInt16(OP20Address.WindingStartList[i], 0);

                        int index = i;
                        Task task = Task.Run(async () =>
                                        {
                                            try
                                            {
                                                //TODO 读取两次绕线的SN码

                                                PLC.ReadString(OP20Address.SNAddrList[index * 2], 8, out string sn1);
                                                PLC.ReadString(OP20Address.SNAddrList[(index * 2) + 1], 8, out string sn2);

                                                Logger.Debug($"读取SN1:[{sn1}]");
                                                Logger.Debug($"读取SN2:[{sn2}]");
                                                OnWeldingStart?.Invoke(index, sn1, sn2);
                                                //string sn2 = "TestCode002";
                                                bool isStart = false;
                                                bool isFinish = false;
                                                Stopwatch sw = Stopwatch.StartNew();
                                                sw.Start();
                                                int timeout = SystemParams.Instance.OP20_WindingTimeOut;
                                                if (timeout < (60 * 1))
                                                {
                                                    timeout = 60 * 1;
                                                }
                                                bool isSendOver = false;
                                                ModbusTCP modbusTcp = ModbusTcpList[index];
                                                List<short> tensionList_A = new List<short>();
                                                List<short> tensionList_B = new List<short>();
                                                //string str = string.Join(",", doubles);

                                                DateTime startDt = DateTime.Now;
                                                //TODO 增加一个超
                                                while (true) //300秒 60*5 5分钟
                                                {
                                                    if (!modbusTcp.IsConnect)
                                                    {
                                                        LogMgr.Instance.Error($"绕线机[{index + 1}]未连接");

                                                        break;
                                                    }
                                                    modbusTcp.ReadUInt16(CoildAddress.WorkState, out ushort workState);
                                                    if (workState == 1)
                                                    {
                                                        Logger.Debug("绕线开始中");
                                                    }
                                                    else if (workState == 2)
                                                    {
                                                        Logger.Debug("绕线结束中");
                                                    }
                                                    else
                                                    {
                                                        Logger.Debug($"绕线工作状态位:{workState}");
                                                    }

                                                    modbusTcp.ReadUInt16(CoildAddress.CoilsState, out ushort state);
                                                    LogMgr.Instance.Info($"读取到绕线状态位:{state}");

                                                    if (state == 1 && isStart)
                                                    {
                                                        //停止
                                                        LogMgr.Instance.Debug("读取到绕线停止..1");
                                                        isFinish = true;
                                                        if (workState == 1)
                                                        {
                                                            LogMgr.Instance.Debug("绕线工作完成");
                                                        }
                                                        else
                                                        {
                                                            LogMgr.Instance.Debug($"绕线工作状态:{workState}");
                                                        }

                                                        CoildDataDto dto = new CoildDataDto();
                                                        dto.BreachNo= PageOP20.Instance.WindingCtrlList[index].Wuliao1;
                                                        //dto.BreachNo = Global.BreachNo;
                                                        //运行中
                                                        modbusTcp.ReadUInt32(CoildAddress.CoilsCurNum, out uint coilsCurNum);
                                                        dto.CoilsCurNum = coilsCurNum / 100;
                                                        modbusTcp.ReadUInt32(CoildAddress.CoilsTargetNum, out uint coilsTargetNum);
                                                        dto.CoilsTargetNum = coilsTargetNum / 100;
                                                        DateTime endDt = DateTime.Now;
                                                        dto.WindingStartDt = startDt;
                                                        dto.WindingEndDt = endDt;
                                                        dto.WindingStation = "工位1";
                                                        dto.WindingMechineName = $"绕线机{index + 1}";
                                                        
                                                        /*  ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsSpeed, out uint coilsSpeed);
                                                          dto.CoilsSpeed = coilsSpeed / 100;*/

                                                        modbusTcp.ReadUInt32(CoildAddress.CoilsTimes, out uint times);
                                                        dto.CoilsTimes = times / 100;
                                                        dto.Good = true;
                                                        //采集张力值 TODO 需要区分是A/B哪个工位
                                                        modbusTcp.ReadInt16(CoildAddress.TensionValue01, out short tension01);
                                                        //dto.TensionValueList=new List<double> { tension01/100 };
                                                        CoildDataDto dto02 = new CoildDataDto(dto);
                                                        dto02.BreachNo = PageOP20.Instance.WindingCtrlList[index].Wuliao2;
                                                        //dto.TensionValue
                                                        tensionList_A.Add(tension01);
                                                        modbusTcp.ReadInt16(CoildAddress.TensionValue02, out short tension02);

                                                        tensionList_B.Add(tension02);
                                                        string tensionStr_A = string.Join(',', tensionList_A);
                                                        dto.TensionValue = tensionStr_A;
                                                        string tensionStr_B = string.Join(',', tensionList_B);
                                                        dto02.TensionValue = tensionStr_B;
                                                        dto02.Good = true;
                                                        dto02.WindingStartDt = startDt;
                                                        dto02.WindingEndDt = endDt;
                                                        dto02.WindingStation = "工位2";
                                                        dto02.WindingMechineName = $"绕线机{index + 1}";
                                                        //dto02.TensionValueList = new List<double> { tension02/100 };
                                                        PassStationDTO passStationDto01 = new PassStationDTO()
                                                        {
                                                            isLastStep = true,
                                                            SnTemp = sn1,
                                                            StationCode = StationCode,
                                                            WorkOrder = Global.WorkOrder,
                                                            PassStationData = dto
                                                        };
                                                        await UploadData(passStationDto01);

                                                        PassStationDTO passStationDto02 = new PassStationDTO()
                                                        {
                                                            isLastStep = true,
                                                            SnTemp = sn2,
                                                            StationCode = StationCode,
                                                            WorkOrder = Global.WorkOrder,
                                                            PassStationData = dto02
                                                        };
                                                        await UploadData(passStationDto02);
                                                        isSendOver = true;
                                                        break;
                                                    }
                                                    else if (state == 12)
                                                    {
                                                        isStart = true;
                                                        if (!isStart)
                                                        {
                                                            LogMgr.Instance.Debug("读取到绕线开始..WorkState:12");
                                                            //TODO 一直读取当前绕线张力值
                                                            modbusTcp.ReadInt16(CoildAddress.TensionValue01, out short tension01);

                                                            tensionList_A.Add(tension01);

                                                            modbusTcp.ReadInt16(CoildAddress.TensionValue02, out short tension02);

                                                            tensionList_B.Add(tension02);

                                                        }
                                                    }

                                                    if (sw.Elapsed.TotalSeconds > timeout)
                                                    {
                                                        LogMgr.Instance.Info($"绕线机采集超时");
                                                        if (!isSendOver)
                                                        {
                                                            //TODO 假如数据没有上传完 这里需不需要上传
                                                            CoildDataDto dto = new CoildDataDto();
                                                            dto.BreachNo = Global.BreachNo;
                                                            //运行中
                                                            modbusTcp.ReadUInt32(CoildAddress.CoilsCurNum, out uint coilsCurNum);
                                                            dto.CoilsCurNum = coilsCurNum / 100;
                                                            modbusTcp.ReadUInt32(CoildAddress.CoilsTargetNum, out uint coilsTargetNum);
                                                            dto.CoilsTargetNum = coilsTargetNum / 100;

                                                            /*  ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsSpeed, out uint coilsSpeed);
                                                              dto.CoilsSpeed = coilsSpeed / 100;*/

                                                            modbusTcp.ReadUInt32(CoildAddress.CoilsTimes, out uint times);
                                                            dto.CoilsTimes = times / 100;
                                                            dto.Good = true;
                                                            DateTime endDt = DateTime.Now;
                                                            dto.WindingStartDt = startDt;
                                                            dto.WindingEndDt = endDt;
                                                            dto.WindingStation = "工位1";
                                                            dto.WindingMechineName = $"绕线机{index + 1}";
                                                            //采集张力值 TODO 需要区分是A/B哪个工位
                                                            modbusTcp.ReadInt16(CoildAddress.TensionValue01, out short tension01);
                                                            //dto.TensionValueList=new List<double> { tension01/100 };
                                                            CoildDataDto dto02 = new CoildDataDto(dto);
                                                            dto02.Good = true;
                                                            //dto.TensionValue
                                                            tensionList_A.Add(tension01);
                                                            modbusTcp.ReadInt16(CoildAddress.TensionValue02, out short tension02);
                                                            dto02.BreachNo = PageOP20.Instance.WindingCtrlList[index].Wuliao2;
                                                            dto.BreachNo = PageOP20.Instance.WindingCtrlList[index].Wuliao1;
                                                            tensionList_B.Add(tension02);
                                                            string tensionStr_A = string.Join(',', tensionList_A);
                                                            dto.TensionValue = tensionStr_A;
                                                            string tensionStr_B = string.Join(',', tensionList_B);
                                                            dto02.TensionValue = tensionStr_B;
                                                            dto02.WindingStartDt = startDt;
                                                            dto02.WindingEndDt = endDt;
                                                            dto02.WindingStation = "工位2";
                                                            dto02.WindingMechineName = $"绕线机{index + 1}";
                                                            //dto02.TensionValueList = new List<double> { tension02/100 };
                                                            PassStationDTO passStationDto01 = new PassStationDTO()
                                                            {
                                                                isLastStep = true,
                                                                SnTemp = sn1,
                                                                StationCode = StationCode,
                                                                WorkOrder = Global.WorkOrder,
                                                                PassStationData = dto
                                                            };
                                                            await UploadData(passStationDto01);

                                                            PassStationDTO passStationDto02 = new PassStationDTO()
                                                            {
                                                                isLastStep = true,
                                                                SnTemp = sn2,
                                                                StationCode = StationCode,
                                                                WorkOrder = Global.WorkOrder,
                                                                PassStationData = dto02
                                                            };
                                                            await UploadData(passStationDto02);
                                                            isSendOver = true;
                                                            break;
                                                        }
                                                        break;
                                                    }
                                                    Thread.Sleep(1000);
                                                }
                                                LogMgr.Instance.Debug("绕线完成..");
                                            }
                                            catch (Exception e)
                                            {
                                                LogMgr.Instance.Error($"绕线监控任务异常:{e.Message},{e.StackTrace}");
                                            }
                                        });
                    }
                }
            }
        }


        private async Task ProcessEntrySignal01()
        {
            if (PLC.ReadInt16(OP20Address.EntrySignal01, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP20Address.EntrySignal01, 0);
                PLC.ReadString(OP20Address.EntrySn01, 8, out string sn);
                if (!CheckWorkOrderState(OnEntryStateChanged01, sn))
                {
                    LogMgr.Instance.Error($"OP20物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult01, 2);
                    OnEntryStateChanged01?.Invoke(sn, 2, "物料不匹配");
                    return;
                }

                bool flag = false;
                //读取当前需要放入的位置
                PLC.ReadInt16(OP20Address.PutPos, out short pos);

                try
                {
                    string wuliaoA  =SystemParams.Instance.OP20_WuliaoList1[pos - 1];
                    //string wuliaoA = PageOP20.Instance.WindingCtrlList[pos - 1].Wuliao1;
                    bool f = checkWuliao(wuliaoA);
                    if (!f)
                    {
                        LogMgr.Instance.Error($"OP20-【绕线机{pos}】[工位1]物料匹配失败，阻止进站 SN:[{sn}]");
                        PLC.WriteInt16(OP20Address.EntryResult01, 2);
                        OnEntryStateChanged01?.Invoke(sn, 2, $"【绕线机{pos}】[工位1]物料不匹配");
                        return;
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"错误:{e.Message}");
                    LogMgr.Instance.Error($"OP20-【绕线机{pos}】[工位1]物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult01, 2);
                    OnEntryStateChanged01?.Invoke(sn, 2, $"【绕线机{pos}】[工位1]物料不匹配");
                    return;
                }


                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = Global.WorkOrder
                };

                ( flag, string msg) = await EntryRequest(requestDto);
                //
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                OnEntryStateChanged01?.Invoke(sn, result, msg);
                PLC.WriteInt16(OP20Address.EntryResult01, result);
            }
        }

        private bool checkWuliao(string str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }

            return true;
        }

        // 处理进站信号
        private async Task ProcessEntrySignal02()
        {
            if (PLC.ReadInt16(OP20Address.EntrySignal02, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP20Address.EntrySignal02, 0);
                PLC.ReadString(OP20Address.EntrySn02, 8, out string sn);
                if (!CheckWorkOrderState(OnEntryStateChanged02, sn))
                {
                    LogMgr.Instance.Error($"OP20-02物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult02, 2);
                    return;
                }
                PLC.ReadInt16(OP20Address.PutPos, out short pos);

                try
                {
                    string wuliaoA = SystemParams.Instance.OP20_WuliaoList2[pos - 1];
                   // string wuliaoA = PageOP20.Instance.WindingCtrlList[pos - 1].Wuliao1;
                    bool f = checkWuliao(wuliaoA);
                    if (!f)
                    {
                        LogMgr.Instance.Error($"OP20-【绕线机{pos}】[工位2]物料匹配失败，阻止进站 SN:[{sn}]");
                        PLC.WriteInt16(OP20Address.EntryResult01, 2);
                        OnEntryStateChanged02?.Invoke(sn, 2, $"【绕线机{pos}】[工位2]物料不匹配");
                        return;
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"错误:{e.Message}");
                    LogMgr.Instance.Error($"OP20-【绕线机{pos}】[工位2]物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult01, 2);
                    OnEntryStateChanged02?.Invoke(sn, 2, $"【绕线机{pos}】[工位2]物料不匹配");
                    return;
                }
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = Global.WorkOrder
                };
                (bool flag, string msg) = await EntryRequest(requestDto);
                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                OnEntryStateChanged02?.Invoke(sn, result, msg);
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                PLC.WriteInt16(OP20Address.EntryResult02, result);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP20Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}