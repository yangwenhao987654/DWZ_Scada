namespace DWZ_Scada
{
    partial class PageOP60
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
            components = new System.ComponentModel.Container();
            uiLabel1 = new Sunny.UI.UILabel();
            uiSwitch_Spot = new Sunny.UI.UISwitch();
            uiLabel5 = new Sunny.UI.UILabel();
            btn_Test = new Sunny.UI.UIButton();
            uiPanel1 = new Sunny.UI.UIPanel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            lbl_EntryMsg = new Sunny.UI.UILabel();
            lbl_EntryResult = new Sunny.UI.UILabel();
            uiLabel10 = new Sunny.UI.UILabel();
            uiLabel11 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            uiLabel12 = new Sunny.UI.UILabel();
            uiLabel16 = new Sunny.UI.UILabel();
            userCtrlResult1 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult2 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult3 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult4 = new DIPTest.Ctrl.UserCtrlResult();
            uiPanel1.SuspendLayout();
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
            uiLabel1.Text = "OP60-电测工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
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
            // btn_Test
            // 
            btn_Test.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_Test.Location = new System.Drawing.Point(1034, 122);
            btn_Test.MinimumSize = new System.Drawing.Size(1, 1);
            btn_Test.Name = "btn_Test";
            btn_Test.Size = new System.Drawing.Size(111, 42);
            btn_Test.TabIndex = 22;
            btn_Test.Text = "AtlBrx调试";
            btn_Test.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_Test.Click += btn_Test_Click;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(myLogCtrl1);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(13, 532);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1211, 294);
            uiPanel1.TabIndex = 48;
            uiPanel1.Text = "uiPanel1";
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            myLogCtrl1.Size = new System.Drawing.Size(1211, 294);
            myLogCtrl1.TabIndex = 33;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // lbl_EntryMsg
            // 
            lbl_EntryMsg.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntryMsg.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntryMsg.Location = new System.Drawing.Point(472, 190);
            lbl_EntryMsg.Name = "lbl_EntryMsg";
            lbl_EntryMsg.Size = new System.Drawing.Size(452, 94);
            lbl_EntryMsg.TabIndex = 47;
            lbl_EntryMsg.Text = "...";
            // 
            // lbl_EntryResult
            // 
            lbl_EntryResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntryResult.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntryResult.Location = new System.Drawing.Point(156, 251);
            lbl_EntryResult.Name = "lbl_EntryResult";
            lbl_EntryResult.Size = new System.Drawing.Size(220, 42);
            lbl_EntryResult.TabIndex = 46;
            lbl_EntryResult.Text = "无";
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel10.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel10.Location = new System.Drawing.Point(10, 251);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new System.Drawing.Size(140, 42);
            uiLabel10.TabIndex = 45;
            uiLabel10.Text = "进站结果:";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(328, 305);
            uiLabel11.Margin = new System.Windows.Forms.Padding(0);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(135, 42);
            uiLabel11.TabIndex = 42;
            uiLabel11.Text = "导通耐压2:";
            uiLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(10, 305);
            uiLabel6.Margin = new System.Windows.Forms.Padding(0);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(133, 42);
            uiLabel6.TabIndex = 41;
            uiLabel6.Text = "导通耐压1:";
            uiLabel6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(933, 305);
            uiLabel7.Margin = new System.Windows.Forms.Padding(0);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(156, 42);
            uiLabel7.TabIndex = 40;
            uiLabel7.Text = "电性能测试2:";
            uiLabel7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new System.Drawing.Point(635, 305);
            uiLabel9.Margin = new System.Windows.Forms.Padding(0);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new System.Drawing.Size(160, 42);
            uiLabel9.TabIndex = 39;
            uiLabel9.Text = "电性能测试1:";
            uiLabel9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel12
            // 
            uiLabel12.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel12.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel12.Location = new System.Drawing.Point(10, 199);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new System.Drawing.Size(140, 42);
            uiLabel12.TabIndex = 38;
            uiLabel12.Text = "进站临时码:";
            // 
            // uiLabel16
            // 
            uiLabel16.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel16.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel16.Location = new System.Drawing.Point(156, 199);
            uiLabel16.Name = "uiLabel16";
            uiLabel16.Size = new System.Drawing.Size(193, 33);
            uiLabel16.TabIndex = 54;
            uiLabel16.Text = "V1SNQWEQSC";
            // 
            // userCtrlResult1
            // 
            userCtrlResult1.Location = new System.Drawing.Point(13, 357);
            userCtrlResult1.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult1.Name = "userCtrlResult1";
            userCtrlResult1.Size = new System.Drawing.Size(276, 168);
            userCtrlResult1.TabIndex = 60;
            userCtrlResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult1.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            userCtrlResult1.Load += userCtrlResult1_Load;
            // 
            // userCtrlResult2
            // 
            userCtrlResult2.Location = new System.Drawing.Point(635, 357);
            userCtrlResult2.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult2.Name = "userCtrlResult2";
            userCtrlResult2.Size = new System.Drawing.Size(276, 168);
            userCtrlResult2.TabIndex = 61;
            userCtrlResult2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult2.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlResult3
            // 
            userCtrlResult3.Location = new System.Drawing.Point(315, 357);
            userCtrlResult3.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult3.Name = "userCtrlResult3";
            userCtrlResult3.Size = new System.Drawing.Size(276, 168);
            userCtrlResult3.TabIndex = 62;
            userCtrlResult3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult3.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlResult4
            // 
            userCtrlResult4.Location = new System.Drawing.Point(944, 357);
            userCtrlResult4.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult4.Name = "userCtrlResult4";
            userCtrlResult4.Size = new System.Drawing.Size(276, 168);
            userCtrlResult4.TabIndex = 63;
            userCtrlResult4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult4.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // PageOP60
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(userCtrlResult4);
            Controls.Add(userCtrlResult3);
            Controls.Add(userCtrlResult2);
            Controls.Add(userCtrlResult1);
            Controls.Add(uiLabel16);
            Controls.Add(uiPanel1);
            Controls.Add(lbl_EntryMsg);
            Controls.Add(lbl_EntryResult);
            Controls.Add(uiLabel10);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel7);
            Controls.Add(uiLabel9);
            Controls.Add(uiLabel12);
            Controls.Add(btn_Test);
            Controls.Add(uiLabel5);
            Controls.Add(uiSwitch_Spot);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP60";
            Text = "PageOP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISwitch uiSwitch_Spot;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIButton btn_Test;
        private Sunny.UI.UIPanel uiPanel1;
        private ctrls.MyLogCtrl myLogCtrl1;
        private Sunny.UI.UILabel lbl_EntryMsg;
        private Sunny.UI.UILabel lbl_EntryResult;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UILabel uiLabel16;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult1;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult2;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult3;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult4;
    }
}