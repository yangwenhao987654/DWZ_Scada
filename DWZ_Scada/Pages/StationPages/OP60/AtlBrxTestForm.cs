using CommunicationUtilYwh.Device;
using DWZ_Scada.ctrls;
using DWZ_Scada.ctrls.LogCtrl;
using DWZ_Scada.Pages.StationPages.OP10;
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

        TcpDevice1 device = new TcpDevice1("测试机");
        public AtlBrxTestForm()
        {
            InitializeComponent();
            mylog = new Mylog(myLogCtrl1);
           GlobalOP60.IsOpenDebugTCPDevice = true;
           GlobalOP60.EnableDisConnect = true;
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
                    ip = SystemParams.Instance.OP60_Safety_01_IP;
                    port = SystemParams.Instance.OP60_Safety_01_Port;
                    break;
                case 3:
                    ip = SystemParams.Instance.OP60_Safety_02_IP;
                    port = SystemParams.Instance.OP60_Safety_02_Port;
                    break;
                default:
                    break;

            }
            tbxIP.Text = ip;
            tbxPort.Text = port;
            device?.Disconnect();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string command = tbxCommand.Text;
            mylog.Debug($"发送指令:{command}");
        }

        private void AtlBrxTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mylog?.Dispose();
            device?.Disconnect();
            GlobalOP60.IsOpenDebugTCPDevice = false;
        }

        private async void uiButton11_Click(object sender, EventArgs e)
        {
            uiButton11.Enabled = false;
            string ip = tbxIP.Text;
            string port = tbxPort.Text;
            (bool f, string err) =await device.ConnectAsync(ip, port);
            if (!f)
            {
                UIMessageBox.ShowError($"连接错误:{err}");
                uiButton11.Enabled = true;
                uiButton12.Enabled = false;
                return;
            }
            mylog.Info("打开连接");
            uiButton12.Enabled = true;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string msg = device.QueryIsReady();

            mylog?.Debug(msg);
        }

        private void uiButton12_Click(object sender, EventArgs e)
        {
            device?.Disconnect();
            mylog.Info("关闭连接");
            uiButton11.Enabled = true;
            uiButton12.Enabled = false;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            string msg = device.TriggerWork();
            mylog?.Debug(msg);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string msg = device.QueryTestStatus();

            mylog?.Debug(msg);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            string msg = device.QueryWorkResult();

            mylog?.Debug(msg);
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            string msg = device.QueryDetailsWorkResult();

            mylog?.Debug(msg);
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            string msg = device.ClearData();

            mylog?.Debug(msg);
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            string msg = device.Stop();

            mylog?.Debug(msg);
        }

        private void uiButton9_Click(object sender, EventArgs e)
        {
            string msg = device.QuerySchemeName();

            mylog?.Debug(msg);
        }

        private void uiButton10_Click(object sender, EventArgs e)
        {
            string str = tbxCommand.Text;
            string msg = device.UpdateSchemeName(str);

            mylog?.Debug(msg);
        }

        private void uiButton13_Click(object sender, EventArgs e)
        {
            string str = tbxCommand.Text;
            string msg = device.UpdateProduct(str);

            mylog?.Debug(msg);
        }
    }
}
