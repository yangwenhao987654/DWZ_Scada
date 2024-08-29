using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.RequestSelectModel
{
    public interface ISelectionStrategyEvent
    {
        // 定义一个静态事件
        public  event EventHandler<SelectionEventArgs> OnSelectionEvent;

    }

    // 定义一个新的事件参数类，包含SelectionResultDTO和string类型的属性
    public class SelectionEventArgs : EventArgs
    {
        public SelectionResultDTO SelectionResult { get; }
        public string Model { get; }

        public SelectionEventArgs(SelectionResultDTO selectionResult, string model)
        {
            SelectionResult = selectionResult;
            Model = model;
        }
    }
}
