using System;
using System.Windows.Forms;
namespace LogTool
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

        public FormCustom()
        {
            InitializeComponent();
        }
        private static FormCustom _instance;
        public static FormCustom Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(FormCustom))
                    {
                        if (_instance == null)
                        {
                            _instance = new FormCustom();
                        }
                    }
                }
                return _instance;
            }
        }
        public ListViewEx_Log LogCtrl
        {
            get { return listViewEx_Log1; }
        }

        private void FormCustom_Closed(object sender, EventArgs e)
        {
            OnCustomFormClosed();
        }

        protected virtual void OnCustomFormClosed()
        {
            CustomFormClosed?.Invoke(this, null);
        }
        public FormCustom(Control c, string title)
        {
            InitializeComponent();
            this.Text = title;
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
            this.Closed += FormCustom_Closed;
        }

    }
}
