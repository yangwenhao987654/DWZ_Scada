﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class OP10Data
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

    public class Vision1Data
    {
        public bool Vision1Result { get; set; }
        public bool Good { get; set; }
    }

    public class Vision2Data
    {
        public bool Vision2Result { get; set; }
        public bool Good { get; set; }
    }
}
