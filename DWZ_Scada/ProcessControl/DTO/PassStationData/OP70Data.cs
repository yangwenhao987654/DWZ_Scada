using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class OP70Data
    {
   /*     /// <summary>
        /// 物料信息
        /// </summary>
        public string Material { get; set; }

        public string VisionData1 { get; set; }

        public string VisionData2 { get; set; }

        public string VisionResult { get; set; }

        public string VisionPicPath { get; set; }*/

        public string a { get;  set; }

        public string b{ get; set; }



    }

    public class FinalCodeData
    {
        /*public bool FinalCodeResult { get; set; }*/
        public bool Good { get; set; }

        public string SN { get; set; }

        public string Level { get; set; }
    }
}
