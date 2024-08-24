using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP20EntryCommand : EntryCommand
    {

        public OP20EntryCommand(string tempSN) : base("OP20", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP20进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP20 with product {TempSN}");
        }
    }
}
