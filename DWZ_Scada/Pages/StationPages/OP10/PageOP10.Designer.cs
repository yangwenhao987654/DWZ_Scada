using Sunny.UI;

namespace DWZ_Scada.Pages.StationPages.OP10
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
            //this.PageOP10_FormClosing(this,null);
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
            uiLabel1 = new UILabel();
            uiLabel8 = new UILabel();
            uiLabel11 = new UILabel();
            lbl_EntryResult = new UILabel();
            myLogCtrl1 = new ctrls.MyLogCtrl();
            uiPanel1 = new UIPanel();
            ctrlResult_V2 = new DIPTest.Ctrl.UserCtrlResult();
            ctrlResult_V1 = new DIPTest.Ctrl.UserCtrlResult();
            userCtrlEntry1 = new DIPTest.Ctrl.UserCtrlEntry();
            uiLabel2 = new UILabel();
            workOrderCtrl1 = new ctrls.workOrderCtrl();
            uiPanel1.SuspendLayout();
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
            uiLabel1.Text = "OP10-上料打码工站";
            uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new System.Drawing.Point(452, 229);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new System.Drawing.Size(183, 42);
            uiLabel8.TabIndex = 25;
            uiLabel8.Text = "画像检测1:";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new System.Drawing.Point(70, 229);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new System.Drawing.Size(159, 42);
            uiLabel11.TabIndex = 26;
            uiLabel11.Text = "画像检测2:";
            // 
            // lbl_EntryResult
            // 
            lbl_EntryResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            lbl_EntryResult.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            lbl_EntryResult.Location = new System.Drawing.Point(176, 339);
            lbl_EntryResult.Name = "lbl_EntryResult";
            lbl_EntryResult.Size = new System.Drawing.Size(220, 42);
            lbl_EntryResult.TabIndex = 30;
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
            myLogCtrl1.MultiSelect = false;
            myLogCtrl1.Name = "myLogCtrl1";
            myLogCtrl1.Size = new System.Drawing.Size(1189, 269);
            myLogCtrl1.TabIndex = 33;
            myLogCtrl1.UseCompatibleStateImageBehavior = false;
            myLogCtrl1.View = System.Windows.Forms.View.Details;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(myLogCtrl1);
            uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiPanel1.Location = new System.Drawing.Point(39, 537);
            uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new System.Drawing.Size(1189, 269);
            uiPanel1.TabIndex = 34;
            uiPanel1.Text = "uiPanel1";
            uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlResult_V2
            // 
            ctrlResult_V2.Location = new System.Drawing.Point(70, 275);
            ctrlResult_V2.Margin = new System.Windows.Forms.Padding(4);
            ctrlResult_V2.Name = "ctrlResult_V2";
            ctrlResult_V2.Size = new System.Drawing.Size(313, 204);
            ctrlResult_V2.TabIndex = 35;
            ctrlResult_V2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ctrlResult_V2.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // ctrlResult_V1
            // 
            ctrlResult_V1.Location = new System.Drawing.Point(452, 275);
            ctrlResult_V1.Margin = new System.Windows.Forms.Padding(4);
            ctrlResult_V1.Name = "ctrlResult_V1";
            ctrlResult_V1.Size = new System.Drawing.Size(313, 204);
            ctrlResult_V1.TabIndex = 36;
            ctrlResult_V1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ctrlResult_V1.TextFont = new System.Drawing.Font("幼圆", 40F, System.Drawing.FontStyle.Bold);
            // 
            // userCtrlEntry1
            // 
            userCtrlEntry1.Location = new System.Drawing.Point(867, 275);
            userCtrlEntry1.Margin = new System.Windows.Forms.Padding(4);
            userCtrlEntry1.Name = "userCtrlEntry1";
            userCtrlEntry1.Size = new System.Drawing.Size(313, 204);
            userCtrlEntry1.TabIndex = 37;
            userCtrlEntry1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            userCtrlEntry1.TextFont = new System.Drawing.Font("微软雅黑", 50F);
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = System.Drawing.Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new System.Drawing.Point(867, 229);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new System.Drawing.Size(131, 30);
            uiLabel2.TabIndex = 38;
            uiLabel2.Text = "产品进站:";
            // 
            // workOrderCtrl1
            // 
            workOrderCtrl1.BackColor = System.Drawing.Color.Transparent;
            workOrderCtrl1.CurPartNo = "";
            workOrderCtrl1.CurProductCode = "";
            workOrderCtrl1.CurProductName = "";
            workOrderCtrl1.CurWorkOrderNo = "";
            workOrderCtrl1.IsCheckPass = false;
            workOrderCtrl1.Location = new System.Drawing.Point(12, 62);
            workOrderCtrl1.Name = "workOrderCtrl1";
            workOrderCtrl1.Orders = null;
            workOrderCtrl1.ProductBomList = null;
            workOrderCtrl1.Size = new System.Drawing.Size(1256, 112);
            workOrderCtrl1.SpotEnable = false;
            workOrderCtrl1.TabIndex = 39;
            workOrderCtrl1.Load += workOrderCtrl1_Load;
            // 
            // PageOP10
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1280, 820);
            Controls.Add(workOrderCtrl1);
            Controls.Add(uiLabel2);
            Controls.Add(userCtrlEntry1);
            Controls.Add(ctrlResult_V1);
            Controls.Add(ctrlResult_V2);
            Controls.Add(uiPanel1);
            Controls.Add(lbl_EntryResult);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel8);
            Controls.Add(uiLabel1);
            Font = new System.Drawing.Font("宋体", 8F);
            Name = "PageOP10";
            Text = "OP10";
            TitleFillColor = System.Drawing.Color.Transparent;
            FormClosing += PageOP10_FormClosing;
            Load += Page_Load;
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel11;
        private UILabel lbl_EntryResult;
        private ctrls.MyLogCtrl myLogCtrl1;
        private UIPanel uiPanel1;
        private DIPTest.Ctrl.UserCtrlResult ctrlResult_V2;
        private DIPTest.Ctrl.UserCtrlResult ctrlResult_V1;
        private DIPTest.Ctrl.UserCtrlEntry userCtrlEntry1;
        private UILabel uiLabel2;
        private ctrls.workOrderCtrl workOrderCtrl1;
    }
}