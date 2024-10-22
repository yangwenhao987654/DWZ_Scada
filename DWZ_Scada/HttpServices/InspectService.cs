using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class InspectService
    {
        private readonly HttpClientHelper _httpClientHelper;
        public static string Url = URLConstants.Base + URLConstants.InspectUrl;
        public InspectService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// 上传点检数据
        /// </summary>
        public async Task<(bool, string)> AddInspectDada(DeviceInspectDTO  dto)
        {
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            LogMgr.Instance.Info($"获取响应:\n{response.Content}");
           return _httpClientHelper.AnalyzeResponse(response);
        }
    }
}
