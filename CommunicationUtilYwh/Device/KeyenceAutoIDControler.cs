
using Keyence.AutoID.SDK;
using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTF
{
    public class KeyenceAutoIDControler
    {
        /// <summary>
        /// 貌似只支持TCP通讯
        /// </summary>
        private ReaderAccessor m_reader = new ReaderAccessor();
        private ReaderSearcher m_searcher = new ReaderSearcher();

        public volatile bool IsConnect = false;

        public volatile bool IsReConnecting = false;

        public string IP;
        /// <summary>
        /// 默认端口是9006
        /// </summary>
        public int Port = 9006;
        List<NicSearchResult> m_nicList;
        private readonly object _lock = new object();

        public KeyenceAutoIDControler()
        {
            Init();
        }

        public void Init()
        {

        }

        /// <summary>
        /// 重连扫码枪
        /// </summary>
        public bool DoReConnect()
        {

            bool flag = m_reader.Connect();
            if (flag)
            {
                LogMgr.Instance.Info("扫码枪连接成功");
                this.IsConnect = true;
            }
            else
            {
                LogMgr.Instance.Info("扫码枪连接失败");
                this.IsConnect = false;
            }
            return flag;
        }

        public bool Connect(string ip)
        {
            m_reader.IpAddress = ip;
            if (IsConnect)
            {
                return true;
            }
            else
            {
                IsConnect = m_reader.Connect();
            }
            return IsConnect;
            //Connect TCP/IP.
            //240100000000000
            //232900000000000
            //240200000000000
        }
        /// <summary>
        /// 触发读取指令
        /// </summary>s
        /// <returns></returns>
        public string Read()
        {
            //默认延迟是1秒
            //如果读取不到或者错误 返回"" 
            //单脉冲模式，只用给开始不用给结束
            string result = m_reader.ExecCommand("LON", 500);
            // m_reader.ExecCommand("LOFF",1000);
            return result;
        }

        public string GetLastErrInfo()
        {
            string res = "";
            ErrorCode errorCode = m_reader.LastErrorInfo;
            if (errorCode != ErrorCode.None)
            {
                res = errorCode.ToString();
            }
            return res;
        }

        /// <summary>
        /// 触发完成指令
        /// </summary>s
        /// <returns></returns>
        public string SendOff()
        {
            //默认延迟是1秒
            //如果读取不到或者错误 返回"" 
            //单脉冲模式，只用给开始不用给结束
            string result = m_reader.ExecCommand("LOFF", 500);
            // m_reader.ExecCommand("LOFF",1000);
            return result;
        }

        /// <summary>
        /// 初始化获取主机的所有网口IP信息
        /// </summary>
        public void InitNicList()
        {
            //查询主机的所有网卡信息
            m_nicList = m_searcher.ListUpNic();
            List<string> IPList = new List<string>();
            if (m_nicList != null)
            {
                for (int i = 0; i < m_nicList.Count; i++)
                {
                    //显示所有结果的IP
                    IPList.Add(m_nicList[i].NicIpAddr);
                    //将IP信息绑定到下拉框
                    //NICcomboBox.Items.Add(m_nicList[i].NicIpAddr);
                }
            }
        }
    }
}
