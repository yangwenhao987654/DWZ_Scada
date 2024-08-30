using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestModel;

namespace DWZ_Scada.ProcessControl.RequestSelectModel
{
    public class OP60SelectionStrategy :SelectionStrategyBase
    {
        public Task<SelectionResultDTO> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<SelectionResultDTO> ExecuteAsync(string model)
        {
            SelectionResultDTO dto = new SelectionResultDTO()
            {
                Code = 1,
                Message = $"获取型号[{model}]"
            };
            RaiseSelectionEvent(dto, model);
            //TODO 处理下发型号的逻辑 
            dto.Message += "事件结束";
            return Task.FromResult(dto);
        }
    }
}
