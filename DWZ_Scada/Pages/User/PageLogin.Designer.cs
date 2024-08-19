namespace AutoTF
{
    partial class PageLogin
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
            uiPanel1 = new Sunny.UI.UIPanel();
            label1 = new System.Windows.Forms.Label();
            uiTextBox2 = new Sunny.UI.UITextBox();
            uiComboBox1 = new Sunny.UI.UIComboBox();
            uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiLine1 = new Sunny.UI.UILine();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = System.Drawing.Color.Transparent;
            uiPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            uiPanel1.Controls.Add(label1);
            uiPanel1.Controls.Add(uiTextBox2);
            uiPanel1.Controls.Add(uiComboBox1);
            uiPanel1.Controls.Add(uiSymbolButton2);
            uiPanel1.Controls.Add(uiSymbolButton1);
            uiPanel1.Controls.Add(uiTextBox1);
            uiPanel1.Controls.Add(uiLine1);
            uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            uiPanel1.ForeDisableColor = System.Drawing.Color.FromArgb(255, 255, 128);
            uiPanel1.Location = new System.Drawing.Point(0, 0);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Radius = 20;
            uiPanel1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            uiPanel1.RectSize = 2;
            uiPanel1.Size = new System.Drawing.Size(849, 606);
            uiPanel1.StyleCustomMode = true;
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            label1.Location = new System.Drawing.Point(162, 71);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(495, 78);
            label1.TabIndex = 13;
            label1.Text = "缔微致上位机";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBox2
            // 
            uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            uiTextBox2.DoubleValue = 1111111D;
            uiTextBox2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox2.IconSize = 20;
            uiTextBox2.IntValue = 1111111;
            uiTextBox2.Location = new System.Drawing.Point(255, 419);
            uiTextBox2.Margin = new System.Windows.Forms.Padding(0);
            uiTextBox2.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new System.Windows.Forms.Padding(1);
            uiTextBox2.ReadOnly = true;
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new System.Drawing.Size(204, 60);
            uiTextBox2.Symbol = 61530;
            uiTextBox2.TabIndex = 10;
            uiTextBox2.Text = "1111111";
            uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "账号所属权限";
            uiTextBox2.TextChanged += uiTextBox2_TextChanged;
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            uiComboBox1.FillColor = System.Drawing.Color.White;
            uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiComboBox1.ItemHeight = 35;
            uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            uiComboBox1.Location = new System.Drawing.Point(255, 280);
            uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            uiComboBox1.Size = new System.Drawing.Size(204, 59);
            uiComboBox1.SymbolSize = 24;
            uiComboBox1.TabIndex = 6;
            uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "请选择用户";
            uiComboBox1.SelectedIndexChanged += uiComboBox1_SelectedIndexChanged;
            // 
            // uiSymbolButton2
            // 
            uiSymbolButton2.BackColor = System.Drawing.Color.Transparent;
            uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            uiSymbolButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            uiSymbolButton2.FillColor = System.Drawing.Color.IndianRed;
            uiSymbolButton2.FillColor2 = System.Drawing.Color.FromArgb(230, 80, 80);
            uiSymbolButton2.FillHoverColor = System.Drawing.Color.FromArgb(235, 115, 115);
            uiSymbolButton2.FillPressColor = System.Drawing.Color.FromArgb(184, 64, 64);
            uiSymbolButton2.FillSelectedColor = System.Drawing.Color.FromArgb(184, 64, 64);
            uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSymbolButton2.LightColor = System.Drawing.Color.FromArgb(253, 243, 243);
            uiSymbolButton2.Location = new System.Drawing.Point(501, 350);
            uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            uiSymbolButton2.Name = "uiSymbolButton2";
            uiSymbolButton2.Radius = 15;
            uiSymbolButton2.RectColor = System.Drawing.Color.DarkRed;
            uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(235, 115, 115);
            uiSymbolButton2.RectPressColor = System.Drawing.Color.Brown;
            uiSymbolButton2.RectSelectedColor = System.Drawing.Color.FromArgb(184, 64, 64);
            uiSymbolButton2.RectSize = 2;
            uiSymbolButton2.Size = new System.Drawing.Size(115, 40);
            uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            uiSymbolButton2.StyleCustomMode = true;
            uiSymbolButton2.Symbol = 61453;
            uiSymbolButton2.TabIndex = 5;
            uiSymbolButton2.Text = "取消";
            uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSymbolButton2.Click += uiSymbolButton2_Click;
            // 
            // uiSymbolButton1
            // 
            uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            uiSymbolButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            uiSymbolButton1.FillColor = System.Drawing.Color.DeepSkyBlue;
            uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSymbolButton1.Location = new System.Drawing.Point(501, 281);
            uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            uiSymbolButton1.Name = "uiSymbolButton1";
            uiSymbolButton1.Radius = 15;
            uiSymbolButton1.RectSize = 2;
            uiSymbolButton1.Size = new System.Drawing.Size(115, 40);
            uiSymbolButton1.TabIndex = 4;
            uiSymbolButton1.Text = "登录";
            uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiSymbolButton1.Click += uiSymbolButton1_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiTextBox1.Location = new System.Drawing.Point(255, 349);
            uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            uiTextBox1.PasswordChar = '*';
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new System.Drawing.Size(204, 60);
            uiTextBox1.Symbol = 61475;
            uiTextBox1.TabIndex = 0;
            uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "请输入密码";
            uiTextBox1.KeyDown += uiTextBox1_KeyDown;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = System.Drawing.Color.Transparent;
            uiLine1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLine1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLine1.Location = new System.Drawing.Point(246, 202);
            uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new System.Drawing.Size(319, 62);
            uiLine1.TabIndex = 1;
            uiLine1.Text = "用户登录";
            // 
            // PageLogin
            // 
            AllowShowTitle = false;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(253, 249, 241);
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(849, 606);
            ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(227, 175, 83);
            Controls.Add(uiPanel1);
            ExtendSymbol = 62144;
            Font = new System.Drawing.Font("宋体", 14F);
            Name = "PageLogin";
            Padding = new System.Windows.Forms.Padding(0);
            RectColor = System.Drawing.Color.Transparent;
            ShowTitle = false;
            Style = Sunny.UI.UIStyle.Custom;
            StyleCustomMode = true;
            Text = "登录";
            TitleColor = System.Drawing.Color.Transparent;
            ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 750, 451);
            Load += FrmLogin_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UITextBox uiTextBox2;
        private System.Windows.Forms.Label label1;
    }
}