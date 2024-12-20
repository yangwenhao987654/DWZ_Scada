﻿namespace DWZ_Scada.Pages
{
    partial class DeviceControlPage
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
            uiListBox2 = new Sunny.UI.UIListBox();
            uiLabel1 = new Sunny.UI.UILabel();
            lbx_Alarm = new Sunny.UI.UIListBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiButton1
            // 
            uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton1.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton1.FillColor2 = System.Drawing.Color.Gray;
            uiButton1.FillHoverColor = System.Drawing.Color.Silver;
            uiButton1.FillPressColor = System.Drawing.Color.Gray;
            uiButton1.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.ForeColor = System.Drawing.Color.Black;
            uiButton1.ForeHoverColor = System.Drawing.Color.Black;
            uiButton1.ForePressColor = System.Drawing.Color.Black;
            uiButton1.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton1.Location = new System.Drawing.Point(318, 24);
            uiButton1.Margin = new System.Windows.Forms.Padding(2);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = System.Drawing.Color.Silver;
            uiButton1.RectHoverColor = System.Drawing.Color.Silver;
            uiButton1.RectPressColor = System.Drawing.Color.Silver;
            uiButton1.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton1.Size = new System.Drawing.Size(145, 50);
            uiButton1.TabIndex = 51;
            uiButton1.Text = "停止";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Visible = false;
            // 
            // uiListBox2
            // 
            uiListBox2.FillColor = System.Drawing.Color.White;
            uiListBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiListBox2.HoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            uiListBox2.ItemSelectBackColor = System.Drawing.Color.Silver;
            uiListBox2.ItemSelectForeColor = System.Drawing.Color.White;
            uiListBox2.Location = new System.Drawing.Point(13, 156);
            uiListBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiListBox2.MinimumSize = new System.Drawing.Size(1, 1);
            uiListBox2.Name = "uiListBox2";
            uiListBox2.Padding = new System.Windows.Forms.Padding(2);
            uiListBox2.RectColor = System.Drawing.Color.Silver;
            uiListBox2.ScrollBarColor = System.Drawing.Color.Silver;
            uiListBox2.ScrollBarStyleInherited = false;
            uiListBox2.ShowText = false;
            uiListBox2.Size = new System.Drawing.Size(605, 567);
            uiListBox2.TabIndex = 54;
            uiListBox2.Text = "uiListBox1";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(13, 117);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(193, 34);
            uiLabel1.TabIndex = 55;
            uiLabel1.Text = "运行日志";
            // 
            // lbx_Alarm
            // 
            lbx_Alarm.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbx_Alarm.ForeColor = System.Drawing.Color.Red;
            lbx_Alarm.HoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            lbx_Alarm.ItemHeight = 35;
            lbx_Alarm.ItemSelectForeColor = System.Drawing.Color.Red;
            lbx_Alarm.Location = new System.Drawing.Point(649, 156);
            lbx_Alarm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            lbx_Alarm.MinimumSize = new System.Drawing.Size(1, 1);
            lbx_Alarm.Name = "lbx_Alarm";
            lbx_Alarm.Padding = new System.Windows.Forms.Padding(2);
            lbx_Alarm.RectColor = System.Drawing.Color.Silver;
            lbx_Alarm.ShowText = false;
            lbx_Alarm.Size = new System.Drawing.Size(605, 567);
            lbx_Alarm.TabIndex = 55;
            lbx_Alarm.Text = "uiListBox2";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(649, 117);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(265, 34);
            uiLabel2.TabIndex = 56;
            uiLabel2.Text = "实时报警信息";
            // 
            // uiButton4
            // 
            uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton4.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton4.FillColor2 = System.Drawing.Color.Gray;
            uiButton4.FillColorGradientDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            uiButton4.FillHoverColor = System.Drawing.Color.Silver;
            uiButton4.FillPressColor = System.Drawing.Color.Gray;
            uiButton4.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.ForeColor = System.Drawing.Color.Black;
            uiButton4.ForeHoverColor = System.Drawing.Color.Black;
            uiButton4.ForePressColor = System.Drawing.Color.Black;
            uiButton4.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton4.Location = new System.Drawing.Point(61, 24);
            uiButton4.Margin = new System.Windows.Forms.Padding(2);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.RectColor = System.Drawing.Color.Silver;
            uiButton4.RectHoverColor = System.Drawing.Color.Silver;
            uiButton4.RectPressColor = System.Drawing.Color.Silver;
            uiButton4.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton4.Size = new System.Drawing.Size(145, 50);
            uiButton4.TabIndex = 57;
            uiButton4.Text = "启动";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Visible = false;
            // 
            // uiButton2
            // 
            uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton2.FillColor2 = System.Drawing.Color.Gray;
            uiButton2.FillHoverColor = System.Drawing.Color.Silver;
            uiButton2.FillPressColor = System.Drawing.Color.Gray;
            uiButton2.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.ForeColor = System.Drawing.Color.Black;
            uiButton2.ForeHoverColor = System.Drawing.Color.Black;
            uiButton2.ForePressColor = System.Drawing.Color.Black;
            uiButton2.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton2.Location = new System.Drawing.Point(570, 24);
            uiButton2.Margin = new System.Windows.Forms.Padding(2);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = System.Drawing.Color.Silver;
            uiButton2.RectHoverColor = System.Drawing.Color.Silver;
            uiButton2.RectPressColor = System.Drawing.Color.Silver;
            uiButton2.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton2.Size = new System.Drawing.Size(145, 50);
            uiButton2.TabIndex = 58;
            uiButton2.Text = "复位";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Visible = false;
            uiButton2.Click += uiButton2_Click_1;
            // 
            // uiButton3
            // 
            uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            uiButton3.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            uiButton3.FillColor2 = System.Drawing.Color.Gray;
            uiButton3.FillHoverColor = System.Drawing.Color.Silver;
            uiButton3.FillPressColor = System.Drawing.Color.Gray;
            uiButton3.FillSelectedColor = System.Drawing.Color.Gray;
            uiButton3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.ForeColor = System.Drawing.Color.Black;
            uiButton3.ForeHoverColor = System.Drawing.Color.Black;
            uiButton3.ForePressColor = System.Drawing.Color.Black;
            uiButton3.ForeSelectedColor = System.Drawing.Color.Black;
            uiButton3.Location = new System.Drawing.Point(819, 24);
            uiButton3.Margin = new System.Windows.Forms.Padding(2);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = System.Drawing.Color.Silver;
            uiButton3.RectHoverColor = System.Drawing.Color.Silver;
            uiButton3.RectPressColor = System.Drawing.Color.Silver;
            uiButton3.RectSelectedColor = System.Drawing.Color.Silver;
            uiButton3.Size = new System.Drawing.Size(145, 50);
            uiButton3.TabIndex = 59;
            uiButton3.Text = "初始化";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Visible = false;
            // 
            // DeviceControlPage
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.AliceBlue;
            ClientSize = new System.Drawing.Size(1266, 778);
            Controls.Add(uiButton3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton4);
            Controls.Add(uiLabel2);
            Controls.Add(lbx_Alarm);
            Controls.Add(uiLabel1);
            Controls.Add(uiListBox2);
            Controls.Add(uiButton1);
            Name = "DeviceControlPage";
            RectColor = System.Drawing.Color.Black;
            Text = "";
            TitleForeColor = System.Drawing.Color.Transparent;
            TitleHeight = 29;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            FormClosing += Manual_Debug_FormClosing;
            Load += DeviceControlPage_Load;
            SizeChanged += DeviceControlPage_SizeChanged;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIListBox uiListBox2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIListBox lbx_Alarm;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
    }
}