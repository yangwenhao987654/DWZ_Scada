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

            InitTable();
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

            OP40MainFunc.Instance.OnWeldStart += Instance_OnWeldStart;

            OP40MainFunc.Instance.OnPressureAlarm += Instance_OnPressureAlarm;

            //OP40DamageStrategy op40DamageStrategy = new OP40DamageStrategy();
            //op40DamageStrategy.OnDamageableEvent += Op40DamageStrategy_OnSelectionEvent;

        }

        private void Instance_OnPressureAlarm(bool isAlarm, int state)
        {
            ShowPressureAlarm(isAlarm, state);
        }

        private void ShowPressureAlarm(bool isAlarm, int state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool,int>(ShowPressureAlarm),isAlarm,state);
                return;
            }

            if (isAlarm)
            {
                light_Pre.State = UILightState.Blink;
                if (state==1)
                {
                    lbl_PressureMsg.Text = "压力超限！！！";
                }
                else
                {
                    lbl_PressureMsg.Text = "压力过低！！！";
                }
            }
            else
            {
                light_Pre.State = UILightState.On;
                lbl_PressureMsg.Text = "";
            }
        }

        private void Instance_OnWeldStart()
        {
            //
            ClaerWeldTableDada();
        }

        private void ClaerWeldTableDada()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ClaerWeldTableDada));
                return;
            }

            dgv.Rows[0].Cells[1].Value = "";
            dgv.Rows[1].Cells[1].Value ="";
            dgv.Rows[2].Cells[1].Value = "";
            dgv.Rows[3].Cells[1].Value = "";
            dgv.Rows[4].Cells[1].Value = "";
            dgv.Rows[5].Cells[1].Value = "";

            dgv.Rows[0].Cells[3].Value = "";
            dgv.Rows[1].Cells[3].Value = "";
            dgv.Rows[2].Cells[3].Value = "";
            dgv.Rows[3].Cells[3].Value = "";
            dgv.Rows[4].Cells[3].Value = "";
            dgv.Rows[5].Cells[3].Value = "";


            dgv.Rows[0].Cells[5].Value = "";
            dgv.Rows[1].Cells[5].Value = "";
            dgv.Rows[2].Cells[5].Value = "";
            dgv.Rows[3].Cells[5].Value = "";
            dgv.Rows[4].Cells[5].Value = "";
            dgv.Rows[5].Cells[5].Value = "";
        }

        private void InitTable()
        {
            dgv.Rows.Add();
            dgv.Rows.Add();
            dgv.Rows.Add();
            dgv.Rows.Add();
            dgv.Rows.Add();
            dgv.Rows.Add();

            dgv.Rows[0].Cells[0].Value = "氩气-1";
            dgv.Rows[1].Cells[0].Value = "氩气-2";
            dgv.Rows[2].Cells[0].Value = "氩气-3";
            dgv.Rows[3].Cells[0].Value = "氩气-4";
            dgv.Rows[4].Cells[0].Value = "氩气-5";
            dgv.Rows[5].Cells[0].Value = "氩气-6";

            dgv.Rows[0].Cells[2].Value = "空气1-1";
            dgv.Rows[1].Cells[2].Value = "空气1-2";
            dgv.Rows[2].Cells[2].Value = "空气1-3";
            dgv.Rows[3].Cells[2].Value = "空气1-4";
            dgv.Rows[4].Cells[2].Value = "空气1-5";
            dgv.Rows[5].Cells[2].Value = "空气1-6";

            dgv.Rows[0].Cells[4].Value = "空气2-1";
            dgv.Rows[1].Cells[4].Value = "空气2-2";
            dgv.Rows[2].Cells[4].Value = "空气2-3";
            dgv.Rows[3].Cells[4].Value = "空气2-4";
            dgv.Rows[4].Cells[4].Value = "空气2-5";
            dgv.Rows[5].Cells[4].Value = "空气2-6";
            dgv.ClearSelection();
        }                                     

        private void Instance_OnPressureRecived(double value)
        {
            UpdatePressure(value);
        }

        private void UpdatePressure(double value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<double>(UpdatePressure), value);
                return;
            }
            if (value == 0)
            {
                lbl_Pressure.Text = $"{value}Mpa";
            }
            else
            {
                lbl_Pressure.Text = $"{value:F2}Mpa";
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

            try
            {
                string values = string.Join(",", arr);
                LogMgr.Instance.Debug($"气体[{type}]:{values}");
                switch (type)
                {
                    case "A":
                        dgv.Rows[0].Cells[1].Value = arr[0].ToString();
                        dgv.Rows[1].Cells[1].Value = arr[1].ToString();
                        dgv.Rows[2].Cells[1].Value = arr[2].ToString();
                        dgv.Rows[3].Cells[1].Value = arr[3].ToString();
                        dgv.Rows[4].Cells[1].Value = arr[4].ToString();
                        dgv.Rows[5].Cells[1].Value = arr[5].ToString();
                        /*          lbl_1_A.Text = arr[0].ToString();
                                  lbl_2_A.Text = arr[1].ToString();
                                  lbl_3_A.Text = arr[2].ToString();
                                  lbl_4_A.Text = arr[3].ToString();
                                  lbl_5_A.Text = arr[4].ToString();
                                  lbl_6_A.Text = arr[5].ToString();

                             */
                        break;

                    case "B":

                        dgv.Rows[0].Cells[3].Value = arr[0].ToString();
                        dgv.Rows[1].Cells[3].Value = arr[1].ToString();
                        dgv.Rows[2].Cells[3].Value = arr[2].ToString();
                        dgv.Rows[3].Cells[3].Value = arr[3].ToString();
                        dgv.Rows[4].Cells[3].Value = arr[4].ToString();
                        dgv.Rows[5].Cells[3].Value = arr[5].ToString();
                        break;
                    case "C":
                        dgv.Rows[0].Cells[5].Value = arr[0].ToString();
                        dgv.Rows[1].Cells[5].Value = arr[1].ToString();
                        dgv.Rows[2].Cells[5].Value = arr[2].ToString();
                        dgv.Rows[3].Cells[5].Value = arr[3].ToString();
                        dgv.Rows[4].Cells[5].Value = arr[4].ToString();
                        dgv.Rows[5].Cells[5].Value = arr[5].ToString();
                        break;
                }
            }
            catch (Exception e)
            {
               LogMgr.Instance.Error($"显示气体值错误:{e.Message} 错误堆栈:{e.StackTrace}");
            }
         
        }

        private void Instance_OnWeldingFinished(string sn, int result,string msg="")
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_Welding, sn, result,msg);
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

        private void uiLabel8_Click(object sender, EventArgs e)
        {

        }

        private void lbl_1_B_Click(object sender, EventArgs e)
        {

        }
    }
}
