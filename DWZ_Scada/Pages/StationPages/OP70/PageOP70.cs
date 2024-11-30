using DIPTest;
using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP70;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DWZ_Scada
{
    public partial class PageOP70 : UIPage
    {
        public List<OrderVo> Orders { get; set; }

        private static PageOP70 _instance;
        public static PageOP70 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP70))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP70();
                        }
                    }
                }
                return _instance;
            }
        }

        private PageOP70()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);


            ISelectionStrategyEvent OP60Strategy = new OP70SelectionStrategy();
            OP60Strategy.OnSelectionEvent += OP70SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP70工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP70_PlcIP,
                SystemParams.Instance.OP70_PlcPort);

            OP70MainFunc.CreateInstance(plcConfig);
            OP70MainFunc.Instance.StartAsync();
            LogMgr.Instance.Debug($"打开{OP70MainFunc.Instance.StationName}工站");
            OP70MainFunc.Instance.OnVision1Finished += Instance_OnVision1Finished;
            OP70MainFunc.Instance.OP70EntryStateChanged += Instance_OP70EntryStateChanged;
            OP70MainFunc.Instance.OP70FinalCodeFinished += Instance_OP70FinalCodeFinished;
        }

        private void Instance_OP70FinalCodeFinished(string finalcode, string codeType, bool result)
        {
            UpdateFinalcodeUI(finalcode, codeType, result);
        }

        private void UpdateFinalcodeUI(string finalcode, string codeType, bool result)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, string, bool>(UpdateFinalcodeUI),
                    finalcode, codeType, result);
                return;
            }
            if (result)
            {
                lbl_CodeResult.Text = "OK";
                lbl_CodeResult.ForeColor = Color.Green;
            }
            else
            {
                lbl_CodeResult.Text = "NG";
                lbl_CodeResult.ForeColor = Color.Red;
            }
            lbl_FinalCode.Text = finalcode;
            lbl_grade.Text = finalcode;
        }

        private void Instance_OP70EntryStateChanged(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry1, sn, result, msg);
        }

        private void Instance_OnVision1Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlVisionResult, sn, result);
        }

        private void OP70SelectionStrategy_OnSelectionEvent(object sender, SelectionEventArgs e)
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

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OP70MainFunc.IsInstanceNull)
            {
                LogMgr.Instance.Info($"关闭{OP70MainFunc.Instance.StationCode}-HttpServer");
                LogMgr.Instance.Info($"关闭{OP70MainFunc.Instance.StationName}程序");
                OP70MainFunc.Instance?.Dispose();
            }
            _instance = null;
        }

        private void uiLabel10_Click(object sender, EventArgs e)
        {

        }

        private void PageOP70_Initialize(object sender, EventArgs e)
        {

        }

        private void workOrderCtrlWithoutPart1_Load(object sender, EventArgs e)
        {

        }
    }
}
