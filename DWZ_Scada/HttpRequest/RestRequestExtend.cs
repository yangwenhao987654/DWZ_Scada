using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TestConsoleApp1;

namespace DWZ_Scada.HttpRequest
{
    public static class RestRequestExtend
    {
        public static void MakePost(this RestRequest request,string url , object jsonBody)
        {
            //增加请求参数
            request.Resource = url;
            request.Method = Method.Post;
            request.AddJsonBody(jsonBody);
        }
    }
}
