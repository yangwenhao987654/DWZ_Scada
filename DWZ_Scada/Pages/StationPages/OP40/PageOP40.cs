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

namespace DWZ_Scada.Pages.StationPages.OP40
{
    public partial class PageOP40 : UIPage
    {

        public HttpService MyHttpService;

        /// <summary>
        /// 当前站名
        /// OP40
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP40";

        public List<OrderVo> Orders { get; set; }

        /// <summary>
        /// 数据模型
        /// </summary>
        public OP40Model Model;

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

        public class OrderVo
        {
            public string WorkOrderCode { get; set; }

            public string WorkOrderName { get; set; }

            public string ProductName { get; set; }

            public string ProductCode { get; set; }
        }

        private PageOP40()
        {
            InitializeComponent();
            _instance = this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug($"打开{CURRENT_STATION_NAME}工站");

            // Mes 选型服务  监控Mes选型消息
            TestHttp();
            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
            PlcAlarmLoader.Load();
            //OP10工站 PLC配置
            PLCConfig plcConfig = new PLCConfig(MyPLCType.KeynecePLC, SystemParams.Instance.OP40_PlcIP,
                SystemParams.Instance.OP40_PlcPort);

            //TODO 这里导致程序卡顿
            MainFuncBase.RegisterFactory(() => new OP40MainFunc(plcConfig));
            MainFuncBase.Instance.StartAsync();


            /*  lbl_EntrySN.DataBindings.Add("Text", Model, "TempSN");
              Model.TempSN = "6666";*/
            UpdateTempSN("6654");
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

        public void TestHttp()
        {
            LogMgr.Instance.Debug($"启动{CURRENT_STATION_NAME}工站服务端...");
            StartServer();
            LogMgr.Instance.Debug($"{CURRENT_STATION_NAME}工站服务端启动完成...");
            //HTTP客户端请求
            /*     
                 Console.WriteLine("启动模拟客户端发送请求...");
                 string url = @"http://localhost:8090/test";
                 TestGetRequest<SelectionResultDTO>(url);
            */
        }

        public void StartServer()
        {
            MyHttpService = new HttpService();
            MyHttpService.Setup(new TouchSocketConfig()
               .SetListenIPHosts(8090)
            /*   .ConfigureContainer(a =>
               {
                   a.AddConsoleLogger();
               })*/
               .ConfigurePlugins(a =>
               {
                   a.Add<SelectionHttpPlug>();
                   a.Add<ConsumablePartsHttpPlug>();
                   a.UseDefaultHttpServicePlugin();
               })
           );
            MyHttpService.Start();
            LogMgr.Instance.Info($"启动{CURRENT_STATION_NAME}-HttpServer");
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
            string sn = uiTextBox1.Text;
            if (string.IsNullOrEmpty(sn))
            {
                sn = "24TT0001";
            }
            EntryCommand op10Entry = new OP10EntryCommand(sn);
            op10Entry.Execute();
        }

        private void PageOP40_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMgr.Instance.Info($"关闭{CURRENT_STATION_NAME}-HttpServer");
            MyHttpService?.Stop();
            MyHttpService?.Dispose();
            OP40MainFunc.Instance?.Dispose();
            LogMgr.Instance.Info($"关闭{CURRENT_STATION_NAME}程序");
        }

        private async Task TestPassStationUpload()
        {
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = CURRENT_STATION_NAME,
                SnTemp = "AQW12dswSAW",
                // PassStationData = n
                PassStationData = new PassStationData()
                {
                    /*       Material = "物料信息AAA",
                           VisionData1 = "4dwadwa",
                           VisionData2 = "sw23435",
                           VisionPicPath = "D:\\test",
                           VisionResult = "OK"*/
                }
            };
            UploadPassStationService service = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            service.SendPassStationData(dto);
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {


        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //进入点检模式 生产数据跟正常数据分开
            OP40MainFunc.Instance.PLC.Write(OP40Address.SpotCheck, "bool", true);
            OP40MainFunc.Instance.IsSpotCheck = true;

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
            OP40MainFunc.Instance.PLC.Write(OP40Address.SpotCheck, "bool", value);
            OP40MainFunc.Instance.IsSpotCheck = value;
        }

        private async void uiButton3_Click(object sender, EventArgs e)
        {
            //从Mes获取最新生产型号 
            //list
            //当前型号的物料Bom
            Orders = new List<OrderVo>();
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
    }
}
