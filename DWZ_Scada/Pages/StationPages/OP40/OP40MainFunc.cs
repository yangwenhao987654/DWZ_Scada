using CommonUtilYwh.Communication.ModbusTCP;
using CommunicationUtilYwh.Communication.ModbusTCP;
using CommunicationUtilYwh.Device;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP40
{
    public class OP40MainFunc : MainFuncBase
    {
        public static bool IsInstanceNull => _instance == null;

        private static OP40MainFunc _instance;

        public static OP40MainFunc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(OP40MainFunc))
                    {
                        if (_instance == null)
                        {

                            // 使用一个工厂方法创建实例，让子类决定实例化逻辑
                            throw new Exception("OP40MainFunc is Not instantiate");
                        }
                    }
                }
                return _instance;
            }
        }

        public static void CreateInstance(PLCConfig plcConfig)
        {
            _instance = new OP40MainFunc(plcConfig);
        }

        public delegate void WeldDataRevived(short[] arr,string type);

        public event WeldDataRevived OnWeldDataRevived;

        public event EntryStateChanged OP40EntryStateChanged;

        public event Action<double, double> OnTemperatureRecived;

        /// <summary>
        /// 焊接开始
        /// </summary>
        public event Action OnWeldStart;

        /// <summary>
        /// 氦气瓶压力
        /// </summary>
        public event Action<double> OnPressureRecived;

        /// <summary>
        /// 视觉检测完成
        /// </summary>
        public event TestStateChanged OnVision1Finished;

        /// <summary>
        /// 焊接完成
        /// </summary>
        public event TestStateChanged OnWeldingFinished;


        /// <summary>
        /// 压力报警
        /// bool 表示有无报警
        /// int 1 超过上限 2 低于下限
        /// </summary>
        public event Action<bool,int> OnPressureAlarm;


        private object _lock = new object();


        public OP40MainFunc(PLCConfig PLCConfig) : base(PLCConfig)
        {
            StationName = "OP40";
            StationCode = "OP40";
            //Logger.AddChargeInfo("执行大电流放电");
        }
        //ModbusTCP modbusTcp01 = new ModbusTCP();
        MyModbus modbusTcp02 = new MyModbus();
        protected override string GetPLCIP()
        {
            return SystemParams.Instance.OP40_PlcIP;
        }

        protected override int GetPLCPort()
        {
            return SystemParams.Instance.OP40_PlcPort;
        }

        public override void Dispose()
        {
            //释放PLC监控线程 所有后台线程
            //释放PLC连接
            base.Dispose();
            PLC?.Dispose();
            modbusTcp02?.Dispose();
        }


        private void TemperatureMonitor(CancellationToken token)
        {
            if (modbusTcp02!=null)
            {
                modbusTcp02.ReviceTimeOut=500;
            }
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (modbusTcp02.IsConnect)
                    {
                        //连接成功
                        try
                        {
                            modbusTcp02.StationNum = 2;
                            double humidity = ReadHumidity(modbusTcp02);
                            double temperature = ReadTemperature(modbusTcp02);
                            //获取到温度和湿度

                            lock (_lock)
                            {
                                CurHumidity = humidity;
                                CurTemperature = temperature;
                            }
                            //实时显示温度和湿度
                            OnTemperatureRecived?.Invoke(temperature, humidity);
                        }
                        catch (Exception e)
                        {
                            LogMgr.Instance.Error($"温湿度读取失败{e.Message}");
                        }
                        
                        //实时显示温度和湿度
                        //数值给PLC
                        //OnPressureRecived?.Invoke(pressure);
                        try
                        {
                           
                            double pressure = ReadPressure(modbusTcp02);
                            //short pressure = modbusTcp02.ReadInt16(4);
                            //LogMgr.Instance.Debug($"ModbusTCP-读取压力结果:{pressure}");
                            OnPressureRecived?.Invoke(pressure);
                            if (pressure>SystemParams.Instance.OP40_PressureMax)
                            {
                                //压力超过上限
                                OnPressureAlarm.Invoke(true,1);
                            }else if (pressure<SystemParams.Instance.OP40_PressureMin)
                            {
                                //压力低于下限值
                                OnPressureAlarm.Invoke(true, 2);
                            }
                            else
                            {
                                OnPressureAlarm.Invoke(false, 0);
                            }
                        }
                        catch (Exception e)
                        {
                            LogMgr.Instance.Error($"压力读取失败{e.Message}");
                        }
                    }
                    else
                    {
                        modbusTcp02.Connect(SystemParams.Instance.OP40_ModbusIP,SystemParams.Instance.OP40_ModbusPort);
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"ModbusTCP-温度采集线程出错:{e.Message},{e.StackTrace}");
                    //LogMgr.Instance.Error($"温度采集线程出错:{e.Message}");
                }
                Thread.Sleep(1000);
            }
            modbusTcp02?.Dispose();
        }


        private void PressureMonitor(CancellationToken token)
        {

           /* while (!token.IsCancellationRequested)
            {
                try
                {
                    if (modbusTcp01.IsConnect)
                    {
                        modbusTcp01.ReadInt16("4", out short pressure);

                        OnPressureRecived?.Invoke(pressure);
                    }
                    else
                    {
                        modbusTcp01.Open(SystemParams.Instance.OP40_ModbusIP, SystemParams.Instance.OP40_ModbusPort, 1);
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"ModbusTCP-温度采集线程出错:{e.Message},{e.StackTrace}");
                    //LogMgr.Instance.Error($"温度采集线程出错:{e.Message}");
                }
                Thread.Sleep(1000);
            }
            modbusTcp02?.Dispose();*/
        }

        /// <summary>
        /// 读取温度
        /// </summary>
        public double ReadTemperature(ModbusTCP client)
        {
            double result = 0;
            string address = "0";
            bool f = client.ReadInt16(address, out short value);
            if (f)
            {
                if (value >= 10000)
                {
                    //假如大于10000  表示温度是负
                    result = (-1 * (value - 10000) * 0.1);
                }
                else
                {
                    result = value * 0.1;
                }
            }
            else
            {
                LogMgr.Instance.Error("读取温度失败");
            }

            return result;
        }

        /// <summary>
        /// 读取湿度
        /// </summary>
        public double ReadHumidity(ModbusTCP client)
        {
            double result = 0;
            string address = "1";
            bool f = client.ReadInt16(address, out short value);
            if (f)
            {
                result = value * 0.1;
            }
            else
            {
                LogMgr.Instance.Error("读取湿度失败");
            }
            return result;
        }

        /// <summary>
        /// 读取湿度
        /// </summary>
        public double ReadHumidity(MyModbus client)
        {
            double result = 0;
            ushort startAddress = 1;
            ushort value = client.ReadUInt16(startAddress);
            if (value!=0)
            {
                result = value * 0.1;
            }
            else
            {
                //LogMgr.Instance.Error("读取湿度失败");
            }
            return result;
        }

        /// <summary>
        /// 读取湿度
        /// </summary>
        public double ReadPressure(MyModbus client)
        {
            client.StationNum = 1;
            double result = 0;
            ushort startAddress = 4;
            short value = client.ReadInt16(startAddress);
            result = (double)((double)value / 10000) * 25;
            return result;
        }

        /// <summary>
        /// 读取温度
        /// </summary>
        public double ReadTemperature(MyModbus client)
        {
            double result = 0;
            ushort startAddress = 0;
            ushort value = client.ReadUInt16(startAddress);
            if (value >= 10000)
            {
                result = (-1 * (value - 10000) * 0.1);
            }
            else
            {
                result = value * 0.1;
            }
            return result;
        }



        /// <summary>
        /// 当前温度
        /// </summary>
        public double CurTemperature { get; set; }

        /// <summary>
        /// 当前湿度
        /// </summary>
        public double CurHumidity { get; set; }
        protected override DeviceStateDTO WrapDeviceStateInner(DeviceStateDTO dto)
        {
       /*     if (dto.Status == "run")
            {
                //运行状态下 读取大电流放电的使用次数
                OP40StateData data = new OP40StateData();
                PLC.ReadInt32(OP40Address.DisChargeCount, out int count);
                data.DisChargeCount = count;
                dto.Data = data;

            }*/
            OP10TempData tempData = new OP10TempData() { Humidity = CurHumidity, Temperature = CurTemperature, };
            lock (_lock)
            {
                tempData.Humidity = CurHumidity;
                tempData.Temperature = CurTemperature;
            }
            dto.Data = tempData;
            return dto;
            return dto;
        }

        public override async void PLCMainWork(CancellationToken token)
        {
            Thread t1 = new Thread(() => WeldingMonitor(token));
            t1.Start();

            Thread t2 = new Thread(() => VisionMonitor(token));
            t2.Start();

            Thread t3 = new Thread(() => TemperatureMonitor(token));
            t3.Start();

            Thread t4 = new Thread(() => PressureMonitor(token));
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

        /// <summary>
        /// 画像检测流程
        /// </summary>
        /// <param name="token"></param>
        private async void VisionMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        await HandleVisionProcess();
                        Thread.Sleep(500);
                    }

                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error($"画像检测线程错误: [{ e.Message}] \n异常堆栈:{e.StackTrace}");
                }
            }
        }

        /// <summary>
        /// 焊接流程
        /// </summary>
        /// <param name="token"></param>
        private void WeldingMonitor(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (IsPlc_Connected)
                    {
                        //TODO 读取大电流放电
                        ReadCharge();

                        //处理焊接流程 获取焊接数据
                        HandleWelding();


                        Thread.Sleep(500);
                    }

                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("焊接流程线程错误:" + e.Message);
                }
            }
        }

        private void ReadCharge()
        {
            if (PLC.ReadInt16(OP40Address.ChargeStart, out short isStart) && isStart == 1)
            {
                Logger.AddChargeInfo("执行大电流放电");
                LogMgr.Instance.Debug("收到[OP40]放电信号");
                //复位视觉完成
                PLC.WriteInt16(OP40Address.ChargeStart, 0);
            }
        }

        /// <summary>
        /// 记录当前易损易耗件使用情况
        /// </summary>
        private void DamageableRead()
        {
            //1.读取设备使用次数
            //TODO 读取PLC
            PLC.ReadInt16(OP40Address.ProbeUseCount, out var count);

            PLC.ReadInt16(OP40Address.ElecUseCount, out var count2);
            Logger.Debug($"读取探针使用次数:[{count}]");
            Logger.Debug($"读取电极使用次数:[{count2}]");
            //2.上报Mes 
            DamageableDTO dto = new DamageableDTO()
            {
                deviceCode="OP40",
                code ="01", //焊接探针
                runNumber = count,
                type = 1,
            };
          
            DamageableDTO dto2 = new DamageableDTO()
            {
                deviceCode = "OP40",
                code = "02", //焊接电极
                runNumber = count2,
                type = 1,
            };
            DamageableReport(dto);
            DamageableReport(dto2);
        }

        private async Task HandleWelding()
        {
            if (PLC.ReadInt16(OP40Address.WeldingStart, out short isRequest) && isRequest == 1)
            {
                LogMgr.Instance.Debug("收到[OP40]焊接请求信号");

                OnWeldStart?.Invoke();
                //复位视觉完成
                PLC.WriteInt16(OP40Address.WeldingStart, 0);
                PLC.ReadString(OP40Address.WeldingSn, 8, out string sn);
                OnWeldingFinished?.Invoke(sn, 0);
              
                if (GlobalOP40.IsAllow)
                {
                    PLC.WriteInt16(OP40Address.WeldingConfirm, 1);
                    LogMgr.Instance.Debug("上位机允许焊接");
                }
                else
                {
                    PLC.WriteInt16(OP40Address.WeldingConfirm, 2);
                    LogMgr.Instance.Debug("上位机禁止焊接");
                }
            }
    
            if (PLC.ReadInt16(OP40Address.WeldingFinish, out short isFinish) && isFinish == 1)
            {
                //TODO 焊接一次记录一次
                Logger.AddChargeInfo("执行焊接");
                //LogMgr.Instance.Debug("收到[OP40]焊接开始信号");
                LogMgr.Instance.Debug("收到[OP40]焊接完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP40Address.WeldingFinish, 0);
                PLC.ReadString(OP40Address.WeldingSn, 8, out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);

                //TODO 读取焊接数据
                short[] arrA = new short[6];
                PLC.ReadInt16(OP40Address.Welding_A_DataStart,6,out arrA);
                OnWeldDataRevived?.Invoke(arrA, "A");
                short[] arrB = new short[6];
                PLC.ReadInt16(OP40Address.Welding_B_DataStart, 6, out arrB);
                OnWeldDataRevived?.Invoke(arrB, "B");
                short[] arrC = new short[6];
                PLC.ReadInt16(OP40Address.Welding_C_DataStart, 6, out arrC);
                OnWeldDataRevived?.Invoke(arrC, "C");
                //short[] arr = new short[18];

                //short result = CheckWeldingData();
                //界面更新

                //TODO 给PLC结果
                PLC.ReadInt16(OP40Address.WeldingResult, out short result);
                OnWeldingFinished?.Invoke(sn, result);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                bool isGood = result == 1;
                LogMgr.Instance.Debug($"焊接结果:{(isGood ? "OK" : "NG")}");

                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    PassStationData = new OP40WeldingData()
                    {
                        WeldingResult = isGood,
                        Good = isGood,
                        GasA1 = arrA[0].ToString(),
                        GasA2 = arrA[1].ToString(),
                        GasA3 = arrA[2].ToString(),
                        GasA4 = arrA[3].ToString(),
                        GasA5 = arrA[4].ToString(),
                        GasA6 = arrA[5].ToString(),

                        GasB1 = arrB[0].ToString(),
                        GasB2 = arrB[1].ToString(),
                        GasB3 = arrB[2].ToString(),
                        GasB4 = arrB[3].ToString(),
                        GasB5 = arrB[4].ToString(),
                        GasB6 = arrB[5].ToString(),

                        GasC1 = arrC[0].ToString(),
                        GasC2 = arrC[1].ToString(),
                        GasC3 = arrC[2].ToString(),
                        GasC4 = arrC[3].ToString(),
                        GasC5 = arrC[4].ToString(),
                        GasC6 = arrC[5].ToString(),
                    },
                    isLastStep = false
                };

                DamageableRead();

                (bool res, string msg) = await UploadData(dto);
                if (res == false)
                {
                    Logger.Error("上传焊接数据错误:" + msg);
                }
            }
        }

        /// <summary>
        /// 判断焊接数据
        /// </summary>
        /// <returns></returns>
        private short CheckWeldingData()
        {
            //判断绕线数据 是否正常
            short result = 1;
            
            //TODO 或者是读PLC 判断结果
            //1 OK 2NG 
            return result;
        }

        private async Task HandleVisionProcess()
        {
            if (PLC.ReadInt16(OP40Address.VisionStart, out short isStart) && isStart == 1)
            {
                LogMgr.Instance.Debug("收到[OP40]视觉开始信号");
                //复位视觉完成
                PLC.WriteInt16(OP40Address.VisionStart, 0);
                PLC.ReadString(OP40Address.VisionSn, 8, out string sn);
                OnVision1Finished?.Invoke(sn, 0);
            }

            if (PLC.ReadInt16(OP40Address.VisionFinish, out short isFinish) && isFinish == 1)
            {
                LogMgr.Instance.Debug("收到[OP40]视觉完成信号");
                //复位视觉完成
                PLC.WriteInt16(OP40Address.VisionFinish, 0);
                PLC.ReadString(OP40Address.VisionSn, 8, out string sn);
                LogMgr.Instance.Debug("读取出站条码内容:" + sn);
                PLC.ReadInt16(OP40Address.VisionResult, out short result);

                bool visionResult = result == 1;
                //界面更新
                OnVision1Finished?.Invoke(sn, result);
                //string snTest = "QWER123456";
                //上传Mes测试数据
                PassStationDTO dto = new PassStationDTO()
                {
                    StationCode = StationCode,
                    SnTemp = sn,
                    WorkOrder = Global.WorkOrder,
                    PassStationData = new OP40Vision1Data()
                    {
                        Vision1Result = visionResult,
                        Good = visionResult,
                    },
                    isLastStep = true
                };
                (bool res, string msg) = await UploadData(dto);
                if (res == false)
                {
                    Logger.Error("上传视觉数据错误:" + msg);
                }
                LogMgr.Instance.Debug($"视觉测试结果:{result}:{(result == 1 ? "OK" : "NG")}");
                PLC.WriteInt16(OP40Address.VisionOut,  result);
            }
        }

        // 处理进站信号

        // 处理进站信号
        private async Task ProcessEntrySignal()
        {
            if (PLC.ReadInt16(OP40Address.EntrySignal, out short isEntry) && isEntry == 1)
            {
                PLC.WriteInt16(OP40Address.EntrySignal, 0);
                PLC.ReadString(OP40Address.EntrySn, 8, out string sn);

                OP40EntryStateChanged?.Invoke(sn, 0);
                EntryRequestDTO requestDto = new()
                {
                    SnTemp = sn,
                    StationCode = StationCode,
                    WorkOrder = Global.WorkOrder
                };

                (bool flag, string msg) = await EntryRequest(requestDto);
                short result = (short)(flag ? 1 : 2);
               /* short result =1;
                bool flag = true;
                string msg = "";*/
                OP40EntryStateChanged?.Invoke(sn, result,msg);

                LogMgr.Instance.Debug($"写进站结果{flag} :\n{msg}");
                PLC.WriteInt16(OP40Address.EntryResult, result);
            }
        }

        /// <summary>
        /// 读取PLC状态
        /// </summary>
        /// <returns></returns>
        protected override int ReadPLCState()
        {
            short state;
            bool readFlag = PLC.ReadInt16(OP40Address.State, out state);
            //读取失败 返回-1
            return readFlag ? state : -1;
        }
    }
}