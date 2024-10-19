using CommunicationUtilYwh.Communication;
using DWZ_Scada.dao.response;
using DWZ_Scada.HttpServices;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using LogTool;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public partial class PageOP10 : UIPage
    {

        /// <summary>
        /// 当前站名
        /// OP10
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP10";

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

        public class OrderVo
        {
            public string WorkOrderCode { get; set; }

            public string WorkOrderName { get; set; }

            public string ProductName { get; set; }

            public string ProductCode { get; set; }
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

            OP10MainFunc.CreateInstance( plcConfig);
            OP10MainFunc.Instance.StartAsync();

            //lbl_ExitSN.DataBindings.Add("Text", op10Model, "ExitSN");
            op10Model.ExitSN = "6666";
            //UpdateTempSN("6654");

            OP10MainFunc.OnVision1Finished += PageOP10_OnVision1Finished;

            OP10MainFunc.OnVision2Finished += PageOP10_OnVision2Finished;
        }

        private void PageOP10_OnVision1Finished(string sn, bool result)
        {
            UpdateV1(sn, result);
        }

        private void PageOP10_OnVision2Finished(string sn, bool result)
        {
            UpdateV2(sn, result);
        }

        public void UpdateV1(string sn, bool result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, bool>(UpdateV1), sn, result);
                return;
            }
            lbl_SN1.Text = sn;
            lbl_Vision1Result.Text = result ? "OK" : "NG";
        }

        public void UpdateEnrtySN(string sn)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateEnrtySN), sn);
                return;
            }
            lbl_EntrySN.Text = sn;

        }

        public void UpdateEnrtyResult(bool result, string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool, string>(UpdateEnrtyResult), result, msg);
                return;
            }
            lbl_EntryResult.Text = result ? "OK" : "NG";
            lbl_EntryMsg.Text = msg;
        }

        public void ClearEntryResult()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearEntryResult));
                return;
            }
            lbl_EntryResult.Text = "";
            lbl_EntryMsg.Text = "请求中.....";
        }

        public void UpdateV2(string sn, bool result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, bool>(UpdateV2), sn, result);
                return;
            }
            lbl_SN2.Text = sn;
            lbl_Vision2Result.Text = result ? "OK" : "NG";
        }

        public void UpdateTempSN(string newValue)
        {
            if (lbl_EntrySN.InvokeRequired)
            {
                lbl_EntrySN.Invoke(new Action<string>(UpdateTempSN), newValue);
                return;
            }
            else
            {
                lbl_EntrySN.Text = newValue;
            }
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

      

        public static void TestGetRequest<T>(string url)
        {
            string baseUrl = url;
            MyHttpClient client = new MyHttpClient(baseUrl);
            Task<RestResponse> task = client.GetAsync("");
            RestResponse response = task.Result;
            string res = response.Content;
            T dto = JsonConvert.DeserializeObject<T>(res);
            Console.WriteLine(dto.GetType());
            string jsonStr = JsonConvert.SerializeObject(dto);
            SelectionResultDTO result = JsonConvert.DeserializeObject<SelectionResultDTO>(res);
            Console.WriteLine(jsonStr);
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string sn = tbx_Part.Text;
            if (string.IsNullOrEmpty(sn))
            {
                sn = "24TT0001";
            }
            EntryCommand op10Entry = new OP10EntryCommand(sn);
            op10Entry.Execute();
        }

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            LogMgr.Instance.Info("关闭OP10-HttpServer");
            OP10MainFunc.Instance?.Dispose();
            LogMgr.Instance.Info("关闭OP10程序");
        }

        private async Task TestPassStationUpload()
        {
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = "OP10",
                SnTemp = "AQW12dswSAW",
                PassStationData = new PassStationData()
                {
                    Data = new Vision2Data() { Vision2Result = false },
                    Good = false,
                },
                isLastStep = true
            };
            UploadPassStationService service = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            service.SendPassStationData(dto);
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            //切换型号


        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //进入点检模式 生产数据跟正常数据分开
            OP10MainFunc.Instance.PLC.Write(OP10Address.SpotCheck, "bool", true);
            OP10MainFunc.Instance.IsSpotCheck = true;

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
            OP10MainFunc.Instance.PLC.Write(OP10Address.SpotCheck, "bool", value);
            OP10MainFunc.Instance.IsSpotCheck = value;
        }

        private async void uiButton3_Click(object sender, EventArgs e)
        {
            //从Mes获取最新生产型号 
            //list
            //当前型号的物料Bom
            Orders = new List<OrderVo>();
            //TODO 1.这段代码可以抽取出来复用
            WorkOrderService service = Global.ServiceProvider.GetRequiredService<WorkOrderService>();
            RestResponse response = await service.GetWorkOrder();
            if (response.IsSuccessful)
            {
                WorkOrderDTO orderDto = JsonConvert.DeserializeObject<WorkOrderDTO>(response.Content);
                if (orderDto.code == 200)
                {
                    //
                    LogMgr.Instance.Debug("获取工单成功");
                    List<DataItem> list = orderDto.data;
                    foreach (var item in list)
                    {
                        OrderVo vo = new OrderVo();
                        vo.WorkOrderCode = item.workorderCode;
                        vo.WorkOrderName = item.workorderName;
                        vo.ProductCode = item.productCode;
                        vo.ProductName = item.productName;
                        Orders.Add(vo);
                    }
                }
                else
                {
                    LogMgr.Instance.Error("获取工单失败");
                }
            }
            cbx_Orders.DataSource = Orders;
            cbx_Orders.DisplayMember = nameof(OrderVo.WorkOrderCode);
        }

        private void uiButton4_Click_1(object sender, EventArgs e)
        {
            //TODO 切换工单之后切换料号


        }

        private void cbx_Orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据所选的工单 获取到产品型号
            //根据产品型号 获取到产品的Bom表

            //从Bom表里对比当前的物料号在Bom中是否存在 如果不存在 则不允许切换此型号
            //需要更换型号 或者更换物料 只有当前型号的产品和当前选择物料相对应才能切换型号
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //切换物料 
            //输入物料后，需要确保当前物料 包含在当前正在生产的产品型号内 
            //根据当前产品型号获取物料Bom,从物料Bom中查询是否有这种物料 
            //如果没有，则不允许切换物料

        }

        private void PageOP10_Initialize(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
