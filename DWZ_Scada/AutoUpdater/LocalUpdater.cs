using DWZ_Scada.Pages;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.AutoUpdater
{
    public class LocalUpdater
    {
        public static string UpdateInfoPath
        {
            get
            {
                return SystemParams.Instance.UpdateInfoPath;
            }
        }

        public static string CurVision { get; set; }

        public static string LatestFilePath;

        public static UpdateInfo CheckForUpdates()
        {
            if (!File.Exists(UpdateInfoPath))
            {
                UIMessageBox.ShowError("更新信息文件不存在！");
                return null;
            }
            //读取当前版本
            
            string jsonContent = File.ReadAllText(UpdateInfoPath);
            var updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(jsonContent);

            if (updateInfo != null )
            {
                LatestFilePath = updateInfo.FilePath;
                string msg = $"发现新版本: {updateInfo.Version}";
                msg += $"\n更新内容: {updateInfo.ReleaseNotes}";
                msg += $"\n确认要更新吗?";
                bool b = UIMessageBox.ShowAsk(msg);
                if (!b)
                {
                    return null;
                }
                return updateInfo;
            }
            UIMessageBox.Show("当前已是最新版本！");
            return null;
        }

        public static void DownloadUpdate(string sourcePath, string destinationPath)
        {
            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, destinationPath, overwrite: true);
                //UIMessageBox.Show("更新文件下载完成！");
            }
            else
            {
                UIMessageBox.ShowError("更新文件不存在！");
            }
        }

        public static void StartUpdater(string updaterPath, string updateFilePath ,string vision)
        {
            string exeFileName = Process.GetCurrentProcess().MainModule.FileName;
            string args = $"\"{updateFilePath}\" \"{AppContext.BaseDirectory.TrimEnd('\\')}\" \"{exeFileName}\" \"{vision}\"";
            Process.Start(new ProcessStartInfo
            {
                FileName = updaterPath,
                Arguments =args,
                UseShellExecute = true
            });

            ZCForm.Instance.AutoClose();
            //Environment.Exit(0); // 关闭当前程序
        }

        public static void AutoUpdate()
        {
            // 检查更新
            var updateInfo = LocalUpdater.CheckForUpdates();
            if (updateInfo == null) return;

            // 下载更新文件
            Assembly assembly = Assembly.GetExecutingAssembly();
            string appName = assembly.GetName().Name;

            string zipFileName = $"{appName}_{updateInfo.Version}.zip";
            string tempDir = "C:\\TempExe\\";
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string localUpdateFilePath = Path.Combine(tempDir, zipFileName);
            LocalUpdater.DownloadUpdate(updateInfo.FilePath, localUpdateFilePath);

            // 启动更新工具
            string updaterPath = Path.Combine(AppContext.BaseDirectory, "AutoUpdater.exe");
            LocalUpdater.StartUpdater(updaterPath, localUpdateFilePath,updateInfo.Version);
        }
    }
}
