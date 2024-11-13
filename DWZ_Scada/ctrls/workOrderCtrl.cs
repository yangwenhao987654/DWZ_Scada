using DWZ_Scada.HttpServices;
using DWZ_Scada.HttpServices.response;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.VO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class workOrderCtrl : UserControl
    {
        public int orderId;
        public List<OrderVo> Orders { get; set; }

        public string CurWorkOrderNo { get; set; } = string.Empty;

        public string CurProductCode { get; set; } = string.Empty;

        public string CurProductName { get; set; } = string.Empty;

        private bool _isCheckPass = false;

        private List<string> BomList { get; set; }
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
                    //ReflashStateColor(value);
                }
            }
        }

        ProductBomService ProductBomService = Global.ServiceProvider.GetRequiredService<ProductBomService>();

        private void ReflashStateColor(bool isOK)
        {
            if (InvokeRequired)
            {
                //使用方法引用
                this.Invoke(new Action<bool>(ReflashStateColor), isOK);
                return;
                /*   //使用Lambda表达式
                   this.Invoke(new Action(()=>
                   {
                       ReflashStateColor(isOK);
                   }));*/
                /*     this.Invoke(
                         new Action( ReflashStateColor),isOK
                     );*/
            }

            if (isOK)
            {
                userCtrlScanInput1.SetPassColor();
                // userCtrlScanInput1.BackColor =Color.Green;   
            }
            else
            {
                userCtrlScanInput1.SetErrColor();
                //userCtrlScanInput1.BackColor = Color.Red; 
            }
        }

        /// <summary>
        /// 当前物料编码
        /// </summary>
        public string CurPartNo { get; set; } = string.Empty;

        public workOrderCtrl()
        {
            InitializeComponent();
        }

        private async void GetWorkOrders()
        {
       /*     test();
            return;*/
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

        private void test()
        {
            //从Mes获取最新生产型号 
            //list
            //当前型号的物料Bom
            Orders = new List<OrderVo>();
            for(int a =0;a<5;a++)
            {
                OrderVo vo = new OrderVo();
                vo.WorkOrderCode = $"{orderId.ToString("D3")}-{a}";
                vo.WorkOrderName = $"{orderId}-{a}";
                vo.ProductCode = $"{a}";
                vo.ProductName = $"{a}";
                Orders.Add(vo);
            }

            orderId++;
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
                lbl_PartNo.Text = "";
                //记录当前的工单
                OrderVo orderVo = cbx_Orders.SelectedItem as OrderVo;
                if (orderVo == null)
                {
                    UIMessageBox.ShowError("获取工单信息为空");
                    return;
                }
                lbl_ProdModel.Text = orderVo.ProductCode;
                CurProductCode = orderVo.ProductCode;
                GetBomList(orderVo.ProductCode);

            }
        }

        private void workOrderCtrl_Load(object sender, EventArgs e)
        {
            userCtrlScanInput1.InputFinishEvent += UserCtrlScanInput1_InputFinishEvent;
        }

        private void UserCtrlScanInput1_InputFinishEvent(string msg)
        {
            IsCheckPass = false;
            if (msg == "")
            {
                return;
            }
            IsCheckPass = false;
            CurPartNo = msg;
            lbl_PartNo.Text = msg;
            //检查物料和工单的匹配关系
            if (CurProductCode == "")
            {
                UIMessageBox.ShowError("请先选择生产工单");
                return;
            }
            // "IF20241030002"
            IsCheckPass = CheckBomMatch(msg);
        }

        private bool CheckBomMatch(string itemCode)
        {
            if (BomList == null && !BomList.Any())
            {
                return false;
            }
            else
            {
                foreach (var bomCode in BomList)
                {
                    if (CheckBomSN(itemCode, bomCode))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private async void GetBomList(string itemCode)
        {
            (bool flag, string err, ProductDetailDto dto) = await ProductBomService.GetBomList(itemCode);
            if (flag)
            {
                if (dto != null)
                {
                    BomList = new List<string>();
                    foreach (ProductBomDTO bomDto in dto.ProductBomList)
                    {
                        BomList.Add(bomDto.BomItemCode);
                    }
                }
            }
            else
            {
                UIMessageBox.ShowError("查询产品Bom错误:" + err);
                LogMgr.Instance.Error("查询产品Bom错误:" + err);
            }
        }

        private async void GetBomList()
        {
            (bool flag, string err, ProductDetailDto dto) = await ProductBomService.GetBomList(CurProductCode);
            if (flag)
            {
                if (dto != null)
                {
                    LogMgr.Instance.Error("查询产品Bom 为null");
                    foreach (var item in dto.ProductBomList)
                    {
                        if (CheckBomSN(item.BomItemCode, CurPartNo))
                        {
                            LogMgr.Instance.Info("工单物料匹配成功");
                            IsCheckPass = true;
                            return;
                        }
                    }
                    return;
                }
            }
            else
            {
                UIMessageBox.ShowError("查询产品Bom错误:" + err);
                LogMgr.Instance.Error("查询产品Bom错误:" + err);
            }
        }

        private bool CheckBomSN(string inputSN, string bomItemCode)
        {
            return inputSN == bomItemCode;
        }

        private void userCtrlScanInput1_Load(object sender, EventArgs e)
        {

        }

        private void cbx_Orders_DropDown(object sender, EventArgs e)
        {
          /*  if (DesignMode)
            {
                UIMessageBox.ShowError("设计模式中");
                return;
            }
            cbx_Orders.SelectedIndexChanged -=cbx_Orders_SelectedIndexChanged;
            GetWorkOrders();
            cbx_Orders.SelectedIndexChanged += cbx_Orders_SelectedIndexChanged;*/
        }
    }
}
