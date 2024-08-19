using HslCommunication.Profinet.Omron;
using HslCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using LogTool;
using HslCommunication.Profinet.Melsec;

namespace Cap
{
    /// <summary>
    /// 西门子PLC S7-1200
    /// </summary>
    public class SiemensPLC
    {
        public enum DataType
        {
            String,
            Int16,
            Float,
            Boolean,
            Int32,
            Double,
            // 添加其他类型...
        }

        private SiemensS7Net client ;

        /// <summary>
        /// 定义PLC型号 S1200
        /// </summary>
        private SiemensPLCS PLCType = SiemensPLCS.S1200;

        private readonly object _lock = new object();
        public bool Connect(string ip)
        {
            bool flag = false;
            try
            {
                client = new SiemensS7Net(PLCType, ip);
                OperateResult operateResult = client.ConnectServer();
                if(operateResult.IsSuccess)
                {
                    flag = true;
                    LogMgr.Instance.Info("PLC连接成功");
                }
                else
                {
                    LogMgr.Instance.Error("PLC连接失败" + operateResult.Message);
                }
            }
            catch(Exception)
            {
                flag = false;
            }
            //Global.IsPlc_Connected = flag;
            return flag;
        }

        public bool ReadUInt16(string adr, out ushort value)
        {
            bool flag = false;
            value = 0;
          
                OperateResult<UInt16> operate = client.ReadUInt16(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            
            return flag;
        }

        public bool ReadUInt32(string adr, out uint value)
        {
            bool flag = false;
            value = 0;
            lock (_lock)
            {
                OperateResult<UInt32> operate = client.ReadUInt32(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }


        public bool ReadInt16(string adr, out short value)
        {
            bool flag = false;
            value = 0;
            lock (_lock)
            {
                OperateResult<Int16> operate = client.ReadInt16(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }


        public bool ReadInt32(string adr, out int value)
        {
            bool flag = false;
            value = 0;
            lock (_lock)
            {
                OperateResult<Int32> operate = client.ReadInt32(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool ReadBool(string adr, out bool value)
        {
            bool flag = false;
            value = false;
            
                OperateResult<bool> operate = client.ReadBool(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            
            return flag;
        }

        public bool ReadBool(string adr,int length , out bool[] value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<bool[]> operate = client.ReadBool(adr,(ushort)length);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }


        public bool ReadUInt16(string adr, ushort length, out ushort[] value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<UInt16[]> operate = client.ReadUInt16(adr, length);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool ReadDouble(string adr, out double value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<double> operate = client.ReadDouble(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool ReadDouble(string adr, out string value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<double> operate = client.ReadDouble(adr);
                value = operate.Content.ToString("f2");
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool ReadFloat(string adr, out float value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<float> operate = client.ReadFloat(adr);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool ReadString(string adr, ushort length, out string value)
        {
            bool flag = false;
            lock (_lock)
            {
                OperateResult<string> operate = client.ReadString(adr, length);
                value = operate.Content;
                flag = operate.IsSuccess;
            }
            return flag;
        }

        public bool WriteInt16(string adr, Int16 value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, Convert.ToInt16(value));
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteUInt16(string adr, UInt16 value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, Convert.ToUInt16(value));
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteInt32(string adr, int value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, Convert.ToInt32(value));
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteUInt32(string adr, uint value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, Convert.ToUInt32(value));
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteFloat(string adr, float value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, value);
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteString(string adr, string value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, value);
                flag = operate.IsSuccess;
                return flag;
            }
        }

        public bool WriteDouble(string adr, double value)
        {
            lock (_lock)
            {
                bool flag = false;
                OperateResult operate = client.Write(adr, value);
                flag = operate.IsSuccess;
                return flag;
           
            }
        }


        public bool Read(string adr, string type, out string value)
        {
            
            lock(_lock)
            {
                value = "0";
                bool flag = false;
                //获取类型和长度 string-10
                string[] str_Type = type.Split('-');
                try
                {
                    switch(str_Type[0])
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
                                value = operate.Content.Trim().Replace("\0", "").Replace("\r", "");
                                flag = operate.IsSuccess;
                                break;
                            }
                        default:
                            break;
                    }

                }
                catch(Exception)
                {
                    flag = false;
                }
                //Global.IsPlc_Connected = flag;
                return flag;
            }
        }

        public bool Read(string adr, DataType type, out string value)
        {
            lock(_lock)
            {
                value = "-1";
                bool flag = false;
                //获取类型和长度 
                try
                {
                    switch(type)
                    {
                        case DataType.Int16:
                            {
                                OperateResult<Int16> operate = client.ReadInt16(adr);
                                value = operate.Content.ToString();
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.Int32:
                            {
                                OperateResult<Int32> operate = client.ReadInt32(adr);
                                value = operate.Content.ToString();
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.Double:
                            {
                                OperateResult<double> operate = client.ReadDouble(adr);
                                value = operate.Content.ToString("f2");
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.Float:
                            {
                                OperateResult<float> operate = client.ReadFloat(adr);
                                value = operate.Content.ToString();
                                flag = operate.IsSuccess;
                                break;
                            }
                        default:
                            break;
                    }
                }
                catch(Exception)
                {
                    flag = false;
                }
                //Global.IsPlc_Connected = flag;
                return flag;
            }
        }
        public bool WriteInt16(string adr, int value)
        {
           
                bool flag = false;
                OperateResult operate = client.Write(adr, Convert.ToInt16(value));
                flag = operate.IsSuccess;
                return flag;
            
        }

        public bool WriteBool(string adr, bool value)
        {
            
                bool flag = false;
                OperateResult operate = client.Write(adr,value);
                flag = operate.IsSuccess;
                return flag;
            
        }

        private bool Write(string adr, string type, object value)
        {
            lock(_lock)
            {
                bool flag = false;
                try
                {
                    switch(type)
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
                catch(Exception)
                {
                    flag = false;
                }
                //Global.IsPlc_Connected = flag;
                return flag;
            }
        }

        public bool Write(string adr, DataType type, object value)
        {
            lock(_lock)
            {
                bool flag = false;
                try
                {
                    switch(type)
                    {
                        case DataType.Int16:
                            {
                                OperateResult operate = client.Write(adr, Convert.ToInt16(value));
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.Int32:
                            {
                                OperateResult operate = client.Write(adr, Convert.ToInt32(value));
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.Double:
                            {
                                OperateResult operate = client.Write(adr, Convert.ToDouble(value));
                                flag = operate.IsSuccess;
                                break;
                            }
                        case DataType.String:
                            {
                                OperateResult operate = client.Write(adr, value.ToString());
                                flag = operate.IsSuccess;
                                break;
                            }
                        default:
                            break;
                    }
                }
                catch(Exception)
                {
                    flag = false;
                }
                //Global.IsPlc_Connected = flag;
                return flag;
            }
        }
        public bool ReadAlarm(string adr, int length ,out bool[] value)
        {
            lock(_lock)
            {
                value = new bool[length];
                bool flag = true;
                try
                {

                    OperateResult<bool[]> operate = client.ReadBool(adr, (ushort)length);
                    value = operate.Content;
                    flag = operate.IsSuccess;
                }
                catch(Exception)
                {
                    flag = false;
                }
                //Global.IsPlc_Connected = flag;
                return flag;
            }
        }
    }
}
