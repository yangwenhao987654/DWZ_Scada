using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada
{
    public class Global
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

        public static bool isYWH { get; set; }

        public static List<PLCAlarmData> PlcAlarmList = new List<PLCAlarmData>();
    }
    public class PLCAlarmData
    {
        public int ID;
        public string Address;

        /// <summary>
        /// 地址类型 有两种
        /// 1.连续地址 2.单个地址
        /// </summary>
        public bool IsArray;
        public string Name;

        public List<SingleAlarmAddress> AlarmList;

        /// <summary>
        /// 报警类型  提示 警告⚠ 错误 
        /// </summary>
        public string AlarmType;

        /// <summary>
        /// 连续类型的地址长度
        /// </summary>
        public int Length;

        public PLCAlarmData(int ID)
        {
            this.ID = ID;
        }
        public PLCAlarmData()
        {

        }
    }

    public class SingleAlarmAddress
    {
        /// <summary>
        /// 连续地址索引 索引从开始
        /// </summary>
        public int Index;

        /// <summary>
        /// 全地址
        /// </summary>
        public string SubAddress;

        /// <summary>
        /// 报警名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType;

        public SingleAlarmAddress(int index)
        {
            Index =index;
        }

        public SingleAlarmAddress()
        {
         
        }
    }

}
