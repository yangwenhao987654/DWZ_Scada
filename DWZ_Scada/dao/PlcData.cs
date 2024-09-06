using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.dao
{
    /// <summary>
    /// PLC参数设置
    /// </summary>
    public class PlcData
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index = 0;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name = "XXX";
        /// <summary>
        /// 地址
        /// </summary>
        public string Address = "0";
        /// <summary>
        /// 数据类型
        /// </summary>
        public string Type = "int";

        public string Desp = "无";

    }
}
