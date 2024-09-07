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
using AutoTF;
using LogTool;
using Sunny.UI;
using DWZ_Scada;
using DWZ_Scada.Pages;
using Timer = System.Threading.Timer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cap.Dialog;
using DIPTest;
using DWZ_Scada.Page.PLCControl;
using AutoStation;

namespace DWZ_Scada.Pages
{
    public partial class ZCForm : UIForm
    {
        private ListViewEx_Log listViewLog;
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
            AddFormTopanel(PageOP10.Instance);
            // 设置KeyPreview为true以捕获键盘事件
            this.KeyPreview = true;
            // 添加事件处理程序
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    AddFormTopanel(PageOP10.Instance);
                    break;
                case Keys.F2:
                    AddFormTopanel(Page_PLCAlarmConfigcs.Instance);
                    break;
                case Keys.F3:
                    AddFormTopanel(Formula_set.Instance);
                    break;
                case Keys.F4:
                    AddFormTopanel(Manual_Debug.Instance);
                    break;
                case Keys.F5:
                    AddFormTopanel(Form_set_PLC.Instance);
                    break;
                case Keys.F10:
                    AddFormTopanel(FormCustom.GetInstance(listViewLog, "日志报警"));
                    break;
                case Keys.F11:
                    AddFormTopanel(new PageProperty(SystemParams.Instance));
                    break;
                case Keys.F12:

                    break;

            }
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
            lblLoginName.Text = "调用线程ID:" + state.ToString();
        }

        public void AddFormTopanel(Form form)
        {
            this.uiPanel1.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.uiPanel1.Controls.Add(form);
            form.Show();
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            bool flag = SystemParams.Instance.OpLvl == 0;
            if (!flag)
            {
                UIMessageBox.ShowError("當前登錄賬號權限不足！");
                return;
            }
            AddFormTopanel(new PageProperty(SystemParams.Instance));
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Form_set_PLC.Instance);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            listViewLog = new ListViewEx_Log();
            LogMgr.Instance.SetCtrl(listViewLog);
            AddFormTopanel(FormCustom.GetInstance(listViewLog, "日志报警"));
        }
        private void uiButton3_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Formula_set.Instance);
        }
        private void uiButton4_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Manual_Debug.Instance);
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Page_PLCAlarmConfigcs.Instance);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            AddFormTopanel(PageOP10.Instance);
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
