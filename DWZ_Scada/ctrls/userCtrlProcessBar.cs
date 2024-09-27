using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DIPTest.Ctrl
{
    public partial class userCtrlProcessBar : UserControl
    {
         string Msg;
         int Rate;
         bool IsAuto;
         int AutoEndRate;
         int Timeout = 0;
        Stopwatch watch;
        public userCtrlProcessBar()
        {
            InitializeComponent();
        }
        private void userCtrlProcessBar_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timer1.Enabled = true;
                ParentForm.FormClosing += ParentForm_FormClosing;
                watch = new Stopwatch();
            }
        }
        public void Init()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Init()));
                return;
            }
            this.IsAuto = false;
            uiLedStopwatch2.Active = false;
            uiLedStopwatch2.Text = "00:00";
            this.Rate = 0;
            this.Msg = "";
        }
        public void Start()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Start()));
                return;
            }
            uiLedStopwatch2.Active=true;
            SetProcess(0, "开始测试");
        }
        public void SetProcess(int rate,string msg)
        {
            this.Rate = rate;
            this.Msg = msg;
            if (IsAuto)
            {
                IsAuto = false;
                watch.Stop();
            }
        }
        public void AutoProcess(int rate,int time, string msg) 
        {
            if (rate<=Rate)
            {
                return;
            }
            this.Msg = msg;
            IsAuto = true;
            AutoEndRate = rate;
            Timeout = time;
            watch.Restart();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsAuto)
            {
                var rate = Rate + (AutoEndRate - Rate) * watch.ElapsedMilliseconds / 1000.0 / Timeout;
                if (rate<AutoEndRate+1)
                {
                    uiProcessBar1.Value = (int)rate;
                }
            }
            else
            {
                uiProcessBar1.Value = Rate;
            }
            if (uiProcessBar1.Value==100)
            {
                uiLedStopwatch2.Active = false;
            }
            uiLabel2.Text = Msg;
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
