namespace DWZ_Scada.Pages.StationPages.OP30
{
    partial class PageOP30
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
            uiPanel1 = new Sunny.UI.UIPanel();
            uiPanel2 = new Sunny.UI.UIPanel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            op30CtrlResult_Vision1 = new DIPTest.Ctrl.UserCtrlResult();
            Op30CtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            workOrderCtrlWithoutPart1 = new ctrls.workOrderCtrlWithoutPart();
            uiPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new System.Drawing.Point(0, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new System.Drawing.Size(1280, 59);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "OP30-画像检查工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiPanel2);
            uiPanel1.Controls.Add(op30CtrlResult_Vision1);
            uiPanel1.Controls.Add(Op30CtrlEntry1);
            uiPanel1.Controls.Add(uiLabel7);
            uiPanel1.Controls.Add(uiLabel6);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(27, 197);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1224, 619);
            uiPanel1.TabIndex = 1;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanel2
            // 
            uiPanel2.Controls.Add(myLogCtrl1);
            uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel2.Location = new System.Drawing.Point(58, 295);
            uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Size = new System.Drawing.Size(1075, 285);
            uiPanel2.TabIndex = 24;
            uiPanel2.Text = "uiPanel2";
            uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myLogCtrl1
            // 
            myLogCtrl1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            myLogCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myLogCtrl1.Font = new System.Drawing.Font("微软雅黑", 12F);
            myLogCtrl1.FullRowSelect = true;
            myLogCtrl1.HideSelection = true;
            myLogCtrl1.LabelWrap = false;
            myLogCtrl1.Location = new System.Drawing.Point(0, 0);
            myLogCtrl1.Name = "myLogCtrl1";
            myLogCtrl1.Size = new System.Drawing.Size(1075, 285);
            myLogCtrl1.TabIndex = 23;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // op30CtrlResult_Vision1
            // 
            op30CtrlResult_Vision1.Location = new System.Drawing.Point(58, 66);
            op30CtrlResult_Vision1.Margin = new System.Windows.Forms.Padding(4);
            op30CtrlResult_Vision1.Name = "op30CtrlResult_Vision1";
            op30CtrlResult_Vision1.Size = new System.Drawing.Size(400, 200);
            op30CtrlResult_Vision1.TabIndex = 22;
            op30CtrlResult_Vision1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            op30CtrlResult_Vision1.TextFont = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // Op30CtrlEntry1
            // 
            Op30CtrlEntry1.Location = new System.Drawing.Point(728, 62);
            Op30CtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            Op30CtrlEntry1.Name = "Op30CtrlEntry1";
            Op30CtrlEntry1.Size = new System.Drawing.Size(400, 200);
            Op30CtrlEntry1.TabIndex = 21;
            Op30CtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Op30CtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new System.Drawing.Point(728, 20);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new System.Drawing.Size(176, 38);
            uiLabel7.TabIndex = 2;
            uiLabel7.Text = "OP30进站临时码:";
            uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new System.Drawing.Point(58, 24);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new System.Drawing.Size(160, 34);
            uiLabel6.TabIndex = 1;
            uiLabel6.Text = "OP30画像检测:";
            uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel6.Click += uiLabel6_Click;
            // 
            // workOrderCtrlWithoutPart1
            // 
            workOrderCtrlWithoutPart1.BackColor = System.Drawing.Color.Transparent;
            workOrderCtrlWithoutPart1.CurPartNo = "";
            workOrderCtrlWithoutPart1.CurProductCode = "";
            workOrderCtrlWithoutPart1.CurProductName = "";
            workOrderCtrlWithoutPart1.CurWorkOrderNo = "";
            workOrderCtrlWithoutPart1.IsCheckPass = false;
            workOrderCtrlWithoutPart1.Location = new System.Drawing.Point(27, 79);
            workOrderCtrlWithoutPart1.Name = "workOrderCtrlWithoutPart1";
            workOrderCtrlWithoutPart1.Orders = null;
            workOrderCtrlWithoutPart1.Size = new System.Drawing.Size(1195, 75);
            workOrderCtrlWithoutPart1.SpotEnable = false;
            workOrderCtrlWithoutPart1.TabIndex = 2;
            // 
            // PageOP30
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 840);
            Controls.Add(workOrderCtrlWithoutPart1);
            Controls.Add(uiPanel1);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP30";
            Text = "OP30";
            TitleFillColor = System.Drawing.Color.Transparent;
            TitleHeight = 19;
            Initialize += PageOP30_Initialize;
            FormClosing += PageOP30_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            uiPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private DIPTest.Ctrl.UserCtrlEntry Op30CtrlEntry1;
        private DIPTest.Ctrl.UserCtrlResult op30CtrlResult_Vision1;
        private ctrls.MyLogCtrl myLogCtrl1;
        private Sunny.UI.UIPanel uiPanel2;
        private ctrls.workOrderCtrlWithoutPart workOrderCtrlWithoutPart1;
    }
}