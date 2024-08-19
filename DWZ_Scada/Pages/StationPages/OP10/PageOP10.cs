
using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWZ_Scada;

namespace DWZ_Scada
{
    public partial class PageOP10 : UIPage
    {
        /// <summary>
        /// 当前站名
        /// DIP_Input
        /// </summary>
        private const string CURRENT_STATION_NAME = "OP10";

        public PageOP10()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            LogMgr.Instance.SetCtrl(listViewEx_Log1);
            LogMgr.Instance.Debug("打开OP10工站");
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
