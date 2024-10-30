﻿using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using RestSharp;
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
        public  async Task<(bool,string)> GetBomList(string itemCode)
        {
            GetBomDTO dto = new GetBomDTO()
            {
                ItemCode = itemCode
            };
            RestResponse response = await _httpClientHelper.SendPostRequestAsync(Url,dto);
            LogMgr.Instance.Info("获取响应");
            (bool, string) value = _httpClientHelper.AnalyzeResponse(response);
            return value;
        }
    }
}
