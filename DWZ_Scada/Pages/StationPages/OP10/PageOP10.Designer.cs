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
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiButton3 = new Sunny.UI.UIButton();
            lbl_EntrySN = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            uiButton4 = new Sunny.UI.UIButton();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 35);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1223, 59);
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
            listViewEx_Log1.Location = new System.Drawing.Point(0, 792);
            listViewEx_Log1.MultiSelect = false;
            listViewEx_Log1.Name = "listViewEx_Log1";
            listViewEx_Log1.ShowGroups = false;
            listViewEx_Log1.Size = new System.Drawing.Size(1223, 232);
            listViewEx_Log1.TabIndex = 2;
            listViewEx_Log1.TabStop = false;
            listViewEx_Log1.UseCompatibleStateImageBehavior = false;
            listViewEx_Log1.View = System.Windows.Forms.View.Details;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox1.Location = new System.Drawing.Point(786, 121);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(202, 36);
            uiTextBox1.TabIndex = 3;
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "扫码物料码";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(30, 121);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(140, 58);
            uiLabel2.TabIndex = 4;
            uiLabel2.Text = "当前型号";
            uiLabel2.Click += uiLabel2_Click;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(442, 121);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(140, 42);
            uiLabel4.TabIndex = 6;
            uiLabel4.Text = "当前物料";
            // 
            // uiButton1
            // 
            uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(176, 121);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(122, 42);
            uiButton1.TabIndex = 7;
            uiButton1.Text = "切换型号";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click_1;
            // 
            // uiButton2
            // 
            uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Location = new System.Drawing.Point(616, 121);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new System.Drawing.Size(122, 42);
            uiButton2.TabIndex = 8;
            uiButton2.Text = "切换物料";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(30, 195);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(140, 42);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "当前工单";
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(176, 184);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(122, 42);
            uiButton3.TabIndex = 10;
            uiButton3.Text = "切换工单";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            // 
            // lbl_EntrySN
            // 
            lbl_EntrySN.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntrySN.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntrySN.Location = new System.Drawing.Point(30, 287);
            lbl_EntrySN.Name = "lbl_EntrySN";
            lbl_EntrySN.Size = new System.Drawing.Size(220, 42);
            lbl_EntrySN.TabIndex = 11;
            lbl_EntrySN.Text = "进站临时码";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(30, 354);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(220, 42);
            uiLabel6.TabIndex = 12;
            uiLabel6.Text = "外观检测结果1";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(30, 430);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(220, 42);
            uiLabel7.TabIndex = 13;
            uiLabel7.Text = "外观检测结果2";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new System.Drawing.Point(363, 287);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new System.Drawing.Size(625, 185);
            uiLabel8.TabIndex = 14;
            uiLabel8.Text = "出站总结果";
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(442, 184);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(122, 42);
            uiButton4.TabIndex = 15;
            uiButton4.Text = "点检模式";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // PageOP10
            // 
            AllowShowTitle = true;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1223, 1024);
            Controls.Add(uiButton4);
            Controls.Add(uiLabel8);
            Controls.Add(uiLabel7);
            Controls.Add(uiLabel6);
            Controls.Add(lbl_EntrySN);
            Controls.Add(uiButton3);
            Controls.Add(uiLabel3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel2);
            Controls.Add(uiTextBox1);
            Controls.Add(listViewEx_Log1);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP10";
            Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "PageOP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private LogTool.ListViewEx_Log listViewEx_Log1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UILabel lbl_EntrySN;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIButton uiButton4;
    }
}