
using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl;
using LogTool;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class WorkOrderService
    {
        private readonly HttpClientHelper _httpClientHelper;
        public  string Url => URLConstants.Base + URLConstants.GetWorkOrderUrl;
        public WorkOrderService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// 上传Mes过站数据
        /// </summary>
        public async Task<RestResponse> GetWorkOrder()
        {
            RestResponse response = await _httpClientHelper.SendGetRequestAsync(Url);
            LogMgr.Instance.Info($"获取响应:\n{response.Content}");
            _httpClientHelper.AnalyzeResponse(response);
            return response;
        }
    }
}
