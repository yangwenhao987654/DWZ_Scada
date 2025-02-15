﻿using Cap.Dialog;
using LogTool;
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


        public int Index { get; set; }
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
                case WindingState.Stop:
                    Wait();
                    break;
                case WindingState.Alarm:
                    Err();
                    break;
                case WindingState.Running:
                    Running();
                    break;
                case WindingState.OffLine:
                    OffLine();
                    break;
                case WindingState.Disable:
                    SetDisable();
                    break;
                default:
                    break;
            }
            if (state != WindingState.Running)
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
            Color color = Color.Green;
            if (InvokeRequired)
            {
                BeginInvoke(updateBackColor, color);
                return;
            }
            updateBackColor(color);
            uiLabel2.Text = "运行中";
            timer.ReStart();
            sw.Reset();
            sw.Start();
        }


        public void SetSN(string sn1, string sn2)
        {
            //这里已经保证切换到UI线程了

            if (InvokeRequired)
            {
                BeginInvoke(SetSN, sn1, sn2);
                return;
            }
            lblSN1.Text = sn1;
            lblSN2.Text = sn2;
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
            Color color = Color.Orange;
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
            Color color = Color.Red;
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
            Color color = Color.White;
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
            CustomMessageBox dialog = new CustomMessageBox(SystemParams.Instance.OP20_WuliaoList1[Index], SystemParams.Instance.OP20_WuliaoList2[Index]);
            dialog.ShowDialog();
            if (dialog.DialogResult==DialogResult.Cancel)
            {
                return;
            }

            Wuliao1 = dialog.Input1;
            Wuliao2 = dialog.Input2;
            LogMgr.Instance.Info($"{WeldingTitle} 录入物料工位1:{Wuliao1}");
            LogMgr.Instance.Info($"{WeldingTitle} 录入物料工位2:{Wuliao2}");
            //物料持久化
            SystemParams.Instance.OP20_WuliaoList1[Index]= Wuliao1;
            //物料持久化
            SystemParams.Instance.OP20_WuliaoList2[Index] = Wuliao2;
        }

        private void 禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsEnable)
            {
                return;
            }
            IsEnable = false;
            SystemParams.Instance.OP20_WeldingEnableList[Index] = false;
            UpdateState(WindingState.Disable);
        }

        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsEnable)
            {
                return;
            }
            IsEnable = true;
            SystemParams.Instance.OP20_WeldingEnableList[Index] = true;
            UpdateState(WindingState.OffLine);
        }

        private void windingCtrl_Click(object sender, EventArgs e)
        {

        }


        private void uiTableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 输入的物料
        /// </summary>
        public string Wuliao1 { get; set; }

        public string Wuliao2 { get; set; }

        public bool IsWuliaoInput { get; set; }
    }

    public class WindingState
    {

        /// <summary>
        /// 未连接状态
        /// </summary>
        public const int OffLine = -1;


        public const int Running = 12;


        public const int Stop = 1;

        public const int Alarm = 2;

        /// <summary>
        /// 禁用状态
        /// </summary>
        public const int Disable = 99;
    }
}
