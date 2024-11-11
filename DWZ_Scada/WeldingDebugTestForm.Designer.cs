namespace DWZ_Scada
{
    partial class WeldingDebugTestForm
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
            btn_Test = new Sunny.UI.UIButton();
            tbxTest = new Sunny.UI.UITextBox();
            uiLabel8 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // btn_Test
            // 
            btn_Test.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btn_Test.Location = new System.Drawing.Point(460, 223);
            btn_Test.MinimumSize = new System.Drawing.Size(1, 1);
            btn_Test.Name = "btn_Test";
            btn_Test.Size = new System.Drawing.Size(122, 42);
            btn_Test.TabIndex = 25;
            btn_Test.Text = "测试";
            btn_Test.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // tbxTest
            // 
            tbxTest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxTest.Location = new System.Drawing.Point(186, 223);
            tbxTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxTest.MinimumSize = new System.Drawing.Size(1, 16);
            tbxTest.Name = "tbxTest";
            tbxTest.Padding = new System.Windows.Forms.Padding(5);
            tbxTest.ShowText = false;
            tbxTest.Size = new System.Drawing.Size(252, 36);
            tbxTest.TabIndex = 24;
            tbxTest.Text = "1,S1245655,1";
            tbxTest.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxTest.Watermark = "张力测试（输入机台号,SN,工位号1|2）";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new System.Drawing.Point(182, 178);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new System.Drawing.Size(212, 36);
            uiLabel8.TabIndex = 23;
            uiLabel8.Text = "绕线检查结果";
            // 
            // WeldingDebugTestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btn_Test);
            Controls.Add(tbxTest);
            Controls.Add(uiLabel8);
            Name = "WeldingDebugTestForm";
            Text = "绕线机调试";
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton btn_Test;
        private Sunny.UI.UITextBox tbxTest;
        private Sunny.UI.UILabel uiLabel8;
    }
}