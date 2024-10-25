using CommunicationUtilYwh.Communication;
using DIPTest;
using DWZ_Scada.dao.response;
using DWZ_Scada.HttpServices;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages;
using DWZ_Scada.Pages.StationPages.OP40;
using DWZ_Scada.Pages.StationPages.OP60;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;

namespace DWZ_Scada
{
    public partial class PageOP60 : UIPage
    {

        public List<OrderVo> Orders { get; set; }

        private static PageOP60 _instance;
        public static PageOP60 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP60))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP60();
                        }
                    }
                }
                return _instance;
            }
        }

        private PageOP60()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug($"打开{OP60MainFunc.StationName}工站");

            ISelectionStrategyEvent OP50Strategy = new OP50SelectionStrategy();
            OP50Strategy.OnSelectionEvent += OP50SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP60工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP60_PlcIP,
                SystemParams.Instance.OP60_PlcPort);

            OP60MainFunc.CreateInstance(plcConfig);
            OP60MainFunc.Instance.StartAsync();
        }

        private void OP50SelectionStrategy_OnSelectionEvent(object sender, SelectionEventArgs e)
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
            _instance = null;
            LogMgr.Instance.Info($"关闭{OP60MainFunc.StationCode}-HttpServer");
            OP60MainFunc.Instance?.Dispose();
            LogMgr.Instance.Info($"关闭{OP60MainFunc.StationName}程序");
        }

        private void uiSwitch_Spot_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                LogMgr.Instance.Info("启动点检");
            }
            else
            {
                LogMgr.Instance.Info("关闭点检");
            }
            OP60MainFunc.Instance.PLC.Write(OP60Address.SpotCheck, "bool", value);
            OP60MainFunc.Instance.IsSpotCheck = value;
        }

        /// <summary>
        /// AtlBrx调试界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Test_Click(object sender, EventArgs e)
        {
            AtlBrxTestForm from = new AtlBrxTestForm();
            from.ShowDialog();
        }

        private void userCtrlResult1_Load(object sender, EventArgs e)
        {

        }
    }
}
