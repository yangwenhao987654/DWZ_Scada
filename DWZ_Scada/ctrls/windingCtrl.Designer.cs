namespace DWZ_Scada.ctrls
{
    partial class windingCtrl
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
            uiLight1 = new Sunny.UI.UILight();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiFlowLayoutPanel1 = new Sunny.UI.UIFlowLayoutPanel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiPanel1.SuspendLayout();
            uiFlowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiLight1
            // 
            uiLight1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLight1.Location = new System.Drawing.Point(0, 5);
            uiLight1.Margin = new System.Windows.Forms.Padding(0);
            uiLight1.MinimumSize = new System.Drawing.Size(1, 1);
            uiLight1.Name = "uiLight1";
            uiLight1.Radius = 34;
            uiLight1.Size = new System.Drawing.Size(35, 34);
            uiLight1.TabIndex = 0;
            uiLight1.Text = "uiLight1";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiFlowLayoutPanel1);
            uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(0, 0);
            uiPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(214, 174);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            uiPanel1.Click += uiPanel1_Click;
            // 
            // uiFlowLayoutPanel1
            // 
            uiFlowLayoutPanel1.Controls.Add(uiLight1);
            uiFlowLayoutPanel1.Controls.Add(uiLabel1);
            uiFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiFlowLayoutPanel1.FillColor = System.Drawing.Color.Transparent;
            uiFlowLayoutPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            uiFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            uiFlowLayoutPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            uiFlowLayoutPanel1.RectColor = System.Drawing.Color.Transparent;
            uiFlowLayoutPanel1.ShowText = false;
            uiFlowLayoutPanel1.Size = new System.Drawing.Size(214, 39);
            uiFlowLayoutPanel1.TabIndex = 2;
            uiFlowLayoutPanel1.Text = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            uiFlowLayoutPanel1.WrapContents = false;
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 5);
            uiLabel1.Margin = new System.Windows.Forms.Padding(0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(214, 34);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "绕线机01";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windingCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(uiPanel1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "windingCtrl";
            Size = new System.Drawing.Size(214, 174);
            Load += windingCtrl_Load;
            uiPanel1.ResumeLayout(false);
            uiFlowLayoutPanel1.ResumeLayout(false);
    
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILight uiLight1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIFlowLayoutPanel uiFlowLayoutPanel1;
    }
}
