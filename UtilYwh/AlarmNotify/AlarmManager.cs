using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilYwh.AlarmNotify
{
    public class AlarmManager
    {
        public enum AlarmEnum
        {
            Err,
            Alarm,
            Info,
        }
        // 定义委托  
        public delegate void AlarmHandler(string msg, AlarmEnum alarmType);

        // 定义事件  
        public static event AlarmHandler AlarmEvent;

        // 触发事件的方法  
        public static void AppendLog(string msg, AlarmEnum alarmType)
        {
            AlarmEvent?.Invoke(msg, alarmType);
        }
    }
}
