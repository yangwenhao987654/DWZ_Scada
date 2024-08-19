using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSocket.Core;
using TouchSocket.Http;

namespace TestConsoleApp1.MyHttpPlug
{
    public class MyHttpPlug1:PluginBase ,IHttpPlugin<IHttpSocketClient>
    {
        public async Task OnHttpRequest(IHttpSocketClient client, HttpContextEventArgs e)
        {
            Console.WriteLine("接收请求:" + e.Context.Request.URL);
            if (e.Context.Request.IsGet())
            {
                //获取请求参数
                IHttpParams httpParams = e.Context.Request.Query;
                if (httpParams.TryGetValue("type", out var type))
                {
                    Console.WriteLine($"获取型号:[{type}]");
                }
              
                //获取请求头
                IHttpHeader header = e.Context.Request.Headers;
                string body = e.Context.Request.GetBody();

                if (e.Context.Request.UrlEquals("/test"))
                {
                    ResultDTO resultDto = new ResultDTO(200, "请求OK的");
                    resultDto.Data = new OP10Data()
                    {
                        Name = "OP10",
                        Description = "收到OP10的测试数据",
                        Count = 666,
                        StartDateTime = DateTime.Now,
                    };
                    string resJson = resultDto.ToJsonString();
                    e.Context.Response.FromJson(resJson).Answer();
                    Console.WriteLine("接收请求:"+e.Context.Request.URL);
                    Console.WriteLine("响应内容:"+resJson);
                    Console.WriteLine("处理完毕");

                    //默认状态码是200
                    return;
                }
                else
                {
                    e.Context.Response.FromText("Request Path Is Not Exist").AnswerAsync();
                }
            }
            await e.InvokeNext();
        }
    }
}
