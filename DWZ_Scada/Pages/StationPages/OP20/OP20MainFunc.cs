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
        private static readonly OP20Model Model = new();

        private const int AlarmState = 2;

        private const int RunningState = 1;

        /// <summary>
        /// 设备停止中
        /// </summary>
        private const int StopState = 3;

        /// <summary>
        /// PLC连接断开
        /// </summary>
        private const int OffState = -1;

        /// <summary>
        /// 在线状态
        /// </summary>
        private const int OnLineState = 0;

        //手持扫码枪 切换物料
        //输入物料
        //1.扫码枪
        //2.人工输入
        public static List<DeviceAlarmEntity> CurrentAlarmList = new();

        public static List<string> CurAlarmInfoVo = new();

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
            int a=0;
            Console.WriteLine("集合元素个数:"+ModbusConnections.Count);
            for (int i = 0; i < ModbusConnections.Count; i++)
            {
                int index = i;
                Console.WriteLine("当前i的值:"+i);
                var modbusTcp = new ModbusTCP();
                var connection = ModbusConnections[index];
                modbusTcp.Open(connection.IP, connection.Port, connection.StationNum);
                ModbusTcpList.Add(modbusTcp);

                Thread thread = new Thread(() => MonitorWindingMachine(_cts.Token,modbusTcp, index));
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
                    //更新界面设备状态
                    UpdateDeviceStateUI(model);
                    if (!IsPlc_Connected)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    #region 读取PLC状态

                    //判断是否点检模式
                    dt = DateTime.Now;
                    // 进站请求信号
                    //TODO 先读一个总的报警信号  如果有报警 再去读报警内容
                    // state状态 报警中 暂停中 运行中
                    //每次循环清一遍
                    CurrentAlarmList.Clear();
                    CurAlarmInfoVo.Clear();
                    state = ReadPLCState();
                    UpdateDeviceState(state);
                    if (state != -1)
                    {
                        // 处理报警信息
                        //假如当前有报警 或者是上一次有报警
                        //TODO 上一次有报警 需要清除上一次的报警信息 
                        CurrentAlarmList.Clear();
                        if (state == AlarmState)
                        {
                            lock (alarmLock)
                            {
                                AlarmInfoList.Clear();
                                ProcessAlarms(dt);
                            }
                        }
                        //如果上一次报警了 
                        if (DeviceState == AlarmState && state != AlarmState)
                        {
                            //TODO 可以 foreach 遍历 获取所有报警消除记录
                            ActiveAlarms.Clear();
                        }
                        if (DeviceControlPage.IsLoad)
                        {
                            //DeviceControlPage.Instance.UpdateAlarm(new List<DeviceAlarmEntity>(CurrentAlarmList));

                            DeviceControlPage.Instance.UpdateAlarm(new List<string>(CurAlarmInfoVo));

                        }
                        // 处理设备状态


                        //这里判断设备是不是点检模式


                        // 处理进站信号
                        await ProcessEntrySignal();

                        //获取绕线完成位置
                        GetWindingPos();

                        //获取绕线开始信号
                        WindingStart();
                    }
                    else
                    {
                        HandlePLCReadError();
                    }
                    #endregion
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
            }
        }

        // 更新设备状态到UI
        private void UpdateDeviceStateUI(OP20Model model)
        {
            model.TempSN = "123";
            Model.TempSN = DateTime.Now.ToString("HH:mm:ss fff");
            // PageOP10.Instance.UpdateTempSN(Model.TempSN);
        }

        private void ProcessAlarms(DateTime dt)
        {
            CurrentAlarmList.Clear();

            foreach (PLCAlarmData data in Global.PlcAlarmList)
            {
                if (data.IsArray && data.AlarmList.Count > 0)
                {
                    HandleArrayAlarm(data, dt);
                }
                else
                {
                    HandleSingleAlarm(data, dt);
                }
            }
        }

        // 处理数组形式的报警
        private void HandleArrayAlarm(PLCAlarmData data, DateTime dt)
        {
            bool[] alarmArr = new bool[data.Length];
            if (PLC.ReadAlarm(data.Address, out alarmArr, data.Length))
            {
                for (int i = 0; i < alarmArr.Length; i++)
                {
                    string alarmKey = data.AlarmList[i].Name;
                    bool isAlarmActive = alarmArr[i];
                    DeviceAlarmEntity alarmEntity = new();
                    alarmEntity.AlarmInfo = data.AlarmList[i].Name;
                    alarmEntity.AlarmType = data.AlarmList[i].AlarmType;
                    alarmEntity.DeviceName = StationName;
                    alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                    alarmEntity.AlarmTime = dt;
                    UpdateAlarmStatus(alarmKey, isAlarmActive, alarmEntity, dt);
                }
            }
        }

        // 处理单一报警
        private void HandleSingleAlarm(PLCAlarmData data, DateTime dt)
        {
            if (PLC.ReadBool(data.Address, out bool isAlarmActive))
            {
                string alarmKey = data.Name;
                DeviceAlarmEntity alarmEntity = new();
                alarmEntity.AlarmInfo = data.Name;
                alarmEntity.AlarmType = data.AlarmType;
                alarmEntity.DeviceName = StationName;
                alarmEntity.AlarmDateStr = dt.ToString("yyyy-MM-dd");
                alarmEntity.AlarmTime = dt;
                UpdateAlarmStatus(alarmKey, isAlarmActive, alarmEntity, dt);
            }
        }

        private void HandlePLCReadError()
        {
            IsPlc_Connected = false;
            LogMgr.Instance.Error("读取PLC 信号异常");
        }

        // 更新报警状态
        private void UpdateAlarmStatus(string alarmKey, bool isActive, DeviceAlarmEntity alarmEntity, DateTime dt)
        {
            if (isActive)
            {
                Global.IsDeviceAlarm = true;
                CurAlarmInfoVo.Add($"{alarmEntity.AlarmTime:yyyy:MM:dd hh:mm:ss}:{alarmEntity.AlarmInfo}--{alarmEntity.AlarmType}");
                CurrentAlarmList.Add(alarmEntity);
                if (ActiveAlarms.TryAdd(alarmKey, alarmEntity))
                {
                    AlarmQueue.Enqueue(alarmEntity);
                    // TODO: 上传报警信息到数据库
                }
            }
            else
            {
                if (ActiveAlarms.ContainsKey(alarmKey))
                {
                    ActiveAlarms.Remove(alarmKey);
                    // TODO: 上传报警消除记录
                }
            }
        }

        /// <summary>
        /// 更新设备状态
        /// </summary>
        /// <param name="state"></param>
        private void UpdateDeviceState(int state)
        {
            if (state == AlarmState)
            {
                PlcState = PlcState.Alarm;
                //DeviceState = 2;
            }
            else if (state == RunningState)
            {
                PlcState = PlcState.Running;
            }
            else if (state == OffState)
            {
                PlcState = PlcState.OffLine;

            }
            else if (state == StopState)
            {
                PlcState = PlcState.Stop;
            }
            else
            {
                PlcState = PlcState.Online;
            }
            lock (stateLock)
            {
                DeviceState = state;
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

        /*/// <summary>
        /// 上传过站数据
        /// </summary>
        private void UploadStationData()
        {
            PassStationDTO dto = new()
            {
                StationCode = "OP10",
                SnTemp = "AQW12dswSAW",
                PassStationData = new OP10Data()
            };
            UploadPassStationService service = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            service.SendPassStationData(dto);
        }*/

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        private int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP20Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}