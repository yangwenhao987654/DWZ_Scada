namespace DIPTest
{
    partial class UserCtrlAgingSingle
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
            components = new System.ComponentModel.Container();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            tbx_SN_A = new Sunny.UI.UITextBox();
            uiLedStopwatch1 = new Sunny.UI.UILedStopwatch();
            btn_A = new Sunny.UI.UIButton();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            tbx_SN_B = new Sunny.UI.UITextBox();
            btn_B = new Sunny.UI.UIButton();
            uiLedStopwatch4 = new Sunny.UI.UILedStopwatch();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            uiGroupBox3 = new Sunny.UI.UIGroupBox();
            uiGroupBox1.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            uiGroupBox2.SuspendLayout();
            uiTableLayoutPanel3.SuspendLayout();
            uiTableLayoutPanel1.SuspendLayout();
            uiGroupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiTableLayoutPanel2);
            uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiGroupBox1.FillColor = System.Drawing.Color.IndianRed;
            uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox1.ForeColor = System.Drawing.Color.Black;
            uiGroupBox1.Location = new System.Drawing.Point(5, 5);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 2);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new System.Drawing.Size(195, 198);
            uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            uiGroupBox1.TabIndex = 1;
            uiGroupBox1.Text = "A工位";
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
            uiTableLayoutPanel2.Size = new System.Drawing.Size(195, 166);
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
            tbx_SN_A.TextChanged += uiTextBox1_TextChanged;
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
            uiLedStopwatch1.Location = new System.Drawing.Point(3, 52);
            uiLedStopwatch1.Name = "uiLedStopwatch1";
            uiLedStopwatch1.Size = new System.Drawing.Size(189, 60);
            uiLedStopwatch1.TabIndex = 10;
            uiLedStopwatch1.Text = "00:00";
            // 
            // btn_A
            // 
            btn_A.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_A.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_A.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_A.Location = new System.Drawing.Point(3, 118);
            btn_A.MinimumSize = new System.Drawing.Size(1, 1);
            btn_A.Name = "btn_A";
            btn_A.Size = new System.Drawing.Size(189, 45);
            btn_A.Style = Sunny.UI.UIStyle.Custom;
            btn_A.TabIndex = 9;
            btn_A.Text = "开始";
            btn_A.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_A.Click += btn_A_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(uiTableLayoutPanel3);
            uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiGroupBox2.FillColor = System.Drawing.Color.IndianRed;
            uiGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox2.ForeColor = System.Drawing.Color.Black;
            uiGroupBox2.Location = new System.Drawing.Point(200, 5);
            uiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 2);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox2.Size = new System.Drawing.Size(195, 198);
            uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            uiGroupBox2.TabIndex = 2;
            uiGroupBox2.Text = "B工位";
            uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            uiGroupBox2.Click += uiGroupBox2_Click;
            // 
            // uiTableLayoutPanel3
            // 
            uiTableLayoutPanel3.ColumnCount = 1;
            uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            uiTableLayoutPanel3.Controls.Add(tbx_SN_B, 0, 0);
            uiTableLayoutPanel3.Controls.Add(btn_B, 0, 2);
            uiTableLayoutPanel3.Controls.Add(uiLedStopwatch4, 0, 1);
            uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel3.Location = new System.Drawing.Point(0, 32);
            uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            uiTableLayoutPanel3.RowCount = 3;
            uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            uiTableLayoutPanel3.Size = new System.Drawing.Size(195, 166);
            uiTableLayoutPanel3.TabIndex = 16;
            uiTableLayoutPanel3.TagString = null;
            // 
            // tbx_SN_B
            // 
            tbx_SN_B.Cursor = System.Windows.Forms.Cursors.IBeam;
            tbx_SN_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 134);
            tbx_SN_B.Location = new System.Drawing.Point(4, 5);
            tbx_SN_B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_SN_B.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_SN_B.Name = "tbx_SN_B";
            tbx_SN_B.Padding = new System.Windows.Forms.Padding(5);
            tbx_SN_B.ShowText = false;
            tbx_SN_B.Size = new System.Drawing.Size(182, 38);
            tbx_SN_B.Style = Sunny.UI.UIStyle.Custom;
            tbx_SN_B.TabIndex = 0;
            tbx_SN_B.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_SN_B.Watermark = "请输入SN";
            // 
            // btn_B
            // 
            btn_B.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_B.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_B.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_B.Location = new System.Drawing.Point(3, 118);
            btn_B.MinimumSize = new System.Drawing.Size(1, 1);
            btn_B.Name = "btn_B";
            btn_B.Size = new System.Drawing.Size(189, 45);
            btn_B.Style = Sunny.UI.UIStyle.Custom;
            btn_B.TabIndex = 9;
            btn_B.Text = "开始";
            btn_B.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // uiLedStopwatch4
            // 
            uiLedStopwatch4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            uiLedStopwatch4.BackColor = System.Drawing.Color.Black;
            uiLedStopwatch4.CharCount = 6;
            uiLedStopwatch4.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLedStopwatch4.ForeColor = System.Drawing.Color.Lime;
            uiLedStopwatch4.IntervalH = 1;
            uiLedStopwatch4.IntervalV = 3;
            uiLedStopwatch4.Location = new System.Drawing.Point(3, 52);
            uiLedStopwatch4.Name = "uiLedStopwatch4";
            uiLedStopwatch4.Size = new System.Drawing.Size(189, 60);
            uiLedStopwatch4.TabIndex = 10;
            uiLedStopwatch4.Text = "00:00";
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            uiTableLayoutPanel1.Controls.Add(uiGroupBox1, 0, 0);
            uiTableLayoutPanel1.Controls.Add(uiGroupBox2, 1, 0);
            uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            uiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            uiTableLayoutPanel1.Size = new System.Drawing.Size(400, 208);
            uiTableLayoutPanel1.TabIndex = 15;
            uiTableLayoutPanel1.TagString = null;
            // 
            // uiGroupBox3
            // 
            uiGroupBox3.Controls.Add(uiTableLayoutPanel1);
            uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox3.Location = new System.Drawing.Point(0, 0);
            uiGroupBox3.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox3.Name = "uiGroupBox3";
            uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox3.Size = new System.Drawing.Size(400, 240);
            uiGroupBox3.TabIndex = 15;
            uiGroupBox3.Text = "绕线机1";
            uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserCtrlAgingSingle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(uiGroupBox3);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UserCtrlAgingSingle";
            Size = new System.Drawing.Size(400, 240);
            Load += UserCtrlAgingSingle_Load;
            uiGroupBox1.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            uiGroupBox2.ResumeLayout(false);
            uiTableLayoutPanel3.ResumeLayout(false);
            uiTableLayoutPanel1.ResumeLayout(false);
            uiGroupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Sunny.UI.UITextBox tbx_SN_A;
        public Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Sunny.UI.UILedStopwatch uiLedStopwatch1;
        public Sunny.UI.UIButton btn_A;
        public Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        public Sunny.UI.UITextBox tbx_SN_B;
        private Sunny.UI.UILedStopwatch uiLedStopwatch4;
        public Sunny.UI.UIButton btn_B;
    }
}
