namespace DWZ_Scada.Pages
{
    partial class PageAlarmTabMenu
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
            tabPage2 = new System.Windows.Forms.TabPage();
            tabPage1 = new System.Windows.Forms.TabPage();
            uiTabControlMenu1 = new Sunny.UI.UITabControlMenu();
            uiTabControlMenu1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Location = new System.Drawing.Point(151, 0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new System.Drawing.Size(649, 450);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "历史报警查询";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new System.Drawing.Point(151, 0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new System.Drawing.Size(649, 450);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "报警信息配置";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiTabControlMenu1
            // 
            uiTabControlMenu1.Alignment = System.Windows.Forms.TabAlignment.Left;
            uiTabControlMenu1.Controls.Add(tabPage1);
            uiTabControlMenu1.Controls.Add(tabPage2);
            uiTabControlMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiTabControlMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            uiTabControlMenu1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTabControlMenu1.ItemSize = new System.Drawing.Size(150, 50);
            uiTabControlMenu1.Location = new System.Drawing.Point(0, 0);
            uiTabControlMenu1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            uiTabControlMenu1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiTabControlMenu1.Multiline = true;
            uiTabControlMenu1.Name = "uiTabControlMenu1";
            uiTabControlMenu1.SelectedIndex = 0;
            uiTabControlMenu1.Size = new System.Drawing.Size(800, 450);
            uiTabControlMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            uiTabControlMenu1.TabBackColor = System.Drawing.Color.AliceBlue;
            uiTabControlMenu1.TabIndex = 0;
            uiTabControlMenu1.TabSelectedColor = System.Drawing.Color.LightCyan;
            uiTabControlMenu1.TabSelectedForeColor = System.Drawing.Color.Black;
            uiTabControlMenu1.TabSelectedHighColor = System.Drawing.Color.LightSkyBlue;
            uiTabControlMenu1.TabUnSelectedForeColor = System.Drawing.Color.Black;
            // 
            // PageAlarmTabMenu
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(uiTabControlMenu1);
            Name = "PageAlarmTabMenu";
            Text = "PageTabMenu";
            Load += PageTabMenu_Load;
            uiTabControlMenu1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UITabControlMenu uiTabControlMenu1;
    }
}