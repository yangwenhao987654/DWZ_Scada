using CommonUtilYwh.Communication.ModbusTCP;
using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
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
            Console.WriteLine("集合元素个数:" + ModbusConnections.Count);
            for (int i = 0; i < ModbusConnections.Count; i++)
            {
                int index = i;
                Console.WriteLine("当前i的值:" + i);
                var modbusTcp = new ModbusTCP();
                var connection = ModbusConnections[index];
                modbusTcp.Open(connection.IP, connection.Port, connection.StationNum);
                ModbusTcpList.Add(modbusTcp);

                Thread thread = new Thread(() => MonitorWindingMachine(_cts.Token, modbusTcp, index));
                thread.Start();
                a = i;
            }

            LogMgr.Instance.Info($"循环外:{a}");

            /*
            ModbusTCP modbusTcp01 = new ModbusTCP();
            modbusTcp01.Open(SystemParams.Instance.OP20_Winding1_IP, SystemParams.Instance.OP20_Winding1_Port,
                SystemParams.Instance.OP20_Winding1_StationNum);

            ModbusTCP modbusTcp02 = new ModbusTCP();
            modbusTcp02.Open(SystemParams.Instance.OP20_Winding2_IP, SystemParams.Instance.OP20_Winding2_Port,
                SystemParams.Instance.OP20_Winding2_StationNum);

            ModbusTCP modbusTcp03 = new ModbusTCP();
            modbusTcp03.Open(SystemParams.Instance.OP20_Winding3_IP, SystemParams.Instance.OP20_Winding3_Port,
                SystemParams.Instance.OP20_Winding3_StationNum);

            ModbusTCP modbusTcp04 = new ModbusTCP();
            modbusTcp04.Open(SystemParams.Instance.OP20_Winding4_IP, SystemParams.Instance.OP20_Winding4_Port,
                SystemParams.Instance.OP20_Winding4_StationNum);

            ModbusTCP modbusTcp05 = new ModbusTCP();
            modbusTcp05.Open(SystemParams.Instance.OP20_Winding5_IP, SystemParams.Instance.OP20_Winding5_Port,
                SystemParams.Instance.OP20_Winding5_StationNum);

            ModbusTCP modbusTcp06 = new ModbusTCP();
            modbusTcp06.Open(SystemParams.Instance.OP20_Winding6_IP, SystemParams.Instance.OP20_Winding6_Port,
                SystemParams.Instance.OP20_Winding6_StationNum);

            ModbusTCP modbusTcp07 = new ModbusTCP();
            modbusTcp07.Open(SystemParams.Instance.OP20_Winding7_IP, SystemParams.Instance.OP20_Winding7_Port,
                SystemParams.Instance.OP20_Winding7_StationNum);

            ModbusTCP modbusTcp08 = new ModbusTCP();
            modbusTcp08.Open(SystemParams.Instance.OP20_Winding8_IP, SystemParams.Instance.OP20_Winding8_Port,
                SystemParams.Instance.OP20_Winding8_StationNum);

            ModbusTCP modbusTcp09 = new ModbusTCP();
            modbusTcp09.Open(SystemParams.Instance.OP20_Winding9_IP, SystemParams.Instance.OP20_Winding9_Port,
                SystemParams.Instance.OP20_Winding9_StationNum);

            ModbusTCP modbusTcp10 = new ModbusTCP();
            modbusTcp10.Open(SystemParams.Instance.OP20_Winding10_IP, SystemParams.Instance.OP20_Winding10_Port,
                SystemParams.Instance.OP20_Winding10_StationNum);

            ModbusTCP modbusTcp11 = new ModbusTCP();
            modbusTcp11.Open(SystemParams.Instance.OP20_Winding11_IP, SystemParams.Instance.OP20_Winding11_Port,
                SystemParams.Instance.OP20_Winding11_StationNum);

            ModbusTCP modbusTcp12 = new ModbusTCP();
            modbusTcp12.Open(SystemParams.Instance.OP20_Winding12_IP, SystemParams.Instance.OP20_Winding12_Port,
                SystemParams.Instance.OP20_Winding12_StationNum);
                */

            //显示绕线机的连接状态
            // 12个线程？ 
            /*Thread t1 = new Thread(Winding1Monitor);
            t1.Start();*/
        }


        // Generic method to monitor each winding machine
        private void MonitorWindingMachine(CancellationToken token, ModbusTCP modbusTcp, int index)
        {
            while (!token.IsCancellationRequested)
            {
                if (modbusTcp.IsConnect)
                {
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
                        LogMgr.Instance.Error($"ThreadId:{Thread.CurrentThread.ManagedThreadId}  Winding machine {index} connection failed: {err}");
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
                    GetWindingPos();

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
            if (PLC.ReadBool(OP20Address.WindingStart, out bool isStart) && isStart)
            {
                LogMgr.Instance.Info("收到绕线开始...");
                PLC.Write(OP20Address.WindingStart, "Bool", false);

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
                EntryRequestService entryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
                (bool flag, string msg) = await entryRequestService.CheckIn(requestDto);
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