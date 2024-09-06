namespace DWZ_Scada.Pages
{
    partial class Manual_Debug
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
            button2 = new Sunny.UI.UIButton();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Cursor = System.Windows.Forms.Cursors.Hand;
            button2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            button2.Location = new System.Drawing.Point(131, 161);
            button2.Margin = new System.Windows.Forms.Padding(2);
            button2.MinimumSize = new System.Drawing.Size(1, 1);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(145, 50);
            button2.TabIndex = 50;
            button2.Text = "启动";
            button2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // uiButton1
            // 
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(398, 161);
            uiButton1.Margin = new System.Windows.Forms.Padding(2);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(145, 50);
            uiButton1.TabIndex = 51;
            uiButton1.Text = "停止";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // uiButton2
            // 
            uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Location = new System.Drawing.Point(669, 161);
            uiButton2.Margin = new System.Windows.Forms.Padding(2);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new System.Drawing.Size(145, 50);
            uiButton2.TabIndex = 52;
            uiButton2.Text = "复位";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // uiButton3
            // 
            uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(948, 161);
            uiButton3.Margin = new System.Windows.Forms.Padding(2);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(145, 50);
            uiButton3.TabIndex = 53;
            uiButton3.Text = "初始化";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // Manual_Debug
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1255, 524);
            Controls.Add(uiButton3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(button2);
            Name = "Manual_Debug";
            Text = "手动调试";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIButton button2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
    }
}