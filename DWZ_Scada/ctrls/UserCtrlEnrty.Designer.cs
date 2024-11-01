namespace DIPTest.Ctrl
{
    partial class UserCtrlEntry
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
            uiLabel4 = new Sunny.UI.UILabel();
            lbl_Input = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = System.Drawing.Color.Gray;
            uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 50F);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(0, 0);
            uiLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(313, 168);
            uiLabel4.TabIndex = 2;
            uiLabel4.Text = "等待中";
            uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel4.Click += uiLabel4_Click;
            // 
            // lbl_Input
            // 
            lbl_Input.BackColor = System.Drawing.Color.PaleTurquoise;
            lbl_Input.Dock = System.Windows.Forms.DockStyle.Top;
            lbl_Input.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_Input.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_Input.Location = new System.Drawing.Point(0, 0);
            lbl_Input.Name = "lbl_Input";
            lbl_Input.Size = new System.Drawing.Size(313, 36);
            lbl_Input.TabIndex = 3;
            lbl_Input.Text = "SN";
            // 
            // UserCtrlEntry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lbl_Input);
            Controls.Add(uiLabel4);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UserCtrlEntry";
            Size = new System.Drawing.Size(313, 168);
            Resize += UserCtrlResult_Resize;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel lbl_Input;
    }
}
