using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;

namespace DWZ_Scada.ProcessControl.RequestModel
{
    /// <summary>
    /// 选型请求基类
    /// </summary>
    public abstract class SelectionStrategyBase: ISelectionStrategyEvent
    {
        public event EventHandler<SelectionEventArgs> OnSelectionEvent;
        // 触发事件的方法
        protected void RaiseSelectionEvent(SelectionResultDTO dto, string model)
        {
            OnSelectionEvent?.Invoke(this, new SelectionEventArgs(dto, model));
        }

        public abstract Task<SelectionResultDTO> ExecuteAsync(string model);
    }

}
