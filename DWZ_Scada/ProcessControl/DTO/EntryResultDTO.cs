using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    /// <summary>
    /// 进站请求结果
    /// </summary>
    public class EntryResultDTO
    {
        public string msg { get; set; }

        /// <summary>
        /// 状态码200 标识成功
        /// </summary>
        public int code { get; set; }
    }
}
