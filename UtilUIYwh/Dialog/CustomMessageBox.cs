using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace Cap.Dialog
{
    public partial class CustomMessageBox : UIForm
    {
        public CustomMessageBox(string a, string b)
        {
            InitializeComponent();
            source1 = a;
            source2 = b;
        }

        private string source1;
        private string source2;


        private void uiButton6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (string.IsNullOrEmpty(tbxA.Text))
            {
                UIMessageBox.ShowError("请输入工位A物料码");
                return;

            }
            if (string.IsNullOrEmpty(tbxB.Text))
            {
                UIMessageBox.ShowError("请输入工位B物料码");
                return;
            }
            GetResult();
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GetResult()
        {
            Input1 = tbxA.Text;
            Input2 = tbxB.Text;
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            lbl1.Text = source1;
            lbl2.Text = source2;
        }

        public string Input1 { get; set; }

        public string Input2 { get; set; }


        public bool IsInputFinish { get; set; }
    }
}
