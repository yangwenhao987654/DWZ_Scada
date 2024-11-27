using System.Drawing;

namespace AutoTF.Pages.Query
{
    partial class PageUserQuery
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
            if(disposing && (components != null))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageUserQuery));
            uiDataGridView1 = new Sunny.UI.UIDataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            coIumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).BeginInit();
            uiContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).BeginInit();
            SuspendLayout();
            // 
            // uiDataGridView1
            // 
            uiDataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            uiDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            uiDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            uiDataGridView1.BackgroundColor = Color.White;
            uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            uiDataGridView1.ColumnHeadersHeight = 50;
            uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1, Column2, Column3, Column4, ColumnBtn, coIumnID });
            uiDataGridView1.ContextMenuStrip = uiContextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 16F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            uiDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            uiDataGridView1.EnableHeadersVisualStyles = false;
            uiDataGridView1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDataGridView1.GridColor = Color.DimGray;
            uiDataGridView1.Location = new Point(12, 91);
            uiDataGridView1.Name = "uiDataGridView1";
            uiDataGridView1.RectColor = Color.Black;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            uiDataGridView1.RowHeadersWidth = 20;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            uiDataGridView1.RowTemplate.Height = 40;
            uiDataGridView1.ScrollBarHandleHeight = 10;
            uiDataGridView1.ScrollBarHandleWidth = 10;
            uiDataGridView1.SelectedIndex = -1;
            uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            uiDataGridView1.Size = new Size(1247, 790);
            uiDataGridView1.StripeOddColor = Color.White;
            uiDataGridView1.TabIndex = 0;
            uiDataGridView1.CellContentClick += uiDataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "序号";
            Column1.MinimumWidth = 9;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "名称";
            Column2.MinimumWidth = 9;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "工号";
            Column3.MinimumWidth = 9;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "权限";
            Column4.MinimumWidth = 9;
            Column4.Name = "Column4";
            // 
            // ColumnBtn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 224, 192);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            ColumnBtn.DefaultCellStyle = dataGridViewCellStyle3;
            ColumnBtn.HeaderText = "编辑";
            ColumnBtn.MinimumWidth = 9;
            ColumnBtn.Name = "ColumnBtn";
            ColumnBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ColumnBtn.Text = "修改";
            ColumnBtn.UseColumnTextForButtonValue = true;
            // 
            // coIumnID
            // 
            coIumnID.HeaderText = "ID";
            coIumnID.MinimumWidth = 2;
            coIumnID.Name = "coIumnID";
            coIumnID.Visible = false;
            // 
            // uiContextMenuStrip1
            // 
            uiContextMenuStrip1.BackColor = Color.FromArgb(243, 249, 255);
            uiContextMenuStrip1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiContextMenuStrip1.ImageScalingSize = new Size(28, 28);
            uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 删除ToolStripMenuItem, 修改ToolStripMenuItem });
            uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            uiContextMenuStrip1.Size = new Size(107, 48);
            // 
            // 删除ToolStripMenuItem
            // 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            删除ToolStripMenuItem.Size = new Size(106, 22);
            删除ToolStripMenuItem.Text = "删除";
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            // 
            // 修改ToolStripMenuItem
            // 
            修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            修改ToolStripMenuItem.Size = new Size(106, 22);
            修改ToolStripMenuItem.Text = "修改";
            修改ToolStripMenuItem.Click += 修改ToolStripMenuItem_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            uiTextBox1.Font = new Font("微软雅黑", 18F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox1.Location = new Point(41, 25);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(0);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(1);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(308, 50);
            uiTextBox1.TabIndex = 1;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "请输入姓名";
            // 
            // uiButton1
            // 
            uiButton1.BackColor = SystemColors.ButtonHighlight;
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.FillColor = SystemColors.ButtonHighlight;
            uiButton1.Font = new Font("微软雅黑", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.ForeColor = Color.Black;
            uiButton1.Location = new Point(435, 25);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(145, 50);
            uiButton1.TabIndex = 2;
            uiButton1.Text = "查询";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            uiButton2.FillColor = SystemColors.ButtonHighlight;
            uiButton2.Font = new Font("微软雅黑", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.ForeColor = Color.Black;
            uiButton2.Location = new Point(673, 25);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new Size(145, 50);
            uiButton2.TabIndex = 3;
            uiButton2.Text = "新建用户";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiImageButton1
            // 
            uiImageButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiImageButton1.Image = (Image)resources.GetObject("uiImageButton1.Image");
            uiImageButton1.Location = new Point(970, 2);
            uiImageButton1.Name = "uiImageButton1";
            uiImageButton1.Size = new Size(81, 83);
            uiImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            uiImageButton1.TabIndex = 4;
            uiImageButton1.TabStop = false;
            uiImageButton1.Text = null;
            uiImageButton1.Click += uiImageButton1_Click;
            // 
            // PageUserQuery
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1280, 960);
            Controls.Add(uiImageButton1);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiTextBox1);
            Controls.Add(uiDataGridView1);
            Font = new Font("宋体", 15F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PageUserQuery";
            RectColor = SystemColors.ButtonHighlight;
            Text = "用户管理";
            Initialize += PageUserQuery_Initialize;
            Load += PageUserQuery_Load;
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).EndInit();
            uiContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)uiImageButton1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coIumnID;
        private Sunny.UI.UIImageButton uiImageButton1;
    }
}