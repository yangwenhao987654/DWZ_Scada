namespace DWZ_Scada.Page.PLCControl
{
    partial class PageAlarmArrayConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            dgv = new Sunny.UI.UIDataGridView();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            column_AlarmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            uiButton6 = new Sunny.UI.UIButton();
            tbxLength = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column3, Column1, Column2, column_AlarmType });
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle13;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.GridColor = System.Drawing.Color.Gray;
            dgv.Location = new System.Drawing.Point(12, 35);
            dgv.Name = "dgv";
            dgv.RectColor = System.Drawing.Color.Gray;
            dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dgv.RowTemplate.Height = 35;
            dgv.ScrollBarColor = System.Drawing.Color.Silver;
            dgv.ScrollBarHandleHeight = 12;
            dgv.ScrollBarHandleWidth = 12;
            dgv.ScrollBarHeight = 10;
            dgv.ScrollBarRectColor = System.Drawing.Color.Silver;
            dgv.ScrollBarStyleInherited = false;
            dgv.ScrollBarWidth = 10;
            dgv.SelectedIndex = -1;
            dgv.Size = new System.Drawing.Size(1019, 735);
            dgv.StripeOddColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dgv.TabIndex = 102;
            dgv.CellClick += dgv_CellClick;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // Column3
            // 
            Column3.HeaderText = "索引";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "地址";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "报警信息";
            Column2.Name = "Column2";
            // 
            // column_AlarmType
            // 
            column_AlarmType.HeaderText = "报警类型";
            column_AlarmType.Name = "column_AlarmType";
            // 
            // uiButton3
            // 
            uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton3.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton3.FillColor2 = System.Drawing.Color.Gray;
            uiButton3.FillColorGradient = true;
            uiButton3.FillHoverColor = System.Drawing.Color.Silver;
            uiButton3.FillPressColor = System.Drawing.Color.Gray;
            uiButton3.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.ForeColor = System.Drawing.Color.Black;
            uiButton3.ForeHoverColor = System.Drawing.Color.Black;
            uiButton3.ForePressColor = System.Drawing.Color.Black;
            uiButton3.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton3.Location = new System.Drawing.Point(1051, 290);
            uiButton3.Margin = new System.Windows.Forms.Padding(2);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = System.Drawing.Color.Silver;
            uiButton3.RectHoverColor = System.Drawing.Color.Silver;
            uiButton3.RectPressColor = System.Drawing.Color.Silver;
            uiButton3.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton3.Size = new System.Drawing.Size(145, 50);
            uiButton3.TabIndex = 107;
            uiButton3.Text = "刷新";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiButton4
            // 
            uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton4.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton4.FillColor2 = System.Drawing.Color.Gray;
            uiButton4.FillColorGradient = true;
            uiButton4.FillHoverColor = System.Drawing.Color.Silver;
            uiButton4.FillPressColor = System.Drawing.Color.Gray;
            uiButton4.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.ForeColor = System.Drawing.Color.Black;
            uiButton4.ForeHoverColor = System.Drawing.Color.Black;
            uiButton4.ForePressColor = System.Drawing.Color.Black;
            uiButton4.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton4.Location = new System.Drawing.Point(1051, 379);
            uiButton4.Margin = new System.Windows.Forms.Padding(2);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.RectColor = System.Drawing.Color.Silver;
            uiButton4.RectHoverColor = System.Drawing.Color.Silver;
            uiButton4.RectPressColor = System.Drawing.Color.Silver;
            uiButton4.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Size = new System.Drawing.Size(145, 50);
            uiButton4.TabIndex = 108;
            uiButton4.Text = "删除";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // uiButton2
            // 
            uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton2.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton2.FillColor2 = System.Drawing.Color.Gray;
            uiButton2.FillColorGradient = true;
            uiButton2.FillHoverColor = System.Drawing.Color.Silver;
            uiButton2.FillPressColor = System.Drawing.Color.Gray;
            uiButton2.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.ForeColor = System.Drawing.Color.Black;
            uiButton2.ForeHoverColor = System.Drawing.Color.Black;
            uiButton2.ForePressColor = System.Drawing.Color.Black;
            uiButton2.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton2.Location = new System.Drawing.Point(1051, 483);
            uiButton2.Margin = new System.Windows.Forms.Padding(2);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = System.Drawing.Color.Silver;
            uiButton2.RectHoverColor = System.Drawing.Color.Silver;
            uiButton2.RectPressColor = System.Drawing.Color.Silver;
            uiButton2.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton2.Size = new System.Drawing.Size(145, 50);
            uiButton2.TabIndex = 109;
            uiButton2.Text = "添加";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click_1;
            // 
            // uiButton1
            // 
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton1.FillColor2 = System.Drawing.Color.Gray;
            uiButton1.FillColorGradient = true;
            uiButton1.FillHoverColor = System.Drawing.Color.Silver;
            uiButton1.FillPressColor = System.Drawing.Color.Gray;
            uiButton1.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.ForeColor = System.Drawing.Color.Black;
            uiButton1.ForeHoverColor = System.Drawing.Color.Black;
            uiButton1.ForePressColor = System.Drawing.Color.Black;
            uiButton1.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton1.Location = new System.Drawing.Point(1051, 576);
            uiButton1.Margin = new System.Windows.Forms.Padding(2);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = System.Drawing.Color.Silver;
            uiButton1.RectHoverColor = System.Drawing.Color.Silver;
            uiButton1.RectPressColor = System.Drawing.Color.Silver;
            uiButton1.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton1.Size = new System.Drawing.Size(145, 50);
            uiButton1.TabIndex = 110;
            uiButton1.Text = "保存";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click_1;
            // 
            // uiButton5
            // 
            uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton5.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton5.FillColor2 = System.Drawing.Color.Gray;
            uiButton5.FillColorGradient = true;
            uiButton5.FillHoverColor = System.Drawing.Color.Silver;
            uiButton5.FillPressColor = System.Drawing.Color.Gray;
            uiButton5.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton5.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.ForeColor = System.Drawing.Color.Black;
            uiButton5.ForeHoverColor = System.Drawing.Color.Black;
            uiButton5.ForePressColor = System.Drawing.Color.Black;
            uiButton5.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton5.Location = new System.Drawing.Point(1051, 112);
            uiButton5.Margin = new System.Windows.Forms.Padding(2);
            uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.RectColor = System.Drawing.Color.Silver;
            uiButton5.RectHoverColor = System.Drawing.Color.Silver;
            uiButton5.RectPressColor = System.Drawing.Color.Silver;
            uiButton5.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton5.Size = new System.Drawing.Size(145, 50);
            uiButton5.TabIndex = 111;
            uiButton5.Text = "上移";
            uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Click += uiButton5_Click;
            // 
            // uiButton6
            // 
            uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton6.FillColor = System.Drawing.Color.FromArgb(224, 224, 224);
            uiButton6.FillColor2 = System.Drawing.Color.Gray;
            uiButton6.FillColorGradient = true;
            uiButton6.FillHoverColor = System.Drawing.Color.Silver;
            uiButton6.FillPressColor = System.Drawing.Color.Gray;
            uiButton6.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton6.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.ForeColor = System.Drawing.Color.Black;
            uiButton6.ForeHoverColor = System.Drawing.Color.Black;
            uiButton6.ForePressColor = System.Drawing.Color.Black;
            uiButton6.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton6.Location = new System.Drawing.Point(1051, 198);
            uiButton6.Margin = new System.Windows.Forms.Padding(2);
            uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton6.Name = "uiButton6";
            uiButton6.RectColor = System.Drawing.Color.Silver;
            uiButton6.RectHoverColor = System.Drawing.Color.Silver;
            uiButton6.RectPressColor = System.Drawing.Color.Silver;
            uiButton6.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton6.Size = new System.Drawing.Size(145, 50);
            uiButton6.TabIndex = 112;
            uiButton6.Text = "下降";
            uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Click += uiButton6_Click;
            // 
            // tbxLength
            // 
            tbxLength.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxLength.Location = new System.Drawing.Point(1059, 701);
            tbxLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxLength.MinimumSize = new System.Drawing.Size(1, 16);
            tbxLength.Name = "tbxLength";
            tbxLength.Padding = new System.Windows.Forms.Padding(5);
            tbxLength.ShowText = false;
            tbxLength.Size = new System.Drawing.Size(136, 46);
            tbxLength.TabIndex = 113;
            tbxLength.Text = "0";
            tbxLength.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            tbxLength.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            tbxLength.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(1051, 654);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(145, 42);
            uiLabel1.TabIndex = 114;
            uiLabel1.Text = "数组长度";
            // 
            // PageAlarmArrayConfig
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Gainsboro;
            ClientSize = new System.Drawing.Size(1216, 778);
            Controls.Add(uiLabel1);
            Controls.Add(tbxLength);
            Controls.Add(uiButton6);
            Controls.Add(uiButton5);
            Controls.Add(uiButton1);
            Controls.Add(uiButton2);
            Controls.Add(uiButton4);
            Controls.Add(uiButton3);
            Controls.Add(dgv);
            Name = "PageAlarmArrayConfig";
            Text = "PLC报警信息配置";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            Load += Page_PLCAlarmConfigcs_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView dgv;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn column_AlarmType;
        private Sunny.UI.UITextBox tbxLength;
        private Sunny.UI.UILabel uiLabel1;
    }
}