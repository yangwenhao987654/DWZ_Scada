using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl
{
    public interface IStationCommand
    {
        /// <summary>
        /// 工站名称
        /// </summary>
        public string StationName { get;}

        /// <summary>
        /// 产品临时码
        /// </summary>
        public string TempSN { get; }


        public string workOrder { get; }
        void Execute();
    }
}
