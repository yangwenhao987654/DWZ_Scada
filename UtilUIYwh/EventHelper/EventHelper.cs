using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilUIYwh.EventHelper
{
    public class EventHelper
    {
        public static void ExecuteWithEventUnSubScribed<TControl>(TControl ctrl, Action action, string eventName)where TControl :class
        {
            if (ctrl==null )
            {
                throw new ArgumentNullException(nameof(ctrl));
            }

            if (action==null)
            {
                throw new ArgumentException(nameof(action));
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentException(nameof(eventName));
            }

            var eventInfo = ctrl.GetType().GetEvent(eventName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (eventInfo == null)
            {
                throw new ArgumentException($"Event '{eventName}' not found on Type '{typeof(TControl).Name}'");
            }

            var eventField = ctrl.GetType().GetField(eventName,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            if (eventField == null)
            {
                throw new ArgumentException($"无法访问事件字段:{eventName}");
            }

            var currentHandler =(Delegate) eventField.GetValue(ctrl);
            try
            {
                if (currentHandler != null)
                {
                    foreach (var d in currentHandler.GetInvocationList())
                    {
                        eventInfo.RemoveEventHandler(ctrl, d);
                    }
                }
                action();
            }
            finally
            {
                if (currentHandler!=null)
                {
                    foreach (var d in currentHandler.GetInvocationList())
                    {
                        eventInfo.AddEventHandler(ctrl,d);
                    }
                }
            }
        }
    }
}
