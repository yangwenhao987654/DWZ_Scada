using DWZ_Scada.Pages.PLCAlarm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada
{
    public static class Global
    {
        // 定义一个静态的 ServiceProvider 变量
        public static ServiceProvider ServiceProvider { get;  set; }

        public static bool IsPlc_Connected { get; set; }

        public static bool IsCheckSignal { get; set; }

        public static bool IsCurrentFinish { get; set; }
        public static bool IsDBConnected { get; set; }
        public static bool IsLogin { get; set; }
        public static string LoginUser { get; set; }
        public static string CurrentUserCode { get; set; }

        /// <summary>
        /// 设备是否在报警
        /// </summary>
        public static bool IsDeviceAlarm;

        public static Dictionary<string, string> AlarmMap = new Dictionary<string, string>()
        {

        };

        public static string WorkOrder { get; set; }
        public static bool isYWH { get; set; }

        public const string LogoFolder = "Logo";          // Logo 目录

        public static bool IsWorkNoCheckPass { get; set; }

        public static List<PLCAlarmData> PlcAlarmList = new List<PLCAlarmData>();
        public static bool IsClose { get; set; }
    }
   
  

}
