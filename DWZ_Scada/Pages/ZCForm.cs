using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Timer = System.Threading.Timer;

namespace DWZ_Scada.Pages
{
    public partial class ZCForm : UIForm
    {

        private Timer timer;
        public ZCForm()
        {
            InitializeComponent();
        }

        private void ZCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ESC 键  会触发退出
            timer?.Dispose();
        }

        private void ZCForm_Load(object sender, EventArgs e)
        {
            timer = new Timer(TimerElapsed, null, 0, 100);
        }

        private void TimerElapsed(object state)
        {
            if (lblTime.InvokeRequired)
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                lblTime.Invoke(new Action(() =>
                {
                    TimerElapsed(id);
                }));
                return;
            } 
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            lblLoginName.Text ="调用线程ID:"+ state.ToString();
        }
    }
}
