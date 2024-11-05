using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.StationPages.OP60
{
    public class GlobalOP60
    {
        /// <summary>
        /// 是否打开设备调试界面
        /// </summary>
        public static bool IsOpenDebugTCPDevice { get; set; }

        /// <summary>
        /// 断开现有测试机TCP连接
        /// </summary>
        public static bool EnableDisConnect { get; set; }
    }
}
