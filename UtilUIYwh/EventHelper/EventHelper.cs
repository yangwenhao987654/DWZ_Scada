using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace UtilUIYwh.EventHelper
{
    public static class EventHelper
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


        public static void ExecuteWithEventUnSubScribed( this Control ctrl,string eventName, EventHandler eventHandler,Action action)
        {
            if (ctrl == null)
            {
                throw new ArgumentNullException(nameof(ctrl));
            }
            if (string.IsNullOrEmpty(eventName)) throw new ArgumentNullException(nameof(eventName));

            if (eventHandler == null)
            {
                throw new ArgumentException(nameof(eventHandler));
            }

            if (action == null)
            {
                throw new ArgumentException(nameof(action));
            }

            EventInfo eventInfo = ctrl.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (eventInfo==null)
            {
                throw new ArgumentException($"Event '{eventName}' not found on type '{ctrl.GetType().Name}'.");
            }
            try
            {
                eventInfo.RemoveEventHandler(ctrl, eventHandler);
                action();
            }
            finally
            {
                // 重新订阅事件
                eventInfo?.AddEventHandler(ctrl, eventHandler);
            }
        }
    }
}
