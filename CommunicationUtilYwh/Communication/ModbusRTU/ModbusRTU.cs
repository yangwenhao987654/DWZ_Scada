using CommunicationUtilYwh.Communication.PLC;
using HslCommunication.Profinet.Keyence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.ModBus;
using LogTool;
using HslCommunication;

namespace CommunicationUtilYwh.Communication.ModbusRTU
{
    public class ModbusRTU : MyPlc
    {
        public string PortName { get; set; } = "COM1";

        public ModbusRTU(string portName)
        {
            PortName = portName;
        }

        public ModbusRTU()
        {
        }

        ModbusRtu client = new ModbusRtu();
        public override bool Connect(string ip, int port)
        {
            throw new NotSupportedException("RTU仅支持串口通信");
        }

        public bool Open()
        {
            try
            {
                
                client.SerialPortInni(portName: PortName);
                client.Open();
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"打开ModbusRTU连接错误: 串口名称:[{PortName}] 错误信息:[{ex.Message}]");;
            }

            IsConnect = client.IsOpen();
            return client.IsOpen();
        }

        public bool Open(string portName)
        {
            try
            {
                client.SerialPortInni(portName);
                client.Open();
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"打开ModbusRTU连接错误: 串口名称:[{portName}] 错误信息:[{ex.Message}]"); ;
            }

            IsConnect = client.IsOpen();
            return client.IsOpen();
        }

        public override bool ReadBool(string address, out bool value)
        {
            OperateResult<bool> result = client.ReadBool(address);
            value = result.Content;
            if (!result.IsSuccess)
            {
                LogMgr.Instance.Error($"PLC Read Bool Error,地址:[{address}]  异常信息:{result.Message}");
            }
            return result.IsSuccess;
        }

        public override bool ReadInt16(string address, out short value)
        {
            OperateResult<short> result = client.ReadInt16(address);
            value = result.Content;
            if (!result.IsSuccess)
            {
                LogMgr.Instance.Error($"PLC Read Int16 Error,地址:[{address}]  异常信息:{result.Message}");
            }
            return result.IsSuccess;
        }

        public override bool ReadInt16(string address, ushort length, out short[] value)
        {
            var result = client.ReadInt16(address, length);
            value = result.Content;
            if (!result.IsSuccess)
            {
                LogMgr.Instance.Error($"PLC Read Int16 Arr[] Error,地址:[{address}] 长度:[{length}]  异常信息:{result.Message}");
            }
            return result.IsSuccess;
        }

        public override bool ReadInt32(string address, ushort length, out int[] value)
        {
            var result = client.ReadInt32(address, length);
            value = result.Content;
            if (!result.IsSuccess)
            {
                LogMgr.Instance.Error($"PLC Read Int32 Arr[] Error,地址:[{address}] 长度:[{length}] 异常信息:{result.Message}");
            }
            return result.IsSuccess;
        }

        public override bool WriteInt16(string address, short value)
        {
            OperateResult operate = client.Write(address, Convert.ToInt16(value));
            bool flag = operate.IsSuccess;
            return flag; ;
        }

        public override bool Read(string adr, string type, out string value)
        {
            value = "0";
            bool flag = true;
            type = type.ToLower();
            //获取类型和长度 string-10
            string[] str_Type = type.Split('-');
            try
            {
                switch (str_Type[0])
                {
                    case "int":
                    {
                        OperateResult<Int16> operate = client.ReadInt16(adr);
                        value = operate.Content.ToString();
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "double":
                    {
                        OperateResult<double> operate = client.ReadDouble(adr);
                        value = operate.Content.ToString("f2");
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "float":
                    {
                        OperateResult<float> operate = client.ReadFloat(adr);
                        value = operate.Content.ToString("f2");
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "string":
                    {
                        OperateResult<string> operate = client.ReadString(adr, Convert.ToUInt16(str_Type[1]));
                        value = operate.Content.ToString();
                        value = RemoveAllCharactersAfterBackslashOrNull(value);
                        flag = operate.IsSuccess;
                        break;
                    }
                    default:

                        LogMgr.Instance.Error($"Read Fail :Require read dataType [{type}] is not support");
                        throw new Exception($"Read PLC Error: not support dataType:[{type}]");
                        break;
                }

            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"PLC读取错误,地址:[{adr}] 类型[{type}] 异常信息:{ex.Message}");
                flag = false;
            }
            return flag;
        }

        public override bool Write(string adr, string type, object value)
        {
            bool flag = true;
            type = type.ToLower();
            try
            {
                switch (type)
                {
                    case "int":
                    {
                        OperateResult operate = client.Write(adr, Convert.ToInt16(value));
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "double":
                    {
                        OperateResult operate = client.Write(adr, Convert.ToDouble(value));
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "float":
                    {
                        float valueF = (float)value;
                        OperateResult operate = client.Write(adr, valueF);
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "string":
                    {
                        OperateResult operate = client.Write(adr, value.ToString());
                        flag = operate.IsSuccess;
                        break;
                    }
                    case "bool":
                    {
                        OperateResult operate = client.Write(adr, Convert.ToBoolean(value));
                        flag = operate.IsSuccess;
                        break;
                    }
                    default:
                        LogMgr.Instance.Error($"Read Fail :Require read dataType [{type}] is not support");
                        throw new Exception($"Read PLC Error: not support dataType:[{type}]");
                        break;
                }
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"PLC写入错误,地址:[{adr}] 类型[{type}] 异常信息:{ex.Message}");
                flag = false;
            }
            return flag;
        }

        public override bool WriteFloat(string adr, float value)
        {
            OperateResult operate = new OperateResult();
            bool flag = true;
            try
            {
                operate = client.Write(adr, value);
                flag = operate.IsSuccess;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"Write Float Fail :{ex.Message} {operate.Message}");
            }
            return flag;
        }

        public override bool ReadAlarm(string adr, out bool[] value, int length)
        {
            value = new bool[length];
            bool flag = true;
            try
            {
                OperateResult<bool[]> operate = client.ReadBool(adr, (ushort)length);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"PLC Read错误,地址:[{adr}] 类型[数据-{length}] 异常信息:{ex.Message}");
                flag = false;
            }
            return flag;
        }

        public override void Dispose()
        {
            LogMgr.Instance.Debug("释放ModbusRtu连接");
            client?.Close();
            client?.Dispose();
        }

        public override bool ReadInt32(string address, out int value)
        {
            var result = client.ReadInt32(address);
            value = result.Content;
            return result.IsSuccess;
        }
    }

}
