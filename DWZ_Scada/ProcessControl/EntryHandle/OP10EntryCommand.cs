using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogTool;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP10EntryCommand : EntryCommand
    {

        public OP10EntryCommand(string tempSN) : 
            base("OP10", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP10进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP10 with product {TempSN}");
        }

    }
}
