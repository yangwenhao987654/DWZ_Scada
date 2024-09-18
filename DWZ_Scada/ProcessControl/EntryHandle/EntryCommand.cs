using DWZ_Scada.HttpServices;
using DWZ_Scada.ProcessControl.DTO;
using LogTool;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public abstract class EntryCommand : IStationCommand
    {
        public string StationName { get; }

        public string TempSN { get; }

        public string workOrder { get; }


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
            requestDto.StationCode = StationName;
            requestDto.WorkOrder = "MO202409110002";
            EntryRequestService entryRequestService = Global.ServiceProvider.GetRequiredService<EntryRequestService>();
            await entryRequestService.CheckIn(requestDto);
        }

        protected abstract void ExecuteEntry();

        protected virtual void PostExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Product {TempSN} has entered station {StationName}");
        }

    }
}
