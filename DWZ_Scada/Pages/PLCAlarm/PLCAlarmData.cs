using System.Collections.Generic;

namespace DWZ_Scada.Pages.PLCAlarm
{
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

}
