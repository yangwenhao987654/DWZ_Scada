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
            op30CtrlResult_Vision1 = new DIPTest.Ctrl.UserCtrlResult();
            Op30CtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            uiPanel2 = new Sunny.UI.UIPanel();
            uiLabel3 = new Sunny.UI.UILabel();
            op20CtrlEntry2 = new DIPTest.Ctrl.UserCtrlEntry();
            op20CtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            uiLabel2 = new Sunny.UI.UILabel();
            uiPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
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
            ctrlWindingS.ColumnCount = 4;
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            ctrlWindingS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            ctrlWindingS.Location = new System.Drawing.Point(23, 288);
            ctrlWindingS.Margin = new System.Windows.Forms.Padding(0);
            ctrlWindingS.Name = "ctrlWindingS";
            ctrlWindingS.RowCount = 3;
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333359F));
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333359F));
            ctrlWindingS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333359F));
            ctrlWindingS.Size = new System.Drawing.Size(829, 539);
            ctrlWindingS.TabIndex = 20;
            ctrlWindingS.TagString = null;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(op30CtrlResult_Vision1);
            uiPanel1.Controls.Add(Op30CtrlEntry1);
            uiPanel1.Controls.Add(uiLabel7);
            uiPanel1.Controls.Add(uiLabel6);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(1003, 313);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(246, 414);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // op30CtrlResult_Vision1
            // 
            op30CtrlResult_Vision1.Location = new System.Drawing.Point(16, 258);
            op30CtrlResult_Vision1.Margin = new System.Windows.Forms.Padding(4);
            op30CtrlResult_Vision1.Name = "op30CtrlResult_Vision1";
            op30CtrlResult_Vision1.Size = new System.Drawing.Size(221, 141);
            op30CtrlResult_Vision1.TabIndex = 22;
            op30CtrlResult_Vision1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            op30CtrlResult_Vision1.TextFont = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // Op30CtrlEntry1
            // 
            Op30CtrlEntry1.Location = new System.Drawing.Point(16, 54);
            Op30CtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            Op30CtrlEntry1.Name = "Op30CtrlEntry1";
            Op30CtrlEntry1.Size = new System.Drawing.Size(221, 141);
            Op30CtrlEntry1.TabIndex = 21;
            Op30CtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Op30CtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 35F);
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
            // uiPanel2
            // 
            uiPanel2.Controls.Add(uiLabel3);
            uiPanel2.Controls.Add(op20CtrlEntry2);
            uiPanel2.Controls.Add(op20CtrlEntry1);
            uiPanel2.Controls.Add(uiLabel2);
            uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel2.Location = new System.Drawing.Point(35, 82);
            uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Size = new System.Drawing.Size(609, 188);
            uiPanel2.TabIndex = 21;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(323, 5);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(124, 38);
            uiLabel3.TabIndex = 24;
            uiLabel3.Text = "OP20进站2:";
            uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // op20CtrlEntry2
            // 
            op20CtrlEntry2.Location = new System.Drawing.Point(323, 46);
            op20CtrlEntry2.Margin = new System.Windows.Forms.Padding(4);
            op20CtrlEntry2.Name = "op20CtrlEntry2";
            op20CtrlEntry2.Size = new System.Drawing.Size(265, 138);
            op20CtrlEntry2.TabIndex = 23;
            op20CtrlEntry2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            op20CtrlEntry2.TextFont = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // op20CtrlEntry1
            // 
            op20CtrlEntry1.Location = new System.Drawing.Point(16, 47);
            op20CtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            op20CtrlEntry1.Name = "op20CtrlEntry1";
            op20CtrlEntry1.Size = new System.Drawing.Size(265, 137);
            op20CtrlEntry1.TabIndex = 21;
            op20CtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            op20CtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(16, 5);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(124, 38);
            uiLabel2.TabIndex = 2;
            uiLabel2.Text = "OP20进站1:";
            uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PageOP20
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(uiPanel2);
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
            uiPanel2.ResumeLayout(false);
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
        private DIPTest.Ctrl.UserCtrlEntry Op30CtrlEntry1;
        private DIPTest.Ctrl.UserCtrlResult op30CtrlResult_Vision1;
        private Sunny.UI.UIPanel uiPanel2;
        private DIPTest.Ctrl.UserCtrlEntry op20CtrlEntry2;
        private DIPTest.Ctrl.UserCtrlEntry op20CtrlEntry1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
    }
}