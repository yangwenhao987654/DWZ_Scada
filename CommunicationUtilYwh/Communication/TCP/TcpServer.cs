using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LogTool;

namespace SJTU_UI
{
    public class TcpServer :IDisposable
    {
        /// <summary>
        /// 监听客户端的连接请求
        /// </summary>
        public Socket ServerSocket { get; set; }
        public Dictionary<string, Socket> Sockets { get; set; } = new Dictionary<string, Socket>();
        public byte[] SendBuffer { get; set; }
        public byte[] ReceiveBuffer { get; set; }

        public int ActiveClientCount {
            get
            {
                return Sockets.Count;
            }
        }

        /// <summary>
        /// 客户端线程
        /// </summary>
        private List<Thread> cLienThreads = new List<Thread>();


        public delegate void SocketReceiveHandler(Socket socket, string str);

        // 定义事件  
        public  event SocketReceiveHandler GetMsgEvent;

        // 触发事件的方法  
        private void RiseReciveEvent(Socket socket, string res)
        {
            GetMsgEvent?.Invoke(socket,res);
          
        }

        public  delegate void SocketConnectHandler(Socket socket, string str);


        // 定义事件  
        public  event SocketConnectHandler ClientUnConnectedEvent;

        // 触发事件的方法  
        private void RiseClientUnConnectedEvent(Socket socket, string res)
        {
            ClientUnConnectedEvent?.Invoke(socket, res);
        }

        // 定义事件  
        public event SocketConnectHandler ClientConnectedEvent;

        // 触发事件的方法  
        private void RiseClientConnectedEvent(Socket socket, string res)
        {
            ClientConnectedEvent?.Invoke(socket, res);
        }
        
        //定义一个客户端未连接报警

