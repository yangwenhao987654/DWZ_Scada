using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LogTool;

namespace SJTU_UI.VisionLink
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    namespace SJTU_Scada
    {
        /// <summary>
        /// 作服务端,同步连接
        /// </summary>
        public class MyTCPServer : IDisposable
        {
            private Socket server, client;
            private Thread th1;
            private object ob = new object();
            public bool Open(string ip, string port, long timeout)
            {
                try
                {
                    IPAddress IP = IPAddress.Parse(ip);
                    Int32 PORT = Int32.Parse(port);
                    IPEndPoint SERVER = new IPEndPoint(IP, PORT);//生成服务器网络端点
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // 构造一个socket
                    server.Bind(SERVER); //将socket和服务器绑定
                    server.Listen(8); //开始监听，允许连接队列的长度为8
                    th1 = new Thread(new ThreadStart(delegate
                    {
                        try { client = server.Accept(); } catch { }
                    }));
                    th1.Start();

                    return WaitThread(timeout);
                }
                catch (Exception ex)
                {
                    string error = "服务端同步连接，打开出现错误，信息为" + ex.Message;
                   // MessageManager.gOnly.Alarm(error);
                    return false;
                }
            }

            public void Test()
            {
                IPAddress IP = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(IP, 6666);
                server.Start();

                Console.WriteLine("Server started. Waiting for clients...");

                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                NetworkStream stream = client.GetStream();
                byte[] data = new byte[1024];
                int bytesRead = stream.Read(data, 0, data.Length);
                string message = Encoding.ASCII.GetString(data, 0, bytesRead);
                Console.WriteLine("已接收: " + message);

                //client.Close();
                //server.Stop();
                Console.ReadKey();

            }

            private bool WaitThread(long timeout)
            {
                long num = 0;
                while (num < timeout)
                {
                    if (IsConnected())
                    {
                        return true;
                    }
                    num += 100;
                    Thread.Sleep(100);
                }
                if (th1 != null)
                {
                    server.Close();
                    th1.Abort();
                }
                return false;
            }
            private void WaitReadAll(long time)
            {
                int prenum = client.Available;
                int nownum = 0;
                for (int i = 0; i < time / 10; i++)
                {
                    Thread.Sleep(10);
                    nownum = client.Available;
                    if (prenum == nownum)
                        break;
                    else
                    {
                        prenum = nownum;
                    }
                }
            }
            public bool IsConnected()
            {
                try
                {
                    if (client != null && (!(client.Poll(1000, SelectMode.SelectRead) && client.Available == 0)) && client.Connected)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    string error = "判断服务端是否连接出现错误，信息为" + ex.Message;
                    LogMgr.Instance.Error(error);
                    return false;
                }
            }
            public string Read()
            {
                lock (ob)
                {
                    string str = string.Empty;
                    try
                    {
                        if (client != null && client.Available > 0)
                        {
                            WaitReadAll(10000);
                            byte[] data = new byte[client.Available];
                            client.Receive(data);
                            str = Encoding.ASCII.GetString(data);
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = "读数据出现错误，信息为" + ex.Message;
                        LogMgr.Instance.Error(error);
                    }
                    return str;
                }
            }

            public void Write(string str)
            {
                lock (ob)
                {
                    try
                    {
                        client.Send(Encoding.ASCII.GetBytes(str.ToCharArray()));
                    }
                    catch (Exception ex)
                    {
                        string error = "写数据出现错误，信息为" + ex.Message;
                        LogMgr.Instance.Error(error);
                    }
                }
            }
            public void Dispose()
            {
                client = null;
                server.Close();
                server.Dispose();
                System.GC.Collect();
            }
        }
    }


}
