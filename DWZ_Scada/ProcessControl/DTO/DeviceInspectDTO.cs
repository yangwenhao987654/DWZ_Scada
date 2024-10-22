using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class DeviceInspectDTO
    {
        public string StationCode { get; set; }
        public string SnTemp { get; set; }

        public string WorkOrder { get; set; }

        public object PassStationData { get; set; }

        /// <summary>
        /// 是否是数据上报的最后一项
        /// </summary>
        public bool isLastStep { get; set; }


        public string DeviceCode { get; set; }

        public string DeviceName { get; set; }

        public object Data { get; set; }
    }
}
