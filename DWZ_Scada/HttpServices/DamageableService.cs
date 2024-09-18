using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using RestSharp;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpServices
{
    public class DamageableService
    {
        private readonly HttpClientHelper _httpClientHelper;

        public static string Url = URLConstants.Base + URLConstants.ReportConsumableUrl;


        public DamageableService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task ReportDamageableAsync(DamageableDTO dto)
        {
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url, dto);
            _httpClientHelper.AnalyzeResponse(response);
        }
    }
}
