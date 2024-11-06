using CommunicationUtilYwh.Communication;
using DIPTest.Ctrl;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.PLC;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using DWZ_Scada.UIUtil;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;
using UtilUIYwh;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    public partial class PageOP10 : UIPage
    {

        private readonly Action _clearAlarmDelegate;

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

            OP10MainFunc.CreateInstance(plcConfig);
            OP10MainFunc.Instance.StartAsync();

            //lbl_ExitSN.DataBindings.Add("Text", op10Model, "ExitSN");
            op10Model.ExitSN = "6666";
            //UpdateTempSN("6654");

            OP10MainFunc.OnVision1Finished += PageOP10_OnVision1Finished;

            OP10MainFunc.OnVision2Finished += PageOP10_OnVision2Finished;

            myLogCtrl1.BindingControl = uiPanel1;
            Mylog.Instance.Init(myLogCtrl1);
        }

        private void PageOP10_OnVision1Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(ctrlResult_V1, sn, result);
            //UpdateV1(sn, result);
        }

        private void PageOP10_OnVision2Finished(string sn, int result)
        {
            MyUIControler.UpdateTestStateCtrl(ctrlResult_V2, sn, result);
            //UpdateV2(sn, result);
        }

        public void UpdateV1(string sn, int result,string err="")
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, int,string>(UpdateV1), sn, result,err);
                return;
            }

            if (result == 0)
            {
                ctrlResult_V1.Start(sn);
            }
            if (result == 1)
            {
                ctrlResult_V1.Pass(sn);
            }
            if (result == 2)
            {
                ctrlResult_V1.Fail(sn,err);
            }
            //lbl_Vision1Result.Text = result ? "OK" : "NG";
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

        public void UpdateV2(string sn, int result,string err)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, int,string>(UpdateV2), sn, result,err);
                return;
            }

            if (result == 0)
            {
                ctrlResult_V2.Start(sn);
            }
            if (result == 1)
            {
                ctrlResult_V2.Pass(sn);
            }
            if (result == 2)
            {
                ctrlResult_V2.Fail(sn,err);
            }
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


        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void PageOP10_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            LogMgr.Instance.Info("关闭OP10-HttpServer");
            if (!OP10MainFunc.IsInstanceNull)
            {
                OP10MainFunc.Instance?.Dispose();
            }

            LogMgr.Instance.Info("关闭OP10程序");
        }



        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiSwitch_Spot_ValueChanged(object sender, bool isSpot)
        {
            if (isSpot)
            {
                Mylog.Instance.Debug("启动点检");
            }
            else
            {
                Mylog.Instance.Debug("关闭点检");
            }
            short value = 0;
            if (isSpot)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            OP10MainFunc.Instance.PLC.WriteInt16(OP10Address.SpotCheck, value);
            OP10MainFunc.Instance.IsSpotCheck = isSpot;
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
                    Mylog.Instance.Error("获取工单失败");
                }
            }
            cbx_Orders.DataSource = Orders;
            cbx_Orders.DisplayMember = nameof(OrderVo.WorkOrderCode);
        }

        private void uiButton4_Click_1(object sender, EventArgs e)
        {
            //TODO 切换工单之后切换料号
            OrderVo workOrder = cbx_Orders.SelectedItem as OrderVo;

            if (workOrder == null)
            {
                return;
            }
            //清空物料编码
            tbx_Part.Text = "";
            OP10MainFunc.Instance.CurMaterialSN = "";
            OP10MainFunc.Instance.CurMaterialNo = "";

            //设置选中工单
            lbl_WorkOrder.Text = workOrder.WorkOrderName + ":" + workOrder.WorkOrderCode;
            lbl_ProdNo.Text = workOrder.ProductName + ":" + workOrder.ProductCode;
            OP10MainFunc.Instance.CurWorkOrder = workOrder.WorkOrderCode;
            OP10MainFunc.Instance.CurProductCode = workOrder.ProductCode;

        }

        private void cbx_Orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据所选的工单 获取到产品型号
            //根据产品型号 获取到产品的Bom表

            //从Bom表里对比当前的物料号在Bom中是否存在 如果不存在 则不允许切换此型号
            //需要更换型号 或者更换物料 只有当前型号的产品和当前选择物料相对应才能切换型号
        }

        private void PageOP10_Initialize(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            /* if (tbx_Part.Text.EndsWith("\n"))
             {
                 string msg = tbx_Part.Text.Trim().Replace("\n", "");
                 UIMessageBox.ShowError($"输入[{msg}],长度[{msg.Length}]");
             }*/
        }

        private async void uiButton1_Click_2(object sender, EventArgs e)
        {
            ProductBomService bomService = Global.ServiceProvider.GetRequiredService<ProductBomService>();
            (bool flag, string msg, ProductDetailDto dto) = await bomService.GetBomList(OP10MainFunc.Instance.CurProductCode);
            if (!flag)
            {
                Mylog.Instance.Error("获取Bom失败:" + msg);
            }
        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {
            string msg = tbx_Part.Text;
        }

        private void tbx_Part_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                UIMessageBox.ShowError("按下回车");
                //这里是能捕捉到这个动作的

                //TODO 抛出一个输入完成事件
            }
        }

        private void tbx_Part_KeyDown(object sender, KeyEventArgs e)
        {
            /* if (e.KeyCode == Keys.Enter)
             {
                 UIMessageBox.ShowError("键盘按下回车");
             }*/
        }

        private void tbx_Part_Click(object sender, EventArgs e)
        {
            //TODO 点击输入框 自动切换输入法为英文
            //InputMethodSwitcher.Set_En_US_LanguageMode();

        }
    }
}
