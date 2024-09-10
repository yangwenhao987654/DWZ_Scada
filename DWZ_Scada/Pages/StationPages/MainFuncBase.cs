using CommunicationUtilYwh.Communication.PLC;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages
{
    public abstract class MainFuncBase : IDisposable
    {
        //PLC类型  
        //PLC 连接配置  IP地址 端口号

        public static bool IsInstanceNull => _instance==null;

        private static MainFuncBase _instance;

        private static Func<MainFuncBase> _createInstanceFunc;

        //private static MainFuncBase myOp10Model;

        public static MainFuncBase Instance
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
        }

        public  bool IsPlc_Connected;

        public LogMgr Logger = LogMgr.Instance;

        public  MyPlc PLC ;

        /// <summary>
        /// PLC的IP地址
        /// </summary>
        public string PLC_IP;

        /// <summary>
        /// PLC端口号
        /// </summary>
        public int PLC_PORT;

        private CancellationTokenSource _cts = new CancellationTokenSource();

        private  int DeviceState = -1;

        private  readonly object stateLock = new object();

        private Timer reportTimer;

        /// <summary>
        /// 启动流程
        /// </summary>
        public async void StartAsync()
        {
            Task.Run(() =>
            {
                //myOp10Model = op10Model;
                //启动PLC监控线程
                Thread t = new Thread(() => ConnStatusMonitor(_cts.Token));
                t.Start();
                Thread.Sleep(300);
                Thread t2 = new Thread(() => PLCMainWork(_cts.Token));
                t2.Start();
                reportTimer = new Timer(ReportDeviceState, null, 0, 1000);
            });
        }

        /// <summary>
        /// 上报设备状态 1S 上报一次
        /// </summary>
        /// <param name="state"></param>
        private async void ReportDeviceState(object state)
        {
            int currentState;
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
                    dto.Status = "错误";
                    break;
            }

            //如果有报警的话 需要带着报警信息

            //记录报警信息

            DeviceStateService stateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();
            await stateService.ReportState(dto);
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
                if (!IsPlc_Connected)
                {
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
