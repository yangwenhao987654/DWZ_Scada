namespace DWZ_Scada
{
    partial class PageOP10
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
            components = new System.ComponentModel.Container();
            uiLabel1 = new Sunny.UI.UILabel();
            listViewEx_Log1 = new LogTool.ListViewEx_Log(components);
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            uiButton6 = new Sunny.UI.UIButton();
            uiButton7 = new Sunny.UI.UIButton();
            uiButton8 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 35);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1912, 59);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "OP10-上料打码工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // listViewEx_Log1
            // 
            listViewEx_Log1.AutoArrange = false;
            listViewEx_Log1.Dock = System.Windows.Forms.DockStyle.Bottom;
            listViewEx_Log1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            listViewEx_Log1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewEx_Log1.LabelWrap = false;
            listViewEx_Log1.Location = new System.Drawing.Point(0, 546);
            listViewEx_Log1.MultiSelect = false;
            listViewEx_Log1.Name = "listViewEx_Log1";
            listViewEx_Log1.ShowGroups = false;
            listViewEx_Log1.Size = new System.Drawing.Size(1912, 232);
            listViewEx_Log1.TabIndex = 2;
            listViewEx_Log1.TabStop = false;
            listViewEx_Log1.UseCompatibleStateImageBehavior = false;
            listViewEx_Log1.View = System.Windows.Forms.View.Details;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox1.Location = new System.Drawing.Point(138, 127);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(202, 36);
            uiTextBox1.TabIndex = 3;
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "模拟临时码SN内容";
            // 
            // uiButton1
            // 
            uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(379, 122);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(111, 41);
            uiButton1.TabIndex = 4;
            uiButton1.Text = "进站请求";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiButton2
            // 
            uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Location = new System.Drawing.Point(538, 127);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new System.Drawing.Size(111, 41);
            uiButton2.TabIndex = 6;
            uiButton2.Text = "过站数据";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(689, 127);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(111, 41);
            uiButton3.TabIndex = 7;
            uiButton3.Text = "查询BOM";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(379, 193);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(111, 41);
            uiButton4.TabIndex = 8;
            uiButton4.Text = "点检上报";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // uiButton5
            // 
            uiButton5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Location = new System.Drawing.Point(538, 193);
            uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.Size = new System.Drawing.Size(111, 41);
            uiButton5.TabIndex = 9;
            uiButton5.Text = "状态上报";
            uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Click += uiButton5_Click;
            // 
            // uiButton6
            // 
            uiButton6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Location = new System.Drawing.Point(689, 193);
            uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton6.Name = "uiButton6";
            uiButton6.Size = new System.Drawing.Size(111, 41);
            uiButton6.TabIndex = 10;
            uiButton6.Text = "请求最终码";
            uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Click += uiButton6_Click;
            // 
            // uiButton7
            // 
            uiButton7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton7.Location = new System.Drawing.Point(379, 254);
            uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton7.Name = "uiButton7";
            uiButton7.Size = new System.Drawing.Size(111, 41);
            uiButton7.TabIndex = 11;
            uiButton7.Text = "获取最新工单";
            uiButton7.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton7.Click += uiButton7_Click;
            // 
            // uiButton8
            // 
            uiButton8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton8.Location = new System.Drawing.Point(538, 254);
            uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton8.Name = "uiButton8";
            uiButton8.Size = new System.Drawing.Size(111, 41);
            uiButton8.TabIndex = 12;
            uiButton8.Text = "上报易损易耗件";
            uiButton8.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton8.Click += uiButton8_Click;
            // 
            // PageOP10
            // 
            AllowShowTitle = true;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1912, 778);
            Controls.Add(uiButton8);
            Controls.Add(uiButton7);
            Controls.Add(uiButton6);
            Controls.Add(uiButton5);
            Controls.Add(uiButton4);
            Controls.Add(uiButton3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiTextBox1);
            Controls.Add(listViewEx_Log1);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP10";
            Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "PageOP10";
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private LogTool.ListViewEx_Log listViewEx_Log1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton7;
        private Sunny.UI.UIButton uiButton8;
    }
}