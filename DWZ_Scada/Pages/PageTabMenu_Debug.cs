using DWZ_Scada.Page.PLCControl;
using LogTool;
using Sunny.UI;
using System;
using System.Windows.Forms;

namespace DWZ_Scada.Pages
{
    public partial class PageTabMenu_Debug : UIPage
    {
        private PageTabMenu_Debug()
        {
            InitializeComponent();
        }

        private ListViewEx_Log listViewExLog;

        private static PageTabMenu_Debug _instance;
        public static PageTabMenu_Debug Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PageTabMenu_Debug))
                    {
                        if (_instance == null)
                        {
                            _instance = new PageTabMenu_Debug();
                        }
                    }
                }
                return _instance;
            }
        }

        private void PageTabMenu_Load(object sender, EventArgs e)
        {
            listViewExLog = new ListViewEx_Log();

            //设置关闭弹窗后返回的位置
            listViewExLog.BindingControl = tabPage2;

            LogMgr.Instance.SetCtrl(listViewExLog);
            InitPage();
        }

        private void InitPage()
        {
            //报警信息配置
            DeviceControlPage page = DeviceControlPage.Instance;
            page.Dock = DockStyle.Fill;
            page.Show();
            tabPage1.Controls.Add(page);

            //历史报警查询
            
         /*   Page_DeviceAlarmQuery pageDeviceAlarmQuery = Page_DeviceAlarmQuery.Instance;
            pageDeviceAlarmQuery.Dock = DockStyle.Fill;
            pageDeviceAlarmQuery.Show();*/

         listViewExLog.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(listViewExLog);
        }
    }
}
