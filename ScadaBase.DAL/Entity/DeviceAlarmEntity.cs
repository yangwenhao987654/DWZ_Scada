using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBase.DAL.Entity
{
    /// <summary>
    /// 设备报警信息表
    /// </summary>
    public class DeviceAlarmEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType { get; set; }

        /// <summary>
        /// 设备名称 
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 报警信息 
        /// </summary>
        public string AlarmInfo { get; set; }

        /// <summary>
        /// 报警日期 YYYY-MM-dd
        /// </summary>
        public string AlarmDateStr { get; set; }

        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime { get; set; }
    }
}
