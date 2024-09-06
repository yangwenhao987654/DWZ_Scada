namespace LogTool
{
    partial class FormCustom
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
            components = new System.ComponentModel.Container();
            listViewEx_Log1 = new ListViewEx_Log(components);
            SuspendLayout();
            // 
            // listViewEx_Log1
            // 
            listViewEx_Log1.AutoArrange = false;
            listViewEx_Log1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            listViewEx_Log1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewEx_Log1.LabelWrap = false;
            listViewEx_Log1.Location = new System.Drawing.Point(12, 12);
            listViewEx_Log1.MultiSelect = false;
            listViewEx_Log1.Name = "listViewEx_Log1";
            listViewEx_Log1.ShowGroups = false;
            listViewEx_Log1.Size = new System.Drawing.Size(1222, 737);
            listViewEx_Log1.TabIndex = 103;
            listViewEx_Log1.TabStop = false;
            listViewEx_Log1.UseCompatibleStateImageBehavior = false;
            listViewEx_Log1.View = System.Windows.Forms.View.Details;
            // 
            // FormCustom
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(1246, 761);
            Controls.Add(listViewEx_Log1);
            Name = "FormCustom";
            Text = "日志报警";
            ResumeLayout(false);
        }

        #endregion
        public ListViewEx_Log listViewEx_Log1;
    }
}