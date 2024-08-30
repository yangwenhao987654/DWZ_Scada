using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP30ExitCommand : ExitCommand
    {

        public OP30ExitCommand(string tempSN) : base("OP30", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP30出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP30 with product {TempSN}");
        }
    }
}
