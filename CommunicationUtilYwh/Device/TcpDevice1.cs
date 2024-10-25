using CommunicationUtilYwh.Communication.TCP;
using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommunicationUtilYwh.Device
{
    public class TcpDevice1
    {
        private TcpClient tcpclient = new TcpClient();

        private readonly object _lock = new object();

        private readonly string updateProductCmdPre = "Func=UpdateProductId,ProductId=";

        private readonly string QueryIsReadyCmd = "Func=QueryIsReady";

        private readonly string TriggerWorkCmd = "Func=Work";

        private readonly string queryTestStatusCmd = "Func=QueryTestStatus";

        private readonly string QueryWorkResultCmd = "Func=QueryWorkResult";

        private readonly string QueryDetailsWorkResultCmd = "Func=QueryDetailsWorkResult";


        private readonly string ClearDataCmd = "Func=ClearData";

        private readonly string StopCmd = "Func=Scrame";

        private readonly string QuerySchemeNameCmd = "Func=QuerySchemeName";

        private readonly string UpdateSchemeNameCmd = "Func=UpdateScheme,SchemeName=";

        private string ip;

        private string port;

        public string Name { get; set; }
        public TcpDevice1()
        {
            // Name = name;
        }

        public (bool, string) Connect(string ip, string port)
        {
            bool flag = false;
            string err = "";
            try
            {
                if (tcpclient == null)
                {
                    tcpclient = new TcpClient();
                }
                flag = tcpclient.Open(ip, port);
                //TODO 连接成功之后查询设备状态
                QueryIsReady();
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
            tcpclient.Dispose();
        }
        public bool DatalogicIsConnect()
        {
            return tcpclient.IsConnected();
        }

        public bool IsConnect()
        {
            return tcpclient.IsConnect;
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

            string result = Read();
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

    
    }
}
