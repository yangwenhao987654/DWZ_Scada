using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestModel;

namespace DWZ_Scada.ProcessControl.RequestSelectModel
{
    public class DefaultSelectionStrategy :SelectionStrategyBase
    {
        /// <summary>
        /// 当前设置的站别名称
        /// </summary>
        public string SelectedsStationName;

        public DefaultSelectionStrategy()
        {

        }

        public DefaultSelectionStrategy(string stationName)
        {
            SelectedsStationName =stationName;
        }

        public Task<SelectionResultDTO> ExecuteAsync()
        {
            SelectionResultDTO dto = new SelectionResultDTO()
            {
                Code = -1,
                Message = "上位机配置站别错误"
            };
            return Task.FromResult(dto);
        }

        public override Task<SelectionResultDTO> ExecuteAsync(string model)
        {
            SelectionResultDTO dto = new SelectionResultDTO()
            {
                Code = -1,
                Message = "上位机配置站别错误"
            };
            RaiseSelectionEvent(dto,model);
            return Task.FromResult(dto);
        }
    }
}
