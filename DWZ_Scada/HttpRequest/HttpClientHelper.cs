using DWZ_Scada.ProcessControl;
using LogTool;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpRequest
{
    public class HttpClientHelper
    {
        private readonly RestClient _client;

        public HttpClientHelper(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> SendPostRequestAsync<T>(string url, T dto)where T:class
        {
            LogMgr.Instance.Debug($"请求路径:{url}");
            var request = new RestRequest(url, Method.Post);
            request.AddJsonBody(dto);
            try
            {
                RestResponse response  = await _client.ExecuteAsync(request);
                LogMgr.Instance.Debug($"请求完成");
                return response;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"请求失败: {ex.Message}");
                throw;
            }
        }

        // 通用GET请求
        public async Task<RestResponse> SendGetRequestAsync(string url, Dictionary<string, object> parameters = null)
        {
            LogMgr.Instance.Debug($"请求路径: {url}");
            var request = new RestRequest(url, Method.Get);
            //request.AddParameter<>("code", "tempSN");
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    //value转化为string类型
                    request.AddParameter(param.Key, param.Value.ToString());
                }
            }
            try
            {
                RestResponse response = await _client.ExecuteAsync(request);
                LogMgr.Instance.Info("请求完成");
                return response;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"请求失败: {ex.Message}");
                throw;
            }
        }

        // 分析响应
        public bool AnalyzeResponse(RestResponse response)
        {
            if (response.IsSuccessful)
            {
                /*{"msg":"出站成功","code":200}*/
                LogMgr.Instance.Info($"响应成功: {response.Content}");
                return true;
            }
            else
            {
                LogMgr.Instance.Error($"请求失败: {response.StatusCode},错误类型:{response.ResponseStatus} \n 错误信息: {response.ErrorMessage}");
                return false;
            }
        }
    }
}
