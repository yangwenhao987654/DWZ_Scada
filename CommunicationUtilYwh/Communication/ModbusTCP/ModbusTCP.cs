using CommunicationUtilYwh.Communication.PLC;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.ModBus;
using LogTool;
using System;
using System.Net;
using System.Windows.Forms;

namespace CommonUtilYwh.Communication.ModbusTCP;

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
public class ModbusConnConfig
{
    public ModbusConnConfig(int id ,string ip, int port, byte stationNum)
    {
        ID = id;
        IP = ip;
        Port = port;
        StationNum = stationNum;
    }

    public int ID { get; set; }

    public string IP { get; set; }
    public int Port { get; set; }
    public byte StationNum { get; set; }
}

/// <summary>
///     Modbus_TCP通信
/// </summary>
public class ModbusTCP : MyPlc
{
    private ModbusTcpNet client;

    public bool IsConnect;


    public void Close()
    {
        client?.ConnectClose();
    }

    public void SetRecivedTimeout(int milltime)
    {
        if (client != null)
        {
            client.ReceiveTimeOut = milltime;
        }
    }

    public void SetStation(byte station)
    {
        if (client != null)
        {
            client.Station = station;
        }
    }

    public (bool, string) Open(string IP, int port, byte station)
    {
        // 连接
        IPAddress address;
        if (station <= 0)
        {
            station = 1;
        }

        if (!IPAddress.TryParse(IP, out address)) return (false, "Ip地址输入不正确！");
        client?.ConnectClose();
        client = new ModbusTcpNet(IP, port, station);
        client.AddressStartWithZero = true;
        client.DataFormat = DataFormat.CDAB;
        client.IsStringReverse = false;
        client.ReceiveTimeOut = 300;
        try
        {
            var connect = client.ConnectServer();
            if (connect.IsSuccess)
            {
                IsConnect = true;
                return (true, "");
            }

            IsConnect = false;
            return (false, "连接失败！" + connect.Message);
        }
        catch (Exception ex)
        {
            IsConnect = false;
            return (false, ex.Message);
        }
    }

    

   

    public override bool Connect(string ip, int port)
    {
        // 连接
        IPAddress address;
        if (!IPAddress.TryParse(IP, out address)) return false;

        client?.ConnectClose();
        //站号 Station 默认为1

        client = new ModbusTcpNet(IP, port);
        client.AddressStartWithZero = true;
        client.DataFormat = DataFormat.CDAB;
        client.IsStringReverse = false;
        try
        {
            var connect = client.ConnectServer();
            if (connect.IsSuccess)
            {
                IsConnect = true;
                return true;
            }

            IsConnect = false;
            return false;
        }
        catch (Exception ex)
        {
            IsConnect = false;
            return false;
        }
    }


    #region 读操作

