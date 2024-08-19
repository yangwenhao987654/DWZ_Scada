using System;
using HslCommunication;
using HslCommunication.Profinet.Omron;
using LogTool;

//FINS(Factory Interface Network Service)协议

namespace ZC_DataAcquisition
{
    /// <summary>
    /// 欧姆龙PLC Fins协议
    /// </summary>
   public class OmornFins
    {
        OmronFinsNet omronFins = new OmronFinsNet();
        
        object _lock = new object();
        public bool Connect(string ip,string port,string SA1,string DA1)
        {
            bool flag = true;
            try
            {
                omronFins = new OmronFinsNet(ip, Convert.ToInt32(port));
                omronFins.SA1 = Convert.ToByte(SA1);//本地ip最后一位
                omronFins.DA1 = Convert.ToByte(DA1);//plc ip最后一位
                
                OperateResult connect = omronFins.ConnectServer();
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

        public bool Read(string adr,string type,out string value)
        {
            lock (_lock)
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
                            OperateResult<Int16> operate = omronFins.ReadInt16(adr);
                            value = operate.Content.ToString();
                            flag = operate.IsSuccess;
                            break;
                        }
                    case "Double":
                        {
                            OperateResult<double> operate = omronFins.ReadDouble(adr);
                            value = operate.Content.ToString("f2");
                            flag = operate.IsSuccess;
                            break;
                        }
                    case "Float":
                        {
                            OperateResult<float> operate = omronFins.ReadFloat(adr);
                            value = operate.Content.ToString();
                            flag = operate.IsSuccess;
                            break;
                        }
                    case "String":
                        {
                            OperateResult<string> operate = omronFins.ReadString(adr,Convert.ToUInt16(str_Type[1]));
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
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\0','\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }

        public bool Write(string adr, string type,object value)
        {
            lock (_lock)
            {
                bool flag = true;
                try
                {
                    switch (type)
                    {
                        case "Int":
                            {
                                OperateResult operate = omronFins.Write(adr, Convert.ToInt16(value));
                                flag = operate.IsSuccess;
                                break;
                            }
                        case "Double":
                            {
                                OperateResult operate = omronFins.Write(adr, Convert.ToDouble(value));
                                flag = operate.IsSuccess;
                                break;
                            }
                        case "Float":
                            {
                                float valueF = (float)value;
                                OperateResult operate = omronFins.Write(adr, valueF);
                                flag = operate.IsSuccess;
                                break;
                            }
                        case "String":
                            {
                                OperateResult operate = omronFins.Write(adr, value.ToString());
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
        }

        public bool WriteFloat(string adr,float value)
        {
            OperateResult operate = new OperateResult();
            lock (_lock)
            {
                bool flag = true;
                try
                {
                     operate = omronFins.Write(adr, value);
                     flag = operate.IsSuccess;  
                }
                catch (Exception ex)
                {
                    LogMgr.Instance.Error($"Write Float Fail :{ex.Message} {operate.Message}");
                }
                return flag;
            }
        }
        public bool ReadAlarm(string adr, out bool[] value)
        {
            lock (_lock)
            {
                value = new bool[16];
                bool flag = true;
                try
                {

                    OperateResult<bool[]> operate = omronFins.ReadBool(adr, 16);
                    value = operate.Content;
                    flag = operate.IsSuccess;
                }
                catch (Exception)
                {
                    flag = false;
                }
                return flag;
            }
        }
    }
}
