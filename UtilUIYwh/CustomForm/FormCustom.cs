using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cap
{
    public partial class FormCustom : Form
    {
        public event EventHandler CustomFormClosed;
        public FormCustom(Control c)
        {
            InitializeComponent();
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
            this.Closed += FormCustom_Closed;
        }

        private void FormCustom_Closed(object sender, EventArgs e)
        {
           OnCustomFormClosed();
        }

        protected virtual void OnCustomFormClosed()
        {
            CustomFormClosed?.Invoke(this,null);
        }

        public FormCustom(Control c ,string title)
        {
            InitializeComponent();
            this.Text = title;
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
            this.Closed += FormCustom_Closed;
        }
    }
}
