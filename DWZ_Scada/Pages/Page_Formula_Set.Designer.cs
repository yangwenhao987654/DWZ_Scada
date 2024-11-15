namespace DWZ_Scada.Pages
{
    partial class Page_Formula_Set
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
            tbx_input = new Sunny.UI.UITextBox();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            dgv = new Sunny.UI.UIDataGridView();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // tbx_input
            // 
            tbx_input.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            tbx_input.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_input.ForeReadOnlyColor = System.Drawing.Color.FromArgb(255, 224, 192);
            tbx_input.Location = new System.Drawing.Point(48, 28);
            tbx_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_input.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_input.Name = "tbx_input";
            tbx_input.Padding = new System.Windows.Forms.Padding(5);
            tbx_input.RectColor = System.Drawing.Color.Snow;
            tbx_input.RectReadOnlyColor = System.Drawing.Color.FromArgb(255, 192, 192);
            tbx_input.ShowText = false;
            tbx_input.Size = new System.Drawing.Size(360, 50);
            tbx_input.TabIndex = 45;
            tbx_input.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_input.Watermark = "请输入产品编号";
            // 
            // uiButton1
            // 
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton1.FillColor2 = System.Drawing.Color.WhiteSmoke;
            uiButton1.FillHoverColor = System.Drawing.Color.Silver;
            uiButton1.FillPressColor = System.Drawing.Color.Gray;
            uiButton1.FillSelectedColor = System.Drawing.Color.Silver;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.ForeColor = System.Drawing.Color.Black;
            uiButton1.ForeHoverColor = System.Drawing.Color.Black;
            uiButton1.ForePressColor = System.Drawing.Color.Black;
            uiButton1.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton1.Location = new System.Drawing.Point(440, 28);
            uiButton1.Margin = new System.Windows.Forms.Padding(2);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = System.Drawing.Color.Silver;
            uiButton1.RectHoverColor = System.Drawing.Color.Silver;
            uiButton1.RectPressColor = System.Drawing.Color.Gray;
            uiButton1.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton1.Size = new System.Drawing.Size(145, 50);
            uiButton1.TabIndex = 54;
            uiButton1.Text = "添加";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton2.FillColor2 = System.Drawing.Color.Gray;
            uiButton2.FillHoverColor = System.Drawing.Color.Silver;
            uiButton2.FillPressColor = System.Drawing.Color.Gray;
            uiButton2.FillSelectedColor = System.Drawing.Color.Silver;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.ForeColor = System.Drawing.Color.Black;
            uiButton2.ForeHoverColor = System.Drawing.Color.Black;
            uiButton2.ForePressColor = System.Drawing.Color.Black;
            uiButton2.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton2.Location = new System.Drawing.Point(626, 28);
            uiButton2.Margin = new System.Windows.Forms.Padding(2);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = System.Drawing.Color.Silver;
            uiButton2.RectHoverColor = System.Drawing.Color.Silver;
            uiButton2.RectPressColor = System.Drawing.Color.Gray;
            uiButton2.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton2.Size = new System.Drawing.Size(145, 50);
            uiButton2.TabIndex = 55;
            uiButton2.Text = "删除";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiButton3
            // 
            uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton3.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton3.FillColor2 = System.Drawing.Color.Gray;
            uiButton3.FillHoverColor = System.Drawing.Color.Silver;
            uiButton3.FillPressColor = System.Drawing.Color.Gray;
            uiButton3.FillSelectedColor = System.Drawing.Color.Silver;
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.ForeColor = System.Drawing.Color.Black;
            uiButton3.ForeHoverColor = System.Drawing.Color.Black;
            uiButton3.ForePressColor = System.Drawing.Color.Black;
            uiButton3.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton3.Location = new System.Drawing.Point(817, 28);
            uiButton3.Margin = new System.Windows.Forms.Padding(2);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = System.Drawing.Color.Silver;
            uiButton3.RectHoverColor = System.Drawing.Color.Silver;
            uiButton3.RectPressColor = System.Drawing.Color.Gray;
            uiButton3.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton3.Size = new System.Drawing.Size(145, 50);
            uiButton3.TabIndex = 56;
            uiButton3.Text = "修改";
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
            uiButton4.FillSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.ForeColor = System.Drawing.Color.Black;
            uiButton4.ForeHoverColor = System.Drawing.Color.Black;
            uiButton4.ForePressColor = System.Drawing.Color.Black;
            uiButton4.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton4.Location = new System.Drawing.Point(1003, 28);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { dataGridViewTextBoxColumn1, Column1, dataGridViewTextBoxColumn2, Column3, Column4, Column2 });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle3;
            dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dgv.GridColor = System.Drawing.Color.DimGray;
            dgv.Location = new System.Drawing.Point(0, 134);
            dgv.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RectColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.NavajoWhite;
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv.RowTemplate.Height = 35;
            dgv.SelectedIndex = -1;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new System.Drawing.Size(1280, 644);
            dgv.StripeOddColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dgv.TabIndex = 58;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "序号";
            dataGridViewTextBoxColumn1.MinimumWidth = 100;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            Column1.FillWeight = 120F;
            Column1.HeaderText = "类型";
            Column1.MinimumWidth = 120;
            Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 200F;
            dataGridViewTextBoxColumn2.HeaderText = "名称";
            dataGridViewTextBoxColumn2.MinimumWidth = 150;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Column3
            // 
            Column3.FillWeight = 353.962616F;
            Column3.HeaderText = "编号";
            Column3.MinimumWidth = 350;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            Column4.FillWeight = 200F;
            Column4.HeaderText = "PLC地址";
            Column4.MinimumWidth = 200;
            Column4.Name = "Column4";
            Column4.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "ID";
            Column2.Name = "Column2";
            Column2.Visible = false;
            // 
            // Page_Formula_Set
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1280, 778);
            Controls.Add(dgv);
            Controls.Add(uiButton4);
            Controls.Add(uiButton3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(tbx_input);
            Name = "Page_Formula_Set";
            RectColor = System.Drawing.Color.Black;
            Text = "";
            TitleHeight = 29;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            FormClosing += Formula_set_FormClosing;
            Load += Page_Formula_Set_Load;
            SizeChanged += Page_Formula_Set_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox tbx_input;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}