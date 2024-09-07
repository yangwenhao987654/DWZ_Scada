using DWZ_Scada.HttpRequest;
using DWZ_Scada.ProcessControl.DTO;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Services
{
    public class DeviceStateService
    {
        private readonly DeviceStateReporter _reporter;

        public DeviceStateService(DeviceStateReporter reporter)
        {
            _reporter = reporter;
        }

        public async Task ReportState(DeviceStateDTO dto)
        {
            await _reporter.AddDeviceState(dto);
        }
    }
}
