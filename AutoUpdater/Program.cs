namespace AutoUpdater
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string argsString = string.Join(", ", args); // ʹ�ö��źͿո���Ϊ�ָ���
            if (args.Length < 4)
            {
                MessageBox.Show($"�������� ����:[{args.Length}]! \n��ȡ��������Ϣ:\n{argsString}");
                return;
            }
            ApplicationConfiguration.Initialize();
            Thread.Sleep(2000);
            Application.Run(new Form1(args[0], args[1], args[2], args[3]));
        }
    }
}