using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using RestSharp;
using System.Threading.Tasks;

namespace DWZ_Scada.HttpRequest
{
    public class MyClient
    {
        private static RestClient client = new RestClient();

        /// <summary>
        /// 上传Mes过站数据
        /// </summary>
        public static async Task PassStationUploadTest(PassStationDTO dto)
        {
            string url = URLConstants.Base + URLConstants.PassStationUpload;
            LogMgr.Instance.Debug("请求路径:" + url);
            var request = new RestRequest();
            //组装过站数据给Mes
            request.MakePost(url,dto);
            RestResponse response = await client.ExecuteAsync(request);
            LogMgr.Instance.Info("获取响应");
            AnalysisResponse(response);
        }

        /// <summary>
        /// 查询BOM
        /// </summary>
        public static async Task GetBomList(string itemCode)
        {
            string url = URLConstants.Base + URLConstants.ProductBomList;
            LogMgr.Instance.Debug("请求路径:" + url);
            var request = new RestRequest();
            GetBomDTO dto = new GetBomDTO()
            {
                ItemCode = itemCode
            };
            //组装过站数据给Mes
            request.MakePost(url, dto);
            RestResponse response = await client.ExecuteAsync(request);
            LogMgr.Instance.Info("获取响应");
            AnalysisResponse(response);
        }

        /// <summary>
        /// 上传点检数据
        /// </summary>
        public static async Task AddInspectDada()
        {
            string url = URLConstants.Base + URLConstants.InspectUrl;
            LogMgr.Instance.Debug("请求路径:" + url);
            var request = new RestRequest();
            DeviceInspectDTO dto = new DeviceInspectDTO()
            {
                DeviceCode = "OP10",
                DeviceName = "工站01",           
            };
            //组装过站数据给Mes
            request.MakePost(url, dto);
            RestResponse response = await client.ExecuteAsync(request);
            LogMgr.Instance.Info("获取响应");
            AnalysisResponse(response);
        }

        /// <summary>
        /// 易损易耗件上报
        /// </summary>
        public static async Task ReportDamageable()
        {
            string url = URLConstants.Base + URLConstants.ReportConsumableUrl;
            LogMgr.Instance.Debug("请求路径:" + url);
            var request = new RestRequest();
            DamageableDTO dto = new DamageableDTO()
            {
                deviceCode = "OP10",
                code = "002",
                runNumber = 1,
                type = 1,
            };
            //组装过站数据给Mes
            request.MakePost(url, dto);
            RestResponse response = await client.ExecuteAsync(request);
            LogMgr.Instance.Info("请求发送完成");
            AnalysisResponse(response);
        }

        /// <summary>
        /// 获取最终码
        /// </summary>
        /// <returns></returns>
        public static async Task GetFinalCode(string tempSN)
        {
            string url = URLConstants.Base + URLConstants.GetFinalCodeUrl;
            var request = new RestRequest(url);
            //增加请求参数
            request.Method = Method.Get;
            request.AddParameter("code", tempSN);
            Task<RestResponse> task = client.ExecuteAsync(request);
            RestResponse response = task.Result;
            AnalysisResponse(response);
        }

        /// <summary>
        /// 获取当前工单
        /// </summary>
        /// <returns></returns>
        public static async Task GetWorkOrder()
        {
            string url = URLConstants.Base + URLConstants.GetWorkOrderUrl;
            var request = new RestRequest(url);

            request.Method = Method.Get;
            Task<RestResponse> task = client.ExecuteAsync(request);
            RestResponse response = task.Result;
            AnalysisResponse(response);
            //获取到工单 workorderCode MO202409110002
            // 产品Code productCode IF20240827001
        }

        private static void AnalysisResponse(RestResponse  response)
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
