using LogTool;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWZ_Scada.ctrls.LogCtrl
{
    public enum LogLvl
    {
        debug,
        info,
        alarm,
        error,
    }
    public struct LogStruct
    {
        public string dt;
        public string line;
        public LogLvl lvl;
        public LogStruct(string Line, LogLvl lvl)
        {
            dt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff");
            this.line = Line;
            this.lvl = lvl;
        }
    }
    public class Mylog
    {
        public static Mylog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Mylog();
                }
                return _instance;
            }
        }
        private static Mylog _instance;
        MyLogCtrl ctrl;
        public bool IsLoad = false;
        ConcurrentQueue<LogStruct> logQueue;
        List<LogStruct> UnShowLogList;
        private Mylog()
        {
           
        }
        public void Init(MyLogCtrl ctrl)
        {
           /* if (IsLoad)
            {
                return ;
            }*/
            logQueue = new ConcurrentQueue<LogStruct>();
            UnShowLogList = new List<LogStruct>();
            ThreadPool.QueueUserWorkItem(Monitor, null);
            IsLoad = true;
            this.ctrl = ctrl;
        }
        private void Monitor(object o)
        {
            while (true)
            {
                if (ctrl != null && UnShowLogList.Count > 0)
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

                if (logQueue.Count == 0)
                {
                    Thread.Sleep(100);
                    continue;
                }
                logQueue.TryDequeue(out var logStruct);
                if (logStruct.dt == null || logStruct.line == null)
                {
                    continue;
                }         
                if (ctrl != null)
                {
                    ctrl?.AppendLog(logStruct);
                }
                else
                {
                    UnShowLogList.Add(logStruct);

                }
            }
        }

        public void Debug(string line)
        {
            ShowLog(line, LogLvl.debug);
            LogMgr.Instance.Debug(line);
        }
        public void Info(string line)
        {
            ShowLog(line, LogLvl.info);
            LogMgr.Instance.Info(line);
        }

        public void Alarm(string line)
        {
            ShowLog(line, LogLvl.alarm);
            LogMgr.Instance.Info(line);
        }
    
        public void Error(string line)
        {
            ShowLog(line, LogLvl.error);
            LogMgr.Instance.Error(line);
        }
        private void ShowLog(string line, LogLvl lvl)
        {
            logQueue.Enqueue(new LogStruct(line, lvl));
        }
    }
}
