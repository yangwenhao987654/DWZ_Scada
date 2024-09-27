namespace DIPTest.Ctrl
{
    partial class userCtrlInput
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
            this.components = new System.ComponentModel.Container();
            this.uiCheckBox12 = new Sunny.UI.UICheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiCheckBox12
            // 
            this.uiCheckBox12.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBox12.Font = new System.Drawing.Font("幼圆", 15F);
            this.uiCheckBox12.Location = new System.Drawing.Point(1318, 4);
            this.uiCheckBox12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiCheckBox12.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiCheckBox12.Name = "uiCheckBox12";
            this.uiCheckBox12.Size = new System.Drawing.Size(217, 62);
            this.uiCheckBox12.TabIndex = 118;
            this.uiCheckBox12.Text = "强制输入";
            this.uiCheckBox12.CheckedChanged += new System.EventHandler(this.uiCheckBox12_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.uiTextBox1.Font = new System.Drawing.Font("幼圆", 15F);
            this.uiTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.uiTextBox1.Location = new System.Drawing.Point(250, 3);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.uiTextBox1.Minimum = 0D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(2, 24);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(1058, 60);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.TabIndex = 119;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "PPID输入框 无焦点";
            this.uiTextBox1.WatermarkActiveColor = System.Drawing.SystemColors.GrayText;
            this.uiTextBox1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.uiTextBox1.TextChanged += new System.EventHandler(this.uiTextBox1_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.Controls.Add(this.uiTextBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiCheckBox12, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1539, 70);
            this.tableLayoutPanel1.TabIndex = 120;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.Cyan;
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("幼圆", 15F);
            this.uiLabel2.Location = new System.Drawing.Point(4, 3);
            this.uiLabel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(236, 64);
            this.uiLabel2.TabIndex = 120;
            this.uiLabel2.Text = "PPID:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userCtrlInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "userCtrlInput";
            this.Size = new System.Drawing.Size(1539, 70);
            this.Load += new System.EventHandler(this.userCtrlInput_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UICheckBox uiCheckBox12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Sunny.UI.UITextBox uiTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel2;
    }
}
