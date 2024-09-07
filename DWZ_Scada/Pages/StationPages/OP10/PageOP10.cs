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
using AutoStation;

namespace DWZ_Scada
{
    public partial class PageOP10 : UIPage
    {
        public HttpService MyHttpService;

        /// <summary>
        /// 当前站名
        /// OP10
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP10";

        /// <summary>
        /// 数据模型
        /// </summary>
        public OP10Model op10Model;

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

        public PageOP10()
        {
            InitializeComponent();
            _instance =this;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug("打开OP10工站");

            // Mes 选型服务  监控Mes选型消息
            TestHttp();
            ISelectionStrategyEvent op10Strategy = new OP10SelectionStrategy();
            op10Strategy.OnSelectionEvent += OP10SelectionStrategy_OnSelectionEvent;
            op10Model = new OP10Model();
            OP10MainFunc.Instance.Start(op10Model);
            /*  lbl_EntrySN.DataBindings.Add("Text", op10Model, "TempSN");
              op10Model.TempSN = "6666";*/
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
            LogMgr.Instance.Debug("启动OP10工站服务端...");
            StartServer();
            LogMgr.Instance.Debug("OP10工站服务端启动完成...");
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

        private async Task TestPassStationUpload()
        {
            PassStationDTO dto = new PassStationDTO()
            {
                StationCode = "OP10",
                SnTemp = "AQW12dswSAW",
                // PassStationData = n
                PassStationData = new OP10Data()
                {
                    Material = "物料信息AAA",
                    VisionData1 = "4dwadwa",
                    VisionData2 = "sw23435",
                    VisionPicPath = "D:\\test",
                    VisionResult = "OK"
                }
            };
            await MyClient.PassStationUploadTest(dto);
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            //从Mes获取最新生产型号 
            //list
            //当前型号的物料Bom

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //进入点检模式 生产数据跟正常数据分开
            OP10MainFunc.PLC.Write(OP10Address.SpotCheck, "bool", true);

            
        }
    }
}