        /// <summary>
        /// 创建构造函数
        /// </summary>
        /// <param name="sendBufferLength"></param>
        /// <param name="receiveBufferLength"></param>
        public TcpServer(int sendBufferLength, int receiveBufferLength)
        {
            SendBuffer = new byte[sendBufferLength];
            ReceiveBuffer = new byte[receiveBufferLength];
        }
        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Start(string ip, int port)
        {
            ServerSocket = CreateSocket(ip, port);
            CreateThread();
        }
        /// <summary>
        /// 服务端向指定客户端发送消息
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="data"></param>
        public void Send(string clientInfo, byte[] data)
        {
            Socket socket = Sockets[clientInfo];
            socket.Send(data);
        }
        /// <summary>
        /// 创建服务端Socket
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private Socket CreateSocket(string ip, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(ip);
            IPEndPoint endPoint = new IPEndPoint(address, port);
            socket.Bind(endPoint);
            socket.Listen(20);
            return socket;
        }
        /// <summary>
        /// 创建监听客户端的线程并启动
        /// </summary>
        private void CreateThread()
        {
            Thread watchThread = new Thread(WatchConnection);
            watchThread.IsBackground = true;
            watchThread.Start();
        }
        /// <summary>
        /// 监听客户端请求
        /// </summary>
        private void WatchConnection()
        {
            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket = ServerSocket.Accept();
                    IPEndPoint endPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                    string ip = endPoint.Address.ToString();
                    string port = endPoint.Port.ToString();
                    Sockets.Add(ip + ":" + port, clientSocket);
                    string msg = $"客户端连接上线: [{ip}:{port}]";
                    LogMgr.Instance.Info($"客户端连接上线: [{ip}:{port}]");
                    RiseClientConnectedEvent(clientSocket, msg);
                }
                //Message = "一个封锁操作被对 WSACancelBlockingCall 的调用中断。"
                catch (Exception ex)
                {
                    if (ex.Message.Contains("WSACancel"))
                    {
                        LogMgr.Instance.Info("关闭服务端");
                        break;
                    }
                    LogMgr.Instance.Error(ex.ToString());
                    break;
                }
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ClientReceiver);
                Thread clientThread = new Thread(pts);
                clientThread.IsBackground = true;
                clientThread.Start(clientSocket);
                cLienThreads.Add(clientThread);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        private void ClientReceiver(object socket)
        {
            Socket clientSocket = socket as Socket;
            int ReceiveBufferSize = 1 * 1024;
            while (true)
            {
                int receivedLength = 0;
                byte[] buffer = new byte[ReceiveBufferSize];
                try
                {
                    if (clientSocket != null)
                    {
                        if (!clientSocket.Connected)
                        {
                            RiseClientUnConnectedEvent(clientSocket, "客户端连接断开!!!");
                            IPEndPoint endPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                            string ip = endPoint.Address.ToString();
                            string port = endPoint.Port.ToString();
                            Sockets.Remove(ip + ":" + port);
                            return;
                        }
                        receivedLength = clientSocket.Receive(buffer);
                        if (receivedLength > 0)
                        {
                            //这里接收到客户端数据
                            //在界面显示数据 
                            //解析请求 响应结果给客户端

                            Buffer.BlockCopy(buffer, 0, ReceiveBuffer, 0, receivedLength);
                            Array.Resize(ref buffer, receivedLength);

                            string res = Encoding.UTF8.GetString(buffer);

                            //可以在这里处理？ 根据不同的结果 触发不同的事件？？

                            RiseReciveEvent(clientSocket,res);
                            /*string msg = $"Receive Success :{res}" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            byte[] datas = System.Text.Encoding.UTF8.GetBytes(msg);
                            //服务端 Socket 返回给客户端Socket的信息

                            clientSocket.Send(datas);*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SocketException)
                    {
                        RiseClientUnConnectedEvent(clientSocket, "客户端连接断开!!!"+ex.Message);

                        IPEndPoint endPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                        string ip = endPoint.Address.ToString();
                        string port = endPoint.Port.ToString();
                        Sockets.Remove(ip + ":" + port);
                    }
                    break;
                }
            }
        }


    /// <summary>
    /// 给指定客户端发送消息
    /// </summary>
    /// <param name="msg"></param>
        public void SendMsgToClient(string msg)
        {
            try
            {
                if (Sockets.Count > 0)
                {
                    Socket socket = Sockets.Values.FirstOrDefault();
                    if (socket != null)
                    {
                        byte[] datas = System.Text.Encoding.UTF8.GetBytes(msg);
                        socket.Send(datas);
                    }
                }
                else
                {
                    throw new Exception("没有客户端连接");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"发送消息错误:{e.Message}",e);
            }
        }

        /// <summary>
        /// 主动发送消息并且等待返回结果
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="timeoutMilliseconds">超时时间 单位ms</param>
        /// <returns></returns>
        public async Task<string> SendMsgAndWaitForResponse(string msg, int timeoutMilliseconds = 10000)
        {
            //触发之后等待结果 接收结果消息

            var tcs = new TaskCompletionSource<string>();

            void OnMessageReceived(Socket socket, string response)
            {
                GetMsgEvent -= OnMessageReceived; // 取消订阅以防止内存泄漏
                tcs.SetResult(response);
            }

            GetMsgEvent += OnMessageReceived;
            SendMsgToClient(msg);
            var completedTask = await Task.WhenAny(tcs.Task, Task.Delay(timeoutMilliseconds));
            if (completedTask==tcs.Task)
            {
                return tcs.Task.Result;
            }
            else
            {
                return $"Timeout:{timeoutMilliseconds}ms  No response received";
            }
        }

        /// <summary>
        /// 服务端向指定客户端发送消息，并接收响应消息
        /// </summary>
        /// <returns>客户端响应的消息内容</returns>
        public async Task<string> SendAndReceive(string msg)
        {
            try
            {
                if (Sockets.Count > 0)
                {
                    Socket socket = Sockets.Values.FirstOrDefault();
                    if (socket != null)
                    {
                        byte[] datas = System.Text.Encoding.UTF8.GetBytes(msg);
                        socket.Send(datas);
                        // 接收客户端的响应消息
                        return await ReceiveResponse(socket);
                    }
                }
                else
                {
                    throw new Exception("没有客户端连接");
                    return "";
                }
            }
            catch (Exception e)
            {
                throw new Exception($"异步发送消息错误:{e.Message}", e);
            }
            return "";
        }


        /// <summary>
        /// 服务端向指定客户端发送消息，并接收响应消息
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="data"></param>
        /// <returns>客户端响应的消息内容</returns>
        public async Task<string> SendAndReceive(string clientInfo, byte[] data)
        {
            Socket socket = Sockets[clientInfo];
            socket.Send(data);

            // 接收客户端的响应消息
            return await ReceiveResponse(socket);
        }

        private async Task<string> ReceiveResponse(Socket client)
        {
            var buffer = new byte[1024];
            try
            {
                int received = await ReceiveAsync(client, buffer);
                if (received > 0)
                {
                    return Encoding.UTF8.GetString(buffer, 0, received);
                }
                else
                {
                    return "No response received";
                }
            }
            catch (Exception ex)
            {
                return $"Error receiving response: {ex.Message}";
            }
        }

        private Task<int> ReceiveAsync(Socket client, byte[] buffer)
        {
            return Task<int>.Factory.FromAsync(
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, null, client) ?? throw new InvalidOperationException(("BeginReceive operation failed.")),
                client.EndReceive);
        }

        public void Dispose()
        {
            foreach (var clientThread in cLienThreads) // 遍历客户端线程列表并停止每个线程
            {
                clientThread.Abort();
            }
            cLienThreads.Clear();
            ServerSocket?.Dispose(); ;
        }
    }

}
