namespace LogTool
{
    partial class ListViewEx_Log
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
            this.components = new System.ComponentModel.Container();
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.内容 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除 = new System.Windows.Forms.ToolStripMenuItem();
            this.弹出日志 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 时间
            // 
            this.时间.Width = 200;
            // 
            // 内容
            // 
            this.内容.Width = 2000;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 清除
            // 
            this.清除.Name = "清除";
            this.清除.Size = new System.Drawing.Size(124, 22);
            this.清除.Text = "清除";
            this.清除.Click += new System.EventHandler(this.清除_Click);
            // 
            // ListViewEx_Log
            // 
            this.AutoArrange = false;
            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.时间,
            this.内容});
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LabelWrap = false;
            this.MultiSelect = false;
            this.ShowGroups = false;
            this.TabStop = false;
            this.View = System.Windows.Forms.View.Details;
            this.Resize += new System.EventHandler(this.listView_Log_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader 时间;
        private System.Windows.Forms.ColumnHeader 内容;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        private System.Windows.Forms.ToolStripMenuItem 弹出日志;
    }
}
