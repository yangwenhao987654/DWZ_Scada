using DWZ_Scada.dao.response;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class EntryRequestService
    {
        private readonly HttpClientHelper _httpClientHelper;

        /// <summary>
        /// 进站请求路径
        /// </summary>
        public static string Url => URLConstants.Base + URLConstants.EntryUrl;

        public EntryRequestService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        public  async Task<(bool,string)> CheckIn(EntryRequestDTO dto)
        {
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            string msg = string.Empty;
            bool isSuccessful = response.IsSuccessful;
            bool result =false;
            try
            {
                if (isSuccessful)
                {
                    string content = response.Content;
                    ResultDTO resultDto = JsonConvert.DeserializeObject<ResultDTO>(content);
                    if (resultDto.code == 200)
                    {
                        LogMgr.Instance.Info($"请求成功:{resultDto.msg}");
                        result = true;
                    }
                    else
                    {
                        LogMgr.Instance.Error($"请求失败:{resultDto.msg}");
                    }
                    msg = resultDto.msg;
                }
                else
                {
                    LogMgr.Instance.Error("请求错误");
                    msg = "请求错误";
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"解析进站响应错误:{e.Message}");
            }
            return (result,msg);
        }
    }
}
