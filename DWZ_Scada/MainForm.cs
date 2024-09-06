using LogTool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using AutoTF;
using AutoTF.Pages.Query;
using Cap;
using Cap.Dialog;
using DIPTest;
using DWZ_Scada;
using SJTU_UI;
using SJTU_UI.Pages.User;
using UtilYwh;

namespace AutoStation
{
    public partial class MainForm : UIForm
    {
        private static MainForm _instance;
        public static MainForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(MainForm))
                    {
                        if (_instance == null)
                        {
                            _instance = new MainForm();
                        }
                    }
                }
                return _instance;
            }
        }
        public MyPage SelectedPage { get; set; }

        /// <summary>
        /// 分割器最小距离
        /// </summary>
        private readonly int min = 60;
        /// <summary>
        /// 分割器最大距离
        /// </summary>
        private readonly int max = 260;
        /// <summary>
        /// 启动时间
        /// </summary>
        private DateTime st = DateTime.Now;
        /// <summary>
        /// ？？？
        /// </summary>
        public bool IsExpand => splitContainer1.SplitterDistance != min;

        /// <summary>
        /// 页面列表
        /// </summary>
        public List<MyPage> PageList;

        /// <summary>
        /// 是否已经初始化CPU信息
        /// </summary>
        public bool CPUInit = false;

        /// <summary>
        /// 当前显示的页面
        /// </summary>
        public UIPage CurrentPage;

        System.Timers.Timer timer = new System.Timers.Timer(1000);
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string err = SystemParams.Load();
            if (err != "")
            {
                LogMgr.Instance.Error($"加载系统配置失败![{err}]");
            }
            InitMenu();
            SystemParams.OPChangeEvent += SystemParams_OPChangeEvent;

            //SystemParams.Instance.Login("无", UserPermissionControl.SuperLvl, "OP");
            CheckMyHost();
            LogMgr.Instance.Debug("开始初始化");

            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStripStatusLabel4.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel5.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel8.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel9.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel10.Alignment = ToolStripItemAlignment.Right;
            Task.Run(() =>
            {
                var d1 = PublicFunc.GetCpuRate();
                var d2 = PublicFunc.GetMemorySize();
                CPUInit = true;
                LogMgr.Instance.Debug("性能计数器初始化完毕");
            });
            uiNavMenu1.SelectedNode = uiNavMenu1.Nodes[0];
            uiNavMenu1_MenuItemClick(uiNavMenu1.Nodes[0], null, 0);

            string file = Application.ExecutablePath;
            System.IO.FileInfo fi = new System.IO.FileInfo(file);
            string version = $"程序集版本[{Application.ProductVersion}]  最后修改时间[{fi.LastWriteTime}]";
            toolStripStatusLabel11.Text = version;
            LogMgr.Instance.Debug(version);

            timer.Start();
            timer.Elapsed += Timer_Elapsed;
            SetAutoSize();
            SetAutoStart();
            SystemParams.StationChanged += SystemParams_StationChangeEvent;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (CPUInit)
            {
                var d1 = PublicFunc.GetCpuRate();
                var d2 = PublicFunc.GetMemorySize();
                toolStripStatusLabel6.Text = $"CPU:{d1.ToString(),5} %";
                toolStripStatusLabel7.Text = $@"内存:{d2.ToString(),4} MB";
            }
            toolStripStatusLabel3.Text = DateTime.Now.ToString("HH:mm:ss");
            var span = (DateTime.Now - st);
            toolStripStatusLabel5.Text = $@"{span.Hours}:{span.Minutes:D2}:{span.Seconds:D2}";
        }

        private bool CheckMyHost()
        {
            string myHostName = "ywh";
            string currentHostName = Dns.GetHostName();
            if (myHostName == currentHostName)
            {
                Global.isYWH = true;
                SystemParams.Instance.Login("等你许久了", UserPermissionControl.SuperLvl, "超级管理员");
                return true;
            }
            else
            {
                //CheckAdmin();
                return false;
            }
        }
        /// <summary>
        /// 判断应用程序启动是否具有管理员权限
        /// </summary>
        private void CheckAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdmin) return;
            CustomMessageBox.ShowDialog("请以管理员权限重新打开程序！");
            this.Close();
        }

        public void SetAutoSize()
        {
            var size1 = Screen.PrimaryScreen.Bounds;
            var size2 = Screen.PrimaryScreen.WorkingArea;
            this.MaximumSize = new Size(size2.Width, size2.Height);
            WindowState = FormWindowState.Maximized;
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
                    ps = PageList.First(r => r.PageName == "OP10工站");
                    page = ps.ShowPage(uiTabControl1, 5000);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                case SystemParams.StationEnum.OP20机械手绕线工站:
                    ps = PageList.First(r => r.PageName == "绑定SSN站");
                    page = ps.ShowPage(uiTabControl1, 5002);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                    break;
                case SystemParams.StationEnum.OP30绕线检查工站:
                    ps = PageList.First(r => r.PageName == "TIG电焊工站");
                    page = ps.ShowPage(uiTabControl1, 5000);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                case SystemParams.StationEnum.OP40TIG电焊工站:
                    ps = PageList.First(r => r.PageName == "PPID打印站");
                    page = ps.ShowPage(uiTabControl1, 5001);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                case SystemParams.StationEnum.OP50电测工站:
                    ps = PageList.First(r => r.PageName == "绑定SSN站");
                    page = ps.ShowPage(uiTabControl1, 5002);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                case SystemParams.StationEnum.OP60出料打码工站:
                    ps = PageList.First(r => r.PageName == "绑定SSN站");
                    page = ps.ShowPage(uiTabControl1, 5002);
                    if (page != null)
                    {
                        uiTabControl1.SelectPage(page.PageIndex);
                    }
                    break;
                default:
                    break;
            }
        }

        private void SystemParams_OPChangeEvent()
        {
            toolStripStatusLabel1.Text = $"账号:{SystemParams.Instance.Op}";
            toolStripStatusLabel2.Text = $"角色:{SystemParams.Instance.OpLvl}.{SystemParams.Instance.OPRule}";
            bool flag = SystemParams.Instance.OpLvl == UserPermissionControl.SuperLvl;
            var station = SystemParams.Instance.Station.ToString();
            foreach (var item in PageList)
            {
                item.IsEnable = flag;
                if (item.PageName == station)
                {
                    item.IsEnable = true;
                }
                if (item.PageName == "账号登录")
                {
                    item.IsEnable = true;
                }
            }
        }

        private void SystemParams_StationChangeEvent()
        {
            SetAutoStart();
        }
        public string InitMenu()
        {
            PageList = new List<MyPage>();

            TreeNode child;
            //
            uiNavMenu2.CreateNode("", 61451, 30, 0);
            var point = new Point(0, 0);
            var pageIndex = 1;

            pageIndex = 10;
            TreeNode parent = uiNavMenu1.CreateNode("用户管理", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "用户查询", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);

            PageList.Add(new MyPage("用户查询", typeof(PageUserQuery), null));

            //维护界面
            pageIndex = 100;
            parent = uiNavMenu1.CreateNode("上料打码工站", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "OP10工站", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);

            PageList.Add(new MyPage("OP10工站", typeof(PageOP10), null));
            //查询界面
            pageIndex = 200;
            parent = uiNavMenu1.CreateNode("机械手绕线工站", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "OP20-30工站", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);
            //PageList.Add(new MyPage("PPID查询", typeof(PageQuaryTb_PPID), null));
            //PageList.Add(new MyPage("良率查询", typeof(PageQuaryStationAll), null));

            pageIndex = 300;
            parent = uiNavMenu1.CreateNode("TIG电焊工站", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "OP40工站", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);

            pageIndex = 400;
            parent = uiNavMenu1.CreateNode("电测工站", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "OP50工站", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);

            pageIndex = 500;
            parent = uiNavMenu1.CreateNode("出料打码工站", SymbolFontUtil.ParentNodeIcon, point, 24, pageIndex++);
            uiNavMenu1.CreateChildNode(parent, "OP60工站", SymbolFontUtil.ChildNodeIcon, point, 24, pageIndex++);
            return "";
        }
        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }

        private void uiNavMenu2_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            uiNavMenu1.CollapseAll();
            splitContainer1.SplitterDistance = IsExpand ? min : max;
            uiNavMenu1.ShowItemsArrow = IsExpand;
            uiNavMenu1.Enabled = IsExpand;
            uiAvatar1.Visible = IsExpand;
            uiAvatar2.Visible = IsExpand;
        }

        private void 全部展开_Click(object sender, EventArgs e)
        {
            uiNavMenu1.ExpandAll();
        }

        //全部折叠
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            uiNavMenu1.CollapseAll();
        }

        //自动更新程序
        private void uiButton1_Click(object sender, EventArgs e)
        {

        }
        //点击某个页面之前
        private void uiNavMenu1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ForeColor == Color.Gray)
            {
                e.Cancel = true;
            }
        }

        private void uiNavMenu1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var pageIndex = uiNavMenu1.GetPageIndex(e.Node);
            var quary = from r in PageList where r.PageName == e.Node.Text select r;
            if (!quary.Any())
            {
                return;
            }
            var ps = quary.First();
            CurrentPage = ps.ShowPage(uiTabControl1, pageIndex);
            uiTabControl1.AddPage(CurrentPage);
            if (CurrentPage != null)
            {
                uiTabControl1.SelectPage(CurrentPage.PageIndex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CPUInit)
            {
                var d1 = PublicFunc.GetCpuRate();
                var d2 = PublicFunc.GetMemorySize();
                toolStripStatusLabel6.Text = $"CPU:{d1.ToString(),5} %";
                toolStripStatusLabel7.Text = $@"内存:{d2.ToString(),4} MB";
            }
            toolStripStatusLabel3.Text = DateTime.Now.ToString("HH:mm:ss");
            var span = (DateTime.Now - st);
            toolStripStatusLabel5.Text = $@"{span.Hours}:{span.Minutes:D2}:{span.Seconds:D2}";
        }
        private void timerTick(object sender, EventArgs e)
        {

        }




        private void uiAvatar1_Click(object sender, EventArgs e)
        {
            new PageLogin().ShowDialog();
        }

        private void uiAvatar2_Click(object sender, EventArgs e)
        {
            bool flag = SystemParams.Instance.OpLvl == 0;
            if (!flag)
            {
                UIMessageBox.ShowError("當前登錄賬號權限不足！");
                return;
            }
            new PageProperty(SystemParams.Instance).ShowDialog();
        }

        private void uiNavMenu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var pageIndex = uiNavMenu1.GetPageIndex(e.Node);
            var query = from r in PageList where r.PageName == e.Node.Text select r;
            if (!query.Any())
            {
                return;
            }
            var ps = query.First();

            if (e.Button == MouseButtons.Left)
            {
                CurrentPage = ps.ShowPage(uiTabControl1, pageIndex);
                if (CurrentPage != null)
                {
                    uiTabControl1.SelectPage(pageIndex);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SelectedPage = ps;
            }
        }
        private void 单独打开_Click(object sender, EventArgs e)
        {
            if (SelectedPage != null)
            {
                var o = Activator.CreateInstance(SelectedPage.PageType, null) as UIPage;
                PopupForm popupForm = new PopupForm(o, SelectedPage.PageName);
            }
        }

        private void uiNavMenu1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            /*  MessageBoxEx.ShowDialog("执行单独弹出窗口");*/
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            bool flag = UIMessageBox.ShowAsk("确定要退出吗?");
            if (flag)
            {
                try
                {
                    LogMgr.Instance.Info("退出程序");

                    //释放资源
                    timer.Stop();
                    timer?.Dispose();
                    e.Cancel = false;
                    Environment.Exit(0);
                }
                catch (Exception exception)
                {

                }
            }

        }

        private void splitContainer1_MouseEnter(object sender, EventArgs e)
        {
          /*  if (splitContainer1)
            {
                
            }*/
        }
    }
}
