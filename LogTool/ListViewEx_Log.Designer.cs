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
            components = new System.ComponentModel.Container();
            时间 = new System.Windows.Forms.ColumnHeader();
            内容 = new System.Windows.Forms.ColumnHeader();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            清除 = new System.Windows.Forms.ToolStripMenuItem();
            弹出日志 = new System.Windows.Forms.ToolStripMenuItem();
            复制选中项 = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // 时间
            // 
            时间.Width = 200;
            // 
            // 内容
            // 
            内容.Width = 2000;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 清除, 弹出日志, 复制选中项 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // 清除
            // 
            清除.Name = "清除";
            清除.Size = new System.Drawing.Size(136, 22);
            清除.Text = "清除";
            清除.Click += 清除_Click;
            // 
            // 弹出日志
            // 
            弹出日志.Name = "弹出日志";
            弹出日志.Size = new System.Drawing.Size(136, 22);
            弹出日志.Text = "弹出日志";
            弹出日志.Click += 弹出日志_Click;
            // 
            // 复制选中项
            // 
            复制选中项.Name = "复制选中项";
            复制选中项.Size = new System.Drawing.Size(136, 22);
            复制选中项.Text = "复制选中行";
            复制选中项.Click += 复制选中项_Click;
            // 
            // ListViewEx_Log
            // 
            AutoArrange = false;
            Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { 时间, 内容 });
            ContextMenuStrip = contextMenuStrip1;
            Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            FullRowSelect = true;
            HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            HideSelection = true;
            LabelWrap = false;
            MultiSelect = false;
            ShowGroups = false;
            TabStop = false;
            View = System.Windows.Forms.View.Details;
            Resize += listView_Log_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ColumnHeader 时间;
        private System.Windows.Forms.ColumnHeader 内容;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        private System.Windows.Forms.ToolStripMenuItem 弹出日志;
        private System.Windows.Forms.ToolStripMenuItem 复制选中项;
    }
}
