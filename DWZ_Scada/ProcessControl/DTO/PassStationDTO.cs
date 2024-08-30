using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    /// <summary>
    /// 过站数据
    /// </summary>
    public class PassStationDTO
    {
        public string StationCode { get; set; }
        public string SnTemp { get; set; }

        public object PassStationData { get; set; }
    }
}
