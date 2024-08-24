using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using RestSharp;
using TouchSocket.Http;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public abstract class EntryCommand :IStationCommand
    {
        public string StationName { get; }

        public string TempSN { get; }

        /// <summary>
        /// 进站请求路径
        /// </summary>
        public string EntryUrl;

        protected EntryCommand(string stationName, string tempSN)
        {
            StationName = stationName;
            TempSN = tempSN;
        }

        public void Execute()
        {
            PreExecute();
            ExecuteEntry();
            PostExecute();
        }

        protected  virtual string PreExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Preparing to enter station {StationName} for product {TempSN}");
            //进行统一进站请求
            RestClient client  = new RestClient();
            var request = new RestRequest(EntryUrl);
            //增加请求参数
            request.Method = Method.Get;
            EntryRequestDTO requestDto = new EntryRequestDTO();
            requestDto.SnTemp = TempSN;
            requestDto.StationbCode = StationName;
            request.AddJsonBody(requestDto);
            Task<RestResponse> task =  client.ExecuteAsync(request);
            RestResponse response = task.Result;
            return response.Content;
        }

        protected abstract void ExecuteEntry();

        protected virtual void PostExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Product {TempSN} has entered station {StationName}");
        }

    }
}
