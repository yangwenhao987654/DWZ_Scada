using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using RestSharp;
using System.Threading.Tasks;
using TouchSocket.Core;

namespace DWZ_Scada.Services
{
    public class DeviceStateService
    {
        private readonly HttpClientHelper _httpClientHelper;

        public static  string Url => URLConstants.Base + URLConstants.DeviceStateUrl;

        public DeviceStateService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// 设备状态上报
        /// </summary>
        public async Task AddDeviceState(DeviceStateDTO dto)
        {
            string jsonString = dto.ToJsonString();
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            _httpClientHelper.AnalyzeResponse(response);
        }
    }
}
