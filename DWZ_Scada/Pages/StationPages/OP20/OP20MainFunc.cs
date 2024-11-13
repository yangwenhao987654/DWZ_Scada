using CommonUtilYwh.Communication.ModbusTCP;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.DTO.OP20;
using DWZ_Scada.Services;
using LogTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TouchSocket.Core;
using static DWZ_Scada.Pages.StationPages.MainFuncBase;

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

        public event EntryStateChanged OnEntryStateChanged01;

        public event EntryStateChanged OnEntryStateChanged02;

        public OP20MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP20";
            StationCode = "OP20";
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
            //TODO 增加Modbus TCP 的连接
            Task.Run(() =>
            {
                ModbusConnections = new List<ModbusConnConfig>
            {
                new (SystemParams.Instance.OP20_Winding1_IP, SystemParams.Instance.OP20_Winding1_Port, SystemParams.Instance.OP20_Winding1_StationNum),
                new (SystemParams.Instance.OP20_Winding2_IP, SystemParams.Instance.OP20_Winding2_Port, SystemParams.Instance.OP20_Winding2_StationNum),
                new (SystemParams.Instance.OP20_Winding3_IP, SystemParams.Instance.OP20_Winding3_Port, SystemParams.Instance.OP20_Winding3_StationNum),
                new (SystemParams.Instance.OP20_Winding4_IP, SystemParams.Instance.OP20_Winding4_Port, SystemParams.Instance.OP20_Winding4_StationNum),
                new (SystemParams.Instance.OP20_Winding5_IP, SystemParams.Instance.OP20_Winding5_Port, SystemParams.Instance.OP20_Winding5_StationNum),
                new (SystemParams.Instance.OP20_Winding6_IP, SystemParams.Instance.OP20_Winding6_Port, SystemParams.Instance.OP20_Winding6_StationNum),
                new (SystemParams.Instance.OP20_Winding7_IP, SystemParams.Instance.OP20_Winding7_Port, SystemParams.Instance.OP20_Winding7_StationNum),
                new (SystemParams.Instance.OP20_Winding8_IP, SystemParams.Instance.OP20_Winding8_Port, SystemParams.Instance.OP20_Winding8_StationNum),
                new (SystemParams.Instance.OP20_Winding9_IP, SystemParams.Instance.OP20_Winding9_Port, SystemParams.Instance.OP20_Winding9_StationNum),
                new (SystemParams.Instance.OP20_Winding10_IP, SystemParams.Instance.OP20_Winding10_Port, SystemParams.Instance.OP20_Winding10_StationNum),
                new (SystemParams.Instance.OP20_Winding11_IP, SystemParams.Instance.OP20_Winding11_Port, SystemParams.Instance.OP20_Winding11_StationNum),
                new(SystemParams.Instance.OP20_Winding12_IP, SystemParams.Instance.OP20_Winding12_Port, SystemParams.Instance.OP20_Winding12_StationNum)
            };
                int a = 0;
                for (int i = 0; i < ModbusConnections.Count; i++)
                {
                    int index = i;
                    var modbusTcp = new ModbusTCP();
                    var connection = ModbusConnections[index];
                    modbusTcp.Open(connection.IP, connection.Port, connection.StationNum);
                    ModbusTcpList.Add(modbusTcp);

                    Thread thread = new Thread(() => MonitorWindingMachine(_cts.Token, modbusTcp, index));
                    thread.Start();
                }
            });
        }


        // Generic method to monitor each winding machine
        private void MonitorWindingMachine(CancellationToken token, ModbusTCP modbusTcp, int index)
        {
            while (!token.IsCancellationRequested)
            {
                short state = -1;
                try
                {
                    if (modbusTcp.IsConnect)
                    {
                        modbusTcp.ReadInt16("2000", out state);
                        ReportDeviceState(index + 1, state);
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
                            ReportDeviceState(index + 1, state);
                            // LogMgr.Instance.Error($"ThreadId:{Thread.CurrentThread.ManagedThreadId}  Winding machine {index} connection failed: {err}");
                        }
                        else
                        {
                            modbusTcp.ReadInt16("2000", out state);
                            ReportDeviceState(index + 1, state);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"绕线机线程[{index + 1}]错误, {e.Message}\n{e.StackTrace}");
                }
                //TODO 更新界面绕线机状态
                OnWeldingStateChangedAction?.Invoke(index, state);
                Thread.Sleep(1000);
            }
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
                case 0:
                    dto.Status = "stop";
                    break;
                case 1:
                    dto.Status = "run";
                    break;
                case 2:
                    dto.Status = "breakdown";
                    break;
                default:
                    dto.Status = "stop";
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

        public async void ReportDeviceState(int weldingMachineId, short state)
        {
            short currentState = -1;
            DeviceStateDTO dto = new DeviceStateDTO();
            dto.DeviceName = "OP20绕线机" + weldingMachineId.ToString("D2");
            dto.DeviceCode = "OP20_" + weldingMachineId.ToString("D2");

            switch (currentState)
            {
                case 1:
                    dto.Status = "stop";
                    break;
                case 0:
                    dto.Status = "breakdown";
                    break;
                case 12:
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
                        LogMgr.Instance.Info("收到绕线开始...");
                        PLC.WriteInt16(OP20Address.WindingStartList[i], 0);
                        Task task = Task.Run(async () =>
                        {
                            //TODO 读取两次绕线的SN码
                            string sn1 = "TestCode001";
                            string sn2 = "TestCode002";
                            bool isStart = false;
                            bool isFinish = false;
                            Stopwatch sw = Stopwatch.StartNew();
                            sw.Start();
                            //TODO 增加一个超
                            while (true) //300秒 60*5 5分钟
                            {
                                ModbusTcpList[0].ReadUInt16(CoildAddress.CoilsState, out ushort state);

                                if (state == 1 && isStart)
                                {
                                    //停止
                                    LogMgr.Instance.Debug("读取到绕线停止..1");
                                    isFinish = true;

                                    CoildDataDto dto = new CoildDataDto();
                                    //运行中
                                    ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsCurNum, out uint coilsCurNum);
                                    dto.CoilsCurNum = coilsCurNum / 100;
                                    ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsTargetNum, out uint coilsTargetNum);
                                    dto.CoilsTargetNum = coilsTargetNum / 100;

                                    /*  ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsSpeed, out uint coilsSpeed);
                                      dto.CoilsSpeed = coilsSpeed / 100;*/

                                    ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsTimes, out uint times);
                                    dto.CoilsTimes = times / 100;

                                    //采集张力值 TODO 需要区分是A/B哪个工位
                                    ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue01, out short tension01);
                                    //dto.TensionValueList=new List<double> { tension01/100 };
                                    CoildDataDto dto02 = new CoildDataDto(dto);

                                    ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue02, out short tension02);
                                    //dto02.TensionValueList = new List<double> { tension02/100 };
                                    PassStationDTO passStationDto01 = new PassStationDTO()
                                    {
                                        isLastStep = true,
                                        SnTemp = sn1,
                                        StationCode = StationCode,
                                        WorkOrder = "MO202410210001",
                                        PassStationData = dto
                                    };
                                    await UploadStationData(passStationDto01);

                                    PassStationDTO passStationDto02 = new PassStationDTO()
                                    {
                                        isLastStep = true,
                                        SnTemp = sn2,
                                        StationCode = StationCode,
                                        WorkOrder = "MO202410210001",
                                        PassStationData = dto02
                                    };
                                    await UploadStationData(passStationDto02);
                                    break;
                                }
                                else if (state == 12)
                                {
                                    isStart = true;
                                    if (!isStart)
                                    {
                                        LogMgr.Instance.Debug("读取到绕线开始..12");
                                        //TODO 一直读取当前绕线张力值
                                    }
                                }
                                else
                                {
                                    LogMgr.Instance.Info($"读取到绕线状态位:{state}");
                                }
                                Thread.Sleep(1000);
                            }
                            LogMgr.Instance.Debug("绕线完成..");
                        });
                    }
                }
            }

            if (PLC.ReadInt16(OP20Address.Winding01Start, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Info("收到绕线开始...");
                PLC.WriteInt16(OP20Address.Winding01Start, 0);
                Task task = Task.Run(async () =>
                {
                    //TODO 读取两次绕线的SN码
                    string sn1 = "TestCode001";
                    string sn2 = "TestCode002";
                    bool isStart = false;
                    while (true)
                    {
                        ModbusTcpList[0].ReadUInt16(CoildAddress.CoilsState, out ushort state);

                        if (state == 1 && isStart)
                        {
                            //停止
                            LogMgr.Instance.Debug("读取到绕线停止..1");

                            CoildDataDto dto = new CoildDataDto();
                            //运行中
                            ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsCurNum, out uint coilsCurNum);
                            dto.CoilsCurNum = coilsCurNum / 100;
                            ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsTargetNum, out uint coilsTargetNum);
                            dto.CoilsTargetNum = coilsTargetNum / 100;

                            /*  ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsSpeed, out uint coilsSpeed);
                              dto.CoilsSpeed = coilsSpeed / 100;*/

                            ModbusTcpList[0].ReadUInt32(CoildAddress.CoilsTimes, out uint times);
                            dto.CoilsTimes = times / 100;

                            //采集张力值 TODO 需要区分是A/B哪个工位
                            ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue01, out short tension01);
                            //dto.TensionValueList=new List<double> { tension01/100 };
                            CoildDataDto dto02 = new CoildDataDto(dto);

                            ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue02, out short tension02);
                            //dto02.TensionValueList = new List<double> { tension02/100 };
                            PassStationDTO passStationDto01 = new PassStationDTO()
                            {
                                isLastStep = true,
                                SnTemp = sn1,
                                StationCode = StationCode,
                                WorkOrder = "MO202410210001",
                                PassStationData = dto
                            };
                            await UploadStationData(passStationDto01);

                            PassStationDTO passStationDto02 = new PassStationDTO()
                            {
                                isLastStep = true,
                                SnTemp = sn2,
                                StationCode = StationCode,
                                WorkOrder = "MO202410210001",
                                PassStationData = dto02
                            };
                            await UploadStationData(passStationDto02);
                            break;
                        }
                        else if (state == 12)
                        {
                            isStart = true;
                            if (!isStart)
                            {
                                LogMgr.Instance.Debug("读取到绕线开始..12");
                                //TODO 一直读取当前绕线张力值
                            }
                        }
                        else
                        {
                            LogMgr.Instance.Info($"读取到绕线状态位:{state}");
                        }
                        Thread.Sleep(1000);
                    }
                });
                task.Wait();
                //TODO 获取到对应的位置 开始监控 
            }
        }

        private void GetWindingPos()
        {
            if (PLC.ReadInt16(OP20Address.WindingPos, out short pos) && pos != 0)
            {
                //获取到当前的绕线位置
                string addressA = OP20Address.WindingStartSn;
                string addressB = OP20Address.WindingStartSn;
                PLC.Read(addressA, "string", out string snA);
                PLC.Read(addressB, "string", out string snB);

                //TODO 把SN写到对应的界面上去

            }
        }

        private async Task ProcessEntrySignal01()
        {
            if (PLC.ReadInt16(OP20Address.EntrySignal01, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP20Address.EntrySignal01, 0);
                PLC.Read(OP20Address.EntrySn01, "string-8", out string sn);
                if (!CheckWorkOrderState(OnEntryStateChanged01, sn))
                {
                    LogMgr.Instance.Error($"OP20-01物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult01, 2);
                    return;
                }

                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = Global.WorkOrder
                };

                (bool flag, string msg) = await EntryRequest(requestDto);
                //
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                PLC.WriteInt16(OP20Address.EntryResult01, result);
            }
        }

        // 处理进站信号
        private async Task ProcessEntrySignal02()
        {
            if (PLC.ReadInt16(OP20Address.EntrySignal02, out short isEntry) && isEntry==1)
            {
                PLC.WriteInt16(OP20Address.EntrySignal02, 0);
                PLC.Read(OP20Address.EntrySn02, "string-8", out string sn);
                if (!CheckWorkOrderState(OnEntryStateChanged02, sn))
                {
                    LogMgr.Instance.Error($"OP20-02物料匹配失败，阻止进站 SN:[{sn}]");
                    PLC.WriteInt16(OP20Address.EntryResult02, 2);
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