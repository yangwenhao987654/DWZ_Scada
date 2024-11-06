namespace DWZ_Scada
{
    partial class PageOP70
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

            PageOP10_FormClosing(this, null);
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uiLabel1 = new Sunny.UI.UILabel();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiButton3 = new Sunny.UI.UIButton();
            uiSwitch_Spot = new Sunny.UI.UISwitch();
            uiLabel5 = new Sunny.UI.UILabel();
            cbx_Orders = new Sunny.UI.UIComboBox();
            uiButton4 = new Sunny.UI.UIButton();
            tbxTest = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            userCtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            userCtrlVisionResult = new DIPTest.Ctrl.UserCtrlResult();
            uiLabel11 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            lbl_FinalCode = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            lbl_grade = new Sunny.UI.UILabel();
            lbl_CodeResult = new Sunny.UI.UILabel();
            uiLabel10 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1280, 59);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "OP70-出料打码工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox1.Location = new System.Drawing.Point(656, 63);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(202, 36);
            uiTextBox1.TabIndex = 3;
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "扫码物料码";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(3, 62);
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
            uiLabel4.Location = new System.Drawing.Point(290, 61);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(140, 42);
            uiLabel4.TabIndex = 6;
            uiLabel4.Text = "当前物料";
            // 
            // uiButton1
            // 
            uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(135, 61);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(122, 42);
            uiButton1.TabIndex = 7;
            uiButton1.Text = "切换型号";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click_1;
            // 
            // uiButton2
            // 
            uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Location = new System.Drawing.Point(464, 61);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new System.Drawing.Size(122, 42);
            uiButton2.TabIndex = 8;
            uiButton2.Text = "切换物料";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(4, 122);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(129, 35);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "当前工单";
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(135, 115);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(122, 42);
            uiButton3.TabIndex = 10;
            uiButton3.Text = "获取最新工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiSwitch_Spot
            // 
            uiSwitch_Spot.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSwitch_Spot.Location = new System.Drawing.Point(847, 114);
            uiSwitch_Spot.MinimumSize = new System.Drawing.Size(1, 1);
            uiSwitch_Spot.Name = "uiSwitch_Spot";
            uiSwitch_Spot.Size = new System.Drawing.Size(117, 44);
            uiSwitch_Spot.TabIndex = 16;
            uiSwitch_Spot.Text = "uiSwitch1";
            uiSwitch_Spot.ValueChanged += uiSwitch_Spot_ValueChanged;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new System.Drawing.Point(710, 116);
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
            cbx_Orders.Location = new System.Drawing.Point(292, 116);
            cbx_Orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbx_Orders.MinimumSize = new System.Drawing.Size(63, 0);
            cbx_Orders.Name = "cbx_Orders";
            cbx_Orders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            cbx_Orders.Size = new System.Drawing.Size(229, 41);
            cbx_Orders.SymbolSize = 24;
            cbx_Orders.TabIndex = 18;
            cbx_Orders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            cbx_Orders.Watermark = "获取Mes生产工单";
            cbx_Orders.SelectedIndexChanged += cbx_Orders_SelectedIndexChanged;
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(551, 116);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(122, 42);
            uiButton4.TabIndex = 19;
            uiButton4.Text = "切换工单";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click_1;
            // 
            // tbxTest
            // 
            tbxTest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxTest.Location = new System.Drawing.Point(971, 116);
            tbxTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxTest.MinimumSize = new System.Drawing.Size(1, 16);
            tbxTest.Name = "tbxTest";
            tbxTest.Padding = new System.Windows.Forms.Padding(5);
            tbxTest.ShowText = false;
            tbxTest.Size = new System.Drawing.Size(252, 36);
            tbxTest.TabIndex = 21;
            tbxTest.Text = "1,S1245655,1";
            tbxTest.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxTest.Watermark = "张力测试（输入机台号,SN,工位号1|2）";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(62, 230);
            uiLabel6.Margin = new System.Windows.Forms.Padding(0);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(133, 42);
            uiLabel6.TabIndex = 71;
            uiLabel6.Text = "产品进站:";
            // 
            // userCtrlEntry1
            // 
            userCtrlEntry1.Location = new System.Drawing.Point(62, 276);
            userCtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            userCtrlEntry1.Name = "userCtrlEntry1";
            userCtrlEntry1.Size = new System.Drawing.Size(313, 168);
            userCtrlEntry1.TabIndex = 70;
            userCtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 50F);
            // 
            // userCtrlVisionResult
            // 
            userCtrlVisionResult.Location = new System.Drawing.Point(62, 555);
            userCtrlVisionResult.Margin = new System.Windows.Forms.Padding(4);
            userCtrlVisionResult.Name = "userCtrlVisionResult";
            userCtrlVisionResult.Size = new System.Drawing.Size(313, 168);
            userCtrlVisionResult.TabIndex = 73;
            userCtrlVisionResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlVisionResult.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(47, 509);
            uiLabel11.Margin = new System.Windows.Forms.Padding(0);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(121, 42);
            uiLabel11.TabIndex = 72;
            uiLabel11.Text = "画像检测:";
            uiLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(464, 230);
            uiLabel7.Margin = new System.Windows.Forms.Padding(0);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(97, 42);
            uiLabel7.TabIndex = 74;
            uiLabel7.Text = "最终码:";
            // 
            // lbl_FinalCode
            // 
            lbl_FinalCode.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_FinalCode.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_FinalCode.Location = new System.Drawing.Point(561, 230);
            lbl_FinalCode.Margin = new System.Windows.Forms.Padding(0);
            lbl_FinalCode.Name = "lbl_FinalCode";
            lbl_FinalCode.Size = new System.Drawing.Size(329, 42);
            lbl_FinalCode.TabIndex = 75;
            lbl_FinalCode.Text = "最终码:";
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new System.Drawing.Point(464, 292);
            uiLabel9.Margin = new System.Windows.Forms.Padding(0);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new System.Drawing.Size(97, 42);
            uiLabel9.TabIndex = 76;
            uiLabel9.Text = "等   级:";
            // 
            // lbl_grade
            // 
            lbl_grade.Font = new System.Drawing.Font("微软雅黑", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_grade.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_grade.Location = new System.Drawing.Point(551, 276);
            lbl_grade.Margin = new System.Windows.Forms.Padding(0);
            lbl_grade.Name = "lbl_grade";
            lbl_grade.Size = new System.Drawing.Size(112, 61);
            lbl_grade.TabIndex = 77;
            lbl_grade.Text = "A";
            lbl_grade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CodeResult
            // 
            lbl_CodeResult.Font = new System.Drawing.Font("微软雅黑", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_CodeResult.ForeColor = System.Drawing.Color.Green;
            lbl_CodeResult.Location = new System.Drawing.Point(584, 337);
            lbl_CodeResult.Margin = new System.Windows.Forms.Padding(0);
            lbl_CodeResult.Name = "lbl_CodeResult";
            lbl_CodeResult.Size = new System.Drawing.Size(160, 81);
            lbl_CodeResult.TabIndex = 78;
            lbl_CodeResult.Text = "OK";
            lbl_CodeResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel10.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel10.Location = new System.Drawing.Point(464, 337);
            uiLabel10.Margin = new System.Windows.Forms.Padding(0);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new System.Drawing.Size(97, 42);
            uiLabel10.TabIndex = 79;
            uiLabel10.Text = "结   果:";
            uiLabel10.Click += uiLabel10_Click;
            // 
            // PageOP70
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(uiLabel10);
            Controls.Add(lbl_CodeResult);
            Controls.Add(lbl_grade);
            Controls.Add(uiLabel9);
            Controls.Add(lbl_FinalCode);
            Controls.Add(uiLabel7);
            Controls.Add(userCtrlVisionResult);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel6);
            Controls.Add(userCtrlEntry1);
            Controls.Add(tbxTest);
            Controls.Add(uiButton4);
            Controls.Add(cbx_Orders);
            Controls.Add(uiLabel5);
            Controls.Add(uiSwitch_Spot);
            Controls.Add(uiButton3);
            Controls.Add(uiLabel3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel2);
            Controls.Add(uiTextBox1);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP70";
            Text = "PageOP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UISwitch uiSwitch_Spot;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIComboBox cbx_Orders;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UITextBox tbxTest;
        private Sunny.UI.UILabel uiLabel6;
        private DIPTest.Ctrl.UserCtrlEntry userCtrlEntry1;
        private DIPTest.Ctrl.UserCtrlResult userCtrlVisionResult;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel lbl_FinalCode;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel lbl_grade;
        private Sunny.UI.UILabel lbl_CodeResult;
        private Sunny.UI.UILabel uiLabel10;
    }
}