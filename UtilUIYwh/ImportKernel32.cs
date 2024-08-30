using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilYwh
{
    public class ImportKernel32
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        #region INI文件读写操作
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        public static string[] GetAllSectionNames(string iniFile)
        {
            uint num = 32767u;
            string[] result = new string[0];
            IntPtr intPtr = Marshal.AllocCoTaskMem((int)(num * 2));
            uint privateProfileSectionNames = GetPrivateProfileSectionNames(intPtr, num, iniFile);
            if (privateProfileSectionNames != 0)
            {
                string text = Marshal.PtrToStringAuto(intPtr, (int)privateProfileSectionNames).ToString();
                result = text.Split(new char[1], StringSplitOptions.RemoveEmptyEntries);
            }
            Marshal.FreeCoTaskMem(intPtr);
            return result;
        }
        public static string GetValue(string iniFile, string section, string key, string defaultValue)
        {
            string result = defaultValue;
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称(key)", "key");
            }
            StringBuilder stringBuilder = new StringBuilder(10240);
            uint privateProfileString = GetPrivateProfileString(section, key, defaultValue, stringBuilder, 10240u, iniFile);
            if (privateProfileString > 0)
            {
                result = stringBuilder.ToString();
            }
            return result;
        }
        public static bool WriteValue(string iniFile, string section, string key, string value)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称", "key");
            }
            if (value == null)
            {
                throw new ArgumentException("值不能为null", "value");
            }
            return WritePrivateProfileString(section, key, value, iniFile);
        }
        public static bool DeleteKey(string iniFile, string section, string key)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称", "key");
            }
            return WritePrivateProfileString(section, key, null, iniFile);
        }
        public static bool DeleteSection(string iniFile, string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            return WritePrivateProfileString(section, null, null, iniFile);
        }
        #endregion


        #region 非本程序的窗体操作

        #region 界面最大化/激活窗体
        public const int SC_MAXIMIZE = 0xF030;
        public const int WM_SYSCOMMAND2 = 0x0112;
        public const int SC_MAXIMIZE2 = 0xF030;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        //[DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);



        public static int OF_READWRITE = 2;
        public static int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        // 判断文件是否打开
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        // 关闭文件句柄
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        #endregion
        #endregion


        #region 获得C盘所在的硬盘ID
        [DllImport("kernel32.dll")]
        private static extern int GetVolumeInformation(string lpRootPathName,string lpVolumeNameBuffer,int nVolumeNameSize,ref int lpVolumeSerialNumber,int lpMaximumComponentLength,int lpFileSystemFlags,string lpFileSystemNameBuffer,int nFileSystemNameSize);
        public static string HDVal()
        {
            const int MAX_FILENAME_LEN = 256;
            int retVal = 0;
            int a = 0;
            int b = 0;
            string str1 = null;
            string str2 = null;
            int i = GetVolumeInformation(
            "c:\\",
            str1,
            MAX_FILENAME_LEN,
            ref retVal,
            a,
            b,
            str2,
            MAX_FILENAME_LEN
            );
            return retVal.ToString();
        }
        #endregion

        #region 获得系统距离上一次操作的时间
        [StructLayout(LayoutKind.Sequential)]
        struct LastInfo
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LastInfo info);
        public static long GetLastInputTime()
        {
            LastInfo info = new LastInfo();
            info.cbSize = Marshal.SizeOf(info);
            if (!GetLastInputInfo(ref info))
            {
                return 0;
            }
            else
            {
                var count = Environment.TickCount - (long)info.dwTime;
                return count / 1000;//单位为s
            }

        }
        #endregion


        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体

        #region 将按钮disable,但是同时还可以修改字体颜色
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public const int GWL_STYLE = -16;
        public const int WS_DISABLED = 0x8000000;


        public static void DisableCtrl(Control c)
        {
            //将控件禁用,同时依然可以修改控件字体颜色
            SetWindowLong(c.Handle, GWL_STYLE, WS_DISABLED + GetWindowLong(c.Handle, GWL_STYLE));
        }


        #endregion


        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_LAYERED = 0x00080000;

        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 x, Int32 y)
            {
                cx = x;
                cy = y;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PointInt
        {
            public Int32 x;
            public Int32 y;

            public PointInt(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public const byte AC_SRC_OVER = 0;
        public const Int32 ULW_ALPHA = 2;
        public const byte AC_SRC_ALPHA = 1;

        /// <summary>
        /// 从左到右显示
        /// </summary>
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        /// <summary>
        /// 从右到左显示
        /// </summary>
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        /// <summary>
        /// 从上到下显示
        /// </summary>
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        /// <summary>
        /// 从下到上显示
        /// </summary>
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        /// <summary>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        /// </summary>
        public const Int32 AW_CENTER = 0x00000010;
        /// <summary>
        /// 隐藏窗口，缺省则显示窗口
        /// </summary>
        public const Int32 AW_HIDE = 0x00010000;
        /// <summary>
        /// 激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        /// </summary>
        public const Int32 AW_ACTIVATE = 0x00020000;
        /// <summary>
        /// 使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        /// </summary>
        public const Int32 AW_SLIDE = 0x00040000;
        /// <summary>
        /// 透明度从高到低
        /// </summary>
        public const Int32 AW_BLEND = 0x00080000;

        /// <summary>
        /// 执行动画
        /// </summary>
        /// <param name="whnd">控件句柄</param>
        /// <param name="dwtime">动画时间</param>
        /// <param name="dwflag">动画组合名称</param>
        /// <returns>bool值，动画是否成功</returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);




        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        public delegate bool EnumWindowsCallback(IntPtr hwnd, IntPtr  intlParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //BOOL WINAPI EnumChildWindows( _In_opt_ HWND        hWndParent,  _In_     WNDENUMPROC lpEnumFunc,  _In_     LPARAM      lParam);
        public static extern int EnumChildWindows(IntPtr hWndParent, EnumWindowsCallback lpfn, int lParam);
        [DllImport("User32.dll")]

        public static extern bool ClientToScreen(IntPtr hwnd, ref System.Drawing.Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteObject(IntPtr hObj);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref PointInt pptDst, ref Size psize, IntPtr hdcSrc, ref PointInt pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);

    }
}
