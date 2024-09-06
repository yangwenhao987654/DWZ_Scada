using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada
{
    public class Global
    {
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

        public static bool isYWH { get; set; }
    }

}
