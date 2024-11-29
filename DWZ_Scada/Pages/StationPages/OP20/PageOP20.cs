using DWZ_Scada.ctrls;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DWZ_Scada.Pages.StationPages.OP20
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
            ISelectionStrategyEvent op20Strategy = new OP20SelectionStrategy();
            op20Strategy.OnSelectionEvent += OP20SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP10工站 PLC配置


            #region 界面加载
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
                    ctrlSingle.IsEnable = SystemParams.Instance.OP20_WeldingEnableList[index - 1];
                    ctrlSingle.Index = index - 1;
                    ctrlSingle.WeldingTitle = $"绕线机{index++:D2}";
                    WindingCtrlList.Add(ctrlSingle);
                    ctrlSingle.Dock = DockStyle.Fill;
                    ctrlWindingS.Controls.Add(ctrlSingle, j, i);//TODO 这里会调用Load方法
                }
            }


            #endregion

            #region OP20工站逻辑

            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP20_PlcIP,
                SystemParams.Instance.OP20_PlcPort);

            OP20MainFunc.CreateInstance(plcConfig);
        
            OP20MainFunc.Instance.StartAsync();

            LogMgr.Instance.Debug($"打开{OP20MainFunc.Instance.StationName}工站");
            #endregion
            OP20MainFunc.Instance.OnWeldingStateChangedAction += Instance_OnWeldingStateChangedAction;
            OP20MainFunc.Instance.OnEntryStateChanged01 += Instance_OnEntryStateChanged01;
            OP20MainFunc.Instance.OnEntryStateChanged02 += Instance_OnEntryStateChanged02;

            OP20MainFunc.Instance.OnWeldingStart += Instance_OnWeldingStart;
        }

        private void Instance_OnWeldingStart(int index, string sn1, string sn2)
        {
            UpdateWeldingSn(index, sn1,sn2);
        }

        private void UpdateWeldingSn(int index, string sn1 ,string sn2)
        {
            /*   if (InvokeRequired)
               {
                   //TODO 关闭软件 这里报错 好几次了
                   this.Invoke(new Action(()=>UpdateWeldingStateLight(index, state)));
                   //this.Invoke(new Action<int, int>(UpdateWeldingStateLight), index, state);
                   return;
               }*/
            WindingCtrlList[index].SetSN(sn1,sn2);
        }

        private void Instance_OnEntryStateChanged02(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(op20CtrlEntry2,sn,result,msg);
        }

        private void Instance_OnEntryStateChanged01(string sn, int result, string msg = "")
        {
            MyUIControler.UpdateEntryStateCtrl(op20CtrlEntry1, sn, result, msg);
        }

        private void Instance_OnWeldingStateChangedAction(int index, int state)
        {
            UpdateWeldingStateLight(index, state);
        }
        private void UpdateWeldingStateLight(int index, int state)
        {
         /*   if (InvokeRequired)
            {
                //TODO 关闭软件 这里报错 好几次了
                this.Invoke(new Action(()=>UpdateWeldingStateLight(index, state)));
                //this.Invoke(new Action<int, int>(UpdateWeldingStateLight), index, state);
                return;
            }*/
            WindingCtrlList[index].UpdateState(state);
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

        private void PageOP20_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OP20MainFunc.IsInstanceNull)
            {
                LogMgr.Instance.Info($"关闭{OP20MainFunc.Instance.StationName}程序");
                LogMgr.Instance.Info($"关闭{OP20MainFunc.Instance.StationCode}-HttpServer");
                OP20MainFunc.Instance.Dispose();
            }
            _instance = null;
        }

        private void PageOP20_Initialize(object sender, EventArgs e)
        {
            // 先进入Load  再进入 Initialize 
        }

        private void workOrderCtrl1_Load(object sender, EventArgs e)
        {

        }
    }
}
