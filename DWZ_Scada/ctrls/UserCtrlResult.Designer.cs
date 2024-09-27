namespace DIPTest.Ctrl
{
    partial class UserCtrlResult
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
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Gray;
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("幼圆", 80F, System.Drawing.FontStyle.Bold);
            this.uiLabel4.Location = new System.Drawing.Point(0, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(572, 249);
            this.uiLabel4.TabIndex = 2;
            this.uiLabel4.Text = "等待中...";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTextBox1.DoubleValue = 230800000100004D;
            this.uiTextBox1.FillColor = System.Drawing.Color.Aqua;
            this.uiTextBox1.Font = new System.Drawing.Font("幼圆", 20F);
            this.uiTextBox1.Location = new System.Drawing.Point(0, 0);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(572, 29);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.TabIndex = 132;
            this.uiTextBox1.Text = "230800000100004";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // uiButton4
            // 
            this.uiButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.uiButton4.Location = new System.Drawing.Point(461, 197);
            this.uiButton4.Margin = new System.Windows.Forms.Padding(4);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(111, 52);
            this.uiButton4.TabIndex = 133;
            this.uiButton4.Text = "复位";
            this.uiButton4.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // UserCtrlResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiLabel4);
            this.Name = "UserCtrlResult";
            this.Size = new System.Drawing.Size(572, 249);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILabel uiLabel4;
        public Sunny.UI.UIButton uiButton4;
    }
}
