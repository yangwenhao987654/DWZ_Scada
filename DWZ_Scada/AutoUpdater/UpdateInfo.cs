using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.AutoUpdater
{
    public class UpdateInfo
    {
        public string Version { get; set; }

        public string FilePath { get; set; }

        public string ReleaseNotes { get;set; }

        public string UpdateTime { get; set; }

    }
}
