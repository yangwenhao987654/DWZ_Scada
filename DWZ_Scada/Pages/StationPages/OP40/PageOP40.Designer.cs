namespace DWZ_Scada.Pages.StationPages.OP40
{
    partial class PageOP40
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
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel42 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            lbl_humidity = new Sunny.UI.UILabel();
            lbl_temperature = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            lbl_Pressure = new Sunny.UI.UILabel();
            uiLabel11 = new Sunny.UI.UILabel();
            dgv = new Sunny.UI.UIDataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            light_Pre = new Sunny.UI.UILight();
            lbl_PressureMsg = new Sunny.UI.UILabel();
            workOrderCtrlWithoutPart2 = new ctrls.workOrderCtrlWithoutPart();
            userCtrlEntry_OP40 = new DIPTest.Ctrl.UserCtrlEntry();
            userCtrlResult_Welding = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlResult_Vision = new DIPTest.Ctrl.UserCtrlResult();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1223, 59);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "OP40-TIG电焊工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(23, 171);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(120, 30);
            uiLabel2.TabIndex = 17;
            uiLabel2.Text = "画像检测:";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(18, 439);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(122, 30);
            uiLabel3.TabIndex = 18;
            uiLabel3.Text = "焊接数据:";
            // 
            // uiLabel42
            // 
            uiLabel42.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel42.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel42.Location = new System.Drawing.Point(469, 171);
            uiLabel42.Name = "uiLabel42";
            uiLabel42.Size = new System.Drawing.Size(120, 30);
            uiLabel42.TabIndex = 63;
            uiLabel42.Text = "TIG焊接:";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new System.Drawing.Point(902, 171);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new System.Drawing.Size(199, 38);
            uiLabel8.TabIndex = 64;
            uiLabel8.Text = "OP40产品进站:";
            uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel8.Click += uiLabel8_Click;
            // 
            // lbl_humidity
            // 
            lbl_humidity.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            lbl_humidity.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_humidity.Location = new System.Drawing.Point(1019, 572);
            lbl_humidity.Name = "lbl_humidity";
            lbl_humidity.Size = new System.Drawing.Size(192, 34);
            lbl_humidity.TabIndex = 70;
            lbl_humidity.Text = "0";
            // 
            // lbl_temperature
            // 
            lbl_temperature.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            lbl_temperature.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_temperature.Location = new System.Drawing.Point(1019, 513);
            lbl_temperature.Name = "lbl_temperature";
            lbl_temperature.Size = new System.Drawing.Size(192, 42);
            lbl_temperature.TabIndex = 69;
            lbl_temperature.Text = "0";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(940, 572);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(73, 45);
            uiLabel4.TabIndex = 68;
            uiLabel4.Text = "湿度:";
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new System.Drawing.Point(940, 513);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new System.Drawing.Size(82, 45);
            uiLabel9.TabIndex = 67;
            uiLabel9.Text = "温度:";
            // 
            // lbl_Pressure
            // 
            lbl_Pressure.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            lbl_Pressure.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_Pressure.Location = new System.Drawing.Point(1019, 647);
            lbl_Pressure.Name = "lbl_Pressure";
            lbl_Pressure.Size = new System.Drawing.Size(196, 43);
            lbl_Pressure.TabIndex = 72;
            lbl_Pressure.Text = "0";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(921, 637);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(92, 79);
            uiLabel11.TabIndex = 71;
            uiLabel11.Text = "氩气瓶压   力:";
            uiLabel11.Click += uiLabel11_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(235, 243, 255);
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersVisible = false;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.Enabled = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.GridColor = System.Drawing.Color.FromArgb(80, 160, 255);
            dgv.Location = new System.Drawing.Point(23, 476);
            dgv.Name = "dgv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            dgv.RowTemplate.Height = 50;
            dgv.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            dgv.SelectedIndex = -1;
            dgv.Size = new System.Drawing.Size(858, 302);
            dgv.StripeOddColor = System.Drawing.Color.FromArgb(235, 243, 255);
            dgv.TabIndex = 75;
            // 
            // Column1
            // 
            Column1.HeaderText = "气体A";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "值";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "气体B";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "值";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "气体C";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "值";
            Column6.Name = "Column6";
            // 
            // light_Pre
            // 
            light_Pre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            light_Pre.Location = new System.Drawing.Point(930, 719);
            light_Pre.MinimumSize = new System.Drawing.Size(1, 1);
            light_Pre.Name = "light_Pre";
            light_Pre.OffColor = System.Drawing.Color.Red;
            light_Pre.Radius = 35;
            light_Pre.Size = new System.Drawing.Size(35, 35);
            light_Pre.TabIndex = 76;
            light_Pre.Text = "uiLight1";
            // 
            // lbl_PressureMsg
            // 
            lbl_PressureMsg.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_PressureMsg.ForeColor = System.Drawing.Color.Red;
            lbl_PressureMsg.Location = new System.Drawing.Point(997, 719);
            lbl_PressureMsg.Name = "lbl_PressureMsg";
            lbl_PressureMsg.Size = new System.Drawing.Size(198, 45);
            lbl_PressureMsg.TabIndex = 77;
            // 
            // workOrderCtrlWithoutPart2
            // 
            workOrderCtrlWithoutPart2.BackColor = System.Drawing.Color.Transparent;
            workOrderCtrlWithoutPart2.CurPartNo = "";
            workOrderCtrlWithoutPart2.CurProductCode = "";
            workOrderCtrlWithoutPart2.CurProductName = "";
            workOrderCtrlWithoutPart2.CurWorkOrderNo = "";
            workOrderCtrlWithoutPart2.IsCheckPass = true;
            workOrderCtrlWithoutPart2.Location = new System.Drawing.Point(0, 62);
            workOrderCtrlWithoutPart2.Name = "workOrderCtrlWithoutPart2";
            workOrderCtrlWithoutPart2.Orders = null;
            workOrderCtrlWithoutPart2.Size = new System.Drawing.Size(1195, 75);
            workOrderCtrlWithoutPart2.SpotEnable = false;
            workOrderCtrlWithoutPart2.TabIndex = 78;
            // 
            // userCtrlEntry_OP40
            // 
            userCtrlEntry_OP40.Location = new System.Drawing.Point(902, 226);
            userCtrlEntry_OP40.Margin = new System.Windows.Forms.Padding(4);
            userCtrlEntry_OP40.Name = "userCtrlEntry_OP40";
            userCtrlEntry_OP40.Size = new System.Drawing.Size(313, 168);
            userCtrlEntry_OP40.TabIndex = 79;
            userCtrlEntry_OP40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlEntry_OP40.TextFont = new System.Drawing.Font("微软雅黑", 50F);
            // 
            // userCtrlResult_Welding
            // 
            userCtrlResult_Welding.Location = new System.Drawing.Point(469, 226);
            userCtrlResult_Welding.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult_Welding.Name = "userCtrlResult_Welding";
            userCtrlResult_Welding.Size = new System.Drawing.Size(313, 168);
            userCtrlResult_Welding.TabIndex = 80;
            userCtrlResult_Welding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult_Welding.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlResult_Vision
            // 
            userCtrlResult_Vision.Location = new System.Drawing.Point(23, 226);
            userCtrlResult_Vision.Margin = new System.Windows.Forms.Padding(4);
            userCtrlResult_Vision.Name = "userCtrlResult_Vision";
            userCtrlResult_Vision.Size = new System.Drawing.Size(313, 168);
            userCtrlResult_Vision.TabIndex = 81;
            userCtrlResult_Vision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlResult_Vision.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // PageOP40
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1223, 821);
            Controls.Add(userCtrlResult_Vision);
            Controls.Add(userCtrlResult_Welding);
            Controls.Add(userCtrlEntry_OP40);
            Controls.Add(workOrderCtrlWithoutPart2);
            Controls.Add(lbl_PressureMsg);
            Controls.Add(light_Pre);
            Controls.Add(dgv);
            Controls.Add(lbl_Pressure);
            Controls.Add(uiLabel11);
            Controls.Add(lbl_humidity);
            Controls.Add(lbl_temperature);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel9);
            Controls.Add(uiLabel8);
            Controls.Add(uiLabel42);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP40";
            Text = "OP40";
            TitleFillColor = System.Drawing.Color.Transparent;
            FormClosing += PageOP40_FormClosing;
            Load += Page_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel42;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel lbl_humidity;
        private Sunny.UI.UILabel lbl_temperature;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel lbl_Pressure;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UIDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private Sunny.UI.UILight light_Pre;
        private Sunny.UI.UILabel lbl_PressureMsg;
        private ctrls.workOrderCtrlWithoutPart workOrderCtrlWithoutPart2;
        private DIPTest.Ctrl.UserCtrlEntry userCtrlEntry_OP40;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult_Welding;
        private DIPTest.Ctrl.UserCtrlResult userCtrlResult_Vision;
    }
}