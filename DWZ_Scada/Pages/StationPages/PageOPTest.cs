using CommunicationUtilYwh.Communication;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.HttpServices;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.Pages.StationPages.OP20;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.Services;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;

namespace DWZ_Scada
{
    public partial class PageOPTest : UIPage
    {
        public HttpService MyHttpService;

        private static PageOPTest _instance;
        public static PageOPTest Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageOPTest))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageOPTest();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 当前站名
        /// OP10
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP10";

        private PageOPTest()
        {
            InitializeComponent();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug("打开测试工站");

            // Mes 选型服务  监控Mes选型消息
            TestHttp();
            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
       
           // OP10MainFunc.Instance.StartAsync();
        }

        private void PLCWorkMonitor()
        {
            
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
            LogMgr.Instance.Debug("启动OP10工站服务端...");
            StartServer();
            LogMgr.Instance.Debug("OP10工站服务端启动完成...");
            //HTTP客户端请求
            /*     Console.WriteLine("启动模拟客户端发送请求...");
                 string url = @"http://localhost:8090/test";
                 TestGetRequest<SelectionResultDTO>(url);*/
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
            LogMgr.Instance.Info("启动HttpServer");
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

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMgr.Instance.Info("关闭OP10-HttpServer");
            MyHttpService?.Stop();
            MyHttpService?.Dispose();
            OP20MainFunc.Instance?.Dispose();
            LogMgr.Instance.Info("关闭OP10程序");
        }

        private async void uiButton2_Click(object sender, EventArgs e)
        {
            LogMgr.Instance.Info("测试发送过站数据");
            await TestPassStationUpload();
            LogMgr.Instance.Info("测试过站数据上传完成");
        }

        private async Task TestPassStationUpload()
        {
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = "OP10",
                SnTemp = "24TT0001",
                // PassStationData = n
                PassStationData = new PassStationData()
                {

                },
                WorkOrder = "MO202409110002"
            };
            UploadPassStationService service = Global.ServiceProvider.GetRequiredService<UploadPassStationService>();
            await service.SendPassStationData(dto);
        }

        private async void uiButton3_Click(object sender, EventArgs e)
        {

            string SnTemp = "AQW12dswSAW";
            ProductBomService service = Global.ServiceProvider.GetRequiredService<ProductBomService>();
            await service.GetBomList(SnTemp);
            LogMgr.Instance.Info("测试请求BOM完成");
        }

        private async void uiButton4_Click(object sender, EventArgs e)
        {
            InspectService service = Global.ServiceProvider.GetRequiredService<InspectService>();
            DeviceInspectDTO dto = new DeviceInspectDTO()
            {
                DeviceCode = "OP10",
                DeviceName = "工站01",

            };
            await service.AddInspectDada(dto);
            LogMgr.Instance.Info("点检上报测试完成");
        }

        private async void uiButton5_Click(object sender, EventArgs e)
        {
            DeviceStateDTO dto = new DeviceStateDTO()
            {
                DeviceCode = "0001",
                DeviceName = "工站01",
                Status = "停机",
            };
            DeviceStateService stateService = Global.ServiceProvider.GetRequiredService<DeviceStateService>();
            await stateService.AddDeviceState(dto);
            LogMgr.Instance.Info("状态上报测试完成");
        }

        private async void uiButton6_Click(object sender, EventArgs e)
        {
            string tempCode = "00011001";
            await MyClient.GetFinalCode(tempCode);
            LogMgr.Instance.Info("测试请求最终码完成");
        }

        private async void uiButton7_Click(object sender, EventArgs e)
        {
            WorkOrderService service = Global.ServiceProvider.GetRequiredService<WorkOrderService>();
            await service.GetWorkOrder();
            LogMgr.Instance.Info("测试获取最新工单完成");
        }

        private async void uiButton8_Click(object sender, EventArgs e)
        {
            DamageableDTO dto = new DamageableDTO()
            {
                deviceCode = "OP10",
                code = "002",
                runNumber = 1,
                type = 1,
            };
            DamageableService service = Global.ServiceProvider.GetRequiredService<DamageableService>();
            await service.ReportDamageableAsync(dto);
            LogMgr.Instance.Info("测试上报易损易耗件完成");
        }
    }
}
