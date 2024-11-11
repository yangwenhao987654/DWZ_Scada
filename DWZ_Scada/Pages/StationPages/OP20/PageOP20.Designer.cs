namespace DWZ_Scada
{
    partial class PageOP20
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
            ctrlWindingS = new Sunny.UI.UITableLayoutPanel();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
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
            uiLabel1.Text = "OP20-绕线工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // ctrlWindingS
            // 
            ctrlWindingS.ColumnCount = 3;
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333359F));
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3333359F));
            ctrlWindingS.Location = new System.Drawing.Point(18, 145);
            ctrlWindingS.Margin = new System.Windows.Forms.Padding(0);
            ctrlWindingS.Name = "ctrlWindingS";
            ctrlWindingS.RowCount = 4;
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            ctrlWindingS.Size = new System.Drawing.Size(824, 678);
            ctrlWindingS.TabIndex = 20;
            ctrlWindingS.TagString = null;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiLabel7);
            uiPanel1.Controls.Add(uiLabel6);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(917, 314);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(306, 389);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(4, 3);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(176, 38);
            uiLabel7.TabIndex = 2;
            uiLabel7.Text = "OP30进站临时码:";
            uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(7, 220);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(160, 34);
            uiLabel6.TabIndex = 1;
            uiLabel6.Text = "OP30画像检测:";
            uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PageOP20
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(uiPanel1);
            Controls.Add(ctrlWindingS);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP20";
            Text = "PageOP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            Initialize += PageOP20_Initialize;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITableLayoutPanel ctrlWindingS;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult_OP30;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private DIPTest.Ctrl.UserCtrlEntry userCtrlEntry_OP30;
    }
}