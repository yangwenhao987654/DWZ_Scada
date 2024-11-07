using CommunicationUtilYwh.Communication.TCP;
using LogTool;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationUtilYwh.Device
{
    public class TcpDevice1 :IDisposable
    {
        private TcpClient tcpclient = new TcpClient();

        private readonly object _lock = new object();

        private readonly string updateProductCmdPre = "Func=UpdateProductId,ProductId=";

        private readonly string QueryIsReadyCmd = "Func=QueryIsReady";

        private readonly string TriggerWorkCmd = "Func=Work";

        /// <summary>
        /// 查询测试状态命令
        /// </summary>
        private readonly string queryTestStatusCmd = "Func=QueryTestStatus";

        private readonly string QueryWorkResultCmd = "Func=QueryWorkResult";

        private readonly string QueryDetailsWorkResultCmd = "Func=QueryDetailsWorkResult";


        private readonly string ClearDataCmd = "Func=ClearData";

        private readonly string StopCmd = "Func=Scrame";

        private readonly string QuerySchemeNameCmd = "Func=QuerySchemeName";

        private readonly string UpdateSchemeNameCmd = "Func=UpdateScheme,SchemeName=";

        private string ip;

        private string port;


        public int ID { get; set; }

        public string Name { get; set; }
        public TcpDevice1(string name)
        {
             Name = name;
        }

        public TcpDevice1( string name, int id)
        {
            ID = id;
            Name = name;
        }

        public async Task<(bool, string)> ConnectAsync(string ip, string port)
        {
            bool flag = false;
            string err = "";
            try
            {
                if (tcpclient == null)
                {
                    tcpclient = new TcpClient();
                }
                flag = await tcpclient.Open(ip, port);
                if (flag)
                {
                    QueryIsReady();
                }
           
            }
            catch (Exception ex)
            {
                err = ex.Message;
                flag = false;
            }
            //Global.IsHKSc_Connected = flag;
            return (flag, err);
        }


        public void Disconnect()
        {
            tcpclient?.Dispose();
        }

        public bool IsConnect()
        {
            return tcpclient!=null &&tcpclient.IsConnected();
        }

        public string UpdateProduct(string name)
        {
            string cmd = updateProductCmdPre + name;
            return Send(cmd);
        }

        /// <summary>
        /// 查询设备状态
        /// </summary>
        /// <returns></returns>
        public string QueryIsReady()
        {
            return Send(QueryIsReadyCmd);
        }
        public string TriggerWork()
        {
            return Send(TriggerWorkCmd);
        }

        /// <summary>
        /// 查询测试状态
        /// </summary>
        /// <returns></returns>
        public string QueryTestStatus()
        {
            return Send(queryTestStatusCmd);
        }


        /// <summary>
        /// 查询测试结果
        /// </summary>
        /// <returns></returns>
        public string QueryWorkResult()
        {
            return Send(QueryWorkResultCmd);
        }

        /// <summary>
        /// 查询测试结果明细
        /// </summary>
        /// <returns></returns>
        public string QueryDetailsWorkResult()
        {
            return Send(QueryDetailsWorkResultCmd);
        }


        public string ClearData()
        {
            return Send(ClearDataCmd);
        }

        /// <summary>
        /// 查询当前运行方案
        /// </summary>
        /// <returns></returns>
        public string QuerySchemeName()
        {
            return Send(QuerySchemeNameCmd);
        }
        public string UpdateSchemeName(string name)
        {
            string cmd = UpdateSchemeNameCmd + name;
            return Send(QuerySchemeNameCmd);
        }


        public string Stop()
        {
            return Send(StopCmd);
        }


        /// <summary>
        /// 发送指令触发扫码
        /// </summary>
        /// <returns></returns>
        private string Send(string cmd)
        {
            cmd += "\r\n";
            bool f = Write(cmd);
            LogMgr.Instance.Debug("发送命令:"+cmd);
            Thread.Sleep(500);
            string result = Read();
            LogMgr.Instance.Debug("读取结果:" + result);
            return result;

        }

        public string Read()
        {
            string res = null;
            int times = 0;
            while (true)
            {
                times++;
                res = tcpclient.Read();
                if (!string.IsNullOrEmpty(res))
                {
                    break;
                }
                if (times > 5)
                {
                    break;
                }
                Thread.Sleep(50);
            }
            return res;
        }


        public void CleanReadBuffer()
        {
            tcpclient.Read();
        }



        private bool Write(string msg)
        {
            lock (_lock)
            {
                return tcpclient.Write(msg);
            }
        }


        public void Dispose()
        {
            tcpclient?.Dispose();
        }

        public int ParseTestState(string input)
        {
            int state = -1;
            try
            {
                string[] parts = input.Split(',');

                if (parts.Length == 4)
                {
                    var strings = parts[3].Split('=');
                    if (strings.Length > 1)
                    {
                        string value = strings[1];
                        value = value.Substring(0, 1);
                        state = int.Parse(value);
                    }
                }
            }
            catch (Exception e)
            {
               LogMgr.Instance.Error($"[{this.Name}]->解析测试状态错误=>:"+e.Message);
            }
            return state;
        }
    }
}
