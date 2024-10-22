using log4net;
using log4net.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogTool
{
    public enum LogLvl
    {
        debug,
        info,
        error,
    }
    public struct LogStruct
    {
        public ILog Log;
        public string dt;
        public string line;
        public LogLvl lvl;
        public LogStruct(string Line, LogLvl lvl,ILog log)
        {
            dt = DateTime.Now.ToString("yy/MM/dd HH:mm:ss:fff");
            this.line = Line;
            this.lvl = lvl;
            this.Log = log;
        }
    }
    public class LogMgr
    {
        public static LogMgr Instance 
        {
            get
            {
                if(_instance == null)
                {
                   _instance = new LogMgr();
                }
                return _instance;
            }
        }
        private static LogMgr _instance ;
        ILog DebugLog;//总Log
        ILog ParamsLog;//系统参数变更log
        ListViewEx_Log ctrl;
        public bool IsLoad =false;
        ConcurrentQueue<LogStruct> logQueue;
        List<LogStruct> UnShowLogList;
        private LogMgr()
        {
            Init();
        }
        public bool Init()
        {
            if(IsLoad)
            {
                return true;
            }
            FileInfo fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Config//Log4Net.config");
            if(!fi.Exists)
            {
                MessageBox.Show($@"日志路径{fi.FullName}不存在");
            }
            XmlConfigurator.Configure(fi);
            DebugLog = LogManager.GetLogger("Debug");
            ParamsLog = LogManager.GetLogger("Params");
            logQueue = new ConcurrentQueue<LogStruct>();
            UnShowLogList = new List<LogStruct>();
            ThreadPool.QueueUserWorkItem(Monitor,null);
            IsLoad = true;
            return DebugLog != null;
        }
        private void Monitor(object o)
        {
            while (true)
            {
                if (ctrl!=null && UnShowLogList.Count>0)
                {
                    foreach (var item in UnShowLogList)
                    {
                        ctrl?.AppendLog(item);
                    }
                    UnShowLogList.Clear();
                }
                if (ctrl != null && UnShowLogList.Count > 1000)
                {
                    UnShowLogList.RemoveAt(0);
                }

                if (logQueue.Count==0)
                {
                    Thread.Sleep(100);
                    continue;
                }
                logQueue.TryDequeue(out var  logStruct);
                if (logStruct.dt==null|| logStruct.line==null)
                {
                    continue;
                }
                switch (logStruct.Log)
                {
                    default:
                        break;
                }
                switch (logStruct.lvl)
                {
                    case LogLvl.debug:
                        logStruct.Log.Debug($"{logStruct.dt} {logStruct.line}");
                        break;
                    case LogLvl.info:
                        logStruct.Log.Info($"{logStruct.dt} {logStruct.line}");
                        break;
                    case LogLvl.error:
                        logStruct.Log.Error($"{logStruct.dt} {logStruct.line}");
                        break;
                    default:
                        break;
                }
                if (ctrl!=null)
                {
                    ctrl?.AppendLog(logStruct);
                }
                else
                {
                    UnShowLogList.Add(logStruct);
                }
            }
        }
        public void SetCtrl(ListViewEx_Log ctrl)
        {
            this.ctrl = ctrl;
        }

        public void Debug(string line)
        {
            ShowLog(line, LogLvl.debug);
        }
        public void Info(string line)
        {
            ShowLog(line, LogLvl.info);

        }
        public void Error(string line)
        {
            ShowLog(line, LogLvl.error);
        }
        private void ShowLog( string line,LogLvl lvl)
        {
            logQueue.Enqueue(new LogStruct(line, lvl,DebugLog));
        }
        public void LogParams(string name,string oldValue,string newValue)
        {
            var line = $"{name.PadRightEx(30)}{oldValue.PadRightEx(30)}-->  {newValue}";
            logQueue.Enqueue(new LogStruct(line, LogLvl.debug, ParamsLog));
        }
    }
    public static class class1
    {
        public static string PadRightEx(this string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }
    }
}
