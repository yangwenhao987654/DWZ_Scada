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
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP70";
            Text = "OP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
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
        private ctrls.workOrderCtrl workOrderCtrl1;
    }
}