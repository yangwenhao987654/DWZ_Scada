using DWZ_Scada.ProcessControl.ExitHandle;
using LogTool;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP70ExitCommand : ExitCommand
    {

        public OP70ExitCommand(string tempSN) : base("OP70", tempSN)
        {

        }

        protected override void ExecuteEntry()
        {
            // OP60出站的具体实现
            LogMgr.Instance.Debug($"Executing specific Exit logic for OP70 with product {TempSN}");
        }
    }
}
