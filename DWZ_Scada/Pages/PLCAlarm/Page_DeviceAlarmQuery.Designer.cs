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
            tbx_AlarmName = new Sunny.UI.UITextBox();
            uiButton4 = new Sunny.UI.UIButton();
            dataGridView1 = new Sunny.UI.UIDataGridView();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dp_AlarmStartTime = new Sunny.UI.UIDatetimePicker();
            dp_AlarmEndTime = new Sunny.UI.UIDatetimePicker();
            dp_date = new Sunny.UI.UIDatePicker();
            radioBtn_Alarmdate = new System.Windows.Forms.RadioButton();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiGroupBox3 = new Sunny.UI.UIGroupBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            radioBtn_Alarmtime = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            uiGroupBox1.SuspendLayout();
            uiGroupBox3.SuspendLayout();
            uiGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tbx_AlarmName
            // 
            tbx_AlarmName.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            tbx_AlarmName.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_AlarmName.Location = new System.Drawing.Point(14, 37);
            tbx_AlarmName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_AlarmName.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_AlarmName.Name = "tbx_AlarmName";
            tbx_AlarmName.Padding = new System.Windows.Forms.Padding(5);
            tbx_AlarmName.RectColor = System.Drawing.Color.Silver;
            tbx_AlarmName.ShowText = false;
            tbx_AlarmName.Size = new System.Drawing.Size(302, 46);
            tbx_AlarmName.TabIndex = 45;
            tbx_AlarmName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_AlarmName.Watermark = "请输入报警名称";
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
            uiButton4.Location = new System.Drawing.Point(1101, 71);
            uiButton4.Margin = new System.Windows.Forms.Padding(2);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.RectColor = System.Drawing.Color.Silver;
            uiButton4.RectHoverColor = System.Drawing.Color.Silver;
            uiButton4.RectPressColor = System.Drawing.Color.Gray;
            uiButton4.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Size = new System.Drawing.Size(140, 50);
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
            dataGridView1.Location = new System.Drawing.Point(0, 184);
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
            dataGridView1.Size = new System.Drawing.Size(1280, 594);
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
            // dp_AlarmStartTime
            // 
            dp_AlarmStartTime.FillColor = System.Drawing.Color.White;
            dp_AlarmStartTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dp_AlarmStartTime.Location = new System.Drawing.Point(166, 37);
            dp_AlarmStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dp_AlarmStartTime.MaxLength = 19;
            dp_AlarmStartTime.MinimumSize = new System.Drawing.Size(63, 0);
            dp_AlarmStartTime.Name = "dp_AlarmStartTime";
            dp_AlarmStartTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            dp_AlarmStartTime.Size = new System.Drawing.Size(258, 46);
            dp_AlarmStartTime.SymbolDropDown = 61555;
            dp_AlarmStartTime.SymbolNormal = 61555;
            dp_AlarmStartTime.SymbolSize = 24;
            dp_AlarmStartTime.TabIndex = 59;
            dp_AlarmStartTime.Text = "2024-09-21 09:44:35";
            dp_AlarmStartTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            dp_AlarmStartTime.Value = new System.DateTime(2024, 9, 21, 9, 44, 35, 145);
            dp_AlarmStartTime.Watermark = "";
            // 
            // dp_AlarmEndTime
            // 
            dp_AlarmEndTime.FillColor = System.Drawing.Color.White;
            dp_AlarmEndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dp_AlarmEndTime.Location = new System.Drawing.Point(166, 93);
            dp_AlarmEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dp_AlarmEndTime.MaxLength = 19;
            dp_AlarmEndTime.MinimumSize = new System.Drawing.Size(63, 0);
            dp_AlarmEndTime.Name = "dp_AlarmEndTime";
            dp_AlarmEndTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            dp_AlarmEndTime.Size = new System.Drawing.Size(258, 46);
            dp_AlarmEndTime.SymbolDropDown = 61555;
            dp_AlarmEndTime.SymbolNormal = 61555;
            dp_AlarmEndTime.SymbolSize = 24;
            dp_AlarmEndTime.TabIndex = 60;
            dp_AlarmEndTime.Text = "2024-09-21 09:44:35";
            dp_AlarmEndTime.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            dp_AlarmEndTime.Value = new System.DateTime(2024, 9, 21, 9, 44, 35, 145);
            dp_AlarmEndTime.Watermark = "";
            // 
            // dp_date
            // 
            dp_date.FillColor = System.Drawing.Color.White;
            dp_date.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dp_date.Location = new System.Drawing.Point(14, 91);
            dp_date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dp_date.MaxLength = 10;
            dp_date.MinimumSize = new System.Drawing.Size(63, 0);
            dp_date.Name = "dp_date";
            dp_date.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            dp_date.Size = new System.Drawing.Size(302, 46);
            dp_date.SymbolDropDown = 61555;
            dp_date.SymbolNormal = 61555;
            dp_date.SymbolSize = 24;
            dp_date.TabIndex = 61;
            dp_date.Text = "2024-09-21";
            dp_date.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            dp_date.Value = new System.DateTime(2024, 9, 21, 9, 45, 31, 274);
            dp_date.Watermark = "";
            // 
            // radioBtn_Alarmdate
            // 
            radioBtn_Alarmdate.AutoSize = true;
            radioBtn_Alarmdate.Location = new System.Drawing.Point(30, 50);
            radioBtn_Alarmdate.Name = "radioBtn_Alarmdate";
            radioBtn_Alarmdate.Size = new System.Drawing.Size(147, 24);
            radioBtn_Alarmdate.TabIndex = 0;
            radioBtn_Alarmdate.TabStop = true;
            radioBtn_Alarmdate.Text = "按照报警日期";
            radioBtn_Alarmdate.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiGroupBox3);
            uiGroupBox1.Controls.Add(uiGroupBox2);
            uiGroupBox1.Controls.Add(uiButton4);
            uiGroupBox1.Controls.Add(radioBtn_Alarmtime);
            uiGroupBox1.Controls.Add(radioBtn_Alarmdate);
            uiGroupBox1.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new System.Drawing.Point(0, 5);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new System.Drawing.Size(1267, 172);
            uiGroupBox1.TabIndex = 62;
            uiGroupBox1.Text = "报警查询";
            uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox3
            // 
            uiGroupBox3.Controls.Add(uiLabel2);
            uiGroupBox3.Controls.Add(uiLabel3);
            uiGroupBox3.Controls.Add(dp_AlarmStartTime);
            uiGroupBox3.Controls.Add(dp_AlarmEndTime);
            uiGroupBox3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox3.Location = new System.Drawing.Point(576, 22);
            uiGroupBox3.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox3.Name = "uiGroupBox3";
            uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox3.Size = new System.Drawing.Size(474, 150);
            uiGroupBox3.TabIndex = 65;
            uiGroupBox3.Text = "报警时间";
            uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(13, 49);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(117, 23);
            uiLabel2.TabIndex = 63;
            uiLabel2.Text = "开始时间:";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(12, 106);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(118, 23);
            uiLabel3.TabIndex = 64;
            uiLabel3.Text = "结束时间:";
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(dp_date);
            uiGroupBox2.Controls.Add(tbx_AlarmName);
            uiGroupBox2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox2.Location = new System.Drawing.Point(218, 17);
            uiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox2.Size = new System.Drawing.Size(336, 150);
            uiGroupBox2.TabIndex = 63;
            uiGroupBox2.Text = "报警日期";
            uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioBtn_Alarmtime
            // 
            radioBtn_Alarmtime.AutoSize = true;
            radioBtn_Alarmtime.Location = new System.Drawing.Point(30, 110);
            radioBtn_Alarmtime.Name = "radioBtn_Alarmtime";
            radioBtn_Alarmtime.Size = new System.Drawing.Size(147, 24);
            radioBtn_Alarmtime.TabIndex = 1;
            radioBtn_Alarmtime.TabStop = true;
            radioBtn_Alarmtime.Text = "按照报警时间";
            radioBtn_Alarmtime.UseVisualStyleBackColor = true;
            // 
            // Page_DeviceAlarmQuery
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1280, 778);
            Controls.Add(uiGroupBox1);
            Controls.Add(dataGridView1);
            Name = "Page_DeviceAlarmQuery";
            RectColor = System.Drawing.Color.Black;
            Text = "";
            TitleHeight = 29;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            FormClosing += Formula_set_FormClosing;
            Load += Page_DeviceAlarmQuery_Load;
            SizeChanged += Page_DeviceAlarmQuery_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            uiGroupBox3.ResumeLayout(false);
            uiGroupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox tbx_AlarmName;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIDataGridView dataGridView1;
        private Sunny.UI.UIDatetimePicker dp_AlarmStartTime;
        private Sunny.UI.UIDatetimePicker dp_AlarmEndTime;
        private Sunny.UI.UIDatePicker dp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.RadioButton radioBtn_Alarmdate;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.RadioButton radioBtn_Alarmtime;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox3;
    }
}