using DWZ_Scada.Forms;
using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.Pages.StationPages;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using ScadaBase.DAL.BLL;
using ScadaBase.DAL.DAL;
using ScadaBase.DAL.Entity;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class workOrderCtrlWithoutPart : UserControl
    {
        public int orderId;
        public List<OrderVo> Orders { get; set; }

        public string CurWorkOrderNo { get; set; } = string.Empty;

        public string CurProductCode { get; set; } = string.Empty;

        public string CurProductName { get; set; } = string.Empty;

        private bool _isCheckPass = false;


        public bool SpotEnable
        {
            get
            {
                return uiSwitch_Spot.Enabled;
            }
            set
            {
                ChangeSpotEnableState(value);
            }
        }

        private void ChangeSpotEnableState(bool value)
        {
            if (InvokeRequired)
            {
                uiSwitch_Spot.Invoke(new Action<bool>(ChangeSpotEnableState), value);
                return;
            }
            uiSwitch_Spot.Enabled = value;
        }

        private List<string> BomList { get; set; } = new List<string>();
        public event Action<bool> CheckStateChanged;

        /// <summary>
        /// 选中料号切换改变事件
        /// </summary>
        public static event Action<int> ONSelectProductNoChanged;

        /// <summary>
        /// 点检状态
        /// </summary>
        public static event Func<bool, bool> SpotStateChanged;


        private IProductFormulaDAL _productFormulaDAL;

        public bool IsCheckPass
        {
            get
            {
                return _isCheckPass;
            }
            set
            {
                if (value != _isCheckPass)
                {
                    _isCheckPass = value;
                    CheckStateChanged?.Invoke(value);
                    Global.IsWorkNoCheckPass = value;
                }
            }
        }

      

        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string CurPartNo { get; set; } = string.Empty;

        public workOrderCtrlWithoutPart()
        {
            InitializeComponent();
            SpotEnable = false;
            MainFuncBase.PlcStateChanged += MainFuncBase_PlcStateChanged;

            IsCheckPass = true;
        }

        private void MainFuncBase_PlcStateChanged(bool flag)
        {
            SpotEnable = flag;
        }

        private async void GetWorkOrders()
        {
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


        private async void uiButton3_Click(object sender, EventArgs e)
        {
            GetWorkOrders();
        }


        private void cbx_Orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选完工单后 记录当前选择的工单信息 工单号等 
            //清空当前物料
            if (cbx_Orders.SelectedIndex != -1)
            {
                CurPartNo = "";
                //记录当前的工单
                OrderVo orderVo = cbx_Orders.SelectedItem as OrderVo;
                if (orderVo == null)
                {
                    UIMessageBox.ShowError("获取工单信息为空");
                    return;
                }
                lbl_ProdModel.Text = orderVo.ProductCode;
                CurProductCode = orderVo.ProductCode;
                IsCheckPass = true;
                Global.WorkOrder = orderVo.WorkOrderCode;
            }
        }

        private void workOrderCtrl_Load(object sender, EventArgs e)
        {
           
        }


        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (IsCheckPass)
            {
                //TODO 下发给PLC型号
                //1. 获取到当前的型号Code
                if (CurProductCode=="")
                {
                    UIMessageBox.ShowError("当前型号为空");
                    return;
                }

                ProductFormulaEntity row = _productFormulaDAL.SelectSingleByProdCode(CurProductCode);
                if (row != null)
                {
                    int plcNo = row.ProductPLCNo;
                    ONSelectProductNoChanged?.Invoke(plcNo);
                }
                else
                {
                    UIMessageBox.ShowError($"查询产品配方失败 产品Code:[{CurProductCode}]，请先添加配方");
                }
                //2.根据型号Code查询配方表，获取到PLC对应型号
                //3.写地址给PLC
            }
            else
            {
                UIMessageBox.ShowError("物料匹配失败 ，禁止切换型号");
            }
        }
    }
}
