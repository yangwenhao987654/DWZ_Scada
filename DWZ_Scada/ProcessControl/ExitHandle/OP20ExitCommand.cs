using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP20ExitCommand : ExitCommand
    {

        public OP20ExitCommand(string tempSN) : base("OP20", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP20出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP20 with product {TempSN}");
        }
    }
}
