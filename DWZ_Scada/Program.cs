using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoStation;
using DWZ_Scada.DAL.DBContext;
using LogTool;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DWZ_Scada
{
    internal static class Program
    {
        public const int SC_MAXIMIZE = 0xF030;
        public const int WM_SYSCOMMAND2 = 0x0112;
        public const int SC_MAXIMIZE2 = 0xF030;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        // 导入Windows API函数
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool RegisterWaitForSingleObject(IntPtr hEvent, IntPtr hObject, WaitOrTimerCallback callback, IntPtr context, uint milliseconds, bool executeImmediately);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 只允许打开一个程序
            bool isAppRunning = false;
            //设置一个互斥体
            Mutex mutex = new Mutex(true, "YANZHAOKUN", out isAppRunning);
            if (!isAppRunning)
            {
                IntPtr handle = IntPtr.Zero;
                var processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                foreach (var item in processes)
                {
                    if (item.MainWindowTitle != "")
                    {
                        handle = item.MainWindowHandle;
                    }
                }
                SendMessage(handle, WM_SYSCOMMAND2, SC_MAXIMIZE2, 0);   // 最大化
                SwitchToThisWindow(handle, true);//显示
                Process.GetCurrentProcess().Kill();//关闭当前线程
            }
            #endregion
            try
            {
                bool canCreateNew;
                string mutexName = System.Reflection.Assembly.GetEntryAssembly().FullName;
                using (Mutex m = new Mutex(false, mutexName, out canCreateNew))
                {
                    if (!canCreateNew)
                    {
                        MessageBox.Show(null, "有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(1);
                    }
                    else
                    {
                        //GC.RegisterForFullGCNotification(GarbageCollectionNotificationCallback,null));

                        #region 处理全局异常,Task类中出现的异常无法在此捕获.
                        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                        //处理UI异常
                        Application.ThreadException += Application_ThreadException;
                        //处理非UI异常
                        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        #endregion
                        Application.EnableVisualStyles();

                        //获取配置
                        //注册服务
                    /*    var config = new ConfigurationBuilder()
                            .AddJsonFile("appSettings.json")
                            .Build();*/

                        var serviceCollection = new ServiceCollection();
                        //serviceCollection
                            //作用域
                      /*      .AddDbContext<MyDbContext>(
                            (builder )=>
                            {
                                builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                            })

                            //上下文实例池==很多上下文实例
                            //状态重置，放回池中，少了初始化阶段，提高一丢丢性能
                            .AddDbContextPool<MyDbContext>(
                                builder =>
                                {
                                    builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                                },1024)
                            ;*/
                        ConfigureServices(serviceCollection);
                        var serviceProvider = serviceCollection.BuildServiceProvider();
                        LogMgr.Instance.Init();
                        SystemParams.Load();
                        MainForm mainForm = MainForm.Instance;
                        mainForm.WindowState = FormWindowState.Maximized;
                        Application.Run(mainForm);
                    }
                }
            }
            catch (Exception ex)
            {
                Application_ThreadException(null, new ThreadExceptionEventArgs(ex));
            }
            finally
            {
                LogMgr.Instance.Info("关闭应用程序！");
            }
        }


        private static void ConfigureServices(ServiceCollection services)
        {
            //1.注册数据访问层
           /* services.AddScoped<IMatlabPaarmsDAL, MatlabParams_DAL>();
            services.AddScoped<IFormulaParamsDAL, FormulaParamsDAL>();*/

            //2.注册业务逻辑层
      /*      services.AddScoped<IMatlabParamsBLL, MatlabParamsBLL>();
            services.AddScoped<IFormulaParamsBLL, FormulaParamsBLL>();*/

            //注册主窗体
            //services.AddScoped<MainForm>();

        }


        #region 具体的异常处理函数
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            WriteError(e.Exception, true);
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteError(e.ExceptionObject as Exception, false);
        }
        private static void WriteError(Exception ex, bool isUIError)
        {
            StringBuilder sb = new StringBuilder();
            string head = string.Empty;
            sb.AppendLine("**************************************************************************异常文本**************************************************************************");
            sb.AppendLine($"[出现时间]:{DateTime.Now.ToString()}");
            if (ex != null)
            {
                sb.AppendLine($"[异常类型]:{ex.GetType()}");
                head = isUIError ? "UI线程" : "非UI线程";
                sb.AppendLine($"[异常线程]:{head}");
                sb.AppendLine($"[异常信息]:{ex.Message}");
                sb.AppendLine($"[调用堆栈]:{ex.StackTrace}");
            }
            else
            {
                sb.AppendLine($"[空异常]");
            }
            sb.AppendLine("**************************************************************************文本结束**************************************************************************");
            sb.AppendLine();
            sb.AppendLine();
            var filePath = $@"{Application.StartupPath}\Error\{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            try
            {
                new FileInfo(filePath).Directory.Create();
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex2)
            {

            }
            head += "异常终止!";
            MessageBox.Show(sb.ToString(), head, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Process.GetCurrentProcess().Kill();
        }
        #endregion
    }
}
