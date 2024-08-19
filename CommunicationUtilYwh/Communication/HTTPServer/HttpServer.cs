using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationUtilYwh.Communication.HTTPServer
{
    public abstract class HttpServer
    {
        protected int Port;
        TcpListener Listener;
        bool is_active = true;

        public HttpServer(int port)
        {
            this.Port =port;
        }

        public void Listen()
        {
            Listener = new TcpListener(Port);
            Listener.Start();
            while (is_active)
            {
                TcpClient client = Listener.AcceptTcpClient();
                //HttpProcessor processor = new HttpProcessor(client,this);
            }
        }
    }
}
