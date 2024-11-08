namespace DWZ_Scada.ctrls
{
    partial class workOrderCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            cbx_Orders = new Sunny.UI.UIComboBox();
            uiButton3 = new Sunny.UI.UIButton();
            uiLabel4 = new Sunny.UI.UILabel();
            lbl_ProdModel = new Sunny.UI.UILabel();
            userCtrlScanInput1 = new DIPTest.Ctrl.userCtrlScanInput();
            lbl_PartNo = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiSwitch_Spot = new Sunny.UI.UISwitch();
            SuspendLayout();
            // 
            // cbx_Orders
            // 
            cbx_Orders.DataSource = null;
            cbx_Orders.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbx_Orders.FillColor = System.Drawing.Color.White;
            cbx_Orders.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cbx_Orders.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            cbx_Orders.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            cbx_Orders.Location = new System.Drawing.Point(197, 70);
            cbx_Orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbx_Orders.MinimumSize = new System.Drawing.Size(63, 0);
            cbx_Orders.Name = "cbx_Orders";
            cbx_Orders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            cbx_Orders.Size = new System.Drawing.Size(229, 45);
            cbx_Orders.SymbolSize = 24;
            cbx_Orders.TabIndex = 24;
            cbx_Orders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            cbx_Orders.Watermark = "获取Mes生产工单";
            cbx_Orders.SelectedIndexChanged += cbx_Orders_SelectedIndexChanged;
            cbx_Orders.DropDown += cbx_Orders_DropDown;
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(21, 70);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(145, 42);
            uiButton3.TabIndex = 23;
            uiButton3.Text = "获取最新工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(663, 12);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(118, 36);
            uiLabel4.TabIndex = 22;
            uiLabel4.Text = "当前物料:";
            // 
            // lbl_ProdModel
            // 
            lbl_ProdModel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_ProdModel.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_ProdModel.Location = new System.Drawing.Point(789, 64);
            lbl_ProdModel.Name = "lbl_ProdModel";
            lbl_ProdModel.Size = new System.Drawing.Size(208, 35);
            lbl_ProdModel.TabIndex = 21;
            lbl_ProdModel.Text = "型号";
            // 
            // userCtrlScanInput1
            // 
            userCtrlScanInput1.BackColor = System.Drawing.Color.IndianRed;
            userCtrlScanInput1.Font = new System.Drawing.Font("微软雅黑", 9F);
            userCtrlScanInput1.IsInputFinish = false;
            userCtrlScanInput1.Location = new System.Drawing.Point(22, 13);
            userCtrlScanInput1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            userCtrlScanInput1.Name = "userCtrlScanInput1";
            userCtrlScanInput1.Size = new System.Drawing.Size(584, 51);
            userCtrlScanInput1.TabIndex = 26;
            userCtrlScanInput1.TextFont = new System.Drawing.Font("微软雅黑", 15F);
            userCtrlScanInput1.TextMessage = "二维码:";
            userCtrlScanInput1.Load += userCtrlScanInput1_Load;
            // 
            // lbl_PartNo
            // 
            lbl_PartNo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_PartNo.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_PartNo.Location = new System.Drawing.Point(787, 12);
            lbl_PartNo.Name = "lbl_PartNo";
            lbl_PartNo.Size = new System.Drawing.Size(210, 36);
            lbl_PartNo.TabIndex = 27;
            lbl_PartNo.Text = "物料编码";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(663, 64);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(118, 35);
            uiLabel1.TabIndex = 28;
            uiLabel1.Text = "当前型号:";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new System.Drawing.Point(1045, 12);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new System.Drawing.Size(131, 36);
            uiLabel5.TabIndex = 30;
            uiLabel5.Text = "点检模式:";
            // 
            // uiSwitch_Spot
            // 
            uiSwitch_Spot.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSwitch_Spot.Location = new System.Drawing.Point(1058, 64);
            uiSwitch_Spot.MinimumSize = new System.Drawing.Size(1, 1);
            uiSwitch_Spot.Name = "uiSwitch_Spot";
            uiSwitch_Spot.Size = new System.Drawing.Size(93, 36);
            uiSwitch_Spot.TabIndex = 29;
            uiSwitch_Spot.Text = "uiSwitch1";
            // 
            // workOrderCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(uiLabel5);
            Controls.Add(uiSwitch_Spot);
            Controls.Add(uiLabel1);
            Controls.Add(lbl_PartNo);
            Controls.Add(userCtrlScanInput1);
            Controls.Add(cbx_Orders);
            Controls.Add(uiButton3);
            Controls.Add(uiLabel4);
            Controls.Add(lbl_ProdModel);
            Name = "workOrderCtrl";
            Size = new System.Drawing.Size(1175, 122);
            Load += workOrderCtrl_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIComboBox cbx_Orders;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel lbl_ProdModel;
        private DIPTest.Ctrl.userCtrlScanInput userCtrlScanInput1;
        private Sunny.UI.UILabel lbl_PartNo;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UISwitch uiSwitch_Spot;
    }
}
