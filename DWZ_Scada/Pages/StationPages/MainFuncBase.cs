using CommunicationUtilYwh.Communication.PLC;
using DWZ_Scada.HttpServices;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using ScadaBase.DAL.DBContext;
using ScadaBase.DAL.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages
{
    public abstract class MainFuncBase : IDisposable
    {
        /// <summary>
        /// 用于Mes测试SN
        /// </summary>
        public string SnTest = "aQWER615ws8851";


        //PLC类型  
        //PLC 连接配置  IP地址 端口号

        public static bool IsInstanceNull => _instance==null;

        private static MainFuncBase _instance;

        private static Func<MainFuncBase> _createInstanceFunc;

        public DeviceStateService DeviceStateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();


        public UploadPassStationService UploadPassStationService = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();

        public InspectService InspectService = Global.ServiceProvider.GetRequiredService<InspectService>();

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
        /// 设备是否点检模式
        /// </summary>
        public  bool IsSpotCheck { get; set; }

        public  bool IsPlc_Connected;

        public LogMgr Logger = LogMgr.Instance;

        public  MyPlc PLC ;

        public PlcState PlcState;

        /// <summary>
        /// PLC的IP地址
        /// </summary>
        public string PLC_IP;

        /// <summary>
        /// PLC端口号
        /// </summary>
        public int PLC_PORT;

        public CancellationTokenSource _cts = new CancellationTokenSource();

        public  int DeviceState = -1;

        public  readonly object stateLock = new object();


        public readonly object alarmLock = new object();

        public Timer reportTimer;

        public ConcurrentQueue<DeviceAlarmEntity> AlarmQueue = new ConcurrentQueue<DeviceAlarmEntity>();

        public  Dictionary<string, DeviceAlarmEntity> ActiveAlarms = new Dictionary<string, DeviceAlarmEntity>();

        public  List<string> AlarmInfoList = new List<string>();

        public static string StationName ;

        public static string StationCode ;

        // 异步保存报警信息的方法
        private async Task SaveAlarmsToDatabaseAsync()
        {
            using (var context = new MyDbContext())
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    if (AlarmQueue.TryDequeue(out var alarmEntity)) // 从队列中取出一个报警信息
                    {
                        context.tbDeviceAlarms.Add(alarmEntity); // 将报警信息添加到DbSet
                        await context.SaveChangesAsync(); // 异步保存更改到数据库
                    }
                    else
                    {
                        await Task.Delay(500); // 如果队列为空，等待一段时间后再重试
                    }
                }
            }
        }

        /// <summary>
        /// 启动流程
        /// </summary>
        public virtual  void StartAsync()
        {
            Task.Run(() =>
            {
                _cts=new CancellationTokenSource();
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
        protected async Task UploadStationData(PassStationDTO dto)
        {
            await UploadPassStationService.SendPassStationData(dto);
        }

        protected async Task<(bool, string)> UploadSpotCheckData(DeviceInspectDTO dto)
        {
            return await InspectService.AddInspectDada(dto);

        }


        /// <summary>
        /// 上报设备状态 1S 上报一次
        /// </summary>
        /// <param name="state"></param>
        protected virtual async void ReportDeviceState(object state)
        {
            int currentState =-1;
            lock (stateLock)
            {
                currentState = DeviceState;
            }
            DeviceStateDTO dto = new DeviceStateDTO()
            {
                DeviceCode = "0001",
                DeviceName = "工站01",
            };
            switch (currentState)
            {
                case -1:
                    dto.Status = "停机";
                    break;
                case 1:
                    dto.Status = "运行中";
                    break;
                case 2:
                    dto.Status = "待机中";
                    break;
                default:
                    dto.Status = "故障";
                    break;
            }

      
            //如果有报警的话 需要带着报警信息
            lock (alarmLock)
            {
                if (AlarmInfoList.Count>0)
                {
                   string message = string.Join(";", AlarmInfoList);
                   dto.Message =message;
                }
            }
            //记录报警信息
         
            //await DeviceStateService.AddDeviceState(dto);
        }

        protected MainFuncBase(PLCConfig PLCConfig)
        {
            PLC = PLCConfig.MyPlc;
            PLC_IP = PLCConfig.IP;
            PLC_PORT = PLCConfig.Port;
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
                        Logger.Info("PLC连接中");
                        bool flag = PLC.Connect(PLC_IP, PLC_PORT);
                        if (flag)
                        {
                            IsPlc_Connected = true;
                            Logger.Debug("PLC连接成功");
                        }
                        else
                        {
                            IsPlc_Connected = false;
                            Logger.Error("PLC连接失败:");
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
                    Logger.Error("PLC监控线程错误:"+ex.Message);
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            _cts.Cancel();
            //释放PLC连接
            PLC?.Dispose();
            reportTimer.Dispose();
        }
    }
}
