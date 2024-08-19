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
            this.components = new System.ComponentModel.Container();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.listViewEx_Log1 = new LogTool.ListViewEx_Log(this.components);
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(1692, 59);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "OP10-上料打码工站";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // listViewEx_Log1
            // 
            this.listViewEx_Log1.AutoArrange = false;
            this.listViewEx_Log1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewEx_Log1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewEx_Log1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewEx_Log1.HideSelection = false;
            this.listViewEx_Log1.LabelWrap = false;
            this.listViewEx_Log1.Location = new System.Drawing.Point(0, 667);
            this.listViewEx_Log1.MultiSelect = false;
            this.listViewEx_Log1.Name = "listViewEx_Log1";
            this.listViewEx_Log1.ShowGroups = false;
            this.listViewEx_Log1.Size = new System.Drawing.Size(1692, 232);
            this.listViewEx_Log1.TabIndex = 2;
            this.listViewEx_Log1.TabStop = false;
            this.listViewEx_Log1.UseCompatibleStateImageBehavior = false;
            this.listViewEx_Log1.View = System.Windows.Forms.View.Details;
            // 
            // PageOP10
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1692, 899);
            this.Controls.Add(this.listViewEx_Log1);
            this.Controls.Add(this.uiLabel1);
            this.Font = new System.Drawing.Font("宋体", 8F);
            this.Name = "PageOP10";
            this.Text = "PageOP10";
            this.Load += new System.EventHandler(this.Page_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private LogTool.ListViewEx_Log listViewEx_Log1;
    }
}