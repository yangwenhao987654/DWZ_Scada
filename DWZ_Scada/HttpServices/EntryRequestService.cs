using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class EntryRequestService
    {
        private readonly HttpClientHelper _httpClientHelper;

        /// <summary>
        /// 进站请求路径
        /// </summary>
        public static string Url = URLConstants.Base + URLConstants.EntryUrl;

        public EntryRequestService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public  async Task<(bool,string)> CheckIn(EntryRequestDTO dto)
        {
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            string msg = string.Empty;
            bool isSuccessful = response.IsSuccessful;
            if (isSuccessful)
            {
                string content = response.Content;
                EntryResultDTO resultDto = JsonConvert.DeserializeObject<EntryResultDTO>(content);
                if (resultDto.Code == 200)
                {
                    LogMgr.Instance.Info($"请求成功:{resultDto.Message}");
                 
                }
                else
                {
                    LogMgr.Instance.Error($"请求失败:{resultDto.Message}");
                    msg = resultDto.Message;
                }
            }
            else
            {
                LogMgr.Instance.Error("请求错误");
                msg = "请求错误";
            }

            bool result = _httpClientHelper.AnalyzeResponse(response);
         
            return (result,msg);
        }
    }
}
