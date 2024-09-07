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
    public partial class Formula_set : UIForm
    {
        private static Formula_set _instance;
        public static Formula_set Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Formula_set))
                    {
                        if (_instance == null)
                        {
                            _instance = new Formula_set();
                        }
                    }
                }
                return _instance;
            }
        }
        public Formula_set()
        {
            InitializeComponent();
        }

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Formula_set.Instance?.Dispose();
        }
    }
}
