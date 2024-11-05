using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class OP10Data
    {

    }

    public class OP10Vision1Data
    {
        public bool Vision1Result { get; set; }
        public bool Good { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BreachNo { get; set; }
    }

    public class OP10Vision2Data
    {
        public bool Vision2Result { get; set; }
        public bool Good { get; set; }
    }

    public class OP30Vision1Data
    {
        public bool Vision1Result { get; set; }
        public bool Good { get; set; }

    }

    public class OP40Vision1Data
    {
        public bool Vision1Result { get; set; }
        public bool Good { get; set; }

    }

    public class OP70Vision1Data
    {
        public bool Vision1Result { get; set; }
        public bool Good { get; set; }

    }
}
