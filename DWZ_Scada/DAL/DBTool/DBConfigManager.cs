
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWZ_Scada;
using LogTool;
using Microsoft.Data.SqlClient;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace AutoTF
{
    public  static class DbConfigManager
    {
        private static string _connectionStr = "";

        public static string ServerIp = "";

        private static readonly object _lockObject = new object();
        public static string ConnectionStr
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStr))
                {
                    lock (_lockObject)
                    {
                        if (string.IsNullOrEmpty(_connectionStr))
                        {
                            _connectionStr = GetConnectionStr();
                        }
                    }
                }
                return _connectionStr;
            }
            private set
            {
                lock (_lockObject)
                {
                    if (string.IsNullOrEmpty(_connectionStr))
                    {
                        _connectionStr = value;
                    }
                }
            }
        }
        public static bool IsConnect
        {
            get => _isConnect;
            set => _isConnect = value;
        }

        private static bool _isConnect;
        private static string ReadConnectionStr()
        {
            try
            {
                string exePath = AppDomain.CurrentDomain.BaseDirectory;
                // 读取 JSON 文件中的连接信息
                string filePath = Path.Combine(exePath, "Config/"); // 替换为实际文件路径
                string fileName = "dbConfig.json";
                string fullPath = Path.Combine(filePath, fileName);
                string jsonContent = File.ReadAllText(fullPath);
                DatabaseConfig config = JsonConvert.DeserializeObject<DatabaseConfig>(jsonContent);
                // 构建连接字符串
               // string connectionString = $"Data Source={config.ServerIp};Initial Catalog={config.DatabaseName};User ID={config.Username};Password={config.Password};Connect Timeout={config.ConnectTimeout}";
                string connectionString = $"Data Source={config.ServerIp};Initial Catalog={config.DatabaseName};User ID={config.Username};Password={config.Password};Trusted_Connection=True;Encrypt=false;";
                ServerIp = config.ServerIp;
                return connectionString;
            }
            catch(Exception e)
            {
                _isConnect =false;
                return "";
            }
        }

        public static void ReflashDBConfig()
        {
             _connectionStr =  ReadConnectionStr();
        }

        public static bool CheckConnectOK()
        {
            if (ConnectionStr=="")
            {
                GetConnectionStr();
                return _isConnect;
            }
            bool result = TestConnect();
            return  result; ;
        }

        public static string GetConnectionStr() 
        {
            if (_connectionStr == "")
            {
                _connectionStr = ReadConnectionStr();
                _isConnect = TestConnect();
                //Global.IsDBConnected =_isConnect;
            }
            return _connectionStr;
        }

        private static bool TestConnect()
        {
            Stopwatch sw = new Stopwatch();
            bool isCnnnect =false;
            Thread t = new Thread(delegate()
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionStr))
                    {
                        conn.Open();
                        isCnnnect =true;
                    }
                }
                catch (Exception e)
                {
                    LogMgr.Instance.Error("数据库连接错误" + e.Message + "\n连接字符串:" + _connectionStr);
                    //_connectionStr = "";
                }
            });
            t.IsBackground =true;
            t.Start();
            sw.Start();
            var timeout = TimeSpan.FromSeconds(3);
            while (!isCnnnect && sw.Elapsed<timeout)
            {
                t.Join(TimeSpan.FromMilliseconds(200));
            }
            sw.Stop();
            return isCnnnect;
        }

        public static bool CheckDBConnect()
        {
            try
            {
                if (!DbConfigManager.CheckConnectOK())
                {
                    LogMgr.Instance.Error($"数据库连接错误:\n请检查服务器连接是否正常[{DbConfigManager.ServerIp}]");
                    //UIMessageBox.ShowError($"数据库连接失败\n请检查服务器IP[{DbConfigManager.ServerIp}]是否能连上");
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"数据库连接错误:【{e.Message}】");
                //UIMessageBox.ShowError("数据库连接失败:" + e.Message);
            }
            return _isConnect;
        }
    }
}
