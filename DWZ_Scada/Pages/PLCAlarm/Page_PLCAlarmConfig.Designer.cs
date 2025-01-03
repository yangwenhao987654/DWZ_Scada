﻿namespace DWZ_Scada.Page.PLCControl
{
    partial class Page_PLCAlarmConfig
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
            dgv = new Sunny.UI.UIDataGridView();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            column_AlarmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            column_IsArray = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            column_Btn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column3, Column1, Column2, column_AlarmType, column_IsArray, column_Btn });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.GridColor = System.Drawing.Color.Gray;
            dgv.Location = new System.Drawing.Point(0, 106);
            dgv.Name = "dgv";
            dgv.RectColor = System.Drawing.Color.Gray;
            dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv.RowTemplate.Height = 35;
            dgv.ScrollBarColor = System.Drawing.Color.Silver;
            dgv.ScrollBarHandleHeight = 12;
            dgv.ScrollBarHandleWidth = 12;
            dgv.ScrollBarHeight = 10;
            dgv.ScrollBarRectColor = System.Drawing.Color.Silver;
            dgv.ScrollBarStyleInherited = false;
            dgv.ScrollBarWidth = 10;
            dgv.SelectedIndex = -1;
            dgv.Size = new System.Drawing.Size(1280, 672);
            dgv.StripeOddColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dgv.TabIndex = 102;
            dgv.CellClick += dgv_CellClick;
            dgv.CellContentClick += dgv_CellContentClick;
            dgv.CellMouseClick += dgv_CellMouseClick;
            dgv.RowHeaderMouseClick += dgv_RowHeaderMouseClick;
            dgv.SelectionChanged += dgv_SelectionChanged;
            // 
            // uiButton3
            // 
            uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton3.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton3.FillColor2 = System.Drawing.Color.Gray;
            uiButton3.FillHoverColor = System.Drawing.Color.Silver;
            uiButton3.FillPressColor = System.Drawing.Color.Gray;
            uiButton3.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.ForeColor = System.Drawing.Color.Black;
            uiButton3.ForeHoverColor = System.Drawing.Color.Black;
            uiButton3.ForePressColor = System.Drawing.Color.Black;
            uiButton3.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton3.Location = new System.Drawing.Point(47, 34);
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
            uiButton4.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton4.FillColor2 = System.Drawing.Color.Gray;
            uiButton4.FillHoverColor = System.Drawing.Color.Silver;
            uiButton4.FillPressColor = System.Drawing.Color.Gray;
            uiButton4.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.ForeColor = System.Drawing.Color.Black;
            uiButton4.ForeHoverColor = System.Drawing.Color.Black;
            uiButton4.ForePressColor = System.Drawing.Color.Black;
            uiButton4.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton4.Location = new System.Drawing.Point(710, 34);
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
            uiButton2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton2.FillColor2 = System.Drawing.Color.Gray;
            uiButton2.FillHoverColor = System.Drawing.Color.Silver;
            uiButton2.FillPressColor = System.Drawing.Color.Gray;
            uiButton2.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.ForeColor = System.Drawing.Color.Black;
            uiButton2.ForeHoverColor = System.Drawing.Color.Black;
            uiButton2.ForePressColor = System.Drawing.Color.Black;
            uiButton2.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton2.Location = new System.Drawing.Point(269, 34);
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
            uiButton1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton1.FillColor2 = System.Drawing.Color.Gray;
            uiButton1.FillHoverColor = System.Drawing.Color.Silver;
            uiButton1.FillPressColor = System.Drawing.Color.Gray;
            uiButton1.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.ForeColor = System.Drawing.Color.Black;
            uiButton1.ForeHoverColor = System.Drawing.Color.Black;
            uiButton1.ForePressColor = System.Drawing.Color.Black;
            uiButton1.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton1.Location = new System.Drawing.Point(913, 34);
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
            uiButton5.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton5.FillColor2 = System.Drawing.Color.Gray;
            uiButton5.FillHoverColor = System.Drawing.Color.Silver;
            uiButton5.FillPressColor = System.Drawing.Color.Gray;
            uiButton5.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton5.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.ForeColor = System.Drawing.Color.Black;
            uiButton5.ForeHoverColor = System.Drawing.Color.Black;
            uiButton5.ForePressColor = System.Drawing.Color.Black;
            uiButton5.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton5.Location = new System.Drawing.Point(485, 34);
            uiButton5.Margin = new System.Windows.Forms.Padding(2);
            uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.RectColor = System.Drawing.Color.Silver;
            uiButton5.RectHoverColor = System.Drawing.Color.Silver;
            uiButton5.RectPressColor = System.Drawing.Color.Silver;
            uiButton5.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton5.Size = new System.Drawing.Size(145, 50);
            uiButton5.TabIndex = 111;
            uiButton5.Text = "插入";
            uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Click += uiButton5_Click;
            // 
            // Column3
            // 
            Column3.HeaderText = "序号";
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
            // column_IsArray
            // 
            column_IsArray.HeaderText = "是否数组";
            column_IsArray.Name = "column_IsArray";
            // 
            // column_Btn
            // 
            column_Btn.HeaderText = "报警数组";
            column_Btn.Name = "column_Btn";
            column_Btn.Text = "报警详情配置";
            column_Btn.UseColumnTextForButtonValue = true;
            // 
            // Page_PLCAlarmConfig
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1280, 778);
            Controls.Add(uiButton5);
            Controls.Add(uiButton1);
            Controls.Add(uiButton2);
            Controls.Add(uiButton4);
            Controls.Add(uiButton3);
            Controls.Add(dgv);
            Name = "Page_PLCAlarmConfig";
            Text = "PLC报警信息配置";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            Load += Page_PLCAlarmConfigcs_Load;
            SizeChanged += Page_PLCAlarmConfig_SizeChanged;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn column_AlarmType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_IsArray;
        private System.Windows.Forms.DataGridViewButtonColumn column_Btn;
    }
}