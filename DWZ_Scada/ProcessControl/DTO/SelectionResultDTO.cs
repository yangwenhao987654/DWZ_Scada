using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class SelectionResultDTO
    {
        /// <summary>
        /// 返回选型结果 1 OK  -1 选型失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回选型结果信息 成功:"OK" 失败:"错误信息"
        /// </summary>
        public string Message { get; set; }
    }
}
