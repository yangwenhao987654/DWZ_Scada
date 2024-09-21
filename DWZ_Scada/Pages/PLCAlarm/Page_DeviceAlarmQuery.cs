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
    public partial class Page_DeviceAlarmQuery : UIPage
    {
        private static Page_DeviceAlarmQuery _instance;
        public static Page_DeviceAlarmQuery Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(Page_DeviceAlarmQuery))
                    {
                        if (_instance == null)
                        {
                            _instance = new Page_DeviceAlarmQuery();
                        }
                    }
                }
                return _instance;
            }
        }
        private Page_DeviceAlarmQuery()
        {
            InitializeComponent();
        }

        private void Formula_set_FormClosing(object sender, FormClosingEventArgs e)
        {
            Page_DeviceAlarmQuery.Instance?.Dispose();
        }
    }
}
