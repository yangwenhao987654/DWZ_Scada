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
    public class ProductBomService
    {
        private readonly HttpClientHelper _httpClientHelper;
        public static string Url => URLConstants.Base + URLConstants.ProductBomList;
        public ProductBomService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        /// <summary>
        /// 查询BOM
        /// </summary>
        public  async Task<(bool,string, ProductDetailDto)> GetBomList(string itemCode)
        {
            GetBomDTO dto = new GetBomDTO()
            {
                ItemCode = itemCode
            };
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url,dto);
            LogMgr.Instance.Info("获取响应");
            (bool, string, ProductDetailDto) value = AnalyzeResponse(response);
            return value;
        }


        public (bool, string, ProductDetailDto) AnalyzeResponse(RestResponse response)
        {
            string msg = string.Empty;
            bool isSuccessful = response.IsSuccessful;
            bool result = false;
            ProductDetailDto dto = null;
            try
            {
                if (isSuccessful)
                {
                    string content = response.Content;
                    BomResultDto resultDto = JsonConvert.DeserializeObject<BomResultDto>(content);
                    dto = resultDto.Data;
                    if (resultDto.code == 200)
                    {
                        LogMgr.Instance.AddChargeInfo($"Bom请求成功:{resultDto.msg}");
                        result = true;
                    }
                    else
                    {
                        LogMgr.Instance.AddMesError($"Bom请求失败:{resultDto.msg}");
                    }
                    msg = resultDto.msg;
                }
                else
                {
                    LogMgr.Instance.AddMesError("请求错误");
                    msg = "请求错误";
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.AddMesError($"解析进站响应错误:{ex.Message}");
            }
            return (result, msg, dto);
        }
    }
}
