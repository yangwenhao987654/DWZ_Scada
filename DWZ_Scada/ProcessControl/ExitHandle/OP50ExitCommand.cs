using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP50ExitCommand : ExitCommand
    {

        public OP50ExitCommand(string tempSN) : base("OP50", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP50出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP50 with product {TempSN}");
        }
    }
}
