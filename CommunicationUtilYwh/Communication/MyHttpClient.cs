using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;

namespace CommunicationUtilYwh.Communication
{
    public class MyHttpClient
    {
        public RestClient RestClient { get; set; }
        public MyHttpClient(string baseUrl)
        {
            RestClient = new RestClient(baseUrl);
        }

        public async Task<RestResponse> GetAsync(string url)
        {
            var request = new RestRequest(url);

            //增加请求参数
            request.AddParameter("type",1000);
            request.Method = Method.Get;

            
            //request.AddBody();
            //request.AddJsonBody();
            RestResponse response = await RestClient.ExecuteGetAsync(request);
            return response;
        }
    }
}
