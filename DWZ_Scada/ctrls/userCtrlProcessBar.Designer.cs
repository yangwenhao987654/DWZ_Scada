namespace DIPTest.Ctrl
{
    partial class userCtrlProcessBar
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
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiLedStopwatch2 = new Sunny.UI.UILedStopwatch();
            this.SuspendLayout();
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProcessBar1.Location = new System.Drawing.Point(3, 3);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.RectColor = System.Drawing.Color.LimeGreen;
            this.uiProcessBar1.Size = new System.Drawing.Size(471, 37);
            this.uiProcessBar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProcessBar1.TabIndex = 125;
            this.uiProcessBar1.Text = "uiProcessBar2";
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.DarkCyan;
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(-2, 43);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(474, 41);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 126;
            this.uiLabel2.Text = "等待启动...";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiLedStopwatch2
            // 
            this.uiLedStopwatch2.BackColor = System.Drawing.Color.Black;
            this.uiLedStopwatch2.CharCount = 6;
            this.uiLedStopwatch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLedStopwatch2.ForeColor = System.Drawing.Color.Lime;
            this.uiLedStopwatch2.IntervalOn = 3;
            this.uiLedStopwatch2.IntervalV = 3;
            this.uiLedStopwatch2.Location = new System.Drawing.Point(317, 46);
            this.uiLedStopwatch2.Name = "uiLedStopwatch2";
            this.uiLedStopwatch2.Size = new System.Drawing.Size(155, 37);
            this.uiLedStopwatch2.TabIndex = 127;
            this.uiLedStopwatch2.Text = "00:00";
            // 
            // userCtrlProcessBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiLedStopwatch2);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiProcessBar1);
            this.Name = "userCtrlProcessBar";
            this.Size = new System.Drawing.Size(474, 85);
            this.Load += new System.EventHandler(this.userCtrlProcessBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIProcessBar uiProcessBar1;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UILedStopwatch uiLedStopwatch2;
    }
}
