using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Newtonsoft.Json;
using RestSharp;
using TouchSocket.Http;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public abstract class EntryCommand : IStationCommand
    {
        public string StationName { get; }

        public string TempSN { get; }


        //{"msg":"没有正在生产的工单","code":200}

        /// <summary>
        /// 进站请求路径
        /// </summary>
        public string EntryUrl = URLConstants.Base + URLConstants.EntryUrl;

        protected EntryCommand(string stationName, string tempSN)
        {
            StationName = stationName;
            TempSN = tempSN;
        }

        public async void Execute()
        {
            PostExecute();
            await PreExecute();
            ExecuteEntry();
        }

        /// <summary>
        /// 统一进站请求
        /// </summary>
        /// <returns></returns>
        protected virtual async Task PreExecute()
        {
            EntryRequestDTO requestDto = new EntryRequestDTO();
            requestDto.SnTemp = TempSN;
            requestDto.StationbCode = StationName;
            await MyClient.CheckIn(requestDto);
          /*  try
            {
                // 统一的执行前处理逻辑
                LogMgr.Instance.Debug($"Preparing to enter station {StationName} for product {TempSN}");
                //进行统一进站请求
                RestClient client = new RestClient();
                var request = new RestRequest(EntryUrl);
                //增加请求参数
                request.Method = Method.Post;
                EntryRequestDTO requestDto = new EntryRequestDTO();
                requestDto.SnTemp = TempSN;
                requestDto.StationbCode = StationName;
                request.AddJsonBody(requestDto);
                RestResponse response = await client.ExecuteAsync(request);
                //RestResponse response = task.Result;
                LogMgr.Instance.Info($"获取响应结果:{response.Content}");
                bool isSuccessful = response.IsSuccessful;
                if (isSuccessful)
                {
                    string result = response.Content;
                    EntryResultDTO resultDto = JsonConvert.DeserializeObject<EntryResultDTO>(result);
                    if (resultDto.Code == 200)
                    {
                        LogMgr.Instance.Info($"请求成功:{resultDto.Message}");
                    }
                    else
                    {
                        LogMgr.Instance.Error($"请求失败:{resultDto.Message}");
                    }
                }
                else
                {
                    LogMgr.Instance.Error("请求错误");
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error("请求错误"+e.Message);
            }*/
        }

        protected abstract void ExecuteEntry();

        protected virtual void PostExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Product {TempSN} has entered station {StationName}");
        }

    }
}
