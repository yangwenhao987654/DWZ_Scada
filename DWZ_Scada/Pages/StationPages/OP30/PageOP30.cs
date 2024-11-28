using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.PLC;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DWZ_Scada.Pages.StationPages.OP30
{
    public partial class PageOP30 : UIPage
    {
        public List<OrderVo> Orders { get; set; }

        private static PageOP30 _instance;
        public static PageOP30 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP30))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP30();
                        }
                    }
                }
                return _instance;
            }
        }

        private PageOP30()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            #region OP30工站
            PLCConfig op30Config = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP30_PlcIP,
                SystemParams.Instance.OP30_PlcPort);

            OP30MainFunc.CreateInstance(op30Config);
            OP30MainFunc.Instance.StartAsync();
            OP30MainFunc.Instance.OP30EntryStateChanged += Instance_OP30EntryStateChanged;
            OP30MainFunc.Instance.OP30VisionFinished += Instance_OP30VisionFinished;
            LogMgr.Instance.Debug($"打开{OP30MainFunc.Instance.StationCode}工站");
            #endregion

            myLogCtrl1.BindingControl = uiPanel2;
            Mylog.Instance.Init(myLogCtrl1);
        }

        private void Instance_OP30VisionFinished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(userCtrlResult_OP30, sn, result);
        }

        private void Instance_OP30EntryStateChanged(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry_OP30, sn, result, msg);
        }


        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void PageOP30_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OP30MainFunc.IsInstanceNull)
            {
                LogMgr.Instance.Info($"关闭{OP30MainFunc.Instance.StationCode}-HttpServer");
                LogMgr.Instance.Info($"关闭{OP30MainFunc.Instance.StationName}程序");
                OP30MainFunc.Instance.Dispose();
            }
            _instance = null;
        }
        private void PageOP30_Initialize(object sender, EventArgs e)
        {

        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
