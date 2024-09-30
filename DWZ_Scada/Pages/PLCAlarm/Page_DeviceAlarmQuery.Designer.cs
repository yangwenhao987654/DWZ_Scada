namespace DWZ_Scada.Pages
{
    partial class Page_DeviceAlarmQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiButton4 = new Sunny.UI.UIButton();
            dataGridView1 = new Sunny.UI.UIDataGridView();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            uiDatetimePicker1 = new Sunny.UI.UIDatetimePicker();
            uiDatetimePicker2 = new Sunny.UI.UIDatetimePicker();
            dp_date = new Sunny.UI.UIDatePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // uiTextBox1
            // 
            uiTextBox1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiTextBox1.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox1.Location = new System.Drawing.Point(200, 18);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            uiTextBox1.RectColor = System.Drawing.Color.Silver;
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(495, 68);
            uiTextBox1.TabIndex = 45;
            uiTextBox1.Text = "请输入报警名称";
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "";
            // 
            // uiButton4
            // 
            uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton4.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton4.FillColor2 = System.Drawing.Color.Gray;
            uiButton4.FillHoverColor = System.Drawing.Color.Silver;
            uiButton4.FillPressColor = System.Drawing.Color.Gray;
            uiButton4.FillSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.ForeColor = System.Drawing.Color.Black;
            uiButton4.ForeHoverColor = System.Drawing.Color.Black;
            uiButton4.ForePressColor = System.Drawing.Color.Black;
            uiButton4.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton4.Location = new System.Drawing.Point(718, 20);
            uiButton4.Margin = new System.Windows.Forms.Padding(2);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.RectColor = System.Drawing.Color.Silver;
            uiButton4.RectHoverColor = System.Drawing.Color.Silver;
            uiButton4.RectPressColor = System.Drawing.Color.Gray;
            uiButton4.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Size = new System.Drawing.Size(145, 50);
            uiButton4.TabIndex = 57;
            uiButton4.Text = "查询";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { dataGridViewTextBoxColumn1, Column2, dataGridViewTextBoxColumn2, Column3, Column4, Column1 });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridView1.Location = new System.Drawing.Point(0, 110);
            dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RectColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.ScrollBarColor = System.Drawing.Color.Silver;
            dataGridView1.ScrollBarRectColor = System.Drawing.Color.Silver;
            dataGridView1.ScrollBarStyleInherited = false;
            dataGridView1.SelectedIndex = -1;
            dataGridView1.Size = new System.Drawing.Size(1912, 668);
            dataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridView1.TabIndex = 58;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "序号";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column2
            // 
            Column2.HeaderText = "设备名称";
            Column2.Name = "Column2";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "报警名称";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Column3
            // 
            Column3.HeaderText = "报警类型";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "报警日期";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column1
            // 
            Column1.HeaderText = "报警时间";
            Column1.Name = "Column1";
            // 
            // uiDatetimePicker1
            // 
            uiDatetimePicker1.FillColor = System.Drawing.Color.White;
            uiDatetimePicker1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiDatetimePicker1.Location = new System.Drawing.Point(947, 20);
            uiDatetimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiDatetimePicker1.MaxLength = 19;
            uiDatetimePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            uiDatetimePicker1.Name = "uiDatetimePicker1";
            uiDatetimePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            uiDatetimePicker1.Size = new System.Drawing.Size(288, 66);
            uiDatetimePicker1.SymbolDropDown = 61555;
            uiDatetimePicker1.SymbolNormal = 61555;
            uiDatetimePicker1.SymbolSize = 24;
            uiDatetimePicker1.TabIndex = 59;
            uiDatetimePicker1.Text = "2024-09-21 09:44:35";
            uiDatetimePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiDatetimePicker1.Value = new System.DateTime(2024, 9, 21, 9, 44, 35, 145);
            uiDatetimePicker1.Watermark = "";
            // 
            // uiDatetimePicker2
            // 
            uiDatetimePicker2.FillColor = System.Drawing.Color.White;
            uiDatetimePicker2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiDatetimePicker2.Location = new System.Drawing.Point(1296, 20);
            uiDatetimePicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiDatetimePicker2.MaxLength = 19;
            uiDatetimePicker2.MinimumSize = new System.Drawing.Size(63, 0);
            uiDatetimePicker2.Name = "uiDatetimePicker2";
            uiDatetimePicker2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            uiDatetimePicker2.Size = new System.Drawing.Size(288, 66);
            uiDatetimePicker2.SymbolDropDown = 61555;
            uiDatetimePicker2.SymbolNormal = 61555;
            uiDatetimePicker2.SymbolSize = 24;
            uiDatetimePicker2.TabIndex = 60;
            uiDatetimePicker2.Text = "2024-09-21 09:44:35";
            uiDatetimePicker2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiDatetimePicker2.Value = new System.DateTime(2024, 9, 21, 9, 44, 35, 145);
            uiDatetimePicker2.Watermark = "";
            // 
            // dp_date
            // 
            dp_date.FillColor = System.Drawing.Color.White;
            dp_date.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dp_date.Location = new System.Drawing.Point(13, 30);
            dp_date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dp_date.MaxLength = 10;
            dp_date.MinimumSize = new System.Drawing.Size(63, 0);
            dp_date.Name = "dp_date";
            dp_date.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            dp_date.Size = new System.Drawing.Size(167, 41);
            dp_date.SymbolDropDown = 61555;
            dp_date.SymbolNormal = 61555;
            dp_date.SymbolSize = 24;
            dp_date.TabIndex = 61;
            dp_date.Text = "2024-09-21";
            dp_date.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            dp_date.Value = new System.DateTime(2024, 9, 21, 9, 45, 31, 274);
            dp_date.Watermark = "";
            // 
            // Page_DeviceAlarmQuery
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1912, 778);
            Controls.Add(dp_date);
            Controls.Add(uiDatetimePicker2);
            Controls.Add(uiDatetimePicker1);
            Controls.Add(dataGridView1);
            Controls.Add(uiButton4);
            Controls.Add(uiTextBox1);
            Name = "Page_DeviceAlarmQuery";
            RectColor = System.Drawing.Color.Black;
            Text = "";
            TitleHeight = 29;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            FormClosing += Formula_set_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIDataGridView dataGridView1;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker1;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker2;
        private Sunny.UI.UIDatePicker dp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}