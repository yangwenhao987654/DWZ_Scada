using CommunicationUtilYwh.Communication.TCP;
using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationUtilYwh.Device
{
    public class TcpScanner
    {
        public TcpClient tcpclient = new TcpClient();
        private readonly string triggeCmd = "A";
        private readonly string EndCmd = "E";

        private string ip;

        private string port;

        public string Name { get; set; }
        public TcpScanner(string name)
        {
            Name = name;
        }

        public async Task<bool> Connect(string ip, string port)
        {
            bool flag = false;
            try
            {
                flag =await tcpclient.Open(ip, port);
            }
            catch (Exception e)
            {
                flag = false;
            }
            //Global.IsHKSc_Connected = flag;
            return flag;
        }
        public bool DatalogicIsConnect()
        {
            return tcpclient.IsConnected();
        }

        public bool IsConnect()
        {
            return tcpclient.IsConnect;
        }

        /// <summary>
        /// 发送指令触发扫码
        /// </summary>
        /// <returns></returns>
        private bool DoScan()
        {
            return Write(triggeCmd);

        }

        public string Doscan()
        {
            string res = null;
            int times = 0;
            while (true)
            {
                DoScan();
                Thread.Sleep(100);
                times++;
                res = tcpclient.Read();
                if (!string.IsNullOrEmpty(res))
                {
                    break;
                }
                if (times > 3)
                {
                    LogMgr.Instance.Error($"{Name}重新扫码{times}次");
                    res = "NoRead";
                    break;
                }
            }
            return res;
        }


        public void CleanReadBuffer()
        {
            tcpclient.Read();
        }

        public string Read()
        {
            //return tcpclient.Read();
            string res = null;
            while (true)
            {
                res = tcpclient.Read();
                if (!string.IsNullOrEmpty(res))
                {
                    break;
                }
                Thread.Sleep(50);
            }
            return res;
        }


        /// <summary>
        /// 发送指令结束扫码
        /// </summary>
        /// <returns></returns>
        public bool EndScan()
        {
            return Write(EndCmd);
        }
        private bool Write(string msg)
        {
            return tcpclient.Write(msg);
        }

    }
}
