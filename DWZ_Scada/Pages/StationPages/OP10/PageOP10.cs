using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWZ_Scada;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;
using CommunicationUtilYwh.Communication;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.ProcessControl.RequestModel;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using Method = RestSharp.Method;
using DWZ_Scada.Pages;

namespace DWZ_Scada
{
    public partial class PageOP10 : UIPage
    {
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

        public HttpService MyHttpService;

        /// <summary>
        /// 当前站名
        /// OP10
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP10";

        public PageOP10()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug("打开OP10工站");

            // Mes 选型服务  监控Mes选型消息
            TestHttp();
            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
       
            OP10MainFunc.Instance.Start();
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

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogMgr.Instance.Info("关闭OP10-HttpServer");
            MyHttpService?.Stop();
            MyHttpService?.Dispose();
            OP10MainFunc.Instance?.Dispose();
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
            await MyClient.PassStationUploadTest();
        }

        private async void uiButton3_Click(object sender, EventArgs e)
        {
            string itemCode = "A0001WED";
            await MyClient.GetBomList(itemCode);
            LogMgr.Instance.Info("测试请求BOM完成");
        }

        private async void uiButton4_Click(object sender, EventArgs e)
        {
            await MyClient.AddInspectDada();
            LogMgr.Instance.Info("点检上报测试完成");
        }

        private async void uiButton5_Click(object sender, EventArgs e)
        {
            await MyClient.AddDeviceState();
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
            await MyClient.GetWorkOrder();
            LogMgr.Instance.Info("测试获取最新工单完成");
        }

        private async void uiButton8_Click(object sender, EventArgs e)
        {
            await MyClient.ReportDamageable();
            LogMgr.Instance.Info("测试上报易损易耗件完成");
        }
    }
}
