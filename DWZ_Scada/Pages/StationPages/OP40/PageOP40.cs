using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
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
        }

        private void Instance_OnWeldingFinished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_Welding,sn,result);
        }

        private void Instance_OnVision1Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_Vision, sn, result);
        }

        private void Instance_OP40EntryStateChanged(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry_OP40,sn, result, msg);
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
            _instance = null;
            LogMgr.Instance.Info($"关闭OP40-HttpServer");
            if (OP40MainFunc.IsInstanceNull)
            {
                OP40MainFunc.Instance?.Dispose();
            }
            LogMgr.Instance.Info($"关闭OP40程序");
        }
    }
}
