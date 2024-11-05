using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class OP40Data
    {


    }


    public class OP40WeldingData
    {
        public bool Good { get; set; }

        /// <summary>
        /// 焊接结果
        /// </summary>
        public bool WeldingResult { get; set; }

        public string GasA1 { get; set; }

        public string GasA2 { get; set; }

        public string GasA3 { get; set; }

        public string GasA4 { get; set; }

        public string GasA5 { get; set; }

        public string GasA6 { get; set; }


        public string GasB1 { get; set; }
                          
        public string GasB2 { get; set; }
                          
        public string GasB3 { get; set; }
                          
        public string GasB4 { get; set; }
                          
        public string GasB5 { get; set; }
                          
        public string GasB6 { get; set; }

        public string GasC1 { get; set; }
                          
        public string GasC2 { get; set; }
                          
        public string GasC3 { get; set; }
                          
        public string GasC4 { get; set; }
                          
        public string GasC5 { get; set; }
                          
        public string GasC6 { get; set; }
    }
}
