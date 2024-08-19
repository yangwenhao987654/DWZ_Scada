using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cap.Util
{
    
    public class Win10key
    {
        Process Winvirkey;
        // Start is called before the first frame update
       public void Start()
        {
            Winvirkey = Process.Start("osk.exe");
            Winvirkey.Kill();
        }

        //打开虚拟键盘
       public void ShowKey()
        {
            //此处需检测Winvirkey进程是否已关闭，否则打开状态再执行会报错
            if (Winvirkey.HasExited)
            {
                Winvirkey = Process.Start("osk.exe");
            }
        }

        //关闭虚拟键盘
       public void HideKey()
        {
            //此处需检测Winvirkey进程是否已打开，否则关闭状态再执行会报错
            if (!Winvirkey.HasExited)
            {
                Winvirkey.Kill();
            }
        }

        public class KeyboardHelper
        {
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr GetForegroundWindow();

            public static void ShowKeyboard()
            {
                IntPtr hwnd = GetForegroundWindow();
                if (hwnd != IntPtr.Zero)
                {
                    ShowWindowAsync(hwnd, 1); // SW_RESTORE = 1
                }
            }
        }



        public static bool isShowNumBoard = false;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

        public static void StartKeyBoardFun()
        {
            //判断软键盘是否进程是否已经存在，如果不存在进行调用
            Process[] pro = Process.GetProcessesByName("osk");
            //说明已经存在，不再进行调用
            if (pro != null && pro.Length > 0)
                return;
            IntPtr ptr = new IntPtr();
            bool isWow64FsRedirectionDisabled = Wow64DisableWow64FsRedirection(ref ptr);
            if (isWow64FsRedirectionDisabled)
            {
                Process.Start(@"C:\WINDOWS\system32\osk.exe");
                bool isWow64FsRedirectionReverted = Wow64RevertWow64FsRedirection(ptr);

            }
        }
    }
}
