namespace DWZ_Scada.ctrls
{
    partial class windingCtrl
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
            uiPanel1 = new Sunny.UI.UIPanel();
            uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            禁用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            启用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            lblSN2 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            lblSN1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            lbl_time = new Sunny.UI.UILabel();
            uiPanel1.SuspendLayout();
            uiContextMenuStrip1.SuspendLayout();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.ContextMenuStrip = uiContextMenuStrip1;
            uiPanel1.Controls.Add(uiTableLayoutPanel1);
            uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel1.FillColor = System.Drawing.Color.Gray;
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(0, 0);
            uiPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Radius = 10;
            uiPanel1.Size = new System.Drawing.Size(214, 160);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            uiPanel1.Load += uiPanel1_Load;
            uiPanel1.Click += uiPanel1_Click;
            // 
            // uiContextMenuStrip1
            // 
            uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(243, 249, 255);
            uiContextMenuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 禁用ToolStripMenuItem, 启用ToolStripMenuItem });
            uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            uiContextMenuStrip1.Size = new System.Drawing.Size(107, 48);
            // 
            // 禁用ToolStripMenuItem
            // 
            禁用ToolStripMenuItem.Name = "禁用ToolStripMenuItem";
            禁用ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            禁用ToolStripMenuItem.Text = "禁用";
            禁用ToolStripMenuItem.Click += 禁用ToolStripMenuItem_Click;
            // 
            // 启用ToolStripMenuItem
            // 
            启用ToolStripMenuItem.Name = "启用ToolStripMenuItem";
            启用ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            启用ToolStripMenuItem.Text = "启用";
            启用ToolStripMenuItem.Click += 启用ToolStripMenuItem_Click;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(lblSN2, 0, 2);
            uiTableLayoutPanel1.Controls.Add(uiLabel1, 0, 0);
            uiTableLayoutPanel1.Controls.Add(lblSN1, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiLabel2, 0, 3);
            uiTableLayoutPanel1.Controls.Add(lbl_time, 0, 4);
            uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            uiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 5;
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            uiTableLayoutPanel1.Size = new System.Drawing.Size(214, 160);
            uiTableLayoutPanel1.TabIndex = 4;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lblSN2
            // 
            lblSN2.BackColor = System.Drawing.Color.Aqua;
            lblSN2.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSN2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            lblSN2.ForeColor = System.Drawing.Color.Black;
            lblSN2.Location = new System.Drawing.Point(0, 60);
            lblSN2.Margin = new System.Windows.Forms.Padding(0);
            lblSN2.Name = "lblSN2";
            lblSN2.Size = new System.Drawing.Size(214, 28);
            lblSN2.TabIndex = 6;
            lblSN2.Text = "SN2";
            lblSN2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = System.Drawing.Color.Transparent;
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 0);
            uiLabel1.Margin = new System.Windows.Forms.Padding(0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(214, 32);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "绕线机01";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // lblSN1
            // 
            lblSN1.BackColor = System.Drawing.Color.Aqua;
            lblSN1.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSN1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            lblSN1.ForeColor = System.Drawing.Color.Black;
            lblSN1.Location = new System.Drawing.Point(0, 32);
            lblSN1.Margin = new System.Windows.Forms.Padding(0);
            lblSN1.Name = "lblSN1";
            lblSN1.Size = new System.Drawing.Size(214, 28);
            lblSN1.TabIndex = 5;
            lblSN1.Text = "SN1";
            lblSN1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(3, 88);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(208, 48);
            uiLabel2.TabIndex = 3;
            uiLabel2.Text = "未连接";
            uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            lbl_time.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl_time.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_time.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_time.Location = new System.Drawing.Point(3, 136);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new System.Drawing.Size(208, 24);
            lbl_time.TabIndex = 4;
            lbl_time.Text = "00:00";
            lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windingCtrl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(uiPanel1);
            Margin = new System.Windows.Forms.Padding(5);
            Name = "windingCtrl";
            Size = new System.Drawing.Size(214, 160);
            Load += windingCtrl_Load;
            uiPanel1.ResumeLayout(false);
            uiContextMenuStrip1.ResumeLayout(false);
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lbl_time;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 禁用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启用ToolStripMenuItem;
        private Sunny.UI.UILabel lblSN1;
        private Sunny.UI.UILabel lblSN2;
    }
}
