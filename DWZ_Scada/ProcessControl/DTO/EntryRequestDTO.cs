using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    /// <summary>
    /// 进站请求数据
    /// </summary>
    public class EntryRequestDTO
    {

        public string StationbCode { get; set; }
        public string SnTemp { get; set; }
        public EntryRequestDTO() { }
    }
}
