using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.ModBus;

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

    /// <summary>
    /// Modbus_TCP通信
    /// </summary>
    public class ModbusTCP
    {
        private ModbusTcpNet busTcpClient = null;

        public bool IsConnect = false;


        public (bool,string) Open(string IP, string port_str, string ID_str)
        {
            // 连接
            System.Net.IPAddress address;
            if (!System.Net.IPAddress.TryParse(IP, out address))
            {
                return (false,"Ip地址输入不正确！");
            }

            int port;
            if (!int.TryParse(port_str, out port))
            {
                return (false, "端口输入不正确！");
            }

            byte station;
            if (!byte.TryParse(ID_str, out station))
            {
                return (false, "站号输入不正确！");
            }
            busTcpClient?.ConnectClose();
            busTcpClient = new ModbusTcpNet(IP, port, station);
            busTcpClient.AddressStartWithZero = true;
            busTcpClient.DataFormat = HslCommunication.Core.DataFormat.ABCD;
            busTcpClient.IsStringReverse = false;
            try
            {
                OperateResult connect = busTcpClient.ConnectServer();
                if (connect.IsSuccess)
                {
                    return (true,"");
                }
                else
                {
                    return (false, "连接失败！"+connect.Message);
                }
            }
            catch (Exception ex)
            {
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
                        str_out = Convert.ToString(busTcpClient.ReadCoil(address).Content);
                        break;
                    case "short":
                        str_out = Convert.ToString(busTcpClient.ReadInt16(address).Content);
                        break;
                    case "int":
                        str_out = Convert.ToString(busTcpClient.ReadInt32(address).Content);
                        break;
                    case "long":
                        str_out = Convert.ToString(busTcpClient.ReadInt64(address).Content);
                        break;
                    case "ushort":
                        str_out = Convert.ToString(busTcpClient.ReadUInt16(address).Content);
                        break;
                    case "uint":
                        str_out = Convert.ToString(busTcpClient.ReadUInt32(address).Content);
                        break;
                    case "ulong":
                        str_out = Convert.ToString(busTcpClient.ReadUInt64(address).Content);
                        break;
                    case "double":
                        str_out = Convert.ToString(busTcpClient.ReadDouble(address).Content);
                        break;
                    case "string":
                        str_out = Convert.ToString(busTcpClient.ReadString(address, 20).Content);
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
                        busTcpClient.WriteCoil(address, bool.Parse(Data));
                        //  str_out = Convert.ToString(busTcpClient.Write(address).Content);
                        break;
                    case "short":
                        busTcpClient.Write(address, short.Parse(Data));
                        break;
                    case "int":
                        busTcpClient.Write(address, int.Parse(Data));
                        break;
                    case "long":
                        busTcpClient.Write(address, long.Parse(Data));
                        break;
                    case "ushort":
                        busTcpClient.Write(address, ushort.Parse(Data));
                        break;
                    case "uint":
                        busTcpClient.Write(address, uint.Parse(Data));
                        break;
                    case "ulong":
                        busTcpClient.Write(address, ulong.Parse(Data));
                        break;
                    case "double":
                        busTcpClient.Write(address, double.Parse(Data));
                        break;
                    case "string":
                        busTcpClient.Write(address, (Data));
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
                        busTcpClient.WriteCoil(address, bool.Parse(Data));
                        break;
                    case DataType.Int16:
                        busTcpClient.Write(address, short.Parse(Data));
                        break;
                    case DataType.Int32:
                        busTcpClient.Write(address, int.Parse(Data));
                        break;
                    case DataType.Int64:
                        busTcpClient.Write(address, long.Parse(Data));
                        break;
                    case DataType.Uint16:
                        busTcpClient.Write(address, ushort.Parse(Data));
                        break;
                    case DataType.Uint32:
                        busTcpClient.Write(address, uint.Parse(Data));
                        break;
                    case DataType.Uint64:
                        busTcpClient.Write(address, ulong.Parse(Data));
                        break;
                    case DataType.Float:
                        busTcpClient.Write(address, float.Parse(Data));
                        break;
                    case DataType.Double:
                        busTcpClient.Write(address, double.Parse(Data));
                        break;
                    case DataType.String:
                        busTcpClient.Write(address, (Data));
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
                return busTcpClient.ReadInt32(address).Content;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
