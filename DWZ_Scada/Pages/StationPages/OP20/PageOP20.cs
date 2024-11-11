using DIPTest;
using DWZ_Scada.ctrls;
using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP20;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DWZ_Scada
{
    public partial class PageOP20 : UIPage
    {
        public List<OrderVo> Orders { get; set; }

        private static PageOP20 _instance;
        public static PageOP20 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOP20))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOP20();
                        }
                    }
                }
                return _instance;
            }
        }

      
        public List<windingCtrl> WindingCtrlList = new List<windingCtrl>();

        private PageOP20()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug($"打开{OP20MainFunc.StationName}工站");

            ISelectionStrategyEvent op20Strategy = new OP20SelectionStrategy();
            op20Strategy.OnSelectionEvent += OP20SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP10工站 PLC配置

            #region OP20工站

            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP20_PlcIP,
                SystemParams.Instance.OP20_PlcPort);

            OP20MainFunc.CreateInstance(plcConfig);
            OP20MainFunc.Instance.OnWeldingStateChangedAction += Instance_OnWeldingStateChangedAction;
            OP20MainFunc.Instance.StartAsync();

       

            #endregion

            #region OP30工站
            PLCConfig op30Config = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP30_PlcIP,
                SystemParams.Instance.OP30_PlcPort);

            OP30MainFunc.CreateInstance(op30Config);
            OP30MainFunc.Instance.StartAsync();
            OP30MainFunc.Instance.OP30EntryStateChanged += Instance_OP30EntryStateChanged;
            OP30MainFunc.Instance.OP30VisionFinished += Instance_OP30VisionFinished;

            #endregion

            int index = 1;
            for (int i = 0; i < ctrlWindingS.RowCount; i++)
            {
                for (int j = 0; j < ctrlWindingS.ColumnCount; j++)
                {
                   /* if (i==2 && j>=2)
                    {
                        break;
                    }*/
                    windingCtrl ctrlSingle = new windingCtrl();
                    ctrlSingle.WeldingTitle = $"绕线机{index++:D2}";
                    WindingCtrlList.Add(ctrlSingle);
                    ctrlSingle.Dock = DockStyle.Fill;
                    ctrlWindingS.Controls.Add(ctrlSingle, j,i);//TODO 这里会调用Load方法
                }
            }
        }

        private void Instance_OnWeldingStateChangedAction(int index, int state)
        {
            UpdateWeldingStateLight(index, state);
        }
        private void UpdateWeldingStateLight(int index, int state)
        {
            if (InvokeRequired)
            {
                //this.Invoke(new Action(()=>UpdateWeldingStateLight(index, state)));
                this.Invoke(new Action<int, int>(UpdateWeldingStateLight), index, state);
            }
            WindingCtrlList[index].UpdateState(state);
        }


        private void Instance_OP30VisionFinished(string sn, int result)
        {
           MyUIControler.UpdateTestStateCtrl(userCtrlResult_OP30,sn,result);
        }

        private void Instance_OP30EntryStateChanged(string sn, int result,string msg="")
        {
            MyUIControler.UpdateEntryStateCtrl(userCtrlEntry_OP30,sn,result,msg);
        }

        private void OP20SelectionStrategy_OnSelectionEvent(object sender, SelectionEventArgs e)
        {
            LogMgr.Instance.Info("触发选型");
            LogMgr.Instance.Info($"下发型号[{e.Model}]");
            SelectionResultDTO dto = e.SelectionResult;
            dto.Message = $"处理选型[{e.Model}]完成";
            dto.Code = 1;

            LogMgr.Instance.Info("选型结束");
        }


        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            LogMgr.Instance.Info($"关闭{OP20MainFunc.StationCode}-HttpServer");
            if (!OP20MainFunc.IsInstanceNull)
            {
                OP20MainFunc.Instance.Dispose();
            }
            if (!OP30MainFunc.IsInstanceNull)
            {
                OP30MainFunc.Instance.Dispose();
            }
            LogMgr.Instance.Info($"关闭{OP20MainFunc.StationName}程序");
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            
        }

        private void PageOP20_Initialize(object sender, EventArgs e)
        {

        }
    }
}
