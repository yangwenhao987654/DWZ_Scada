using DWZ_Scada.Page.PLCControl;
using Sunny.UI;
using System;
using System.Windows.Forms;

namespace DWZ_Scada.Pages
{
    public partial class PageAlarmTabMenu : UIPage
    {
        private PageAlarmTabMenu()
        {
            InitializeComponent();
        }

        private static PageAlarmTabMenu _instance;
        public static PageAlarmTabMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageAlarmTabMenu))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageAlarmTabMenu();
                        }
                    }
                }
                return _instance;
            }
        }

        private void PageTabMenu_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        private void InitPage()
        {
            //报警信息配置
            Page_PLCAlarmConfig pageAlarmConfig = Page_PLCAlarmConfig.Instance;
            pageAlarmConfig.Dock = DockStyle.Fill;
            pageAlarmConfig.Show();
            tabPage1.Controls.Add(pageAlarmConfig);

            //历史报警查询
            Page_DeviceAlarmQuery pageDeviceAlarmQuery = Page_DeviceAlarmQuery.Instance;
            pageDeviceAlarmQuery.Dock = DockStyle.Fill;
            pageDeviceAlarmQuery.Show();
            tabPage2.Controls.Add(pageDeviceAlarmQuery);
        }
    }
}
