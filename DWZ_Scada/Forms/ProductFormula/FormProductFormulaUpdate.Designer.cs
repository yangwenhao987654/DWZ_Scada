namespace DWZ_Scada.Forms.ProductFormula
{
    partial class FormProductFormulaUpdate
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
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            tbx_Type = new Sunny.UI.UITextBox();
            tbxName = new Sunny.UI.UITextBox();
            tbx_Code = new Sunny.UI.UITextBox();
            tbx_PLCNo = new Sunny.UI.UITextBox();
            SuspendLayout();
            // 
            // uiButton1
            // 
            uiButton1.FillColor = System.Drawing.Color.White;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.ForeColor = System.Drawing.Color.Black;
            uiButton1.Location = new System.Drawing.Point(154, 357);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(107, 48);
            uiButton1.TabIndex = 0;
            uiButton1.Text = "保存";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.FillColor = System.Drawing.Color.White;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.ForeColor = System.Drawing.Color.Black;
            uiButton2.Location = new System.Drawing.Point(391, 357);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectHoverColor = System.Drawing.Color.Red;
            uiButton2.Size = new System.Drawing.Size(107, 48);
            uiButton2.TabIndex = 1;
            uiButton2.Text = "取消";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(87, 91);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(127, 38);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "产品类型:";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(87, 153);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(127, 38);
            uiLabel2.TabIndex = 3;
            uiLabel2.Text = "产品名称:";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(87, 209);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(127, 38);
            uiLabel3.TabIndex = 4;
            uiLabel3.Text = "产品编号:";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(87, 274);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(127, 38);
            uiLabel4.TabIndex = 5;
            uiLabel4.Text = "PLC 料号:";
            // 
            // tbx_Type
            // 
            tbx_Type.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_Type.Location = new System.Drawing.Point(221, 91);
            tbx_Type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_Type.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_Type.Name = "tbx_Type";
            tbx_Type.Padding = new System.Windows.Forms.Padding(5);
            tbx_Type.ShowText = false;
            tbx_Type.Size = new System.Drawing.Size(244, 38);
            tbx_Type.TabIndex = 6;
            tbx_Type.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_Type.Watermark = "";
            // 
            // tbxName
            // 
            tbxName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxName.Location = new System.Drawing.Point(221, 153);
            tbxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxName.MinimumSize = new System.Drawing.Size(1, 16);
            tbxName.Name = "tbxName";
            tbxName.Padding = new System.Windows.Forms.Padding(5);
            tbxName.ShowText = false;
            tbxName.Size = new System.Drawing.Size(244, 38);
            tbxName.TabIndex = 7;
            tbxName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxName.Watermark = "";
            // 
            // tbx_Code
            // 
            tbx_Code.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_Code.Location = new System.Drawing.Point(221, 209);
            tbx_Code.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_Code.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_Code.Name = "tbx_Code";
            tbx_Code.Padding = new System.Windows.Forms.Padding(5);
            tbx_Code.ShowText = false;
            tbx_Code.Size = new System.Drawing.Size(244, 38);
            tbx_Code.TabIndex = 8;
            tbx_Code.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_Code.Watermark = "";
            // 
            // tbx_PLCNo
            // 
            tbx_PLCNo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbx_PLCNo.Location = new System.Drawing.Point(221, 274);
            tbx_PLCNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbx_PLCNo.MinimumSize = new System.Drawing.Size(1, 16);
            tbx_PLCNo.Name = "tbx_PLCNo";
            tbx_PLCNo.Padding = new System.Windows.Forms.Padding(5);
            tbx_PLCNo.ShowText = false;
            tbx_PLCNo.Size = new System.Drawing.Size(244, 38);
            tbx_PLCNo.TabIndex = 9;
            tbx_PLCNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbx_PLCNo.Watermark = "";
            // 
            // FormProductFormulaUpdate
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(708, 450);
            Controls.Add(tbx_PLCNo);
            Controls.Add(tbx_Code);
            Controls.Add(tbxName);
            Controls.Add(tbx_Type);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Name = "FormProductFormulaUpdate";
            Text = "产品配方编辑";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            Load += FormProductFormulaUpdate_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox tbx_Type;
        private Sunny.UI.UITextBox tbxName;
        private Sunny.UI.UITextBox tbx_Code;
        private Sunny.UI.UITextBox tbx_PLCNo;
    }
}