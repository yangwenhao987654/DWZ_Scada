using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace DWZ_Scada.Pages
{
    public partial class Page_Formula_Set : UIPage
    {
        private static Page_Formula_Set _instance;
        public static Page_Formula_Set Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_Formula_Set))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_Formula_Set();
                        }
                    }
                }
                return _instance;
            }
        }
        public Page_Formula_Set()
        {
            InitializeComponent();
        }

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_Formula_Set.Instance?.Dispose();
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
