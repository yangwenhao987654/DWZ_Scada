namespace DWZ_Scada.ctrls
{
    partial class MyLogCtrl
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
            col0 = new System.Windows.Forms.ColumnHeader();
            col1 = new System.Windows.Forms.ColumnHeader();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            清除 = new System.Windows.Forms.ToolStripMenuItem();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // col0
            // 
            col0.Text = "时间";
            // 
            // col1
            // 
            col1.Text = "信息";
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
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 清除 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 清除
            // 
            清除.Name = "清除";
            清除.Size = new System.Drawing.Size(100, 22);
            清除.Text = "清除";
            清除.Click += 清除_Click_1;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "时间";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "内容";
            columnHeader2.Width = 2000;
            // 
            // MyLogCtrl
            // 
            Alignment = System.Windows.Forms.ListViewAlignment.Default;
            Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            ContextMenuStrip = contextMenuStrip1;
            Font = new System.Drawing.Font("微软雅黑", 12F);
            LabelWrap = false;
            MultiSelect = false;
            Size = new System.Drawing.Size(554, 345);
            View = System.Windows.Forms.View.Details;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
