using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationUtilYwh.Communication.ModbusRTU;
using LogTool;

namespace CommunicationUtilYwh.Device
{
    /// <summary>
    /// RS485 温度控制器 ModbusRTU协议
    /// </summary>
    public class TemperatureController485 :IDisposable
    {
        private ModbusRTU client;

        public bool IsConnect
        {
            get
            {
                return client != null && client.IsConnect;
            }
        }
        public TemperatureController485( )
        {
            client = new ModbusRTU();
        }

        public bool Open(string portName)
        {
            return client.Open(portName);
        }

        private bool Open()
        {
            return client.Open();
        }

        private bool SendCmd()
        {

            //client.Read()
            return true;
        }

        /// <summary>
        /// 读取温度
        /// </summary>
        public double ReadTemperature()
        {
            double result = 0;
            string address = "30001";
            bool f = client.ReadInt16(address,out short value);
            if (f)
            {
                if (value>=10000)
                {
                    //假如大于10000  表示温度是负
                    result = (-1 * (value - 10000) * 0.1);
                }
                else
                {
                    result = value * 0.1;
                }
            }
            else
            {
                LogMgr.Instance.Error("读取温度失败");
            }

            return result;
        }

        /// <summary>
        /// 读取湿度
        /// </summary>
        public double ReadHumidity()
        {
            double result = 0;
            string address = "30002";
            bool f = client.ReadInt16(address, out short value);
            if (f)
            {
                result = value * 0.1;
            }
            else
            {
                LogMgr.Instance.Error("读取湿度失败");
            }
            return result;
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
