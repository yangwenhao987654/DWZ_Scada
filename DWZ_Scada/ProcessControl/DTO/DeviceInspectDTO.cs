﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.DTO
{
    public class DeviceInspectDTO
    {
        public string DeviceCode { get; set; }

        public string DeviceName { get; set; }

        public object Data { get; set; }
    }
}