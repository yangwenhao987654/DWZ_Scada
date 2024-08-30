using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP30EntryCommand : EntryCommand
    {
        public OP30EntryCommand(string tempSN) : base("OP30", tempSN)
        {
        }

        protected override void ExecuteEntry()
        {
            // OP30进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP30 with product {TempSN}");
        }
    }
}
