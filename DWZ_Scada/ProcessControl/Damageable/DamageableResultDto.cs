using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.Damageable
{
    public class DamageableResultDto
    {
        /** ID */
        public long id { get; set; }

        /** 设备ID */
        public long deviceId { get; set; }

        /** 设备编号 */
        public string deviceCode { get; set; }

        /** 代码 */
        public string code { get; set; }

        /** 名称 */
        public string name { get; set; }


        /** 型号 */
        public string mode { get; set; }


        /** 最大使用时间 */
        public string maxRunTime { get; set; }

        /** 运行累计时间 */
        public string runTime { get; set; }

        /** 使用预警时间 */

        public string earlyWarningTime { get; set; }

        /** 最大使用次数 */

        public long maxRunNumber { get; set; }

        /** 运行累计次数 */
        public long runNumber { get; set; }

        /** 使用预警次数 */
        public long earlyWarningNumber { get; set; }

        /// <summary>
        /// 是否正在使用
        /// </summary>
        public int use { get; set; }


        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
    }
}
