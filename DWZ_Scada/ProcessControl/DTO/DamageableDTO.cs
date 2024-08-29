using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class DamageableDTO
    {
        /// <summary>
        /// 设备Code
        /// </summary>
        public string deviceCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public int runTime { get; set; }
        /// <summary>
        /// 运行次数
        /// </summary>
        public int runNumber { get; set; }
        /// <summary>
        /// 类型 时间/次数
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int use { get; set; }
    }
}
