using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP50EntryCommand : EntryCommand
    {
        public OP50EntryCommand(string tempSN) : base("OP50", tempSN)
        {
        }

        protected override void ExecuteEntry()
        {
            // OP50进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP50 with product {TempSN}");
        }
    }
}
