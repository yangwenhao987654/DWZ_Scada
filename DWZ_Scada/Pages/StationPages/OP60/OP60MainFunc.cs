using CommunicationUtilYwh.Device;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.DTO.OP60;
using LogTool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TouchSocket.Core;

namespace DWZ_Scada.Pages.StationPages.OP60
{
    public class OP60MainFunc : MainFuncBase, IDisposable
    {
        private static OP60MainFunc _instance;

        public static OP60MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP60MainFunc))
                    {
                        if (_instance == null)
                        {

                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP60MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP60MainFunc(plcConfig);

        }

        private static readonly OP60Model Model = new();

        public event EntryStateChanged OP60EntryStateChanged;

        public TcpDevice1 SafetyDevice1 = new TcpDevice1("安规测试机1", 1);

        public TcpDevice1 SafetyDevice2 = new TcpDevice1("安规测试机2", 2);

        public TcpDevice1 AtlBrxDevice1 = new TcpDevice1("AtlBrx测试机1", 3);

        public TcpDevice1 AtlBrxDevice2 = new TcpDevice1("AtlBrx测试机2", 4);

        public Dictionary<int, TcpDevice1> DeviceMap = new Dictionary<int, TcpDevice1>();


        public OP60MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP60";
            StationCode = "OP60";

            DeviceMap.Add(1, SafetyDevice1);
            DeviceMap.Add(2, SafetyDevice2);
            DeviceMap.Add(3, AtlBrxDevice1);
            DeviceMap.Add(4, AtlBrxDevice2);
        }

        public void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            PLC?.Dispose();
            //AtlBrxDevice1?.Dispose();
            foreach ((int key, TcpDevice1 value) in DeviceMap)
            {
                value?.Dispose();
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
            OP60Model model = new OP60Model();

            Thread t1 = new Thread(() => SafetyTestMonitor(token));
            t1.Start();

            Thread t2 = new Thread(() => AtlBrxTestMonitor(token));
            t2.Start();

            Thread t3 = new Thread(() => SafetyTestMonitor2(token));
            t3.Start();

            Thread t4 = new Thread(() => AtlBrxTestMonitor2(token));
            t4.Start();

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
                    // 处理进站信号
                    await ProcessEntrySignal();

                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Exception in PLCMainWork: {ex.Message}");
                }

                Thread.Sleep(1000);
            }
        }

        private async void SafetyTestMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        if (SafetyDevice1.IsConnect())
                        {
                            await ProcessSafetyTestSignal();
                        }
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(20);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("安规测试1线程错误:" + e.StackTrace);
                }
            }
        }


        private async void SafetyTestMonitor2(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        if (SafetyDevice2.IsConnect())
                        {
                            await ProcessSafetyTestSignal2();
                        }
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(20);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("安规测试2线程错误:" + e.StackTrace);
                }
            }
        }

        private async void AtlBrxTestMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        if (AtlBrxDevice1.IsConnect())
                        {
                            await ProcessAtlBrxTest();
                        }

                        Thread.Sleep(500);
                    }
                    Thread.Sleep(20);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("电性能测试1线程错误:" + e.StackTrace);
                }
            }
        }

        private async void AtlBrxTestMonitor2(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        if (AtlBrxDevice2.IsConnect())
                        {
                            await ProcessAtlBrxTest2();
                        }

                        Thread.Sleep(500);
                    }
                    Thread.Sleep(20);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("电性能测试2线程错误:" + e.StackTrace);
                }
            }
        }


        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadInt16(OP60Address.EntrySignal, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP60Address.EntrySignal, 0);
                PLC.Read(OP60Address.EntrySn, "string-8", out string sn);
                OP60EntryStateChanged?.Invoke(sn, 0);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = CurWorkOrder,
                };
                //(bool flag, string msg) = await EntryRequest(requestDto);
                bool flag = true;
                string msg = "";
                short result = 2;
                if (flag)
                {
                    result = 1;
                }
                OP60EntryStateChanged?.Invoke(sn, result, msg);
                LogMgr.Instance.Debug($"写进站结果{flag}:{result} :\n{msg}");
                PLC.WriteInt16(OP60Address.EntryResult, result);
            }
        }

        private void StartTest(int pos, string sn)
        {
            PageOP60.Instance.StartTestUI(pos, sn);
            switch (pos)
            {
                case 1:
                    break;
            }

            SafetyDevice1.UpdateProduct(sn);
            //Thread.Sleep(100);
            SafetyDevice1.TriggerWork();
            //等待结果
            //等待测试状态改变

            SafetyDevice1.QueryTestStatus();
        }

        private async Task<short> HandleSafetyTestAndResult(TcpDevice1 device, string sn)
        {
            Mylog.Instance.Debug($"准备触发测试");
            int state = await TriggerDeviceTest(device, sn, SystemParams.Instance.OP60_Safety_TimeOut * 1000);
            Logger.Debug($"获取测试状态:[{state}]");
            SafetyTestDto dto = new SafetyTestDto();
            short result = 2; //结果2 表示NG
            if (state == 2)
            {
                //表示正常测试完成 可以读取结果
                string output = SafetyDevice1.QueryDetailsWorkResult();
                dto = SafetyTestDto.ParseDto(output);
                if (dto.SafetyTestResult == "Y")
                {
                    //表示测试OK
                    result = 1;
                }
            }
            else if (state == 0)
            {
                LogMgr.Instance.Error($"[{device.Name}]未进行测试!");
            }
            else if (state == 10)
            {
                //返回10 表示超时
                result = 10;
            }
            PassStationDTO requestDto = new()
            {
                SnTemp = sn,
                StationCode = StationCode,
                WorkOrder = CurWorkOrder,
                PassStationData = dto,
                isLastStep = false,
            };
            // (bool flag, string msg) = await UploadStationData(requestDto);
            string msg = "屏蔽mes";
            LogMgr.Instance.Debug($"Device:[{device.Name}]传Mes安规测试结果:{result} :\n{msg}");
            /*if (flag)
            {
                result = 1;
            }*/
            return result;
        }


        private async Task<short> HandleAtlBrxTestAndResult(TcpDevice1 device, string sn)
        {
            int state = await TriggerDeviceTest(device, sn, SystemParams.Instance.OP60_AtlBrx_TimeOut * 60);
            AtlBrxTestDto dto = new AtlBrxTestDto();
            short result = 2; //结果2 表示NG
            if (state == 2)
            {
                //表示正常测试完成 可以读取结果
                string output = SafetyDevice1.QueryDetailsWorkResult();
                dto = AtlBrxTestDto.ParseDto(output);
                if (dto.AtlBrxTestResult == "Y")
                {
                    //表示测试OK
                    result = 1;
                }
            }
            else if (state == 0)
            {
                LogMgr.Instance.Error($"[{device.Name}]未进行测试!");
            }
            else if( state == 10) {
            
                result = 10;
            }
            PassStationDTO requestDto = new()
            {
                SnTemp = sn,
                StationCode = StationCode,
                WorkOrder = CurWorkOrder,
                PassStationData = dto,
                isLastStep = true,
            };
            (bool flag, string msg) = await UploadStationData(requestDto);
            LogMgr.Instance.Debug($"Device:[{device.Name}]写电性能测试结果:{result} :\n{msg}");
            /*if (flag)
            {
                result = 1;
            }*/
            return result;
        }

        // 处理安规测试
        private async Task ProcessSafetyTestSignal()
        {
            if (PLC.ReadInt16(OP60Address.SafetyStartSignal, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP60Address.SafetyStartSignal, 0);
                Mylog.Instance.Debug("安规测试1开始..");
                //工位1 安规测试
                PLC.Read(OP60Address.SafetyTestSN1, "string-8", out string sn1);
                PageOP60.Instance.StartTestUI(1, sn1);
                Task task1 = Task.Run(async () =>
                {
                    try
                    {
                        short result = await HandleSafetyTestAndResult(SafetyDevice1, sn1);
                        Mylog.Instance.Debug($"await 异步测试完成..result:[{result}]");
                        if (result == 1)
                        {
                            PageOP60.Instance.TestPassUI(1, sn1);
                        }
                        else if (result == 10)
                        {
                            PageOP60.Instance.TestFailUI(1, sn1,"超时");
                        }
                        else
                        {
                            PageOP60.Instance.TestFailUI(1, sn1);
                        }
                        PLC.WriteInt16(OP60Address.SafetyResult1, result);
                        Mylog.Instance.Debug($"安规测试1完成..结果[{(result == 1 ? "OK" : "NG")}]");
                    }
                    catch (Exception ex)
                    {
                        PageOP60.Instance.TestFailUI(1, sn1);
                        PLC.WriteInt16(OP60Address.SafetyResult1, 2);
                        Mylog.Instance.Error("安规测试1等待测试异步任务错误:" + ex.Message);
                        Mylog.Instance.Error(ex.StackTrace);
                    }
                });
                //task1.Wait();

            }
        }

        // 处理安规测试
        private async Task ProcessSafetyTestSignal2()
        {
            if (PLC.ReadInt16(OP60Address.SafetyStartSignal2, out short isEntry2) && isEntry2 == 1)
            {

                PLC.WriteInt16(OP60Address.SafetyStartSignal2, 0);
                Mylog.Instance.Debug("安规测试2开始..");
                //工位2 安规测试
                PLC.Read(OP60Address.SafetyTestSN2, "string-8", out string sn2);
                PageOP60.Instance.StartTestUI(2, sn2);
                Task task2 = Task.Run(async () =>
                {

                    try
                    {
                        short result = await HandleSafetyTestAndResult(SafetyDevice2, sn2);
                        if (result == 1)
                        {
                            PageOP60.Instance.TestPassUI(2, sn2);
                        }
                        else if (result == 10)
                        {
                            PageOP60.Instance.TestFailUI(2, sn2, "超时");
                        }
                        else
                        {
                            PageOP60.Instance.TestFailUI(2, sn2);
                        }
                        PLC.WriteInt16(OP60Address.SafetyResult2, result);
                        Mylog.Instance.Debug($"安规测试2完成..结果[{(result == 1 ? "OK" : "NG")}]");

                    }
                    catch (Exception ex)
                    {
                        PageOP60.Instance.TestFailUI(2, sn2);
                        PLC.WriteInt16(OP60Address.SafetyResult2, 2);
                        Mylog.Instance.Error("安规测试2等待测试异步任务错误:" + ex.Message);
                        Mylog.Instance.Error(ex.StackTrace);
                    }
                });
                /*                task2.Wait();*/
            }
        }

        private async Task<int> TriggerDeviceTest(TcpDevice1 device, string sn, int timeout)
        {
            Mylog.Instance.Debug($"清除上一次数据");
            device.ClearData();
            //Thread.Sleep(200);
            Mylog.Instance.Debug($"更新产品ID");
            device.UpdateProduct(sn);
            //Thread.Sleep(200);
            Mylog.Instance.Debug($"触发测试命令");
            device.TriggerWork();
            //Thread.Sleep(100);
            Logger.Debug($"[{device.Name}]触发测试");
            var service = new ElecDeviceService(device);
            //解析测试结果
            //1.获取测试状态值
            //TODO 一直监控测试状态,控制超时时间
            //int timeout = 1000 * 60; // 设置超时时间（毫秒）
            Mylog.Instance.Debug($"等待测试结果");
            var result = await service.GetTestStateWithTimeout(timeout);
            //10 表示超时
            if (result != 10)
            {
                Logger.Debug($"Device:[{device.Name}]GetTestState成功，返回值: " + result);
            }
            else
            {
                Logger.Error($"Device:[{device.Name}]GetTestState超时");
            }
            Mylog.Instance.Debug($"获取到测试结果:{result}");
            //3. 请求测试结果明细

            //4.封装结果返回 给Mes

            //5.清空上一次测试数据

            return result;
        }

        /// <summary>
        /// 动态电测
        /// </summary>
        /// <returns></returns>
        private async Task ProcessAtlBrxTest()
        {
            if (PLC.ReadInt16(OP60Address.AtlBrxStartSignal, out short isEntry) && isEntry == 1)
            {
                try
                {
                    PLC.WriteInt16(OP60Address.AtlBrxStartSignal, 0);
                    Mylog.Instance.Debug("电性能测试1开始..");
                    //工位2 安规测试
                    PLC.Read(OP60Address.AtlBrxTestSN1, "string-8", out string sn1);
                    PageOP60.Instance.StartTestUI(3, sn1);
                    Task task1 = Task.Run(async () =>
                    {

                        try
                        {

                            short result = await HandleAtlBrxTestAndResult(AtlBrxDevice1, sn1);
                            if (result == 1)
                            {
                                PageOP60.Instance.TestPassUI(3, sn1);
                            }
                            else if (result == 10)
                            {
                                PageOP60.Instance.TestFailUI(3, sn1, "超时");
                            }
                            else
                            {
                                PageOP60.Instance.TestFailUI(3, sn1);
                            }
                            PLC.WriteInt16(OP60Address.AtlBrxResult1, result);
                            Mylog.Instance.Debug($"电性能测试1完成..结果[{(result == 1 ? "OK" : "NG")}]");

                        }
                        catch (Exception ex)
                        {
                            PLC.WriteInt16(OP60Address.AtlBrxResult1, 2);
                            PageOP60.Instance.TestFailUI(3, sn1);
                            Mylog.Instance.Error("电性能测试1等待测试异步任务错误:" + ex.Message);
                            Mylog.Instance.Error(ex.StackTrace);
                        }
                    });
                }
                catch (Exception ex)
                {
                    Mylog.Instance.Error("异步执行电性能测试1错误:" + ex.Message);
                    Logger.Error("错误堆栈:" + ex.StackTrace);
                }

            }
        }

        /// <summary>
        /// 动态电测
        /// </summary>
        /// <returns></returns>
        private async Task ProcessAtlBrxTest2()
        {
            if (PLC.ReadInt16(OP60Address.AtlBrxStartSignal2, out short isEntry2) && isEntry2 == 1)
            {
                PLC.WriteInt16(OP60Address.AtlBrxStartSignal2, 0);
                Mylog.Instance.Debug("电性能测试2开始..");
                PLC.Read(OP60Address.AtlBrxTestSN2, "string-8", out string sn2);
                PageOP60.Instance.StartTestUI(4, sn2);
                Task task2 = Task.Run(async () =>
                {
                    try
                    {
                        //工位2 安规测试

                        short result = await HandleAtlBrxTestAndResult(AtlBrxDevice2, sn2);
                        if (result == 1)
                        {
                            PageOP60.Instance.TestPassUI(4, sn2);
                        }
                        else if (result == 10)
                        {
                            PageOP60.Instance.TestFailUI(4, sn2, "超时");
                        }
                        else
                        {
                            PageOP60.Instance.TestFailUI(4, sn2);
                        }
                        //超时给3 
                        PLC.WriteInt16(OP60Address.AtlBrxResult2, result);
                        Mylog.Instance.Debug($"电性能测试2完成..结果[{(result == 1 ? "OK" : "NG")}]");
                    }
                    catch (Exception ex)
                    {
                        PLC.WriteInt16(OP60Address.AtlBrxResult2, 2);
                        PageOP60.Instance.TestFailUI(4, sn2);
                        Mylog.Instance.Error("异步执行电性能测试2错误:" + ex.Message);

                        Logger.Error("错误堆栈:" + ex.StackTrace);
                    }
                });
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP60Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }

        protected override void ConnStatusMonitor(CancellationToken token)
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
                        PLC.Write(OP60Address.HeartBeat, "int", 1);
                    }
                    if (!GlobalOP60.IsOpenDebugTCPDevice)
                    {
                        CheckDeviceConnState(SafetyDevice1, SystemParams.Instance.OP60_Safety_01_IP, SystemParams.Instance.OP60_Safety_01_Port);
                        CheckDeviceConnState(SafetyDevice2, SystemParams.Instance.OP60_Safety_02_IP, SystemParams.Instance.OP60_Safety_02_Port);
                        CheckDeviceConnState(AtlBrxDevice1, SystemParams.Instance.OP60_AtlBrx_01_IP, SystemParams.Instance.OP60_AtlBrx_01_Port);
                        CheckDeviceConnState(AtlBrxDevice2, SystemParams.Instance.OP60_AtlBrx_02_IP, SystemParams.Instance.OP60_AtlBrx_02_Port);
                        //TODO 电测设备TCP连接监控
                    }
                    if (GlobalOP60.EnableDisConnect)
                    {
                        GlobalOP60.EnableDisConnect = false;
                        SafetyDevice1?.Disconnect();
                        SafetyDevice2?.Disconnect();
                        AtlBrxDevice1?.Disconnect();
                        AtlBrxDevice2?.Disconnect();
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

        private async void CheckDeviceConnState(TcpDevice1 device, string ip, string port)
        {
            if (!device.IsConnect())
            {
                (bool flag, string err) = await device.ConnectAsync(ip, port);
                if (flag)
                {
                    Mylog.Instance.Info($"{device.Name} 连接成功");
                }
                else
                {
                    Mylog.Instance.Error($"{device.Name} 连接失败:{err} IP:[{ip}] Port:[{port}]");
                }
                PageOP60.Instance.TriggerDeviceStateChanged(device.ID, flag);

            }
        }
    }
}