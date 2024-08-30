using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP40ExitCommand : ExitCommand
    {

        public OP40ExitCommand(string tempSN) : base("OP40", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP40出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP40 with product {TempSN}");
        }
    }
}
