using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP60ExitCommand : ExitCommand
    {

        public OP60ExitCommand(string tempSN) : base("OP60", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP60出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP60 with product {TempSN}");
        }
    }
}
