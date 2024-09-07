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

        private static ZCForm _instance;
        public static ZCForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(ZCForm))
                    {
                        if (_instance == null)
                        {
                            _instance = new ZCForm();
                        }
                    }
                }
                return _instance;
            }
        }

        private ListViewEx_Log listViewExLog;
        public ZCForm()
        {
            InitializeComponent();
        }
        private void ZCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bool flag = UIMessageBox.ShowAsk("确定要退出吗?");
            if (flag)
            {
                try
                {
                    LogMgr.Instance.Info("退出程序");

                    //释放资源
                    timer?.Dispose();
                    e.Cancel = false;
                    Environment.Exit(0);
                }
                catch (Exception exception)
                {

                }
            }
        }
        private void ZCForm_Load(object sender, EventArgs e)
        {
            timer = new Timer(TimerElapsed, null, 0, 100);
            // 设置KeyPreview为true以捕获键盘事件
            this.KeyPreview = true;
            // 添加事件处理程序
            this.KeyDown += ZCForm_KeyDown;
            SetAutoStart();
        }

        private void ZCForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                uiButton6_Click(sender, e);
            }

            if (e.KeyCode==Keys.F5)
            {
                
            }
        }
        public void SetAutoSize()
        {
            var size1 = Screen.PrimaryScreen.Bounds;
            var size2 = Screen.PrimaryScreen.WorkingArea;
            this.MaximumSize = new Size(size2.Width, size2.Height);
            WindowState = FormWindowState.Maximized;
        }

        private void SetMainPage(Control c)
        {
            uiPanel1.Controls.Clear();
            c.Dock = DockStyle.Fill;
            c.Show();
            uiPanel1.Controls.Add(c);
        }
        public void SetAutoStart()
        {
            MyPage ps = null;
            UIPage page = null;
            switch (SystemParams.Instance.Station)
            {
                case SystemParams.StationEnum.无:
                    break;
                case SystemParams.StationEnum.所有:
                    break;
                case SystemParams.StationEnum.OP10上料打码工站:
                    SetMainPage(PageOP10.Instance);
                    break;
                case SystemParams.StationEnum.OP20机械手绕线工站:
                    break;
                case SystemParams.StationEnum.OP30绕线检查工站:
            
                    break;
                case SystemParams.StationEnum.OP40TIG电焊工站:
            
                    break;
                case SystemParams.StationEnum.OP50电测工站:
              
                    break;
                case SystemParams.StationEnum.OP60出料打码工站:
                   
                    break;
                default:
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
        private void SystemParams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                uiButton6_Click(sender, e);
            }
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {

            Form_set_PLC form_set_plc = new Form_set_PLC();
            AddFormTopanel(form_set_plc);
        }
        private void Form_set_PLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                uiButton7_Click(sender, e);
            }
        }
        private void uiButton5_Click(object sender, EventArgs e)
        {

            listViewLog = new ListViewEx_Log();
            LogMgr.Instance.SetCtrl(listViewLog);
            FormCustom formCustom = new FormCustom(listViewLog, "日志报警");
            AddFormTopanel(formCustom);

             

        }
        private void FormCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                uiButton5_Click(sender, e);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            Formula_set formula_set = new Formula_set();
            AddFormTopanel(formula_set);
        }
        private void Formula_set_KeyDown(object sender, KeyEventArgs e)
        {
            // 检查按下的是否是F3键
            if (e.KeyCode == Keys.F3)
            {
                // 打开特定窗口
                uiButton3_Click(sender, e);
            }
        }
        private void uiButton4_Click(object sender, EventArgs e)
        {
            Manual_Debug manual_Debug = new Manual_Debug();
            AddFormTopanel(manual_Debug);
        }
        private void Manual_Debug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                uiButton4_Click(sender, e);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            PageOP10 pageOp10 = new PageOP10();
            AddFormTopanel(pageOp10);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Page_PLCAlarmConfigcs page_PLCAlarmConfigcs = new Page_PLCAlarmConfigcs();
            AddFormTopanel(page_PLCAlarmConfigcs);
        }
    }
}
