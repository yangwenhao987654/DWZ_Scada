namespace DWZ_Scada.Forms
{
    partial class BomListForm
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
            uiListBox1 = new Sunny.UI.UIListBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            复制选中物料码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uiContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // uiListBox1
            // 
            uiListBox1.ContextMenuStrip = uiContextMenuStrip1;
            uiListBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiListBox1.HoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            uiListBox1.ItemHeight = 30;
            uiListBox1.ItemSelectForeColor = System.Drawing.Color.White;
            uiListBox1.Location = new System.Drawing.Point(19, 132);
            uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            uiListBox1.Name = "uiListBox1";
            uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            uiListBox1.ShowText = false;
            uiListBox1.Size = new System.Drawing.Size(527, 317);
            uiListBox1.TabIndex = 12;
            uiListBox1.Text = "uiListBox1";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(19, 73);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(122, 35);
            uiLabel1.TabIndex = 13;
            uiLabel1.Text = "物料明细:";
            // 
            // uiContextMenuStrip1
            // 
            uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(243, 249, 255);
            uiContextMenuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 复制选中物料码ToolStripMenuItem });
            uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            uiContextMenuStrip1.Size = new System.Drawing.Size(187, 26);
            // 
            // 复制选中物料码ToolStripMenuItem
            // 
            复制选中物料码ToolStripMenuItem.Name = "复制选中物料码ToolStripMenuItem";
            复制选中物料码ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            复制选中物料码ToolStripMenuItem.Text = "复制选中物料码";
            复制选中物料码ToolStripMenuItem.Click += 复制选中物料码ToolStripMenuItem_Click;
            // 
            // BomListForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(585, 530);
            Controls.Add(uiLabel1);
            Controls.Add(uiListBox1);
            Name = "BomListForm";
            Text = "自定义对话框";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            Load += BomListForm_Load;
            uiContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIListBox uiListBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制选中物料码ToolStripMenuItem;
    }
}