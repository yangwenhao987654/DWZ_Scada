using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.ProcessControl.ExitHandle
{
    public abstract class ExitCommand:IStationCommand
    {
        public string StationName { get; }
        public string TempSN { get; }

        public string workOrder { get; }

        protected ExitCommand(string stationName, string tempSN)
        {
            StationName = stationName;
            TempSN = tempSN;
        }
        public void Execute()
        {
            PreExecute();
            ExecuteEntry();
            PostExecute();
        }

        protected virtual void PreExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Preparing to Exit station {StationName} for product {TempSN}");
        }

        protected abstract void ExecuteEntry();

        protected virtual void PostExecute()
        {
            // 统一的执行前处理逻辑
            LogMgr.Instance.Debug($"Product {TempSN} has Exited station {StationName}");
        }
    }
}
