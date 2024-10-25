namespace DWZ_Scada.Pages.StationPages.OP60
{
    partial class AtlBrxTestForm
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
            tbxIP = new Sunny.UI.UITextBox();
            tbxPort = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            tbxCommand = new Sunny.UI.UITextBox();
            uiButton1 = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiButton2 = new Sunny.UI.UIButton();
            uiButton3 = new Sunny.UI.UIButton();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiButton10 = new Sunny.UI.UIButton();
            uiButton9 = new Sunny.UI.UIButton();
            uiButton8 = new Sunny.UI.UIButton();
            uiButton7 = new Sunny.UI.UIButton();
            uiButton6 = new Sunny.UI.UIButton();
            uiButton5 = new Sunny.UI.UIButton();
            uiButton4 = new Sunny.UI.UIButton();
            uiButton11 = new Sunny.UI.UIButton();
            uiButton12 = new Sunny.UI.UIButton();
            uiComboBox1 = new Sunny.UI.UIComboBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiButton13 = new Sunny.UI.UIButton();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tbxIP
            // 
            tbxIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxIP.Location = new System.Drawing.Point(428, 59);
            tbxIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxIP.MinimumSize = new System.Drawing.Size(1, 16);
            tbxIP.Name = "tbxIP";
            tbxIP.Padding = new System.Windows.Forms.Padding(5);
            tbxIP.ShowText = false;
            tbxIP.Size = new System.Drawing.Size(150, 29);
            tbxIP.TabIndex = 0;
            tbxIP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxIP.Watermark = "IP地址";
            // 
            // tbxPort
            // 
            tbxPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxPort.Location = new System.Drawing.Point(703, 60);
            tbxPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxPort.MinimumSize = new System.Drawing.Size(1, 16);
            tbxPort.Name = "tbxPort";
            tbxPort.Padding = new System.Windows.Forms.Padding(5);
            tbxPort.ShowText = false;
            tbxPort.Size = new System.Drawing.Size(87, 29);
            tbxPort.TabIndex = 1;
            tbxPort.Text = "0";
            tbxPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxPort.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            tbxPort.Watermark = "端口号";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(295, 59);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(126, 36);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = " IP   地址:";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(617, 58);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(79, 36);
            uiLabel2.TabIndex = 3;
            uiLabel2.Text = "端口:";
            uiLabel2.Click += uiLabel2_Click;
            // 
            // myLogCtrl1
            // 
            myLogCtrl1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            myLogCtrl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            myLogCtrl1.FullRowSelect = true;
            myLogCtrl1.HideSelection = true;
            myLogCtrl1.LabelWrap = false;
            myLogCtrl1.Location = new System.Drawing.Point(17, 392);
            myLogCtrl1.Name = "myLogCtrl1";
            myLogCtrl1.Size = new System.Drawing.Size(850, 200);
            myLogCtrl1.TabIndex = 4;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // tbxCommand
            // 
            tbxCommand.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxCommand.Location = new System.Drawing.Point(138, 133);
            tbxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxCommand.MinimumSize = new System.Drawing.Size(1, 16);
            tbxCommand.Name = "tbxCommand";
            tbxCommand.Padding = new System.Windows.Forms.Padding(5);
            tbxCommand.ShowText = false;
            tbxCommand.Size = new System.Drawing.Size(150, 29);
            tbxCommand.TabIndex = 5;
            tbxCommand.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxCommand.Watermark = "输入指令";
            // 
            // uiButton1
            // 
            uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Location = new System.Drawing.Point(331, 127);
            uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new System.Drawing.Size(75, 35);
            uiButton1.TabIndex = 6;
            uiButton1.Text = "发送";
            uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(5, 127);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(126, 36);
            uiLabel3.TabIndex = 7;
            uiLabel3.Text = "通讯指令:";
            // 
            // uiButton2
            // 
            uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Location = new System.Drawing.Point(180, 50);
            uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Size = new System.Drawing.Size(117, 35);
            uiButton2.TabIndex = 8;
            uiButton2.Text = "查询设备状态";
            uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiButton3
            // 
            uiButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Location = new System.Drawing.Point(22, 50);
            uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.Size = new System.Drawing.Size(124, 42);
            uiButton3.TabIndex = 9;
            uiButton3.Text = "触发测试";
            uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton3.Click += uiButton3_Click;
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiButton13);
            uiGroupBox1.Controls.Add(uiButton10);
            uiGroupBox1.Controls.Add(uiButton9);
            uiGroupBox1.Controls.Add(uiButton8);
            uiGroupBox1.Controls.Add(uiButton7);
            uiGroupBox1.Controls.Add(uiButton6);
            uiGroupBox1.Controls.Add(uiButton5);
            uiGroupBox1.Controls.Add(uiButton4);
            uiGroupBox1.Controls.Add(uiButton2);
            uiGroupBox1.Controls.Add(uiButton3);
            uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new System.Drawing.Point(17, 204);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new System.Drawing.Size(850, 180);
            uiGroupBox1.TabIndex = 10;
            uiGroupBox1.Text = "通讯测试";
            uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton10
            // 
            uiButton10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton10.Location = new System.Drawing.Point(694, 112);
            uiButton10.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton10.Name = "uiButton10";
            uiButton10.Size = new System.Drawing.Size(120, 35);
            uiButton10.TabIndex = 16;
            uiButton10.Text = "更新测试方案";
            uiButton10.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton10.Click += uiButton10_Click;
            // 
            // uiButton9
            // 
            uiButton9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton9.Location = new System.Drawing.Point(694, 50);
            uiButton9.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton9.Name = "uiButton9";
            uiButton9.Size = new System.Drawing.Size(138, 35);
            uiButton9.TabIndex = 15;
            uiButton9.Text = "查询当前运行方案";
            uiButton9.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton9.Click += uiButton9_Click;
            // 
            // uiButton8
            // 
            uiButton8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton8.Location = new System.Drawing.Point(515, 112);
            uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton8.Name = "uiButton8";
            uiButton8.Size = new System.Drawing.Size(120, 35);
            uiButton8.TabIndex = 14;
            uiButton8.Text = "急停";
            uiButton8.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton8.Click += uiButton8_Click;
            // 
            // uiButton7
            // 
            uiButton7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton7.Location = new System.Drawing.Point(515, 50);
            uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton7.Name = "uiButton7";
            uiButton7.Size = new System.Drawing.Size(120, 35);
            uiButton7.TabIndex = 13;
            uiButton7.Text = "清除数据记录";
            uiButton7.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton7.Click += uiButton7_Click;
            // 
            // uiButton6
            // 
            uiButton6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Location = new System.Drawing.Point(341, 112);
            uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton6.Name = "uiButton6";
            uiButton6.Size = new System.Drawing.Size(120, 35);
            uiButton6.TabIndex = 12;
            uiButton6.Text = "测试结果明细";
            uiButton6.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton6.Click += uiButton6_Click;
            // 
            // uiButton5
            // 
            uiButton5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Location = new System.Drawing.Point(341, 50);
            uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton5.Name = "uiButton5";
            uiButton5.Size = new System.Drawing.Size(120, 35);
            uiButton5.TabIndex = 11;
            uiButton5.Text = "查询测试结果";
            uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton5.Click += uiButton5_Click;
            // 
            // uiButton4
            // 
            uiButton4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Location = new System.Drawing.Point(177, 112);
            uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton4.Name = "uiButton4";
            uiButton4.Size = new System.Drawing.Size(120, 35);
            uiButton4.TabIndex = 10;
            uiButton4.Text = "查询测试状态";
            uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton4.Click += uiButton4_Click;
            // 
            // uiButton11
            // 
            uiButton11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton11.Location = new System.Drawing.Point(468, 128);
            uiButton11.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton11.Name = "uiButton11";
            uiButton11.Size = new System.Drawing.Size(75, 35);
            uiButton11.TabIndex = 11;
            uiButton11.Text = "连接";
            uiButton11.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton11.Click += uiButton11_Click;
            // 
            // uiButton12
            // 
            uiButton12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton12.Location = new System.Drawing.Point(577, 128);
            uiButton12.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton12.Name = "uiButton12";
            uiButton12.Size = new System.Drawing.Size(75, 35);
            uiButton12.TabIndex = 12;
            uiButton12.Text = "断开";
            uiButton12.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton12.Click += uiButton12_Click;
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = System.Drawing.Color.White;
            uiComboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            uiComboBox1.Location = new System.Drawing.Point(138, 66);
            uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            uiComboBox1.Size = new System.Drawing.Size(150, 29);
            uiComboBox1.SymbolSize = 24;
            uiComboBox1.TabIndex = 13;
            uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            uiComboBox1.SelectedIndexChanged += uiComboBox1_SelectedIndexChanged;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(5, 66);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(126, 36);
            uiLabel4.TabIndex = 14;
            uiLabel4.Text = "选择设备:";
            // 
            // uiButton13
            // 
            uiButton13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton13.Location = new System.Drawing.Point(22, 112);
            uiButton13.MinimumSize = new System.Drawing.Size(1, 1);
            uiButton13.Name = "uiButton13";
            uiButton13.Size = new System.Drawing.Size(124, 42);
            uiButton13.TabIndex = 17;
            uiButton13.Text = "更新产品ID";
            uiButton13.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiButton13.Click += uiButton13_Click;
            // 
            // AtlBrxTestForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(881, 605);
            Controls.Add(uiLabel4);
            Controls.Add(uiComboBox1);
            Controls.Add(uiButton12);
            Controls.Add(uiButton11);
            Controls.Add(uiGroupBox1);
            Controls.Add(uiLabel3);
            Controls.Add(uiButton1);
            Controls.Add(tbxCommand);
            Controls.Add(myLogCtrl1);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(tbxPort);
            Controls.Add(tbxIP);
            Name = "AtlBrxTestForm";
            Text = "AtlBrx调试";
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            FormClosing += AtlBrxTestForm_FormClosing;
            Load += AtlBrxTestForm_Load;
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox tbxIP;
        private Sunny.UI.UITextBox tbxPort;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private ctrls.MyLogCtrl myLogCtrl1;
        private Sunny.UI.UITextBox tbxCommand;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UIButton uiButton8;
        private Sunny.UI.UIButton uiButton7;
        private Sunny.UI.UIButton uiButton10;
        private Sunny.UI.UIButton uiButton9;
        private Sunny.UI.UIButton uiButton11;
        private Sunny.UI.UIButton uiButton12;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIButton uiButton13;
    }
}