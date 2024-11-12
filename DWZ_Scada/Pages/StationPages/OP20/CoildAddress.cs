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
        /// 张力值01
        /// </summary>
        public static readonly string TensionValue01 = "2041";

        /// <summary>
        /// 张力值02
        /// </summary>
        public static readonly string TensionValue02 = "2042";
        #endregion
    }
}
