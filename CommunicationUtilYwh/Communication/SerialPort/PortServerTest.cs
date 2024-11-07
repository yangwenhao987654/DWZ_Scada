using System;
using System.IO.Ports;

namespace CommunicationUtilYwh.Communication
{
    public class PortServerTest : IDisposable
    {
        private SerialCommunication SerialPortTest;
        private SerialPort serialPort;
        public string TestComName ="COM9";
        public PortServerTest() 
        {
            Init();
        }

        private void Init()
        {
            SerialPort serialPort = new SerialPort(TestComName, 9600, Parity.None, 8, StopBits.One);
            this.serialPort = serialPort;
            SerialPortTest = new SerialCommunication(serialPort,true);
            SerialPortTest.DataReceived += SerialPortTest_DataReceived;
        }

        public bool Open()
        {
            return SerialPortTest.Open();
        }

        public bool Close() 
        {
            return SerialPortTest.Close();
        }

        private void SerialPortTest_DataReceived(object sender, string data)
        {
            if (data.EndsWith("\n"))
            {
                data =data.Replace("\n","");
            }
            switch(data)
            {
                case "?":
                    SerialPortTest.SendData("R=+66.599 mO");
                    break;
                case "G":
                    SerialPortTest.SendData("Start");
                    break;
                case "S5":
                    SerialPortTest.SendData("P=66.969%");
                    break;
                default:
                    SerialPortTest.SendData("Error");
                    break;
            }            
        }

        /// <summary>
        /// 1.显式调用(手动调用)
        /// 2.使用using语句，结束后自动调用
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
