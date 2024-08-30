using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LogTool;

namespace CommunicationUtilYwh.Communication
{
    public class SerialCommunication
    {
        // 定义一个事件，用于通知串口数据接收
        public event EventHandler<string> DataReceived;
        private SerialPort serialPort;

        private bool isSubscribeDataReceived;

        /// <summary>
        /// 是否需要回车发送
        /// </summary>
        private bool needCR = true;
        private string portName;
        public string PortName
        {
            get { return portName; }
        }
        public SerialCommunication() { }

        public SerialCommunication(SerialPort serialPort, bool isSubscribeDataReceived)
        {
            this.serialPort = serialPort;
            this.portName = serialPort.PortName;
            this.isSubscribeDataReceived = isSubscribeDataReceived;
            if(isSubscribeDataReceived)
            {
                serialPort.DataReceived += SerialPort_DataReceived;
            }
        }

        public SerialCommunication( string portName, int baudRate , Parity parity ,int dataBits ,StopBits stopBits)
        {
            serialPort = new SerialPort(portName,baudRate,parity,dataBits,stopBits);
            this.portName = portName;
           // serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if(e.EventType == SerialData.Chars)
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                string receivedData = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"接收到数据：{receivedData}");
                // 触发事件，通知数据接收
                OnDataReceived(receivedData);
            }
        }
        // 事件触发方法
        protected virtual void OnDataReceived(string data)
        {
            DataReceived?.Invoke(this, data);
        }

        public bool Open()
        {
            try
            {
                if(!serialPort.IsOpen)
                {
                    serialPort.Open();
                    return true;
                }
                return serialPort.IsOpen;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 发送是否需要添加回车换行
        /// </summary>
        public bool NeedCR
        {
            get
            {
                return needCR;
            }
            set
            {
                if(value != needCR)
                {
                    needCR = value;
                }
            }
        }

        /// <summary>
        /// 串口是否打开
        /// </summary>
        public bool IsOpen 
        { 
            get 
            {
                if(serialPort != null)
                {
                    return serialPort.IsOpen;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Close()
        {
            try
            {
                if(serialPort.IsOpen)
                {
                    serialPort.Close();
                    return true;
                }
                else
                {
                    return serialPort.IsOpen == false;
                }
            }
            catch(Exception ex)
            {
                LogMgr.Instance.Error($"串口关闭失败：{ex.Message}");
                return false;
            }
        }

        public void Initialize()
        {
            if(serialPort.IsOpen)
            {
                serialPort.Close();
            }

            // 在初始化之前可以设置其他串口属性
            // serialPort.ReadTimeout = 1000;

            Open();
        }

        /// <summary>
        /// 发送数据的方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(string data)
        {
            if(serialPort.IsOpen)
            {
                //是否需要添加回车换行
                if (this.NeedCR)
                {
                    //data += "\r\n";
                    //加
                    data += "\n";

                }
                //写入之前是否需要清空缓存区
                serialPort.Write(data);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 清空输入(读取)缓冲区
        /// </summary>
        /// <returns></returns>
        public bool CleanInBuffer()
        {
            if(serialPort!=null && serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 清空输出(写入)缓冲区
        /// </summary>
        /// <returns></returns>
        public bool CleanOutBuffer()
        {
            if(serialPort!=null &&  serialPort.IsOpen)
            {
                serialPort.DiscardOutBuffer();
                return true;
            }
            return false;
        }

        private bool isListening;

        // 停止监听串口数据
        public void StopListening()
        {
            isListening = false;
        }
        // 开始监听串口数据
        public void StartListening()
        {
            if(!isListening)
            {
                isListening = true;
                // 启动一个线程来监听串口
                Thread listeningThread = new Thread(ListenSerialPort);
                listeningThread.Start();
            }
        }

        // 监听串口的方法
        private void ListenSerialPort()
        {
            while(isListening)
            {
                try
                {
                    if(serialPort.BytesToRead > 0)
                    {
                        string receivedData = serialPort.ReadLine();
                        // 处理接收到的数据，可以在这里进行相应的操作
                    }
                }
                catch(Exception ex)
                {
                    LogMgr.Instance.Error($"数据读取失败：{ex.Message}");
                }
                // 添加适当的延迟，避免过于频繁地检查串口
                Thread.Sleep(100);
            }
        }
        // 关闭串口的方法
        public void CloseSerialPort()
        {
            StopListening(); // 停止监听
            if(serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public ReadResult Read()
        {
            ReadResult result = new ReadResult();
            result.Code = ResultCode.Fail;
            result.Msg = "没有数据";
            //按照ASCII格式解码
            string type = "ASCII";
            try
            {
                byte[] receivedData = new byte[serialPort.BytesToRead];//创建接收数据数组
                serialPort.Read(receivedData, 0, receivedData.Length);//读取数据
                var content = string.Empty;
                //显示形式
                switch(type)
                {
                    case "HEX":
                        for(int i = 0; i < receivedData.Length; i++)
                        {
                            //ToString("X2") 为C#中的字符串格式控制符
                            //X为     十六进制
                            //2为 每次都是两位数
                            content += (receivedData[i].ToString("X2") + " ");
                        }
                        break;
                    case "ASCII":
                        content = Encoding.GetEncoding("GB2312").GetString(receivedData);//防止乱码
                        break;
                }
                //接收文本框
                SetSuccessResult( out result, content);
                //丢弃缓存区数据
                serialPort.DiscardInBuffer();
            }
            catch(Exception ex)
            {
                SetErrResult(out result, $"读取失败：{ex.Message}", null);
                return result;
            }
            return result;
        }
     /*   #region 读一行 循环读取三次
        public ReadResult ReadLine()
        {
            ReadResult result = new ReadResult();
            result.Code = ResultCode.Fail;
            result.Msg = "没有数据";
            try
            {
                for(int i = 0; i < 3; i++)
                {

                    if(serialPort.BytesToRead > 0)
                    {
                        string receivedData = serialPort.ReadLine();
                        if(receivedData != null)
                        {
                            MessageBox.Show(receivedData);
                            SetSuccessResult(result, receivedData);
                            serialPort.DiscardInBuffer();
                            return result;
                        }
                        // 处理接收到的数据，可以在这里进行相应的操作
                    }
                }
                Thread.Sleep(20);
            }
            catch(Exception ex)
            {
                SetErrResult(result, $"读取失败：{ex.Message}", null);
                return result;
            }
            return result;
        }   
        #endregion*/
        public SerialPort SerialPort { get {  return serialPort; } }
        public SerialPort GetSerialPort() {  return serialPort; }

        private ReadResult SetErrResult(out ReadResult result,string msg , string value)
        {
            result.Msg = msg;
            result.Value = value;
            result.Code = ResultCode.Fail;
            return result;
        }

        private ReadResult SetSuccessResult(out ReadResult result, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                result.Msg = "无数据";
            }
            else {
                result.Msg = "读取成功";
            }
            //result.Msg = "123";
            result.Value = value;
            result.Code = ResultCode.Success;
            return result;
        }
        public struct ReadResult
        {
            public String Value;
            public ResultCode Code;
            public string Msg;
        }

        public enum ResultCode
        {
            Success =1,
            Fail = 0,
        }
    }
}
