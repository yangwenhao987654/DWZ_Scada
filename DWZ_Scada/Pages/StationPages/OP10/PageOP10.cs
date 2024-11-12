using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.Pages.PLCAlarm;
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

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public partial class PageOP10 : UIPage
    {

        private readonly Action _clearAlarmDelegate;

        public List<OrderVo> Orders { get; set; }

        /// <summary>
        /// 数据模型
        /// </summary>
        public OP10Model op10Model = new OP10Model();

        private static PageOP10 _instance;
        public static PageOP10 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP10))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP10();
                        }
                    }
                }
                return _instance;
            }
        }

        private PageOP10()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug("打开OP10工站");

            // Mes 选型服务  监控Mes选型消息

            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP10工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP10_PlcIP,
                SystemParams.Instance.OP10_PlcPort);

            OP10MainFunc.CreateInstance(plcConfig);
            OP10MainFunc.Instance.StartAsync();

            OP10MainFunc.Instance.OnVision1Finished += PageOP10_OnVision1Finished;

            OP10MainFunc.Instance.OnVision2Finished += PageOP10_OnVision2Finished;

            OP10MainFunc.Instance.OnEntryStateChanged += Instance_OnEntryStateChanged;

            myLogCtrl1.BindingControl = uiPanel1;
            Mylog.Instance.Init(myLogCtrl1);
        }

        private void Instance_OnEntryStateChanged(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry1,sn,result,msg);
        }

        private void PageOP10_OnVision1Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(ctrlResult_V1, sn, result);
        }

        private void PageOP10_OnVision2Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(ctrlResult_V2, sn, result);
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

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMgr.Instance.Info("关闭OP10-HttpServer");
            if (!OP10MainFunc.IsInstanceNull)
            {
                OP10MainFunc.Instance?.Dispose();
            }
            LogMgr.Instance.Info("关闭OP10程序");
            _instance = null;
            //调用 Close() 方法,先进入  FormClosing 事件 ，之后再调用Designer类的Dispose
        }
    }
}
