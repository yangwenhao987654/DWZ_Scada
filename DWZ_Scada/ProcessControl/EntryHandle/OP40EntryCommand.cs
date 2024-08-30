using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP40EntryCommand : EntryCommand
    {

        public OP40EntryCommand( string tempSN) : base("OP40", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP30进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP40 with product {TempSN}");
        }
    }
}
