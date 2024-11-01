using DIPTest.Ctrl;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP60;
using DWZ_Scada.Pages.StationPages.OP70;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.VO;
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DWZ_Scada
{

    public partial class PageOP60 : UIPage
    {
        // 定义一个新的事件参数类，包含SelectionResultDTO和string类型的属性
        public class DeviceStateEventArgs : EventArgs
        {
            public int DeviceId { get; }
            public bool isConnect { get; }
             
            public DeviceStateEventArgs(int id, bool isConnect)
            {
                DeviceId = id;
                this.isConnect = isConnect;
            }
        }
        public event EventHandler<DeviceStateEventArgs> OnDeviceStateChangedEvent;

        // 定义一个字典，将ID映射到对应的UI控件
        private Dictionary<int, UILight> lightMap= new Dictionary<int, UILight>();


        // 定义一个字典，将ID映射到对应的UI控件
        private Dictionary<int, UserCtrlResult> ctrlResultMap = new Dictionary<int, UserCtrlResult>();
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
            lightMap.Add(1, uiLight1);
            lightMap.Add(2, uiLight2);
            lightMap.Add(3, uiLight3);
            lightMap.Add(4, uiLight4);

            ctrlResultMap.Add(1,userCtrlResult1);
            ctrlResultMap.Add(2, userCtrlResult2);
            ctrlResultMap.Add(3, userCtrlResult3);
            ctrlResultMap.Add(4, userCtrlResult4);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug($"打开{OP60MainFunc.StationName}工站");

            ISelectionStrategyEvent op60SelectionStrategy = new OP60SelectionStrategy();
            op60SelectionStrategy.OnSelectionEvent += OP60SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP60工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP60_PlcIP,
                SystemParams.Instance.OP60_PlcPort);

            OP60MainFunc.CreateInstance(plcConfig);
            OP60MainFunc.Instance.StartAsync();

            Mylog.Instance.Init(myLogCtrl1);
            OnDeviceStateChangedEvent += PageOP60_OnDeviceStateChangedEvent;
        }
        // 方法用于触发事件
        public void TriggerDeviceStateChanged(int id,bool isConnect)
        {
            OnDeviceStateChangedEvent?.Invoke(this, new DeviceStateEventArgs(id,isConnect));
        }

        private void PageOP60_OnDeviceStateChangedEvent(object sender, DeviceStateEventArgs e)
        {
            updateDeviceStateLight(e.DeviceId, e.isConnect);
        }

        private void updateDeviceStateLight(int id, bool isConnect)
        {
            if (lightMap.TryGetValue(id, out var light))
            {
                light.Invoke(new Action(() =>
                {
                    light.OnColor = isConnect ? Color.LawnGreen : Color.DimGray;
                }));
            }
        }

        private void OP60SelectionStrategy_OnSelectionEvent(object sender, SelectionEventArgs e)
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
            if (!OP60MainFunc.IsInstanceNull)
            {
                OP60MainFunc.Instance?.Dispose();
            }
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

        public void StartTestUI(int pos ,string sn)
        {
            if(ctrlResultMap.TryGetValue(pos, out  var ctrl))
            {
                ctrl.Start(sn);
            }
        }

        public void TestPassUI(int pos,string sn)
        {
            if (ctrlResultMap.TryGetValue(pos, out var ctrl))
            {
                ctrl.Pass(sn);
            }
        }

        public void TestFailUI(int pos,string sn)
        {
            if (ctrlResultMap.TryGetValue(pos, out var ctrl))
            {
                ctrl.Fail(sn);
            }
        }
    }
}
