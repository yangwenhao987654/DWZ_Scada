using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl;
using LogTool;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSocket.Sockets;

namespace DWZ_Scada.HttpRequest
{
    public class DeviceStateReporter
    {
        private readonly RestClient _client;

        public DeviceStateReporter(RestClient client)
        {
            _client =client;
        }

        /// <summary>
        /// 设备状态上报
        /// </summary>
        public  async Task AddDeviceState(DeviceStateDTO dto)
        {
            string url = URLConstants.Base + URLConstants.DeviceStateUrl;
            LogMgr.Instance.Debug("请求路径:" + url);
            var request = new RestRequest();
            //组装过站数据给Mes
            request.MakePost(url, dto);
            RestResponse response = await _client.ExecuteAsync(request);
            LogMgr.Instance.Info("请求发送完成");
            AnalysisResponse(response);
        }

        private  void AnalysisResponse(RestResponse response)
        {
            bool isSuccessful = response.IsSuccessful;
            if (isSuccessful)
            {
                LogMgr.Instance.Info($"获取响应结果:{response.Content}");
            }
            else
            {
                LogMgr.Instance.Error("请求错误");
            }
            string res = response.Content;
        }
    }
}
