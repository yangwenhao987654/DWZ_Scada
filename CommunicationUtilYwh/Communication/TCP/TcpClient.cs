using LogTool;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationUtilYwh.Communication.TCP
{
    public class TcpClient : IDisposable
    {
        private Socket tcpclient;
        private object ob = new object();

        private NetworkStream _stream;

        public event Action<string> DataReceived;


        public TcpClient()
        {
           
        }

        /// <summary>
        /// 读取超时时间 ms
        /// </summary>
        public int Timeout { get; set; }= 3000;
        public async Task<bool> Open(string ip, string port)
        {
            try
            {
                IPAddress IP = IPAddress.Parse(ip);
                IPEndPoint Host = new IPEndPoint(IP, Convert.ToInt32(port));
                tcpclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                tcpclient.SendTimeout = 3000;
                tcpclient.ReceiveTimeout = 3000;
                var timeoutTask = Task.Delay(3000);
                Task connectTask = tcpclient.ConnectAsync(Host);
                connectTask.Wait();
                var completedTask = await Task.WhenAny(connectTask, timeoutTask);

                if (completedTask==timeoutTask)
                {
                    tcpclient.Close();
                    return false;
                }
                //StartReceiving();
                return tcpclient.Connected;
            }
            catch (Exception ex)
            {
                string error = "客户端连接打开出现错误，信息为" + ex.Message;
                //function.LOGS_disp(error);
                LogMgr.Instance.Error(error);
                tcpclient?.Close();
                return false;
            }
        }

        public void StartReceiving()
        {
            byte[] buffer = new byte[1024];
            tcpclient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, buffer);
        }
        public bool IsConnected()
        {
            try
            {
                if (tcpclient != null && (!(tcpclient.Poll(1000, SelectMode.SelectRead) && tcpclient.Available == 0)) && tcpclient.Connected)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string error = "判断客户端是否连接出现错误，信息为" + ex.Message;
                //  MessageManager.gOnly.Alarm(error);
                LogMgr.Instance.Error($"客户端连接异常:{ex.Message}");
                return false;
            }
        }

        public bool IsConnect
        {
            get
            {
                return tcpclient != null && tcpclient.Connected;
            }
        }
        /// <summary>
        /// 确保接收到的数据完整 不丢包
        /// </summary>
        /// <param name="time"></param>
        private void WaitReadAll(long time)
        {
            int prenum = tcpclient.Available;
            int nownum = 0;
            for (int i = 0; i < time / 1000; i++)
            {
                Thread.Sleep(5);
                nownum = tcpclient.Available;
                if (prenum == nownum)
                    break;
                /*else
                {
                    prenum = nownum;
                }*/
            }
        }
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Read()
        {
            lock (ob)
            {
                string datastr = string.Empty;
                try
                {
                    if (IsConnected() && tcpclient.Available > 0)
                    {
                        WaitReadAll(Timeout);
                        byte[] data = new byte[tcpclient.Available];
                        tcpclient.Receive(data);
                        datastr = Encoding.ASCII.GetString(data);

                        //TODO 把末尾\n后面的都去掉
                        if (datastr!="")
                        {
                            datastr = RemoveCR(datastr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = "读数据错误:" + ex.Message;
                    //  MessageManager.gOnly.Alarm(error);
                }
                return datastr;
            }
        }

        private string RemoveCR(string str)
        {
            string[] strings = str.Split("\r");
            return strings[0];
        }

        public void CleanReadBuffer()
        {
            //tcpclient.();
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = tcpclient.EndReceive(ar);
                if (bytesRead > 0)
                {
                    string data = Encoding.UTF8.GetString((byte[])ar.AsyncState, 0, bytesRead);
                    DataReceived?.Invoke(data);
                    StartReceiving(); // 继续接收数据
                }
            }
            catch (Exception e)
            {
               LogMgr.Instance.Error(e.Message);
            }
          
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Write(string str)
        {
            lock (ob)
            {
                try
                {
                    if (IsConnected())
                    {
                        byte[] data = Encoding.ASCII.GetBytes(str);
                        tcpclient.Send(data);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    string error = "写数据出现错误，信息为" + ex.Message;
                    // MessageManager.gOnly.Alarm(error);
                    return false;
                }
            }
        }
        public void Dispose()
        {
            if (tcpclient != null)
            {
                if (tcpclient.Connected && (!tcpclient.Poll(1000, SelectMode.SelectRead)))
                {
                    try
                    {
                        tcpclient.Shutdown(SocketShutdown.Both);
                        tcpclient.Disconnect(true);
                    }
                    catch (Exception ex)
                    {
                        string error = "断开客户端连接出现错误，信息为" + ex.Message;
                        // MessageManager.gOnly.Alarm(error);
                    }
                }
                tcpclient.Close();
                tcpclient = null;
            }
            GC.Collect();
        }
    }
}
