using CommunicationUtilYwh.Communication.PLC;
using HslCommunication;
using HslCommunication.ModBus;
using LogTool;
using System;
using TouchSocket.Sockets;

namespace CommonUtilYwh.Communication.ModbusTCP
{
    public enum DataType
    {
        Bool,
        Int16,
        Uint16,
        Int32,
        Uint32,
        Int64,
        Uint64,
        String,
        Float,
        Double

    }

    //主构造函数
    public class ModbusConnConfig(string ip, int port, byte stationNum)
    {
        public string IP { get; set; } = ip;
        public int Port { get; set; } = port;
        public Byte StationNum { get; set; } = stationNum;
    }

    /// <summary>
    /// Modbus_TCP通信
    /// </summary>
    public class ModbusTCP:MyPlc
    {
        private ModbusTcpNet client = null;

        public bool IsConnect = false;


        public (bool,string) Open(string IP, int port, byte station)
        {
            // 连接
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(IP, out address))
            {
                return (false,"Ip地址输入不正确！");
            }
            client?.ConnectClose();
            client = new ModbusTcpNet(IP, port, station);
            client.AddressStartWithZero = true;
            client.DataFormat = HslCommunication.Core.DataFormat.ABCD;
            client.IsStringReverse = false;
            try
            {
                OperateResult connect = client.ConnectServer();
                if (connect.IsSuccess)
                {
                    IsConnect = true;
                    return (true,"");
                }
                else
                {
                    IsConnect = false;
                    return (false, "连接失败！"+connect.Message);
                }
            }
            catch (Exception ex)
            {
                IsConnect =false;
                return (false,ex.Message);
            }
        }

        public string read_(string address, string type)
        {
            try
            {
                string str_out = "";
                switch (type)
                {
                    case "bool":
                        str_out = Convert.ToString(client.ReadCoil(address).Content);
                        break;
                    case "short":
                        str_out = Convert.ToString(client.ReadInt16(address).Content);
                        break;
                    case "int":
                        str_out = Convert.ToString(client.ReadInt32(address).Content);
                        break;
                    case "long":
                        str_out = Convert.ToString(client.ReadInt64(address).Content);
                        break;
                    case "ushort":
                        str_out = Convert.ToString(client.ReadUInt16(address).Content);
                        break;
                    case "uint":
                        str_out = Convert.ToString(client.ReadUInt32(address).Content);
                        break;
                    case "ulong":
                        str_out = Convert.ToString(client.ReadUInt64(address).Content);
                        break;
                    case "double":
                        str_out = Convert.ToString(client.ReadDouble(address).Content);
                        break;
                    case "string":
                        str_out = Convert.ToString(client.ReadString(address, 20).Content);
                        break;
                }
                return str_out;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("读取错误：" + ex.Message);
                return "NG";
            }
        }

        public string write_(string address, string type, string Data)
        {
            try
            {
                string str_out = "";

                switch (type)
                {
                    case "bool":
                        client.WriteCoil(address, bool.Parse(Data));
                        //  str_out = Convert.ToString(client.Write(address).Content);
                        break;
                    case "short":
                        client.Write(address, short.Parse(Data));
                        break;
                    case "int":
                        client.Write(address, int.Parse(Data));
                        break;
                    case "long":
                        client.Write(address, long.Parse(Data));
                        break;
                    case "ushort":
                        client.Write(address, ushort.Parse(Data));
                        break;
                    case "uint":
                        client.Write(address, uint.Parse(Data));
                        break;
                    case "ulong":
                        client.Write(address, ulong.Parse(Data));
                        break;
                    case "double":
                        client.Write(address, double.Parse(Data));
                        break;
                    case "string":
                        client.Write(address, (Data));
                        break;
                }
                return str_out;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("写入错误：" + ex.Message);
                return "NG";
            }
        }

        public bool write_(string address, DataType type, string Data)
        {
            try
            {
                switch (type)
                {
                    case DataType.Bool:
                        client.WriteCoil(address, bool.Parse(Data));
                        break;
                    case DataType.Int16:
                        client.Write(address, short.Parse(Data));
                        break;
                    case DataType.Int32:
                        client.Write(address, int.Parse(Data));
                        break;
                    case DataType.Int64:
                        client.Write(address, long.Parse(Data));
                        break;
                    case DataType.Uint16:
                        client.Write(address, ushort.Parse(Data));
                        break;
                    case DataType.Uint32:
                        client.Write(address, uint.Parse(Data));
                        break;
                    case DataType.Uint64:
                        client.Write(address, ulong.Parse(Data));
                        break;
                    case DataType.Float:
                        client.Write(address, float.Parse(Data));
                        break;
                    case DataType.Double:
                        client.Write(address, double.Parse(Data));
                        break;
                    case DataType.String:
                        client.Write(address, (Data));
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error("写入错误：" + ex.Message);
                return false;
            }
        }

        public int read_int(string address)
        {
            try
            {
                return client.ReadInt32(address).Content;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public override bool Connect(string ip, int port)
        {
            // 连接
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(IP, out address))
            {
                return false;
            }

            client?.ConnectClose();
            //站号 Station 默认为1

            client = new ModbusTcpNet(IP, port);
            client.AddressStartWithZero = true;
            client.DataFormat = HslCommunication.Core.DataFormat.ABCD;
            client.IsStringReverse = false;
            try
            {
                OperateResult connect = client.ConnectServer();
                if (connect.IsSuccess)
                {
                    IsConnect = true;
                    return (true);
                }
                else
                {
                    IsConnect = false;
                    return (false);
                }
            }
            catch (Exception ex)
            {
                IsConnect = false;
                return (false);
            }
        }

        public override bool ReadBool(string address, out bool value)
        {
            OperateResult<bool> result = client.ReadBool(address);
            value = result.Content;
            return result.IsSuccess;
        }

        public override bool ReadInt16(string address, out short value)
        {
            OperateResult<short> result = client.ReadInt16(address);
            value = result.Content;
            return result.IsSuccess;
        }

        public  bool ReadUInt16(string address, out ushort value)
        {
            OperateResult<UInt16> result = client.ReadUInt16(address);
            value = result.Content;
            return result.IsSuccess;
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public override void Dispose()
        {
            client?.Dispose();
        }
    }
}
