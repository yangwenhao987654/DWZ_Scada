using System;
using System.Linq;
using System.Threading.Tasks;
using CommunicationUtilYwh.Communication;
using CommunicationUtilYwh.Communication.ModbusTCP;
using Newtonsoft.Json;
using RestSharp;
using TestConsoleApp1.MyHttpPlug;
using TestConsoleApp1.OOP;
using TouchSocket.Core;
using TouchSocket.Http;
using TouchSocket.Sockets;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestConsoleApp1
{
    internal class Program
    {
        delegate void VoidMethod();

        static void  Main(string[] args)
        {

            //测试ModbusServer

          /*  ModbusTcpServer server = new ModbusTcpServer(502);
            server.Start();*/

          //
/*          Animal animal = new Dog();
         
            //animal.Eat();
            VoidMethod m;
            m =  animal.Eat;
            int a=1;
            
            m.Invoke();

            Console.ReadLine();*/
        }

        public static void TestHttp()
        {
            Console.WriteLine("启动服务端...");
            StartServer();

            //HTTP客户端请求
            Console.WriteLine("启动模拟客户端发送请求...");
            string url = @"http://localhost:8090/test";
            TestGetRequest<ResultDTO>(url);
            Console.ReadLine();
        }

        public static void StartServer()
        {
            var service = new HttpService();
            service.Setup(new TouchSocketConfig()
                .SetListenIPHosts(8090)
                .ConfigureContainer(a =>
                {
                    a.AddConsoleLogger();
                })
                .ConfigurePlugins(a =>
                {
                    a.Add<MyHttpPlug1>();
                    a.UseDefaultHttpServicePlugin();
                })
            );
            service.Start();
        }

        public static void TestGetRequest<T>(string url)
        {
            string baseUrl = url;
            MyHttpClient client = new MyHttpClient(baseUrl);
            Task<RestResponse> task = client.GetAsync("");
            RestResponse response = task.Result;
            string res = response.Content;
            T dto = JsonConvert.DeserializeObject<T>(res);
            Console.WriteLine(dto.GetType());
            string jsonStr = JsonConvert.SerializeObject(dto);
            ResultDTO result = JsonConvert.DeserializeObject<ResultDTO>(res);
            Console.WriteLine(jsonStr);
         
        }
    }
}
