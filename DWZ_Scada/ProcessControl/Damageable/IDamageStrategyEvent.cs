using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.Damageable
{
    public interface IDamageStrategyEvent
    {
        // 定义一个静态事件
        public event EventHandler<DamageEventArgs> OnDamageablenEvent;
    }

    // 定义一个新的事件参数类，包含SelectionResultDTO和string类型的属性
    public class DamageEventArgs : EventArgs
    {
        public DamageableResultDto DamageableResult { get; }

        public DamageEventArgs(DamageableResultDto damageableResult)
        {
            DamageableResult = damageableResult;
        }
    }
}
