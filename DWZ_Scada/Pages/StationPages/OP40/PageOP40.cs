using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DWZ_Scada.Pages.StationPages.OP40
{
    public partial class PageOP40 : UIPage
    {
        public List<OrderVo> Orders { get; set; }

        private static PageOP40 _instance;
        public static PageOP40 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP40))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP40();
                        }
                    }
                }
                return _instance;
            }
        }

        private PageOP40()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);

            LogMgr.Instance.Debug($"打开OP40工站");
            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP40工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP40_PlcIP,
                SystemParams.Instance.OP40_PlcPort);
            OP40MainFunc.CreateInstance(plcConfig);
            OP40MainFunc.Instance.StartAsync();

            OP40MainFunc.Instance.OP40EntryStateChanged += Instance_OP40EntryStateChanged;
            OP40MainFunc.Instance.OnVision1Finished += Instance_OnVision1Finished;
            OP40MainFunc.Instance.OnWeldingFinished += Instance_OnWeldingFinished;

            OP40MainFunc.Instance.OnWeldDataRevived += Instance_OnWeldDataRevived;

            OP40MainFunc.Instance.OnTemperatureRecived += Instance_OnTemperatureRecived;

            OP40MainFunc.Instance.OnPressureRecived += Instance_OnPressureRecived;

            //OP40DamageStrategy op40DamageStrategy = new OP40DamageStrategy();
            //op40DamageStrategy.OnDamageableEvent += Op40DamageStrategy_OnSelectionEvent;

        }

        private void Instance_OnPressureRecived(ushort value)
        {
            UpdatePressure(value);
        }

        private void UpdatePressure(ushort value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ushort>(UpdatePressure), value);
                return;
            }

            if (value <= 0)
            {
                lbl_Pressure.Text = $"{value}Mpa";
            }
            else
            {
                //换算压力
                double v = (double)((double)value / 10000 )* 20;
                lbl_Pressure.Text = $"{v:F4}Mpa";
            }
        }

        private void Instance_OnTemperatureRecived(double temperature, double humidity)
        {
            UpdateTemperature(temperature, humidity);
        }

        private void UpdateTemperature(double temperature, double humidity)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<double, double>(UpdateTemperature), temperature, humidity);
                return;
            }
            lbl_temperature.Text = $"{temperature:F1}℃";
            lbl_humidity.Text = $"{humidity:F1}%RH";
        }

        private void Instance_OnWeldDataRevived(short[] arr, string type)
        {
            UpdateWeldingData(arr, type);
        }

        public void UpdateWeldingData(short[] arr, string type)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateWeldingData(arr, type)));
                return;
            }
            string values = string.Join(",", arr);
            LogMgr.Instance.Debug($"气体[{type}]:{values}");
            switch (type)
            {
                case "A":
                    lbl_1_A.Text = arr[0].ToString();
                    lbl_2_A.Text = arr[1].ToString();
                    lbl_3_A.Text = arr[2].ToString();
                    lbl_4_A.Text = arr[3].ToString();
                    lbl_5_A.Text = arr[4].ToString();
                    lbl_6_A.Text = arr[5].ToString();

                    /*          lbl_2_A.Text = arr[3].ToString();
                              lbl_2_B.Text = arr[4].ToString();
                              lbl_2_C.Text = arr[5].ToString();*/
                    break;

                case "B":

                    lbl_1_B.Text = arr[0].ToString();
                    lbl_2_B.Text = arr[1].ToString();
                    lbl_3_B.Text = arr[2].ToString();
                    lbl_4_B.Text = arr[3].ToString();
                    lbl_5_B.Text = arr[4].ToString();
                    lbl_6_B.Text = arr[5].ToString();
                    break;
                case "C":
                    lbl_1_C.Text = arr[0].ToString();
                    lbl_2_C.Text = arr[1].ToString();
                    lbl_3_C.Text = arr[2].ToString();
                    lbl_4_C.Text = arr[3].ToString();
                    lbl_5_C.Text = arr[4].ToString();
                    lbl_6_C.Text = arr[5].ToString();
                    break;

            }
        }

        private void Instance_OnWeldingFinished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_Welding, sn, result);
        }

        private void Instance_OnVision1Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_Vision, sn, result);
        }

        private void Instance_OP40EntryStateChanged(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry_OP40, sn, result, msg);
        }

        private void OP10SelectionStrategy_OnSelectionEvent(object sender, SelectionEventArgs e)
        {
            LogMgr.Instance.Info("触发选型");
            LogMgr.Instance.Info($"下发型号[{e.Model}]");
            SelectionResultDTO dto = e.SelectionResult;
            dto.Message = $"处理选型[{e.Model}]完成";
            dto.Code = 1;
            //Thread.Sleep(2000);
            LogMgr.Instance.Info("选型结束");
        }
        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
        private void PageOP40_FormClosing(object sender, FormClosingEventArgs e)
        {

            LogMgr.Instance.Info($"关闭OP40-HttpServer");
            if (OP40MainFunc.IsInstanceNull)
            {
                OP40MainFunc.Instance?.Dispose();
            }
            LogMgr.Instance.Info($"关闭OP40程序");
            _instance = null;
        }

        private void lbl_3_B_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel11_Click(object sender, EventArgs e)
        {

        }
    }
}
