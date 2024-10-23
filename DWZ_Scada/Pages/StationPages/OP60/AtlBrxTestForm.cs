using DWZ_Scada.ctrls;
using DWZ_Scada.ctrls.LogCtrl;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada.Pages.StationPages.OP60
{
    public partial class AtlBrxTestForm : UIForm
    {
        Mylog mylog;
        public AtlBrxTestForm()
        {
            InitializeComponent();
            mylog = new Mylog(myLogCtrl1);
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void AtlBrxTestForm_Load(object sender, EventArgs e)
        {
            uiComboBox1.Items.Add("AtlBrx_01");
            uiComboBox1.Items.Add("AtlBrx_02");
            uiComboBox1.Items.Add("安规_01");
            uiComboBox1.Items.Add("安规_02");
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = uiComboBox1.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            string ip = "";
            string port = "";
            switch (index)
            {
                case 0:
                    ip = SystemParams.Instance.OP60_AtlBrx_01_IP;
                    port = SystemParams.Instance.OP60_AtlBrx_01_Port;
                    break;
                case 1:
                    ip = SystemParams.Instance.OP60_AtlBrx_02_IP;
                    port = SystemParams.Instance.OP60_AtlBrx_02_Port;
                    break;
                case 2:
                    ip = SystemParams.Instance.OP60_Dyn_01_IP;
                    port = SystemParams.Instance.OP60_Dyn_01_Port;
                    break;
                case 3:
                    ip = SystemParams.Instance.OP60_Dyn_02_IP;
                    port = SystemParams.Instance.OP60_Dyn_02_Port;
                    break;
                default:
                    break;

            }
            tbxIP.Text = ip;
            tbxPort.Text = port;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string command = tbxCommand.Text;
            mylog.Debug($"发送指令:{command}");
        }

        private void AtlBrxTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mylog?.Dispose();
        }
    }
}
