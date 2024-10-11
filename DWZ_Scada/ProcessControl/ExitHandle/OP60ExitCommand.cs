using DWZ_Scada.ProcessControl.ExitHandle;
using LogTool;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP60ExitCommand : ExitCommand
    {

        public OP60ExitCommand(string tempSN) : base("OP60", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP50出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP60 with product {TempSN}");
        }
    }
}
