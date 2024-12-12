using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class CoildAddress
    {
        #region 绕线机数据通讯 ModbusTCP通讯
        /// <summary>
        /// 绕线机状态  0故障 1待机 12 运行中
        /// </summary>
        public static readonly string CoilsState = "2000";

        /// <summary>
        /// 当前绕线圈数
        /// </summary>
        public static readonly string CoilsCurNum = "2021";

        /// <summary>
        /// 绕线目标圈数
        /// </summary>
        public static readonly string CoilsTargetNum = "2023";

        /// <summary>
        /// 绕线速度
        /// </summary>
        public static readonly string CoilsSpeed = "2025";

        /// <summary>
        /// 绕线周期
        /// </summary>
        public static readonly string CoilsTimes = "2031";


        /// <summary>
        /// 绕线状态 1开始 2结束
        /// </summary>
        public static readonly string WorkState = "2040";

        /// <summary>
        /// 张力值01
        /// </summary>
        public static readonly string TensionValue01 = "2041";

        /// <summary>
        /// 张力值02
        /// </summary>
        public static readonly string TensionValue02 = "2042";

        /// <summary>
        /// 读取报警状态 2037急停报警  2038 暂停报警 2039 提示报警
        /// </summary>
        public static readonly string AlarmState = "2037";


        #endregion
    }
}
