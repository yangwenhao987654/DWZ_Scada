using Sunny.UI;
using System.Windows.Forms;

namespace DWZ_Scada
{
    partial class Page_PLCAddress
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            textBox_IP = new UITextBox();
            label1 = new Label();
            label2 = new Label();
            textBox_DK = new UITextBox();
            label3 = new Label();
            textBox_ID = new UITextBox();
            dataGridView1 = new UIDataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            comboBox1 = new UIComboBox();
            button4 = new UIButton();
            button3 = new UIButton();
            textBox4 = new UITextBox();
            button1 = new UIButton();
            label5 = new Label();
            timer1 = new Timer(components);
            label4 = new Label();
            button2 = new UIButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox_IP
            // 
            textBox_IP.Cursor = Cursors.IBeam;
            textBox_IP.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox_IP.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            textBox_IP.Location = new System.Drawing.Point(86, 45);
            textBox_IP.Margin = new Padding(2);
            textBox_IP.MinimumSize = new System.Drawing.Size(1, 16);
            textBox_IP.Name = "textBox_IP";
            textBox_IP.Padding = new Padding(5);
            textBox_IP.RectColor = System.Drawing.Color.Gray;
            textBox_IP.ShowText = false;
            textBox_IP.Size = new System.Drawing.Size(160, 40);
            textBox_IP.TabIndex = 0;
            textBox_IP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            textBox_IP.Watermark = "";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("微软雅黑", 20F);
            label1.Location = new System.Drawing.Point(27, 47);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 37);
            label1.TabIndex = 2;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label2.Location = new System.Drawing.Point(272, 47);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 35);
            label2.TabIndex = 4;
            label2.Text = "端口号:";
            // 
            // textBox_DK
            // 
            textBox_DK.Cursor = Cursors.IBeam;
            textBox_DK.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox_DK.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            textBox_DK.Location = new System.Drawing.Point(375, 44);
            textBox_DK.Margin = new Padding(2);
            textBox_DK.MinimumSize = new System.Drawing.Size(1, 16);
            textBox_DK.Name = "textBox_DK";
            textBox_DK.Padding = new Padding(5);
            textBox_DK.RectColor = System.Drawing.Color.Gray;
            textBox_DK.ShowText = false;
            textBox_DK.Size = new System.Drawing.Size(160, 40);
            textBox_DK.TabIndex = 3;
            textBox_DK.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            textBox_DK.Watermark = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label3.Location = new System.Drawing.Point(564, 47);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 35);
            label3.TabIndex = 6;
            label3.Text = "站号:";
            // 
            // textBox_ID
            // 
            textBox_ID.Cursor = Cursors.IBeam;
            textBox_ID.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox_ID.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            textBox_ID.Location = new System.Drawing.Point(640, 44);
            textBox_ID.Margin = new Padding(2);
            textBox_ID.MinimumSize = new System.Drawing.Size(1, 16);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Padding = new Padding(5);
            textBox_ID.RectColor = System.Drawing.Color.Gray;
            textBox_ID.ShowText = false;
            textBox_ID.Size = new System.Drawing.Size(160, 40);
            textBox_ID.TabIndex = 5;
            textBox_ID.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            textBox_ID.Watermark = "";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle22.Padding = new Padding(2);
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle23;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridView1.GridColor = System.Drawing.Color.Gray;
            dataGridView1.Location = new System.Drawing.Point(0, 179);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RectColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            dataGridViewCellStyle25.Padding = new Padding(2);
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle25;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.ScrollBarColor = System.Drawing.Color.Silver;
            dataGridView1.ScrollBarRectColor = System.Drawing.Color.Silver;
            dataGridView1.ScrollBarStyleInherited = false;
            dataGridView1.SelectedIndex = -1;
            dataGridView1.Size = new System.Drawing.Size(1911, 596);
            dataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
            // 
            // Column1
            // 
            Column1.HeaderText = "序号";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "名称";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "地址";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "数据类型";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "描述";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // comboBox1
            // 
            comboBox1.DataSource = null;
            comboBox1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            comboBox1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            comboBox1.Items.AddRange(new object[] { "ABCD", "BADC", "CDAB", "DCBA" });
            comboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            comboBox1.Location = new System.Drawing.Point(930, 44);
            comboBox1.Margin = new Padding(2);
            comboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Padding = new Padding(0, 0, 30, 2);
            comboBox1.RectColor = System.Drawing.Color.Gray;
            comboBox1.Size = new System.Drawing.Size(160, 40);
            comboBox1.SymbolSize = 24;
            comboBox1.TabIndex = 29;
            comboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            comboBox1.Watermark = "";
            // 
            // button4
            // 
            button4.Cursor = Cursors.Hand;
            button4.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            button4.FillColor2 = System.Drawing.Color.Gray;
            button4.FillHoverColor = System.Drawing.Color.Silver;
            button4.FillPressColor = System.Drawing.Color.Gray;
            button4.FillSelectedColor = System.Drawing.Color.Silver;
            button4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button4.ForeColor = System.Drawing.Color.Black;
            button4.ForeHoverColor = System.Drawing.Color.Black;
            button4.ForePressColor = System.Drawing.Color.Black;
            button4.ForeSelectedColor = System.Drawing.Color.Black;
            button4.Location = new System.Drawing.Point(1714, 108);
            button4.Margin = new Padding(2);
            button4.MinimumSize = new System.Drawing.Size(1, 1);
            button4.Name = "button4";
            button4.RectColor = System.Drawing.Color.Silver;
            button4.RectHoverColor = System.Drawing.Color.Silver;
            button4.RectPressColor = System.Drawing.Color.Gray;
            button4.RectSelectedColor = System.Drawing.Color.Silver;
            button4.Size = new System.Drawing.Size(145, 50);
            button4.TabIndex = 34;
            button4.Text = "添加";
            button4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            button3.FillColor2 = System.Drawing.Color.Gray;
            button3.FillHoverColor = System.Drawing.Color.Silver;
            button3.FillPressColor = System.Drawing.Color.Gray;
            button3.FillSelectedColor = System.Drawing.Color.Silver;
            button3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button3.ForeColor = System.Drawing.Color.Black;
            button3.ForeHoverColor = System.Drawing.Color.Black;
            button3.ForePressColor = System.Drawing.Color.Black;
            button3.ForeSelectedColor = System.Drawing.Color.Black;
            button3.Location = new System.Drawing.Point(1337, 108);
            button3.Margin = new Padding(2);
            button3.MinimumSize = new System.Drawing.Size(1, 1);
            button3.Name = "button3";
            button3.RectColor = System.Drawing.Color.Silver;
            button3.RectHoverColor = System.Drawing.Color.Silver;
            button3.RectPressColor = System.Drawing.Color.Gray;
            button3.RectSelectedColor = System.Drawing.Color.Silver;
            button3.Size = new System.Drawing.Size(145, 50);
            button3.TabIndex = 40;
            button3.Text = "写入";
            button3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button3.Click += button3_Click_1;
            // 
            // textBox4
            // 
            textBox4.Cursor = Cursors.IBeam;
            textBox4.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            textBox4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            textBox4.ForeColor = System.Drawing.Color.Silver;
            textBox4.Location = new System.Drawing.Point(930, 118);
            textBox4.Margin = new Padding(2);
            textBox4.MinimumSize = new System.Drawing.Size(1, 16);
            textBox4.Name = "textBox4";
            textBox4.Padding = new Padding(5);
            textBox4.RectColor = System.Drawing.Color.Gray;
            textBox4.ShowText = false;
            textBox4.Size = new System.Drawing.Size(160, 40);
            textBox4.TabIndex = 38;
            textBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            textBox4.Watermark = "";
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            button1.FillColor2 = System.Drawing.Color.Gray;
            button1.FillHoverColor = System.Drawing.Color.Silver;
            button1.FillPressColor = System.Drawing.Color.Gray;
            button1.FillSelectedColor = System.Drawing.Color.Silver;
            button1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button1.ForeColor = System.Drawing.Color.Black;
            button1.ForeHoverColor = System.Drawing.Color.Black;
            button1.ForePressColor = System.Drawing.Color.Black;
            button1.ForeSelectedColor = System.Drawing.Color.Black;
            button1.Location = new System.Drawing.Point(1530, 108);
            button1.Margin = new Padding(2);
            button1.MinimumSize = new System.Drawing.Size(1, 1);
            button1.Name = "button1";
            button1.RectColor = System.Drawing.Color.Silver;
            button1.RectHoverColor = System.Drawing.Color.Silver;
            button1.RectPressColor = System.Drawing.Color.Gray;
            button1.RectSelectedColor = System.Drawing.Color.Silver;
            button1.Size = new System.Drawing.Size(145, 50);
            button1.TabIndex = 36;
            button1.Text = "保存";
            button1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button1.Click += button1_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label5.Location = new System.Drawing.Point(827, 47);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 35);
            label5.TabIndex = 41;
            label5.Text = "字节序:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label4.Location = new System.Drawing.Point(829, 120);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(93, 35);
            label4.TabIndex = 42;
            label4.Text = "地   址";
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            button2.FillColor2 = System.Drawing.Color.Gray;
            button2.FillHoverColor = System.Drawing.Color.Silver;
            button2.FillPressColor = System.Drawing.Color.Gray;
            button2.FillSelectedColor = System.Drawing.Color.Silver;
            button2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button2.ForeColor = System.Drawing.Color.Black;
            button2.ForeHoverColor = System.Drawing.Color.Black;
            button2.ForePressColor = System.Drawing.Color.Black;
            button2.ForeSelectedColor = System.Drawing.Color.Black;
            button2.Location = new System.Drawing.Point(1136, 108);
            button2.Margin = new Padding(2);
            button2.MinimumSize = new System.Drawing.Size(1, 1);
            button2.Name = "button2";
            button2.RectColor = System.Drawing.Color.Silver;
            button2.RectHoverColor = System.Drawing.Color.Silver;
            button2.RectPressColor = System.Drawing.Color.Gray;
            button2.RectSelectedColor = System.Drawing.Color.Silver;
            button2.Size = new System.Drawing.Size(145, 50);
            button2.TabIndex = 43;
            button2.Text = "读取";
            button2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // Page_PLCAddress
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1912, 778);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBox_ID);
            Controls.Add(label2);
            Controls.Add(textBox_DK);
            Controls.Add(label1);
            Controls.Add(textBox_IP);
            Margin = new Padding(2);
            Name = "Page_PLCAddress";
            RectColor = System.Drawing.Color.Black;
            Text = " ";
            TitleFont = new System.Drawing.Font("宋体", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            TitleHeight = 29;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1352, 729);
            FormClosing += Form_set_PLC_FormClosing;
            Load += Form_set_PLC_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UITextBox textBox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UITextBox textBox_DK;
        private System.Windows.Forms.Label label3;
        private UITextBox textBox_ID;
        private UIDataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private UIComboBox comboBox1;
        private UIButton button4;
        private UIButton button3;
        private UITextBox textBox4;
        private UIButton button1;
        private Label label5;
        private Timer timer1;
        private Label label4;
        private UIButton button2;
    }
}