namespace DWZ_Scada.ctrls
{
    partial class ETestBCtrl
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
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            tbx_SN_A = new Sunny.UI.UITextBox();
            uiLedStopwatch1 = new Sunny.UI.UILedStopwatch();
            btn_A = new Sunny.UI.UIButton();
            uiGroupBox1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiTableLayoutPanel2);
            uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiGroupBox1.FillColor = System.Drawing.Color.IndianRed;
            uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox1.ForeColor = System.Drawing.Color.Black;
            uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 2);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new System.Drawing.Size(282, 254);
            uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            uiGroupBox1.TabIndex = 2;
            uiGroupBox1.Text = "电测B";
            uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 1;
            uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            uiTableLayoutPanel2.Controls.Add(tbx_SN_A, 0, 0);
            uiTableLayoutPanel2.Controls.Add(uiLedStopwatch1, 0, 1);
            uiTableLayoutPanel2.Controls.Add(btn_A, 0, 2);
            uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel2.Location = new System.Drawing.Point(0, 32);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 3;
            uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            uiTableLayoutPanel2.Size = new System.Drawing.Size(282, 222);
            uiTableLayoutPanel2.TabIndex = 15;
            uiTableLayoutPanel2.TagString = null;
            // 
            // tbx_SN_A
            // 
            tbx_SN_A.Cursor = System.Windows.Forms.Cursors.IBeam;
            tbx_SN_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 134);
            tbx_SN_A.Location = new System.Drawing.Point(4, 5);
            tbx_SN_A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_SN_A.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_SN_A.Name = "tbx_SN_A";
            tbx_SN_A.Padding = new System.Windows.Forms.Padding(5);
            tbx_SN_A.ShowText = false;
            tbx_SN_A.Size = new System.Drawing.Size(182, 38);
            tbx_SN_A.Style = Sunny.UI.UIStyle.Custom;
            tbx_SN_A.TabIndex = 0;
            tbx_SN_A.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_SN_A.Watermark = "请输入SN";
            // 
            // uiLedStopwatch1
            // 
            uiLedStopwatch1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            uiLedStopwatch1.BackColor = System.Drawing.Color.Black;
            uiLedStopwatch1.CharCount = 6;
            uiLedStopwatch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLedStopwatch1.ForeColor = System.Drawing.Color.Lime;
            uiLedStopwatch1.IntervalH = 1;
            uiLedStopwatch1.IntervalV = 3;
            uiLedStopwatch1.Location = new System.Drawing.Point(3, 69);
            uiLedStopwatch1.Name = "uiLedStopwatch1";
            uiLedStopwatch1.Size = new System.Drawing.Size(276, 82);
            uiLedStopwatch1.TabIndex = 10;
            uiLedStopwatch1.Text = "00:00";
            // 
            // btn_A
            // 
            btn_A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_A.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_A.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_A.Location = new System.Drawing.Point(3, 157);
            btn_A.MinimumSize = new System.Drawing.Size(1, 1);
            btn_A.Name = "btn_A";
            btn_A.Size = new System.Drawing.Size(276, 62);
            btn_A.Style = Sunny.UI.UIStyle.Custom;
            btn_A.TabIndex = 9;
            btn_A.Text = "开始";
            btn_A.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // WindingCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(uiGroupBox1);
            Name = "WindingCtrl";
            Size = new System.Drawing.Size(282, 254);
            uiGroupBox1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        public Sunny.UI.UITextBox tbx_SN_A;
        private Sunny.UI.UILedStopwatch uiLedStopwatch1;
        public Sunny.UI.UIButton btn_A;
    }
}
