using System.Diagnostics;
using System.IO.Compression;

namespace AutoUpdater
{
    public partial class Form1 : Form
    {
        public Form1(string updateFilePath, string targetDir, string mainExe, string newVersion)
        {
            InitializeComponent();
            UpdateFilePath = updateFilePath;
            TargetDir = targetDir;
            MainExe = mainExe;
            NewVersion = newVersion;
        }

        public string UpdateFilePath;

        public string TargetDir;

        public string MainExe;

        public string NewVersion;

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdate();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            AutoUpdate();
        }

        private void AppendMsg(string msg)
        {
            uiListBox1.Items.Add($"{DateTime.Now:HH:mm:ss fff}:{msg}");
        }

        private void AutoUpdate()
        {
            uiListBox1.Items.Clear();
            AppendMsg($"更新文件路径: {UpdateFilePath}");
            AppendMsg($"目标目录: {TargetDir}");
            try
            {
                // Step 1: 解压更新文件到目标目录
                AppendMsg("开始解压更新文件...");
                if (Directory.Exists(TargetDir))
                {
                    ZipFile.ExtractToDirectory(UpdateFilePath, TargetDir, overwriteFiles: true);
                }
                else
                {
                    AppendMsg("目标目录不存在!!!");
                    MessageBox.Show("目标目录不存在！");
                    return;
                }
                // Step 2: 删除临时更新文件
                if (File.Exists(UpdateFilePath))
                {
                    AppendMsg("删除临时文件");
                    File.Delete(UpdateFilePath);
                }
           
              
                //记录当前版本信息
                //写入最新版本号
                string filePath = @"Params\version.txt"; // 文件路径

                //写入版本号
                File.WriteAllText(filePath, NewVersion);
                AppendMsg($"写入版本号:{NewVersion}");
                string file2Path = @"Params\UpdateInfo.txt"; // 

                //写入版本号
                File.WriteAllText(file2Path, $"UpdateTime:{DateTime.Now:yyyy-MM-dd HH:mm:ss fff}");

                // Step 3: 启动主程序
                //string mainExePath = Path.Combine(TargetDir, MainExe); // 主程序的可执行文件名
                AppendMsg("更新完成");
                MessageBox.Show("更新完成");
                if (File.Exists(MainExe))
                {
                    AppendMsg($"启动主程序:{MainExe}");
                    Process.Start(MainExe);
                }
                else
                {
                    MessageBox.Show("主程序未找到！");
                    return;
                }
                AppendMsg($"关闭更新程序");
                Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失败: {ex.Message} \n{ex.StackTrace}");
            }
        }
    }
}
