using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap.WinUtil
{
    public class WinHelper
    {

        public static void ShutdownPC(bool isCancel, uint interval)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe"; // 启动命令行程序
            proc.StartInfo.UseShellExecute = false; // 不使用Shell来执行,用程序来执行
            proc.StartInfo.RedirectStandardError = true; // 重定向标准输入输出
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true; // 执行时不创建新窗口
            proc.Start();
            string commandLine;
            if (isCancel)
                commandLine = @"shutdown /a"; //取消自动关机命令
            else
                commandLine = @"shutdown /s /t " + interval.ToString();
            proc.StandardInput.WriteLine(commandLine);
        }
    }
}
