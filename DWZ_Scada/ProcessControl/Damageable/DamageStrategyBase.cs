using DWZ_Scada.ProcessControl.DTO;
using DWZ_Scada.ProcessControl.RequestSelectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.Damageable
{
    public abstract class DamageStrategyBase
    {
        public event EventHandler<DamageEventArgs> OnDamageableEvent;
        // 触发事件的方法
        protected void RaiseSelectionEvent(DamageableResultDto dto)
        {
            OnDamageableEvent?.Invoke(this, new DamageEventArgs(dto));
        }

        public abstract Task<DamageableResultDto> ExecuteAsync();
    }
}
