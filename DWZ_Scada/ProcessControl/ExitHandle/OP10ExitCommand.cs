using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWZ_Scada.ProcessControl.ExitHandle;
using LogTool;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP10ExitCommand : ExitCommand
    {
        public OP10ExitCommand(string tempSN) : base("OP10", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            //处理数据上报 出站 
            //封装数据 上报 
            // OP10出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP10 with product {TempSN}");
        }

    }
}
