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
            AppendMsg($"�����ļ�·��: {UpdateFilePath}");
            AppendMsg($"Ŀ��Ŀ¼: {TargetDir}");
            try
            {
                // Step 1: ��ѹ�����ļ���Ŀ��Ŀ¼
                AppendMsg("��ʼ��ѹ�����ļ�...");
                if (Directory.Exists(TargetDir))
                {
                    ZipFile.ExtractToDirectory(UpdateFilePath, TargetDir, overwriteFiles: true);
                }
                else
                {
                    AppendMsg("Ŀ��Ŀ¼������!!!");
                    MessageBox.Show("Ŀ��Ŀ¼�����ڣ�");
                    return;
                }
                // Step 2: ɾ����ʱ�����ļ�
                if (File.Exists(UpdateFilePath))
                {
                    AppendMsg("ɾ����ʱ�ļ�");
                    File.Delete(UpdateFilePath);
                }
           
              
                //��¼��ǰ�汾��Ϣ
                //д�����°汾��
                string filePath = @"Params\version.txt"; // �ļ�·��

                //д��汾��
                File.WriteAllText(filePath, NewVersion);
                AppendMsg($"д��汾��:{NewVersion}");
                string file2Path = @"Params\UpdateInfo.txt"; // 

                //д��汾��
                File.WriteAllText(file2Path, $"UpdateTime:{DateTime.Now:yyyy-MM-dd HH:mm:ss fff}");

                // Step 3: ����������
                //string mainExePath = Path.Combine(TargetDir, MainExe); // ������Ŀ�ִ���ļ���
                AppendMsg("�������");
                MessageBox.Show("�������");
                if (File.Exists(MainExe))
                {
                    AppendMsg($"����������:{MainExe}");
                    Process.Start(MainExe);
                }
                else
                {
                    MessageBox.Show("������δ�ҵ���");
                    return;
                }
                AppendMsg($"�رո��³���");
                Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"����ʧ��: {ex.Message} \n{ex.StackTrace}");
            }
        }
    }
}
