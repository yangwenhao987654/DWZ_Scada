using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommunicationUtilYwh.Communication;
using DWZ_Scada.ProcessControl.EntryHandle;
using DWZ_Scada.ProcessControl.ExitHandle;
using LogTool;
using Newtonsoft.Json;
using RestSharp;

namespace DWZ_Scada.ProcessControl
{
    public class StationInvoker
    {
        private EntryCommand _getInCommand;

        private ExitCommand _exitCommand;

        public void SetEntryCommand(EntryCommand entryCommand)
        {
            _getInCommand = entryCommand;
        }

        public void SetExitCommand(ExitCommand exitCommand)
        {
            _exitCommand = exitCommand; 
        }

        public void ProcessEntryRequest()
        {
            LogMgr.Instance.Debug("Default pre-processing logic for entry...");
            //请求Mes的逻辑
            //发送Http请求 
            string url = @"http://localhost:8090/test";
            //TestEntryRequest<ResultDTO>(url);
            _getInCommand.Execute();

            LogMgr.Instance.Debug("Default post-processing logic for entry...");
        }

        public void ProcessExitRequest()
        {
            LogMgr.Instance.Debug("Default pre-processing logic for exit...");
            _exitCommand.Execute();
            LogMgr.Instance.Debug("Default post-processing logic for exit...");
        }

    /*    /// <summary>
        /// 进站请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        private static void TestEntryRequest<T>(string url)
        {
            string baseUrl = url;
            MyHttpClient client = new MyHttpClient(baseUrl);
            Task<RestResponse> task = client.GetAsync("");
            RestResponse response = task.Result;
            string res = response.Content;
            T dto = JsonConvert.DeserializeObject<T>(res);
            Console.WriteLine(dto.GetType());
            string jsonStr = JsonConvert.SerializeObject(dto);
            ResultDTO result = JsonConvert.DeserializeObject<ResultDTO>(res);
            Console.WriteLine(jsonStr);

        }*/
    }
}
