﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Pages.PLCAlarm
{
    public enum PlcState
    {
        Online=0,
        OffLine=-1,
        Alarm=2,
        Running=1,
        Stop=3,
    }
}
