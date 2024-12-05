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
            string argsString = string.Join(", ", args); // 使用逗号和空格作为分隔符
            if (args.Length < 4)
            {
                MessageBox.Show($"参数错误 数量:[{args.Length}]! \n获取到参数信息:\n{argsString}");
                return;
            }
            ApplicationConfiguration.Initialize();
            Thread.Sleep(2000);
            Application.Run(new Form1(args[0], args[1], args[2], args[3]));
        }
    }
}