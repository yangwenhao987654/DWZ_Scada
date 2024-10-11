using LogTool;

namespace DWZ_Scada.ProcessControl.EntryHandle
{
    public class OP70EntryCommand : EntryCommand
    {
        public OP70EntryCommand( string tempSN) : base("OP70", tempSN)
        {
        }

        protected override void ExecuteEntry()
        {
            // OP60进站的具体实现
            LogMgr.Instance.Debug($"Executing specific entry logic for OP70 with product {TempSN}");
        }
    }
}