    public override bool ReadBool(string address, out bool value)
    {
        value = false;
        bool flag = true;
        try
        {
            var result = client.ReadBool(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Bool] Fail,地址:[{address}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Bool] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool ReadBool(string address, ushort length, out bool[] value)
    {
        bool flag = false;
        value = new bool[length];
        try
        {
            var result = client.ReadBool(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Bool]数组 Fail,地址:[{address}] 长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Bool]数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadInt16(string address, out short value)
    {
        bool flag = false;
        value = -1;
        try
        {
            var result = client.ReadInt16(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [int16] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read int16 Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool ReadInt16(string address, ushort length, out short[] value)
    {
        bool flag = false;
        value = new short[length];
        try
        {
            var result = client.ReadInt16(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Int16]数组 Fail,地址:[{address}] 长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Int16]数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt16(string address, out ushort value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadUInt16(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt16]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt16] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt16(string address, ushort length, out ushort[] value)
    {
        bool flag = false;
        value = new ushort[length];
        try
        {
            var result = client.ReadUInt16(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt16]数组 Fail,地址:[{address}] 长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt16]数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadInt32(string address, out int value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadInt32(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Int32]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Int32] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadInt32(string address, ushort length, out int[] value)
    {
        bool flag = false;
        value = new int[length];
        try
        {
            var result = client.ReadInt32(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [int32] 数组 Fail,地址:[{address}],长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [int32] 数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt32(string address, out uint value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadUInt32(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt32]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt32] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt32(string address, ushort length, out uint[] value)
    {
        bool flag = false;
        value = new uint[length];
        try
        {
            var result = client.ReadUInt32(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt32] 数组 Fail,地址:[{address}],长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt32] 数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadInt64(string address, out long value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadInt64(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Int64]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Int64] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadInt64(string address, ushort length, out long[] value)
    {
        bool flag = false;
        value = new long[length];
        try
        {
            var result = client.ReadInt64(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Int64] 数组 Fail,地址:[{address}],长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Int64] 数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt64(string address, out ulong value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadUInt64(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt64]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt64] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadUInt64(string address, ushort length, out ulong[] value)
    {
        bool flag = false;
        value = new ulong[length];
        try
        {
            var result = client.ReadUInt64(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [UInt64] 数组 Fail,地址:[{address}],长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [UInt64] 数组 Err,地址:[{address}],长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadFloat(string address, out float value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadFloat(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Float]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Float] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadDouble(string address, out double value)
    {
        bool flag = true;
        value = 0;
        try
        {
            var result = client.ReadDouble(address);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [Double]  Fail ,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [Double] Err ,地址:[{address}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool ReadString(string address, ushort length, out string value)
    {
        bool flag = true;
        value = "";
        try
        {
            var result = client.ReadString(address, length);
            value = result.Content;
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Read [String]  Fail ,地址:[{address}] 长度:[{length}] 错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Read [String] Err ,地址:[{address}] 长度:[{length}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    #endregion

    #region 写操作

    public override bool WriteInt16(string address, short value)
    {
        bool flag = false;
        try
        {
            OperateResult result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [int16] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [int16] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool WriteBool(string adr, bool value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(adr, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [Bool] Fail,地址:[{adr}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [Bool] Err,地址:[{adr}] 异常信息:{ex.Message} ");
        }

        return flag;
    }

    public override bool WriteFloat(string adr, float value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(adr, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [Float] Fail,地址:[{adr}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [Float] Err,地址:[{adr}] 异常信息:{ex.Message}");
        }

        return flag;
    }


    public override bool WriteInt32(string adr, int value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(adr, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [Int32] Fail,地址:[{adr}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [Int32] Err,地址:[{adr}] 异常信息:{ex.Message}");
        }

        return flag;
    }


    public override bool WriteInt64(string address, long value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [Int64] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [Int64] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool WriteUInt16(string address, ushort value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [UInt16] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [UInt16] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool WriteUInt32(string address, uint value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [UInt32] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [UInt32] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool WriteUInt64(string address, ulong value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [UInt64] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [UInt64] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    public override bool WriteString(string address, string value)
    {
        bool flag = true;
        try
        {
            var result = client.Write(address, value);
            flag = result.IsSuccess;
            if (!flag)
            {
                LogMgr.Instance.Error($"Write [String] Fail,地址:[{address}]  错误信息:[{result.Message}]");
            }
        }
        catch (Exception ex)
        {
            LogMgr.Instance.Error($"Write [String] Err,地址:[{address}] 异常信息:{ex.Message}");
        }

        return flag;
    }

    #endregion


    #region 扩展读写方法

    public override bool Read(string adr, string type, out string value)
    {
        value = "0";
        bool flag = true;
        //获取类型和长度 string-10
        string[] str_Type = type.Split('-');
        try
        {
            switch (str_Type[0])
            {
                case "Int":
                {
                    OperateResult<Int16> operate = client.ReadInt16(adr);
                    value = operate.Content.ToString();
                    flag = operate.IsSuccess;
                    break;
                }
                case "Double":
                {
                    OperateResult<double> operate = client.ReadDouble(adr);
                    value = operate.Content.ToString("f2");
                    flag = operate.IsSuccess;
                    break;
                }
                case "Float":
                {
                    OperateResult<float> operate = client.ReadFloat(adr);
                    value = operate.Content.ToString();
                    flag = operate.IsSuccess;
                    break;
                }
                case "String":
                {
                    OperateResult<string> operate = client.ReadString(adr, Convert.ToUInt16(str_Type[1]));
                    value = operate.Content.ToString();

                    value = RemoveAllCharactersAfterBackslashOrNull(value);
                    flag = operate.IsSuccess;
                    break;
                }
                default:
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
        try
        {
            switch (type)
            {
                case "Int":
                {
                    OperateResult operate = client.Write(adr, Convert.ToInt16(value));
                    flag = operate.IsSuccess;
                    break;
                }
                case "Double":
                {
                    OperateResult operate = client.Write(adr, Convert.ToDouble(value));
                    flag = operate.IsSuccess;
                    break;
                }
                case "Float":
                {
                    float valueF = (float)value;
                    OperateResult operate = client.Write(adr, valueF);
                    flag = operate.IsSuccess;
                    break;
                }
                case "String":
                {
                    OperateResult operate = client.Write(adr, value.ToString());
                    flag = operate.IsSuccess;
                    break;
                }
                default:
                    break;
            }
        }
        catch (Exception)
        {
            flag = false;
        }

        return flag;
    }
    #endregion


    public override void Dispose()
    {
        client?.Dispose();
    }
}