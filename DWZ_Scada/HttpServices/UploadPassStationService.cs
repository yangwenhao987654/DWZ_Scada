using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using RestSharp;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class UploadPassStationService
    {
        private readonly HttpClientHelper _httpClientHelper;
        public static string Url = URLConstants.Base + URLConstants.PassStationUpload;
        public UploadPassStationService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// 上传Mes过站数据
        /// </summary>
        public  async Task SendPassStationData(PassStationDTO dto)
        {
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            LogMgr.Instance.Info($"获取响应:\n{response.Content}");
            _httpClientHelper.AnalyzeResponse(response);
        }
    }
}
