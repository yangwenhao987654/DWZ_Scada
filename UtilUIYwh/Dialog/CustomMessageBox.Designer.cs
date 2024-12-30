namespace Cap.Dialog
{
    partial class CustomMessageBox
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
            uiButton6 = new Sunny.UI.UIButton();
            tbxA = new Sunny.UI.UITextBox();
            tbxB = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            lbl1 = new Sunny.UI.UILabel();
            lbl2 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // uiButton6
            // 
            uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton6.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Location = new System.Drawing.Point(251, 469);
            uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton6.Name = "uiButton6";
            uiButton6.Size = new System.Drawing.Size(165, 58);
            uiButton6.TabIndex = 11;
            uiButton6.Text = "确定";
            uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Click += uiButton6_Click;
            // 
            // tbxA
            // 
            tbxA.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxA.Location = new System.Drawing.Point(237, 249);
            tbxA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxA.MinimumSize = new System.Drawing.Size(1, 16);
            tbxA.Name = "tbxA";
            tbxA.Padding = new System.Windows.Forms.Padding(5);
            tbxA.ShowText = false;
            tbxA.Size = new System.Drawing.Size(619, 61);
            tbxA.TabIndex = 12;
            tbxA.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxA.Watermark = "";
            tbxA.KeyPress += uiTextBox1_KeyPress;
            // 
            // tbxB
            // 
            tbxB.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxB.Location = new System.Drawing.Point(237, 348);
            tbxB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxB.MinimumSize = new System.Drawing.Size(1, 16);
            tbxB.Name = "tbxB";
            tbxB.Padding = new System.Windows.Forms.Padding(5);
            tbxB.ShowText = false;
            tbxB.Size = new System.Drawing.Size(619, 61);
            tbxB.TabIndex = 13;
            tbxB.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxB.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(29, 249);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(201, 49);
            uiLabel1.TabIndex = 14;
            uiLabel1.Text = "工位1物料:";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(29, 360);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(201, 49);
            uiLabel2.TabIndex = 15;
            uiLabel2.Text = "工位2物料:";
            // 
            // uiButton1
            // 
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(508, 469);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(165, 58);
            uiButton1.TabIndex = 16;
            uiButton1.Text = "取消";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click_1;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(29, 152);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(201, 49);
            uiLabel3.TabIndex = 20;
            uiLabel3.Text = "当前工位2:";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(29, 67);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(201, 49);
            uiLabel4.TabIndex = 19;
            uiLabel4.Text = "当前工位1:";
            // 
            // lbl1
            // 
            lbl1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl1.Location = new System.Drawing.Point(251, 67);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size(593, 57);
            lbl1.TabIndex = 21;
            // 
            // lbl2
            // 
            lbl2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl2.Location = new System.Drawing.Point(236, 152);
            lbl2.Name = "lbl2";
            lbl2.Size = new System.Drawing.Size(593, 57);
            lbl2.TabIndex = 22;
            // 
            // CustomMessageBox
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(877, 569);
            Controls.Add(lbl2);
            Controls.Add(lbl1);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel4);
            Controls.Add(uiButton1);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(tbxB);
            Controls.Add(tbxA);
            Controls.Add(uiButton6);
            Name = "CustomMessageBox";
            Text = "物料输入框";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            Load += CustomMessageBox_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UITextBox tbxA;
        private Sunny.UI.UITextBox tbxB;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel lbl1;
        private Sunny.UI.UILabel lbl2;
    }
}