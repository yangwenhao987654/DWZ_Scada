using Sunny.UI;

namespace DWZ_Scada.Pages.StationPages.OP10
{
    partial class PageOP10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            this.PageOP10_FormClosing(this,null);
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            uiLabel1 = new UILabel();
            tbx_Part = new UITextBox();
            uiLabel2 = new UILabel();
            uiLabel4 = new UILabel();
            uiLabel3 = new UILabel();
            uiButton3 = new UIButton();
            lbl_EntrySN = new UILabel();
            lbl_Vision1Result = new UILabel();
            lbl_Vision2Result = new UILabel();
            uiSwitch_Spot = new UISwitch();
            uiLabel5 = new UILabel();
            cbx_Orders = new UIComboBox();
            uiButton4 = new UIButton();
            uiLabel9 = new UILabel();
            uiLabel6 = new UILabel();
            uiLabel7 = new UILabel();
            uiLabel8 = new UILabel();
            uiLabel11 = new UILabel();
            lbl_SN1 = new UILabel();
            lbl_SN2 = new UILabel();
            uiLabel10 = new UILabel();
            lbl_EntryResult = new UILabel();
            lbl_EntryMsg = new UILabel();
            lbl_WorkOrder = new UILabel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            uiPanel1 = new UIPanel();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 35);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1223, 59);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "OP10-上料打码工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // tbx_Part
            // 
            tbx_Part.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_Part.Location = new System.Drawing.Point(880, 121);
            tbx_Part.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_Part.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_Part.Name = "tbx_Part";
            tbx_Part.Padding = new System.Windows.Forms.Padding(5);
            tbx_Part.ShowText = false;
            tbx_Part.Size = new System.Drawing.Size(202, 36);
            tbx_Part.TabIndex = 3;
            tbx_Part.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_Part.Watermark = "扫码物料码";
            tbx_Part.TextChanged += uiTextBox1_TextChanged;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(30, 121);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(140, 35);
            uiLabel2.TabIndex = 4;
            uiLabel2.Text = "当前型号";
            uiLabel2.Click += uiLabel2_Click;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(733, 122);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(140, 42);
            uiLabel4.TabIndex = 6;
            uiLabel4.Text = "当前物料";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(30, 195);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(129, 35);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "当前工单";
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(164, 121);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(122, 42);
            uiButton3.TabIndex = 10;
            uiButton3.Text = "获取最新工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // lbl_EntrySN
            // 
            lbl_EntrySN.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntrySN.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntrySN.Location = new System.Drawing.Point(176, 287);
            lbl_EntrySN.Name = "lbl_EntrySN";
            lbl_EntrySN.Size = new System.Drawing.Size(220, 42);
            lbl_EntrySN.TabIndex = 11;
            // 
            // lbl_Vision1Result
            // 
            lbl_Vision1Result.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_Vision1Result.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_Vision1Result.Location = new System.Drawing.Point(251, 524);
            lbl_Vision1Result.Name = "lbl_Vision1Result";
            lbl_Vision1Result.Size = new System.Drawing.Size(220, 42);
            lbl_Vision1Result.TabIndex = 12;
            lbl_Vision1Result.Text = "...";
            // 
            // lbl_Vision2Result
            // 
            lbl_Vision2Result.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_Vision2Result.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_Vision2Result.Location = new System.Drawing.Point(826, 512);
            lbl_Vision2Result.Name = "lbl_Vision2Result";
            lbl_Vision2Result.Size = new System.Drawing.Size(220, 42);
            lbl_Vision2Result.TabIndex = 13;
            lbl_Vision2Result.Text = "...";
            // 
            // uiSwitch_Spot
            // 
            uiSwitch_Spot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSwitch_Spot.Location = new System.Drawing.Point(871, 174);
            uiSwitch_Spot.MinimumSize = new System.Drawing.Size(1, 1);
            uiSwitch_Spot.Name = "uiSwitch_Spot";
            uiSwitch_Spot.Size = new System.Drawing.Size(141, 73);
            uiSwitch_Spot.TabIndex = 16;
            uiSwitch_Spot.Text = "uiSwitch1";
            uiSwitch_Spot.ValueChanged += uiSwitch_Spot_ValueChanged;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new System.Drawing.Point(734, 195);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new System.Drawing.Size(131, 42);
            uiLabel5.TabIndex = 17;
            uiLabel5.Text = "点检模式:";
            // 
            // cbx_Orders
            // 
            cbx_Orders.DataSource = null;
            cbx_Orders.FillColor = System.Drawing.Color.White;
            cbx_Orders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cbx_Orders.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            cbx_Orders.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            cbx_Orders.Location = new System.Drawing.Point(322, 108);
            cbx_Orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbx_Orders.MinimumSize = new System.Drawing.Size(63, 0);
            cbx_Orders.Name = "cbx_Orders";
            cbx_Orders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            cbx_Orders.Size = new System.Drawing.Size(229, 67);
            cbx_Orders.SymbolSize = 24;
            cbx_Orders.TabIndex = 18;
            cbx_Orders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            cbx_Orders.Watermark = "获取Mes生产工单";
            cbx_Orders.SelectedIndexChanged += cbx_Orders_SelectedIndexChanged;
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(581, 121);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(122, 42);
            uiButton4.TabIndex = 19;
            uiButton4.Text = "切换工单";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click_1;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new System.Drawing.Point(30, 287);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new System.Drawing.Size(140, 42);
            uiLabel9.TabIndex = 20;
            uiLabel9.Text = "进站临时码:";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(630, 524);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(183, 42);
            uiLabel6.TabIndex = 24;
            uiLabel6.Text = "外观检测结果2:";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(35, 524);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(183, 42);
            uiLabel7.TabIndex = 23;
            uiLabel7.Text = "外观检测结果1:";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new System.Drawing.Point(35, 426);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new System.Drawing.Size(183, 42);
            uiLabel8.TabIndex = 25;
            uiLabel8.Text = "视觉1临时码:";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(631, 426);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(159, 42);
            uiLabel11.TabIndex = 26;
            uiLabel11.Text = "视觉2临时码:";
            // 
            // lbl_SN1
            // 
            lbl_SN1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_SN1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_SN1.Location = new System.Drawing.Point(240, 426);
            lbl_SN1.Name = "lbl_SN1";
            lbl_SN1.Size = new System.Drawing.Size(220, 42);
            lbl_SN1.TabIndex = 27;
            lbl_SN1.Text = "V1SN";
            // 
            // lbl_SN2
            // 
            lbl_SN2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_SN2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_SN2.Location = new System.Drawing.Point(826, 426);
            lbl_SN2.Name = "lbl_SN2";
            lbl_SN2.Size = new System.Drawing.Size(220, 42);
            lbl_SN2.TabIndex = 28;
            lbl_SN2.Text = "V2SN";
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel10.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel10.Location = new System.Drawing.Point(30, 339);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new System.Drawing.Size(140, 42);
            uiLabel10.TabIndex = 29;
            uiLabel10.Text = "进站结果:";
            // 
            // lbl_EntryResult
            // 
            lbl_EntryResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntryResult.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntryResult.Location = new System.Drawing.Point(176, 339);
            lbl_EntryResult.Name = "lbl_EntryResult";
            lbl_EntryResult.Size = new System.Drawing.Size(220, 42);
            lbl_EntryResult.TabIndex = 30;
            // 
            // lbl_EntryMsg
            // 
            lbl_EntryMsg.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntryMsg.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntryMsg.Location = new System.Drawing.Point(492, 278);
            lbl_EntryMsg.Name = "lbl_EntryMsg";
            lbl_EntryMsg.Size = new System.Drawing.Size(452, 94);
            lbl_EntryMsg.TabIndex = 31;
            lbl_EntryMsg.Text = "...";
            // 
            // lbl_WorkOrder
            // 
            lbl_WorkOrder.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_WorkOrder.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_WorkOrder.Location = new System.Drawing.Point(176, 195);
            lbl_WorkOrder.Name = "lbl_WorkOrder";
            lbl_WorkOrder.Size = new System.Drawing.Size(129, 35);
            lbl_WorkOrder.TabIndex = 32;
            lbl_WorkOrder.Text = "当前工单";
            // 
            // myLogCtrl1
            // 
            myLogCtrl1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            myLogCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myLogCtrl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            myLogCtrl1.FullRowSelect = true;
            myLogCtrl1.HideSelection = true;
            myLogCtrl1.LabelWrap = false;
            myLogCtrl1.Location = new System.Drawing.Point(0, 0);
            myLogCtrl1.MultiSelect = false;
            myLogCtrl1.Name = "myLogCtrl1";
            myLogCtrl1.Size = new System.Drawing.Size(1189, 348);
            myLogCtrl1.TabIndex = 33;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(myLogCtrl1);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(18, 620);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1189, 348);
            uiPanel1.TabIndex = 34;
            uiPanel1.Text = "uiPanel1";
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PageOP10
            // 
            AllowShowTitle = true;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1223, 1000);
            Controls.Add(uiPanel1);
            Controls.Add(lbl_WorkOrder);
            Controls.Add(lbl_EntryMsg);
            Controls.Add(lbl_EntryResult);
            Controls.Add(uiLabel10);
            Controls.Add(lbl_SN2);
            Controls.Add(lbl_SN1);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel8);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel7);
            Controls.Add(uiLabel9);
            Controls.Add(uiButton4);
            Controls.Add(cbx_Orders);
            Controls.Add(uiLabel5);
            Controls.Add(uiSwitch_Spot);
            Controls.Add(lbl_Vision2Result);
            Controls.Add(lbl_Vision1Result);
            Controls.Add(lbl_EntrySN);
            Controls.Add(uiButton3);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel2);
            Controls.Add(tbx_Part);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP10";
            Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "PageOP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            Initialize += PageOP10_Initialize;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox tbx_Part;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UILabel lbl_EntrySN;
        private UILabel lbl_Vision1Result;
        private Sunny.UI.UILabel lbl_Vision2Result;
        private Sunny.UI.UISwitch uiSwitch_Spot;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIComboBox cbx_Orders;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel lbl_SN1;
        private Sunny.UI.UILabel lbl_SN2;
        private UILabel uiLabel10;
        private UILabel lbl_EntryResult;
        private UILabel lbl_EntryMsg;
        private UILabel lbl_WorkOrder;
        private ctrls.MyLogCtrl myLogCtrl1;
        private UIPanel uiPanel1;
    }
}