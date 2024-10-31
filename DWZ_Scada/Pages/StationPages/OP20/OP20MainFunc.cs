using CommonUtilYwh.Communication.ModbusTCP;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.DTO.OP20;
using DWZ_Scada.Services;
using LogTool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class OP20MainFunc : MainFuncBase, IDisposable
    {
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


        public OP20MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP20";
            StationCode = "OP20";
        }

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            _cts.Cancel();
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
        }


        // Generic method to monitor each winding machine
        private void MonitorWindingMachine(CancellationToken token, ModbusTCP modbusTcp, int index)
        {
            while (!token.IsCancellationRequested)
            {
                if (modbusTcp.IsConnect)
                {
                    modbusTcp.ReadInt16("2000", out short state);
                    ReportDeviceState(index + 1, state);
                    /*bool flag = modbusTcp.ReadUInt16("2000", out ushort value);
                    modbusTcp.ReadInt16("2041", out short tension1);*/
                }
                else
                {
                    // Attempt to reconnect
                    (bool flag, string err) = modbusTcp.Open(
                        ModbusConnections[index].IP,
                        ModbusConnections[index].Port,
                        ModbusConnections[index].StationNum
                    );

                    if (!flag)
                    {
                        ReportDeviceState(index+1,1);
                       // LogMgr.Instance.Error($"ThreadId:{Thread.CurrentThread.ManagedThreadId}  Winding machine {index} connection failed: {err}");
                    }
                    else
                    {
                        modbusTcp.ReadInt16("2000", out short state);
                        ReportDeviceState(index + 1, state);
                    }
                }
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

        public  async void ReportDeviceState(int weldingMachineId ,int state)
        {
            int currentState = -1;

            DeviceStateDTO dto = new DeviceStateDTO();
            dto.DeviceName = "OP20绕线机"+ weldingMachineId.ToString("D2");
            dto.DeviceCode = "OP20_"+ weldingMachineId.ToString("D2");
           /* switch (weldingMechineId)
            {
                case 1:
                    name = "OP20绕线机1";
                    code = "OP20_1";
                    break;
            }*/

           /* DeviceStateDTO dto = new DeviceStateDTO()
            {
                DeviceCode = "0001",
                DeviceName = "工站01",
            };*/

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

           /* //如果有报警的话 需要带着报警信息
            lock (alarmLock)
            {
                if (AlarmInfoList.Count > 0)
                {
                    string message = string.Join(";", AlarmInfoList);
                    dto.Message = message;
                }
            }*/
            //记录报警信息

            await DeviceStateService.AddDeviceState(dto);
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            //进站信号
            bool isEntry;
            int state = -1;
            DateTime dt;
            OP20Model model = new OP20Model();
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
                    await ProcessEntrySignal();

                    //获取绕线完成位置
                    //GetWindingPos();

                    //获取绕线开始信号
                    WindingStart();

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }
                Thread.Sleep(1000);
            }
        }

        private void WindingStart()
        {
            if (PLC.ReadBool(OP20Address.Winding01Start, out bool isStart) && isStart)
            {
                LogMgr.Instance.Info("收到绕线开始...");
                PLC.Write(OP20Address.Winding01Start, "Bool", false);
                Task task = Task.Run(() =>
                {
                    //TODO 读取两次绕线的SN码
                    string sn1 = "123456111";
                    string sn2 = "123456222";
                    ModbusTcpList[0].ReadInt16(CoildAddress.CoilsState, out short state);
                    while (true)
                    {
                        if (state == 1)
                        {
                            //停止
                            LogMgr.Instance.Debug("读取到绕线停止..1");
                        }
                        else if (state == 12)
                        {
                            LogMgr.Instance.Debug("读取到绕线开始..12");
                            CoildDataDto dto = new CoildDataDto();
                            //运行中
                            ModbusTcpList[0].ReadInt32(CoildAddress.CoilsCurNum, out int coilsCurNum);
                            dto.CoilsCurNum = coilsCurNum;
                            ModbusTcpList[0].ReadInt32(CoildAddress.CoilsTargetNum, out int coilsTargetNum);
                            dto.CoilsTargetNum = coilsTargetNum;

                            ModbusTcpList[0].ReadInt32(CoildAddress.CoilsSpeed, out int coilsSpeed);
                            dto.CoilsSpeed = coilsSpeed;

                            ModbusTcpList[0].ReadInt32(CoildAddress.CoilsTimes, out int times);
                            dto.CoilsTimes = times;

                            //采集张力值 TODO 需要区分是A/B哪个工位
                            ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue01, out short tension01);
                            dto.TensionValue = tension01;
                            CoildDataDto dto02 = new CoildDataDto(dto);

                            ModbusTcpList[0].ReadInt16(CoildAddress.TensionValue02, out short tension02);
                            dto02.TensionValue = tension02;
                            PassStationDTO passStationDto01 = new PassStationDTO()
                            {
                                isLastStep = true,
                                SnTemp = sn1,
                                StationCode = StationCode,
                                WorkOrder = "",
                                PassStationData = dto
                            };
                            UploadStationData(passStationDto01);

                            PassStationDTO passStationDto02 = new PassStationDTO()
                            {
                                isLastStep = true,
                                SnTemp = sn2,
                                StationCode = StationCode,
                                WorkOrder = "",
                                PassStationData = dto02
                            };
                            UploadStationData(passStationDto02);
                            break;
                        }
                        else
                        {
                            //故障
                            LogMgr.Instance.Info($"读取到绕线状态位:{state}");
                        }
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

        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadBool(OP20Address.EntrySignal, out bool isEntry) && isEntry)
            {
                PLC.Read(OP20Address.EntrySn, "string-20", out string sn);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = "MO202409110002"
                };
         
                (bool flag, string msg) = await EntryRequest(requestDto);
                //
                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                PLC.Write(OP10Address.EntryResult, "Bool", flag);
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