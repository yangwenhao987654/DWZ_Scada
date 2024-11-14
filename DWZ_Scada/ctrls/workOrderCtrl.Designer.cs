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
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiPanel2 = new Sunny.UI.UIPanel();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            userCtrlScanInput1 = new DIPTest.Ctrl.userCtrlScanInput();
            uiButton3 = new Sunny.UI.UIButton();
            cbx_Orders = new Sunny.UI.UIComboBox();
            uiPanel3 = new Sunny.UI.UIPanel();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiSwitch_Spot = new Sunny.UI.UISwitch();
            uiLabel5 = new Sunny.UI.UILabel();
            lbl_ProdModel = new Sunny.UI.UILabel();
            lbl_PartNo = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiTableLayoutPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            uiPanel3.SuspendLayout();
            uiTableLayoutPanel3.SuspendLayout();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.Controls.Add(uiPanel2, 0, 0);
            uiTableLayoutPanel1.Controls.Add(uiPanel3, 1, 0);
            uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.Size = new System.Drawing.Size(1195, 125);
            uiTableLayoutPanel1.TabIndex = 31;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiPanel2
            // 
            uiPanel2.Controls.Add(uiTableLayoutPanel2);
            uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel2.Location = new System.Drawing.Point(0, 0);
            uiPanel2.Margin = new System.Windows.Forms.Padding(0);
            uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.RectColor = System.Drawing.Color.Transparent;
            uiPanel2.Size = new System.Drawing.Size(597, 125);
            uiPanel2.TabIndex = 0;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 2;
            uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4757118F));
            uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5242844F));
            uiTableLayoutPanel2.Controls.Add(userCtrlScanInput1, 0, 0);
            uiTableLayoutPanel2.Controls.Add(uiButton3, 0, 1);
            uiTableLayoutPanel2.Controls.Add(cbx_Orders, 1, 1);
            uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 2;
            uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel2.Size = new System.Drawing.Size(597, 125);
            uiTableLayoutPanel2.TabIndex = 30;
            uiTableLayoutPanel2.TagString = null;
            // 
            // userCtrlScanInput1
            // 
            userCtrlScanInput1.BackColor = System.Drawing.Color.IndianRed;
            uiTableLayoutPanel2.SetColumnSpan(userCtrlScanInput1, 2);
            userCtrlScanInput1.Dock = System.Windows.Forms.DockStyle.Fill;
            userCtrlScanInput1.Font = new System.Drawing.Font("微软雅黑", 9F);
            userCtrlScanInput1.IsForcedInput = false;
            userCtrlScanInput1.IsInputFinish = false;
            userCtrlScanInput1.Location = new System.Drawing.Point(3, 4);
            userCtrlScanInput1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            userCtrlScanInput1.Name = "userCtrlScanInput1";
            userCtrlScanInput1.Size = new System.Drawing.Size(591, 54);
            userCtrlScanInput1.TabIndex = 29;
            userCtrlScanInput1.TextFont = new System.Drawing.Font("微软雅黑", 15F);
            userCtrlScanInput1.TextMessage = "二维码:";
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(5, 67);
            uiButton3.Margin = new System.Windows.Forms.Padding(5, 5, 20, 5);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(145, 53);
            uiButton3.TabIndex = 27;
            uiButton3.Text = "获取最新工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // cbx_Orders
            // 
            cbx_Orders.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            cbx_Orders.DataSource = null;
            cbx_Orders.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbx_Orders.FillColor = System.Drawing.Color.White;
            cbx_Orders.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cbx_Orders.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            cbx_Orders.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            cbx_Orders.Location = new System.Drawing.Point(174, 67);
            cbx_Orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbx_Orders.MinimumSize = new System.Drawing.Size(63, 0);
            cbx_Orders.Name = "cbx_Orders";
            cbx_Orders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            cbx_Orders.Size = new System.Drawing.Size(273, 53);
            cbx_Orders.SymbolSize = 24;
            cbx_Orders.TabIndex = 28;
            cbx_Orders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            cbx_Orders.Watermark = "获取Mes生产工单";
            cbx_Orders.SelectedIndexChanged += cbx_Orders_SelectedIndexChanged;
            cbx_Orders.DropDown += cbx_Orders_DropDown_1;
            cbx_Orders.DropDownClosed += cbx_Orders_DropDownClosed;
            // 
            // uiPanel3
            // 
            uiPanel3.Controls.Add(uiTableLayoutPanel3);
            uiPanel3.Controls.Add(uiLabel1);
            uiPanel3.Controls.Add(uiLabel4);
            uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel3.Location = new System.Drawing.Point(597, 0);
            uiPanel3.Margin = new System.Windows.Forms.Padding(0);
            uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel3.Name = "uiPanel3";
            uiPanel3.RectColor = System.Drawing.Color.Transparent;
            uiPanel3.Size = new System.Drawing.Size(598, 125);
            uiPanel3.TabIndex = 1;
            uiPanel3.Text = null;
            uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 3;
            uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.7404919F));
            uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.25951F));
            uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            uiTableLayoutPanel3.Controls.Add(uiLabel3, 0, 1);
            uiTableLayoutPanel3.Controls.Add(uiLabel2, 0, 0);
            uiTableLayoutPanel3.Controls.Add(uiSwitch_Spot, 2, 1);
            uiTableLayoutPanel3.Controls.Add(uiLabel5, 2, 0);
            uiTableLayoutPanel3.Controls.Add(lbl_ProdModel, 1, 1);
            uiTableLayoutPanel3.Controls.Add(lbl_PartNo, 1, 0);
            uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 2;
            uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel3.Size = new System.Drawing.Size(598, 125);
            uiTableLayoutPanel3.TabIndex = 37;
            uiTableLayoutPanel3.TagString = null;
            // 
            // uiLabel3
            // 
            uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(3, 62);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(118, 63);
            uiLabel3.TabIndex = 38;
            uiLabel3.Text = "型号:";
            uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            uiLabel3.Click += uiLabel3_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(3, 0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(118, 62);
            uiLabel2.TabIndex = 37;
            uiLabel2.Text = "物料编码:";
            uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            uiLabel2.Click += uiLabel2_Click;
            // 
            // uiSwitch_Spot
            // 
            uiSwitch_Spot.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSwitch_Spot.Location = new System.Drawing.Point(450, 65);
            uiSwitch_Spot.MinimumSize = new System.Drawing.Size(1, 1);
            uiSwitch_Spot.Name = "uiSwitch_Spot";
            uiSwitch_Spot.Size = new System.Drawing.Size(104, 57);
            uiSwitch_Spot.TabIndex = 35;
            uiSwitch_Spot.Text = "uiSwitch1";
            uiSwitch_Spot.ValueChanged += uiSwitch_Spot_ValueChanged;
            // 
            // uiLabel5
            // 
            uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new System.Drawing.Point(450, 0);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new System.Drawing.Size(145, 62);
            uiLabel5.TabIndex = 36;
            uiLabel5.Text = "点检模式:";
            uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ProdModel
            // 
            lbl_ProdModel.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_ProdModel.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_ProdModel.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_ProdModel.Location = new System.Drawing.Point(127, 62);
            lbl_ProdModel.Name = "lbl_ProdModel";
            lbl_ProdModel.Size = new System.Drawing.Size(317, 63);
            lbl_ProdModel.TabIndex = 31;
            lbl_ProdModel.Text = "型号";
            lbl_ProdModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PartNo
            // 
            lbl_PartNo.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_PartNo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_PartNo.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_PartNo.Location = new System.Drawing.Point(127, 0);
            lbl_PartNo.Name = "lbl_PartNo";
            lbl_PartNo.Size = new System.Drawing.Size(317, 62);
            lbl_PartNo.TabIndex = 33;
            lbl_PartNo.Text = "物料编码";
            lbl_PartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(-107, 61);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(118, 35);
            uiLabel1.TabIndex = 34;
            uiLabel1.Text = "当前型号:";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(-107, 9);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(118, 36);
            uiLabel4.TabIndex = 32;
            uiLabel4.Text = "当前物料:";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiTableLayoutPanel1);
            uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel1.FillColor = System.Drawing.Color.Transparent;
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(0, 0);
            uiPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1195, 125);
            uiPanel1.TabIndex = 32;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workOrderCtrl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(uiPanel1);
            Name = "workOrderCtrl";
            Size = new System.Drawing.Size(1195, 125);
            Load += workOrderCtrl_Load;
            uiTableLayoutPanel1.ResumeLayout(false);
            uiPanel2.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            uiPanel3.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel4;
        private DIPTest.Ctrl.userCtrlScanInput userCtrlScanInput1;
        private Sunny.UI.UIComboBox cbx_Orders;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UISwitch uiSwitch_Spot;
        private Sunny.UI.UILabel lbl_ProdModel;
        private Sunny.UI.UILabel lbl_PartNo;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
    }
}
