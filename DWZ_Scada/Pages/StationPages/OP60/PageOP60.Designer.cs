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
            uiPanel1 = new Sunny.UI.UIPanel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            uiLabel11 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            userCtrlResult1 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult3 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult2 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult4 = new DIPTest.Ctrl.UserCtrlResult();
            uiLight1 = new Sunny.UI.UILight();
            uiLight2 = new Sunny.UI.UILight();
            uiLight3 = new Sunny.UI.UILight();
            uiLight4 = new Sunny.UI.UILight();
            userCtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            uiLabel2 = new Sunny.UI.UILabel();
            workOrderCtrlWithoutPart1 = new ctrls.workOrderCtrlWithoutPart();
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
            // uiPanel1
            // 
            uiPanel1.Controls.Add(myLogCtrl1);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(13, 647);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1244, 179);
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
            myLogCtrl1.Size = new System.Drawing.Size(1244, 179);
            myLogCtrl1.TabIndex = 33;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(648, 427);
            uiLabel11.Margin = new System.Windows.Forms.Padding(0);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(130, 36);
            uiLabel11.TabIndex = 42;
            uiLabel11.Text = "安规测试2:";
            uiLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(981, 426);
            uiLabel6.Margin = new System.Windows.Forms.Padding(0);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(130, 36);
            uiLabel6.TabIndex = 41;
            uiLabel6.Text = "安规测试1:";
            uiLabel6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(24, 430);
            uiLabel7.Margin = new System.Windows.Forms.Padding(0);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(160, 36);
            uiLabel7.TabIndex = 40;
            uiLabel7.Text = "电性能测试2:";
            uiLabel7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new System.Drawing.Point(336, 430);
            uiLabel9.Margin = new System.Windows.Forms.Padding(0);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new System.Drawing.Size(160, 36);
            uiLabel9.TabIndex = 39;
            uiLabel9.Text = "电性能测试1:";
            uiLabel9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // userCtrlResult1
            // 
            userCtrlResult1.Location = new System.Drawing.Point(981, 472);
            userCtrlResult1.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult1.Name = "userCtrlResult1";
            userCtrlResult1.Size = new System.Drawing.Size(276, 168);
            userCtrlResult1.TabIndex = 60;
            userCtrlResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult1.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            userCtrlResult1.Load += userCtrlResult1_Load;
            // 
            // userCtrlResult3
            // 
            userCtrlResult3.Location = new System.Drawing.Point(336, 470);
            userCtrlResult3.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult3.Name = "userCtrlResult3";
            userCtrlResult3.Size = new System.Drawing.Size(276, 168);
            userCtrlResult3.TabIndex = 61;
            userCtrlResult3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult3.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlResult2
            // 
            userCtrlResult2.Location = new System.Drawing.Point(648, 470);
            userCtrlResult2.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult2.Name = "userCtrlResult2";
            userCtrlResult2.Size = new System.Drawing.Size(276, 168);
            userCtrlResult2.TabIndex = 62;
            userCtrlResult2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult2.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlResult4
            // 
            userCtrlResult4.Location = new System.Drawing.Point(24, 470);
            userCtrlResult4.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult4.Name = "userCtrlResult4";
            userCtrlResult4.Size = new System.Drawing.Size(276, 168);
            userCtrlResult4.TabIndex = 63;
            userCtrlResult4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult4.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // uiLight1
            // 
            uiLight1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLight1.Location = new System.Drawing.Point(1222, 427);
            uiLight1.MinimumSize = new System.Drawing.Size(1, 1);
            uiLight1.Name = "uiLight1";
            uiLight1.OnColor = System.Drawing.Color.DimGray;
            uiLight1.Radius = 35;
            uiLight1.Size = new System.Drawing.Size(35, 35);
            uiLight1.TabIndex = 64;
            uiLight1.Text = "uiLight1";
            // 
            // uiLight2
            // 
            uiLight2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLight2.Location = new System.Drawing.Point(889, 427);
            uiLight2.MinimumSize = new System.Drawing.Size(1, 1);
            uiLight2.Name = "uiLight2";
            uiLight2.OnColor = System.Drawing.Color.DimGray;
            uiLight2.Radius = 35;
            uiLight2.Size = new System.Drawing.Size(35, 35);
            uiLight2.TabIndex = 65;
            uiLight2.Text = "uiLight2";
            // 
            // uiLight3
            // 
            uiLight3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLight3.Location = new System.Drawing.Point(577, 430);
            uiLight3.MinimumSize = new System.Drawing.Size(1, 1);
            uiLight3.Name = "uiLight3";
            uiLight3.OnColor = System.Drawing.Color.DimGray;
            uiLight3.Radius = 35;
            uiLight3.Size = new System.Drawing.Size(35, 35);
            uiLight3.TabIndex = 66;
            uiLight3.Text = "uiLight3";
            // 
            // uiLight4
            // 
            uiLight4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLight4.Location = new System.Drawing.Point(249, 428);
            uiLight4.MinimumSize = new System.Drawing.Size(1, 1);
            uiLight4.Name = "uiLight4";
            uiLight4.OnColor = System.Drawing.Color.DimGray;
            uiLight4.Radius = 35;
            uiLight4.Size = new System.Drawing.Size(35, 35);
            uiLight4.TabIndex = 67;
            uiLight4.Text = "uiLight4";
            // 
            // userCtrlEntry1
            // 
            userCtrlEntry1.Location = new System.Drawing.Point(944, 219);
            userCtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            userCtrlEntry1.Name = "userCtrlEntry1";
            userCtrlEntry1.Size = new System.Drawing.Size(313, 168);
            userCtrlEntry1.TabIndex = 68;
            userCtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 50F);
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(944, 179);
            uiLabel2.Margin = new System.Windows.Forms.Padding(0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(133, 36);
            uiLabel2.TabIndex = 69;
            uiLabel2.Text = "产品进站:";
            // 
            // workOrderCtrlWithoutPart1
            // 
            workOrderCtrlWithoutPart1.BackColor = System.Drawing.Color.Transparent;
            workOrderCtrlWithoutPart1.CurPartNo = "";
            workOrderCtrlWithoutPart1.CurProductCode = "";
            workOrderCtrlWithoutPart1.CurProductName = "";
            workOrderCtrlWithoutPart1.CurWorkOrderNo = "";
            workOrderCtrlWithoutPart1.IsCheckPass = false;
            workOrderCtrlWithoutPart1.Location = new System.Drawing.Point(13, 62);
            workOrderCtrlWithoutPart1.Name = "workOrderCtrlWithoutPart1";
            workOrderCtrlWithoutPart1.Orders = null;
            workOrderCtrlWithoutPart1.Size = new System.Drawing.Size(1244, 75);
            workOrderCtrlWithoutPart1.SpotEnable = false;
            workOrderCtrlWithoutPart1.TabIndex = 70;
            // 
            // PageOP60
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(workOrderCtrlWithoutPart1);
            Controls.Add(uiLabel2);
            Controls.Add(userCtrlEntry1);
            Controls.Add(uiLight4);
            Controls.Add(uiLight3);
            Controls.Add(uiLight2);
            Controls.Add(uiLight1);
            Controls.Add(userCtrlResult4);
            Controls.Add(userCtrlResult2);
            Controls.Add(userCtrlResult3);
            Controls.Add(userCtrlResult1);
            Controls.Add(uiPanel1);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel7);
            Controls.Add(uiLabel9);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP60";
            Text = "OP60";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel1;
        private ctrls.MyLogCtrl myLogCtrl1;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel9;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult1;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult3;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult2;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult4;
        private Sunny.UI.UILight uiLight1;
        private Sunny.UI.UILight uiLight2;
        private Sunny.UI.UILight uiLight3;
        private Sunny.UI.UILight uiLight4;
        private DIPTest.Ctrl.UserCtrlEntry userCtrlEntry1;
        private Sunny.UI.UILabel uiLabel2;
        private ctrls.workOrderCtrlWithoutPart workOrderCtrlWithoutPart1;
    }
}