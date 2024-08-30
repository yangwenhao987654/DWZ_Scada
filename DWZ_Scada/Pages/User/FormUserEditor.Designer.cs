namespace SJTU_UI.Pages.User
{
    partial class FormUserEditor
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
            if(disposing && (components != null))
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
            btnCancel = new Sunny.UI.UIButton();
            btnOK = new Sunny.UI.UIButton();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            tbxPassword = new Sunny.UI.UITextBox();
            tbxUserName = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiComboBox1 = new Sunny.UI.UIComboBox();
            tbxUserCode = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnCancel.Location = new System.Drawing.Point(456, 347);
            btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(135, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            btnOK.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnOK.Location = new System.Drawing.Point(215, 347);
            btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(135, 50);
            btnOK.TabIndex = 0;
            btnOK.Text = "确定";
            btnOK.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            uiTableLayoutPanel1.Controls.Add(tbxPassword, 1, 2);
            uiTableLayoutPanel1.Controls.Add(tbxUserName, 1, 1);
            uiTableLayoutPanel1.Controls.Add(uiLabel2, 0, 1);
            uiTableLayoutPanel1.Controls.Add(uiLabel3, 0, 2);
            uiTableLayoutPanel1.Controls.Add(uiLabel4, 0, 3);
            uiTableLayoutPanel1.Controls.Add(uiComboBox1, 1, 3);
            uiTableLayoutPanel1.Controls.Add(tbxUserCode, 1, 0);
            uiTableLayoutPanel1.Controls.Add(uiLabel1, 0, 0);
            uiTableLayoutPanel1.Location = new System.Drawing.Point(19, 63);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 4;
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            uiTableLayoutPanel1.Size = new System.Drawing.Size(704, 258);
            uiTableLayoutPanel1.TabIndex = 1;
            uiTableLayoutPanel1.TagString = null;
            // 
            // tbxPassword
            // 
            tbxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            tbxPassword.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxPassword.Location = new System.Drawing.Point(285, 133);
            tbxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxPassword.MinimumSize = new System.Drawing.Size(1, 16);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.ShowText = false;
            tbxPassword.Size = new System.Drawing.Size(289, 54);
            tbxPassword.TabIndex = 7;
            tbxPassword.Text = "uiTextBox3";
            tbxPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxPassword.Watermark = "";
            // 
            // tbxUserName
            // 
            tbxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            tbxUserName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxUserName.Location = new System.Drawing.Point(285, 69);
            tbxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxUserName.MinimumSize = new System.Drawing.Size(1, 16);
            tbxUserName.Name = "tbxUserName";
            tbxUserName.ShowText = false;
            tbxUserName.Size = new System.Drawing.Size(289, 54);
            tbxUserName.TabIndex = 6;
            tbxUserName.Text = "uiTextBox2";
            tbxUserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxUserName.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(3, 64);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(272, 62);
            uiLabel2.TabIndex = 1;
            uiLabel2.Text = "姓名：";
            uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new System.Drawing.Point(3, 128);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new System.Drawing.Size(272, 62);
            uiLabel3.TabIndex = 2;
            uiLabel3.Text = "密码：";
            uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new System.Drawing.Point(3, 192);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new System.Drawing.Size(272, 62);
            uiLabel4.TabIndex = 3;
            uiLabel4.Text = "权限：";
            uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = System.Drawing.Color.White;
            uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiComboBox1.ItemHeight = 35;
            uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(155, 200, 255);
            uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(235, 243, 255);
            uiComboBox1.Location = new System.Drawing.Point(285, 197);
            uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            uiComboBox1.Size = new System.Drawing.Size(348, 56);
            uiComboBox1.SymbolSize = 24;
            uiComboBox1.TabIndex = 4;
            uiComboBox1.Text = "uiComboBox1";
            uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // tbxUserCode
            // 
            tbxUserCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            tbxUserCode.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            tbxUserCode.Location = new System.Drawing.Point(285, 5);
            tbxUserCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tbxUserCode.MinimumSize = new System.Drawing.Size(1, 16);
            tbxUserCode.Name = "tbxUserCode";
            tbxUserCode.ShowText = false;
            tbxUserCode.Size = new System.Drawing.Size(289, 54);
            tbxUserCode.TabIndex = 5;
            tbxUserCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            tbxUserCode.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(3, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(272, 62);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "工号：";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormUserEditor
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(745, 418);
            Controls.Add(btnCancel);
            Controls.Add(uiTableLayoutPanel1);
            Controls.Add(btnOK);
            Name = "FormUserEditor";
            Text = "用户编辑";
            ZoomScaleRect = new System.Drawing.Rectangle(26, 26, 800, 450);
            Load += FormUserEditor_Load;
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton btnCancel;
        private Sunny.UI.UIButton btnOK;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UITextBox tbxPassword;
        private Sunny.UI.UITextBox tbxUserName;
        private Sunny.UI.UITextBox tbxUserCode;
    }
}