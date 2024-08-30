using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogTool;
using TouchSocket.Core;
using TouchSocket.Http;

namespace TestConsoleApp1.MyHttpPlug
{
    public class MyHttpPlug1:PluginBase ,IHttpPlugin<IHttpSocketClient>
    {
        public async Task OnHttpRequest(IHttpSocketClient client, HttpContextEventArgs e)
        {
            //"http：//XXX:8090/workorder/issue/${产品型号ID}";
            Console.WriteLine("接收请求:" + e.Context.Request.URL);
            if (e.Context.Request.IsGet())
            {
                //获取请求参数
                IHttpParams httpParams = e.Context.Request.Query;
                if (httpParams.TryGetValue("type", out var type))
                {
                    LogMgr.Instance.Info($"获取型号:[{type}]");
                }
                //获取请求头
                IHttpHeader header = e.Context.Request.Headers;
                string body = e.Context.Request.GetBody();

                //Mes选型请求接口
                if (e.Context.Request.UrlEquals("/workorder/issue"))
                {
                    //返回响应信息  
                    ResultDTO resultDto = new ResultDTO(200, "请求OK的");
                /*    resultDto.Data = new OP10Data()
                    {
                        Name = "OP10",
                        Description = "收到OP10的测试数据",
                        Count = 666,
                        StartDateTime = DateTime.Now,
                    };*/
                    string resJson = resultDto.ToJsonString();
                   
                    Console.WriteLine("接收请求:"+e.Context.Request.URL);
                    Console.WriteLine("响应内容:"+resJson);
                    Console.WriteLine("处理完毕");

                    //处理选型 
                    //默认状态码是200
                    await e.Context.Response.FromJson(resJson).AnswerAsync();

                    return ;
                }
                else
                {
                   await e.Context.Response.FromText("Request Path Is Not Exist").AnswerAsync();
                }
            }
            await e.InvokeNext();
        }
    }
}
