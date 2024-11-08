namespace DIPTest.Ctrl
{
    partial class userCtrlScanInput
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
            uiCheckBox12 = new Sunny.UI.UICheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            uiTextBox1 = new Sunny.UI.UITextBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            uiLabel2 = new Sunny.UI.UILabel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiCheckBox12
            // 
            uiCheckBox12.BackColor = System.Drawing.Color.Transparent;
            uiCheckBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            uiCheckBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            uiCheckBox12.Font = new System.Drawing.Font("幼圆", 15F);
            uiCheckBox12.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiCheckBox12.Location = new System.Drawing.Point(1080, 4);
            uiCheckBox12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            uiCheckBox12.MinimumSize = new System.Drawing.Size(2, 2);
            uiCheckBox12.Name = "uiCheckBox12";
            uiCheckBox12.Size = new System.Drawing.Size(114, 58);
            uiCheckBox12.TabIndex = 118;
            uiCheckBox12.Text = "强制输入";
            uiCheckBox12.CheckedChanged += uiCheckBox12_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // uiTextBox1
            // 
            uiTextBox1.BackColor = System.Drawing.Color.Transparent;
            uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            uiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTextBox1.FillColor2 = System.Drawing.Color.FromArgb(255, 128, 128);
            uiTextBox1.Font = new System.Drawing.Font("幼圆", 15F);
            uiTextBox1.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            uiTextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            uiTextBox1.Location = new System.Drawing.Point(105, 3);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            uiTextBox1.Minimum = 0D;
            uiTextBox1.MinimumSize = new System.Drawing.Size(2, 23);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(6, 8, 6, 8);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(967, 60);
            uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            uiTextBox1.TabIndex = 119;
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "二维码扫码输入框";
            uiTextBox1.WatermarkActiveColor = System.Drawing.SystemColors.GrayText;
            uiTextBox1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            uiTextBox1.TextChanged += uiTextBox1_TextChanged;
            uiTextBox1.KeyPress += uiTextBox1_KeyPress;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(uiTextBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(uiCheckBox12, 2, 0);
            tableLayoutPanel1.Controls.Add(uiLabel2, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1197, 66);
            tableLayoutPanel1.TabIndex = 120;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = System.Drawing.Color.Transparent;
            uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel2.Font = new System.Drawing.Font("幼圆", 15F);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(3, 3);
            uiLabel2.Margin = new System.Windows.Forms.Padding(3);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(94, 60);
            uiLabel2.TabIndex = 120;
            uiLabel2.Text = "二维码:";
            uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userCtrlScanInput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.IndianRed;
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "userCtrlScanInput";
            Size = new System.Drawing.Size(1197, 66);
            Load += userCtrlInput_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UICheckBox uiCheckBox12;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UITextBox uiTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
    }
}
