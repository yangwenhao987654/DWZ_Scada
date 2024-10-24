﻿using AutoTF;
using DWZ_Scada.MyHttpPlug;
using DWZ_Scada.Pages.PLCAlarm;
using DWZ_Scada.Pages.StationPages.OP10;
using DWZ_Scada.Pages.StationPages.OP40;
using LogTool;
using Sunny.UI;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;
using Timer = System.Threading.Timer;

namespace DWZ_Scada.Pages
{
    public partial class ZCForm : UIForm
    {
        private Form mainForm;
        private static ZCForm _instance;

        public HttpService MyHttpService;

        private ListViewEx_Log listViewExLog;
        private Timer timer;

        private ZCForm()
        {
            InitializeComponent();
        }

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

        private void ZCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bool flag = UIMessageBox.ShowAsk("确定要退出吗?");
            if (flag)
            {
                try
                {
                    LogMgr.Instance.Info("退出程序");
                    MyHttpService?.Stop();
                    MyHttpService?.Dispose();
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
            timer = new Timer(TimerElapsed, null, 0, 1000);
            // 设置KeyPreview为true以捕获键盘事件
            KeyPreview = true;
            // 添加事件处理程序
            KeyDown += Form_KeyDown;

            SetAutoStart();
            StartServer();
            listViewExLog = new ListViewEx_Log();

            //设置关闭弹窗后返回的位置
            listViewExLog.BindingControl = uiPanel1;

            LogMgr.Instance.SetCtrl(listViewExLog);

            lblLoginUserName.Text = Global.LoginUser;
            lblLoginTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        public void StartServer()
        {
            MyHttpService = new HttpService();
            MyHttpService.Setup(new TouchSocketConfig()
                .SetListenIPHosts(8090)
                /*   .ConfigureContainer(a =>
                   {
                       a.AddConsoleLogger();
                   })*/
                .ConfigurePlugins(a =>
                {
                    a.Add<SelectionHttpPlug>();
                    a.Add<ConsumablePartsHttpPlug>();
                    a.UseDefaultHttpServicePlugin();
                })
            );
            MyHttpService.Start();
            LogMgr.Instance.Info("启动HttpServer");
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    SetAutoStart();
                    break;
                case Keys.F2:
                    AddFormTopanel(PageAlarmTabMenu.Instance);
                    break;
                case Keys.F3:
                    AddFormTopanel(Page_Formula_Set.Instance);
                    break;
                case Keys.F4:
                    AddFormTopanel(DeviceControlPage.Instance);
                    break;
                case Keys.F5:
                    AddFormTopanel(Page_PLCAddress.Instance);
                    break;
                case Keys.F10:
                    AddFormTopanel(listViewExLog);
                    break;
                case Keys.F11:
                    OpenPageProperty();
                    break;
                case Keys.F12:
                    break;
            }
        }

        private void ZCForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                uiButton6_Click(sender, e);
            }

            if (e.KeyCode == Keys.F5)
            {
            }
        }

        public void SetAutoSize()
        {
            Rectangle size1 = Screen.PrimaryScreen.Bounds;
            Rectangle size2 = Screen.PrimaryScreen.WorkingArea;
            MaximumSize = new Size(size2.Width, size2.Height);
            WindowState = FormWindowState.Maximized;
        }

        private void SetMainPage(Form form)
        {
            if (mainForm!=form)
            {
                mainForm?.Close();
            }
            uiPanel1.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.Show();
            uiPanel1.Controls.Add(form);
            mainForm = form;
        }

        public void SetAutoStart()
        {
            MyPage ps = null;
            UIPage page = null;
            switch (SystemParams.Instance.Station)
            {
                case SystemParams.StationEnum.无:
                    SetMainPage(PageOPTest.Instance);
                    break;
                case SystemParams.StationEnum.所有:
                    break;
                case SystemParams.StationEnum.OP10上料打码工站:
                    SetMainPage(PageOP10.Instance);
                    break;
                case SystemParams.StationEnum.OP20机械手绕线工站:
                    SetMainPage(PageOP20.Instance);
                    break;
                case SystemParams.StationEnum.OP30绕线检查工站:
                    SetMainPage(PageOP20.Instance);
                    break;
                case SystemParams.StationEnum.OP40TIG电焊工站:
                    SetMainPage(PageOP40.Instance);
                    break;
                case SystemParams.StationEnum.OP60电测工站:
                    SetMainPage(PageOP60.Instance);
                    break;
                case SystemParams.StationEnum.OP70出料打码工站:
                    SetMainPage(PageOP70.Instance);
                    break;
            }
        }

        private void TimerElapsed(object state)
        {
            if (lblTime.InvokeRequired)
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                lblTime.Invoke(() =>
                {
                    TimerElapsed(id);
                });
                return;
            }

            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
        }

        public void AddFormTopanel(Control ctrl)
        {
            //LogMgr.Instance.Debug($"当前线程ID:{Thread.CurrentThread.ManagedThreadId.ToString()}");
            uiPanel1.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            uiPanel1.Controls.Add(ctrl);
            ctrl.Show();
        }

        private void OpenPageProperty()
        {
            bool flag = SystemParams.Instance.OpLvl == 0;
            if (!flag)
            {
                UIMessageBox.ShowError("当前登录账号权限不足！");
                return;
            }

            PageProperty form = new(SystemParams.Instance);
            form.ShowDialog();
            /*FormCustom form = new(pageProperty, "系统配置参数");
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();*/
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            OpenPageProperty();
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Page_PLCAddress.Instance);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            AddFormTopanel(listViewExLog);
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            AddFormTopanel(Page_Formula_Set.Instance);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            AddFormTopanel(DeviceControlPage.Instance);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            AddFormTopanel(PageAlarmTabMenu.Instance);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            SetAutoStart();
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            this.OnFormClosing(new FormClosingEventArgs(CloseReason.UserClosing, true));
        }

        public void UpdatePlcState(PlcState state)
        {
            if (state.ToString()==uiLight1.Tag.ToString())
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new Action<PlcState>(UpdatePlcState), state);
                return;
            }
            lbl_PLCConn.Text = "已连接";
            switch (state)
            {
                case PlcState.OffLine:
                    lbl_PLCState.Text = "离线";
                    lbl_PLCConn.Text = "未连接";
                    uiLight1.OnColor = Color.LightGray;
                    break;

                case PlcState.Online:
                    lbl_PLCState.Text = "在线";
                    uiLight1.OnColor = Color.Green;
                    break;
                case PlcState.Alarm:
                    lbl_PLCState.Text = "报警";
                    uiLight1.OnColor = Color.Red;
                    break;
                case PlcState.Stop:
                    lbl_PLCState.Text = "停止";
                    uiLight1.OnColor = Color.DimGray;
                    break;
                case PlcState.Running:
                    lbl_PLCState.Text = "运行中";
                    uiLight1.OnColor = Color.GreenYellow;
                    break;
            }
        }

        private void uiLight1_Click(object sender, EventArgs e)
        {
        }
    }
}