using Sunny.UI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls
{
    public partial class windingCtrl : UserControl
    {
        private TimeSpan ts;
        public windingCtrl()
        {
            InitializeComponent();
            updateBackColor = new Action<Color>((color) =>
                UpdateBackColor(color)
            );

            updateWeldingTime = new Action(() =>
            {
                ts = sw.Elapsed;
                //uiLedStopwatch1.Text = $"{ts.Minutes:D2}:{ts.Seconds:D2}";
                //lbl_timeTime.Text = $"绕线时间:{sw.Elapsed.TotalSeconds:F2} S";
                lbl_time.Text = $"{ts.Minutes:D2}:{ts.Seconds:D2}";
            });
        }


        public int  Index { get; set; }
        public bool IsEnable { get; set; }

        private Timer timer;

        private Action<Color> updateBackColor;

        private Action updateWeldingTime;

        /*    public windingCtrl(string weldingName):this()
            {
                WeldingTitle = weldingName;
            }*/
        [Browsable(true)]
        [DisplayName("绕线机名称"), Category("AAA自定义_绕线"), Description("请输入绕线机的名称")]
        public string WeldingTitle
        {
            get => uiLabel1.Text;
            set => uiLabel1.Text = value;
        }

        public int CurState { get; set; } = -100;

        /// <summary>
        /// 运行中状态
        /// </summary>
        public int RunningState { get; set; } = 12;

        /*   [Browsable(true)]
           [DisplayName("绕线机名称"), Category("AAA自定义_绕线"), Description("请输入绕线机的名称")]*/


        private Stopwatch sw;
        private void windingCtrl_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            //timer.Enabled = true;
            //timer.ReStart();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            sw = new Stopwatch();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            /*     if (InvokeRequired)
                 {
                    //lbl_timeTime.Invoke(new Action(update))
                 }*/
            updateWeldingTime?.Invoke();
        }

        public void UpdateState(int state)
        {
            if (state == CurState)
            {
                return;
            }

            if (InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateState(state)));
                return;
            }
            CurState = state;
            switch (state)
            {
                case 1:
                    //uiLight1.OnColor = Color.DarkGray;
                    Wait();
                    break;
                case 0:
                    //uiLight1.OnColor = Color.Red;
                    Err();
                    break;
                case 12:
                    //uiLight1.OnColor = Color.Green;
                    Running();
                    break;
                case -1:
                    //uiLight1.OnColor = Color.Green;
                    OffLine();
                    break;
                case 99:
                    //uiLight1.OnColor = Color.Green;
                    SetDisable();
                    break;
                default:
                    //uiLight1.OnColor = Color.Gray;
                    break;
            }
            //TODO 假如不是运行中 停止绕线时间监控显示
            /*  if (state!=12)
              {
                  sw.Stop();
                  timer.Stop();
              }*/
            if (state != RunningState)
            {
                sw.Stop();
                timer.Stop();
            }
        }

        private void UpdateBackColor(Color color)
        {
            uiPanel1.FillColor = color;
        }

        public void Running()
        {
            //这里已经保证切换到UI线程了
            Color color = Color.Yellow;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "测试中";
            timer.ReStart();
            sw.Reset();
            sw.Start();
        }

        public void StopTest()
        {
            Color color = Color.Aqua;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
        }

        public void Wait()
        {
            Color color = Color.Green;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "等待中";
        }

        public void OffLine()
        {
            Color color = Color.Gray;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "未连接";
        }

        public void Err()
        {
            Color color = Color.FromArgb(255, 192, 192);
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "故障中";
        }

        public void SetDisable()
        {
            Color color = Color.Beige;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "禁用中";
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Load(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void 禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsEnable)
            {
                return;
            }
            IsEnable = false;
            SystemParams.Instance.OP20_WeldingEnableList[Index] = false;
            UpdateState(99);
        }

        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsEnable)
            {
                return;
            }
            IsEnable =true;
            SystemParams.Instance.OP20_WeldingEnableList[Index] = true;
            UpdateState(-1);
        }
    }
}
