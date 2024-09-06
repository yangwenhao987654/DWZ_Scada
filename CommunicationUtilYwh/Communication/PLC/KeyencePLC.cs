using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Profinet.Keyence;
using HslCommunication.Profinet.Omron;
using LogTool;
using ZC_DataAcquisition;

namespace CommunicationUtilYwh.Communication.PLC
{
    /// <summary>
    /// 基恩士PLC的MC协议 TCP
    /// </summary>
    public class KeyencePLC:IDisposable
    {
        private KeyenceMcNet client;

        public bool Connect(string ip, int port)
        {
            bool flag = true;
            try
            {
                client = new KeyenceMcNet(ip, port);
                OperateResult connect = client.ConnectServer();
                if (!connect.IsSuccess)
                {
                    flag = false;
                }
                if (flag)
                {
                    LogMgr.Instance.Info("PLC连接成功");
                }
                else
                {
                    LogMgr.Instance.Error("PLC连接失败:" + connect.Message);
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        public bool ReadBool(string address,out bool value )
        {
            OperateResult<bool> result = client.ReadBool(address);
            value = result.Content;
            return result.IsSuccess;
        }

        public bool ReadInt16(string address, out int value)
        {
            OperateResult<short> result = client.ReadInt16(address);
            value = result.Content;
            return result.IsSuccess;
        }

        public bool Read(string adr, string type, out string value)
        {
            value = "0";
            bool flag = true;
            type =type.ToLower();
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

        /// <summary>
        /// 移除所有包含\\ \r \0 字符之后的所有字符 
        /// 去尾部
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAllCharactersAfterBackslashOrNull(string input)
        {
            // 查找反斜杠或空字符的位置
            //查找到第一个包含所有\\ 普通反斜杠 \0 空字符 \r回车 的索引 
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\0', '\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }

        public bool Write(string adr, string type, object value)
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

        public bool WriteFloat(string adr, float value)
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
        public bool ReadAlarm(string adr, out bool[] value, int length)
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

        public void Dispose()
        {
            //Dispose 会调用Close()  =》  client?.ConnectClose();
            client?.Dispose();
        }
    }
}
