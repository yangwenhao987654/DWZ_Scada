namespace DWZ_Scada.ctrls
{
    partial class workOrderCtrl
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
            uiButton4 = new Sunny.UI.UIButton();
            cbx_Orders = new Sunny.UI.UIComboBox();
            uiButton3 = new Sunny.UI.UIButton();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            tbx_Part = new Sunny.UI.UITextBox();
            SuspendLayout();
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(588, 17);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(122, 42);
            uiButton4.TabIndex = 25;
            uiButton4.Text = "切换工单";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // cbx_Orders
            // 
            cbx_Orders.DataSource = null;
            cbx_Orders.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbx_Orders.FillColor = System.Drawing.Color.White;
            cbx_Orders.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cbx_Orders.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            cbx_Orders.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            cbx_Orders.Location = new System.Drawing.Point(158, 11);
            cbx_Orders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cbx_Orders.MinimumSize = new System.Drawing.Size(63, 0);
            cbx_Orders.Name = "cbx_Orders";
            cbx_Orders.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            cbx_Orders.Size = new System.Drawing.Size(229, 51);
            cbx_Orders.SymbolSize = 24;
            cbx_Orders.TabIndex = 24;
            cbx_Orders.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            cbx_Orders.Watermark = "获取Mes生产工单";
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(13, 17);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(122, 42);
            uiButton3.TabIndex = 23;
            uiButton3.Text = "获取最新工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(751, 17);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(118, 36);
            uiLabel4.TabIndex = 22;
            uiLabel4.Text = "当前物料";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(412, 18);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(140, 35);
            uiLabel2.TabIndex = 21;
            uiLabel2.Text = "当前型号";
            // 
            // tbx_Part
            // 
            tbx_Part.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_Part.Location = new System.Drawing.Point(898, 17);
            tbx_Part.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_Part.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_Part.Name = "tbx_Part";
            tbx_Part.Padding = new System.Windows.Forms.Padding(5);
            tbx_Part.ShowText = false;
            tbx_Part.Size = new System.Drawing.Size(173, 36);
            tbx_Part.TabIndex = 20;
            tbx_Part.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_Part.Watermark = "扫码物料码";
            tbx_Part.TextChanged += tbx_Part_TextChanged;
            // 
            // workOrderCtrl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(uiButton4);
            Controls.Add(cbx_Orders);
            Controls.Add(uiButton3);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel2);
            Controls.Add(tbx_Part);
            Name = "workOrderCtrl";
            Size = new System.Drawing.Size(1165, 91);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIComboBox cbx_Orders;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox tbx_Part;
    }
}
