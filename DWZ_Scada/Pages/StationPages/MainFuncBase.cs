using CommunicationUtilYwh.Communication.PLC;
using DWZ_Scada.ctrls;
using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.DBContext;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages
{
    public abstract class MainFuncBase : IDisposable
    {
        #region 报警状态属性

        private const int AlarmState = 3;

        private const int RunningState = 1;

        /// <summary>
        /// 设备停止中
        /// </summary>
        private const int StopState = 2;

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

        #endregion

        /// <summary>
        /// 用于Mes测试SN
        /// </summary>
        public string SnTest = "aQWER615ws8851";


        //PLC类型  
        //PLC 连接配置  IP地址 端口号


        //父类只提供通用方法，不涉及实际例管理

        /*        public  static  bool IsInstanceNull => _instance==null;

                private static MainFuncBase _instance;*/

        private static Func<MainFuncBase> _createInstanceFunc;

        private EntryRequestService EntryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();

        public DeviceStateService DeviceStateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();

        private DamageableService DamageableService = Global.ServiceProvider.GetRequiredService<DamageableService>();

        private UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();

        private InspectService InspectService = Global.ServiceProvider.GetRequiredService<InspectService>();

        //private static MainFuncBase myOp10Model;

        /*public static MainFuncBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(MainFuncBase))
                    {
                        if (_instance == null)
                        {
                            if (_createInstanceFunc==null)
                            {
                                throw new Exception("没有注册工厂方法来创建 MainFuncBase 实例.");
                            }
                            else
                            {
                                // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                                _instance = _createInstanceFunc();
                            }
                        }
                    }
                }
                return _instance;
            }
        }
        // 工厂方法，供子类实现
        public static void RegisterFactory(Func<MainFuncBase> factoryMethod)
        {
            _createInstanceFunc = factoryMethod;
           
        }*/
        /// <summary>
        /// 更新测试状态
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="result"></param>
        public delegate void TestStateChanged(string sn, int result);

        /// <summary>
        /// 进站请求处理状态
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="result"></param>
        public delegate void EntryStateChanged(string sn, int result, string msg = "");

        /// <summary>
        /// 设备是否点检模式
        /// </summary>
        public bool IsSpotCheck { get; set; }

        private bool isPlc_Connected;

        public bool IsPlc_Connected
        {
            get
            {
                return isPlc_Connected;
            }
            set
            {
                if (value!=isPlc_Connected)
                {
                    isPlc_Connected =value;
                    PlcStateChanged?.Invoke(value);
                }
            }
        }

        public static event Action<bool> PlcStateChanged; 

        public LogMgr Logger = LogMgr.Instance;

        public MyPlc PLC;

        public PlcState PlcState;

        public PLCConfig PLCConfig { get; set; }

        /// <summary>
        /// PLC的IP地址
        /// </summary>
        public string PLC_IP { get; set; }

        /// <summary>
        /// PLC端口号
        /// </summary>
        public int PLC_PORT { get; set; }

        public CancellationTokenSource _cts = new CancellationTokenSource();

        public int DeviceState = -1;

        public readonly object stateLock = new object();


        public readonly object alarmLock = new object();

        public Timer reportTimer;

        public ConcurrentQueue<DeviceAlarmEntity> AlarmQueue = new ConcurrentQueue<DeviceAlarmEntity>();

        public Dictionary<string, DeviceAlarmEntity> ActiveAlarms = new Dictionary<string, DeviceAlarmEntity>();

        public List<string> AlarmInfoList = new List<string>();

        public  string StationName;

        public  string StationCode;
        private IDeviceAlarmDAL _deviceAlarmDAL;

        /// <summary>
        /// 当前的工单
        /// </summary>
        public string CurWorkOrder { get; set; }

        /// <summary>
        /// 当前产品型号
        /// </summary>
        public string CurProductCode { get; set; }

        /// <summary>
        /// 当前批次号
        /// </summary>
        public string CurBatchNo { get; set; }


        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string CurMaterialNo { get; set; }


        /// <summary>
        /// 当前物料SN码
        /// </summary>
        public string CurMaterialSN { get; set; }


        // 异步保存报警信息的方法
        private async Task SaveAlarmsToDatabaseAsync()
        {
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    if (AlarmQueue.TryDequeue(out var alarmEntity)) // 从队列中取出一个报警信息
                    {
                        bool flag = await _deviceAlarmDAL.Insert(alarmEntity);
                        if (!flag)
                        {
                            //假如插入失败了，重新假如队列
                            AlarmQueue.Enqueue(alarmEntity);
                        }
                    }
                    else
                    {
                        await Task.Delay(500); // 如果队列为空，等待一段时间后再重试
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"存储报警信息错误:{ex.StackTrace}\n" + ex.Message);
                Thread.Sleep(1000);
            }
        }
        
        /// <summary>
        /// 启动流程
        /// </summary>
        public virtual void StartAsync()
        {
            _deviceAlarmDAL = Global.ServiceProvider.GetRequiredService<IDeviceAlarmDAL>();

            Task.Run(() =>
            {
                _cts = new CancellationTokenSource();
                //myOp10Model = Model;
                //启动PLC监控线程
                Thread t = new Thread(() => ConnStatusMonitor(_cts.Token));
                t.Start();
                Thread.Sleep(300);

                //Thread.Sleep(5200);
                Thread t2 = new Thread(() => PLCMainWork(_cts.Token));
                t2.Start();
                reportTimer = new Timer(ReportDeviceState, null, 0, 1000);

                // 启动后台任务来处理队列中的报警信息
                Task.Run(() => SaveAlarmsToDatabaseAsync());
            });
        }

        /// <summary>
        /// 上传过站数据
        /// </summary>
        protected async Task<(bool, string)> UploadData(PassStationDTO dto)
        {
            if (IsSpotCheck)
            {
                //封装点检数据
                DeviceInspectDTO inspectDto = ParseDeviceInspectDto(dto);
                return await UploadSpotCheckData(inspectDto);
            }
            else
            {
                return await UploadStationData(dto);
            }
        }

        public DeviceInspectDTO ParseDeviceInspectDto(PassStationDTO passStationDto)
        {
            DeviceInspectDTO inspectDto = new DeviceInspectDTO();
            inspectDto.WorkOrder = passStationDto.WorkOrder;
            //inspectDto.Data = passStationDto.PassStationData;
            inspectDto.DeviceCode = passStationDto.StationCode;
            inspectDto.SnTemp = passStationDto.SnTemp;
            inspectDto.isLastStep = passStationDto.isLastStep;
            inspectDto.PassStationData = passStationDto.PassStationData;

            return inspectDto;
        }

        /// <summary>
        /// 上传过站数据
        /// </summary>
        protected async Task<(bool, string)> UploadStationData(PassStationDTO dto)
        {
            return await UploadPassStationService.SendPassStationData(dto);
        }

        protected async Task<(bool, string)> UploadSpotCheckData(DeviceInspectDTO dto)
        {
            return await InspectService.AddInspectDada(dto);
        }

        protected async Task<(bool, string)> EntryRequest(EntryRequestDTO dto)
        {
            return await EntryRequestService.CheckIn(dto);
        }

        protected async Task<(bool, string)> DamageableReport(DamageableDTO dto)
        {
            return await DamageableService.ReportDamageableAsync(dto);
        }

        /// <summary>
        /// 上报设备状态 1S 上报一次
        /// </summary>
        /// <param name="state"></param>
        protected virtual async void ReportDeviceState(object state)
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
                case 3:
                    dto.Status = "breakdown";
                    break;
                case 2:
                    dto.Status = "stop";
                    break;
                default:
                    dto.Status = "stop";
                    break;
            }

            //如果有报警的话 需要带着报警信息
            lock (alarmLock)
            {
                if (AlarmInfoList.Count > 0)
                {
                    string message = string.Join(";", AlarmInfoList);
                    dto.Message = message;
                }
            }
            //记录报警信息

            //await DeviceStateService.AddDeviceState(dto);
        }

        protected MainFuncBase(PLCConfig PLCConfig)
        {
            this.PLCConfig = PLCConfig;
            PLC = PLCConfig.MyPlc;
            PLC_IP = PLCConfig.IP;
            PLC_PORT = PLCConfig.Port;
           // workOrderCtrl.SpotStateChanged += WorkOrderCtrl_SpotStateChanged1;
            workOrderCtrl.SpotStateChanged += WorkOrderCtrl_SpotStateChanged;

            workOrderCtrl.ONSelectProductNoChanged += WorkOrderCtrl_ONSelectProductNoChanged;
        }

        private void WorkOrderCtrl_ONSelectProductNoChanged(int no)
        {
            if (!IsPlc_Connected)
            {
                Logger.Error("PLC未连接，型号切换错误");
                return ;
            }
            try
            {
                PLC.WriteInt16(OP10Address.Product, (short)no);
                PLC.WriteInt16(OP10Address.ChangeProduct, 1);
                UIMessageBox.Show("型号下发成功");
            }
            catch (Exception e)
            {
               UIMessageBox.ShowError($"下发plc切换型号错误,型号[{no}] 异常:{e.Message}");
            }
        }

        private bool WorkOrderCtrl_SpotStateChanged(bool value)
        {
            if (!IsPlc_Connected)
            {
                Logger.Error("PLC未连接，点检切换错误");
                return false;
            }

            try
            {
                if (value)
                {
                    //点检地址 DM3030 
                    PLC.WriteInt16(OP10Address.SpotCheck, 1);
                }
                else
                {
                    PLC.WriteInt16(OP10Address.SpotCheck, 0);
                }
                IsSpotCheck = value;
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"切换点检状态失败:{e.Message}");
                return false;
            }
            return true;
        }

        //手持扫码枪 切换物料
        //输入物料
        //1.扫码枪
        //2.人工输入

        public abstract void PLCMainWork(CancellationToken token);
        #region 后台监控线程
        /// <summary>
        /// 后台线程，PLC重连策略
        /// </summary>
        protected virtual void ConnStatusMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!IsPlc_Connected)
                    {
                        PlcState = PlcState.OffLine;
                        //全局PLC连接配置
                        PLC_IP = GetPLCIP();
                        PLC_PORT = GetPLCPort();
                        bool flag = PLC.Connect(PLC_IP, PLC_PORT);
                        if (flag)
                        {
                            IsPlc_Connected = true;
                            Logger.Debug("PLC连接成功");
                        }
                        else
                        {
                            IsPlc_Connected = false;
                            //Logger.Error("PLC连接失败:");
                        }
                    }
                    else
                    {
                        PLC.Write(OP10Address.HeartBeat, "int", 1);
                    }

                    ZCForm.Instance.UpdatePlcState(PlcState);
                }
                catch (Exception ex)
                {
                    Logger.Error("PLC监控线程错误:" + ex.Message);
                }
                Thread.Sleep(1000);
            }
        }

       protected abstract string GetPLCIP();
       protected abstract int GetPLCPort();

        #endregion

        #region 处理设备报警
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
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected abstract int ReadPLCState();

        protected void HandleAlarm()
        {
            #region 读取PLC状态
            int state = -1;
            DateTime dt;
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


            }
            else
            {
                HandlePLCReadError();
            }
            #endregion
        }

        #endregion

        #region 工单检查

        protected bool CheckWorkOrderState(EntryStateChanged callback, string sn)
        {
            if (!Global.IsWorkNoCheckPass)
            {
                LogMgr.Instance.Info("物料校验失败");
                callback?.Invoke(sn, 2, "物料错误");
                return false;
            }

            return true;
        }

        #endregion




        public virtual void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            _cts.Cancel();
            //释放PLC连接
            PLC?.Dispose();
            reportTimer.Dispose();
        }
    }
}
