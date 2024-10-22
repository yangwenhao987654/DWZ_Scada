using System;
using System.Windows.Forms;
using CommunicationUtilYwh.Communication.PLC;
using HslCommunication;
using HslCommunication.Profinet.Omron;
using LogTool;

//FINS(Factory Interface Network Service)协议

namespace ZC_DataAcquisition
{
    /// <summary>
    /// 欧姆龙PLC Fins协议
    /// </summary>
    public class OmornFins : MyPlc
    {
        OmronFinsNet client = new OmronFinsNet();

        object _lock = new object();
        public bool Connect(string ip, string port, string SA1, string DA1)
        {
            bool flag = true;
            try
            {
                client = new OmronFinsNet(ip, Convert.ToInt32(port));
                client.SA1 = Convert.ToByte(SA1);//本地ip最后一位
                client.DA1 = Convert.ToByte(DA1);//plc ip最后一位
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

        public override bool Connect(string ip, int port)
        {
            bool flag = true;
            try
            {
                client = new OmronFinsNet(ip, Convert.ToInt32(port));
                /* client.SA1 = Convert.ToByte(SA1);//本地ip最后一位
                 client.DA1 = Convert.ToByte(DA1);//plc ip最后一位*/

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

        public override bool ReadBool(string address, out bool value)
        {
            throw new NotImplementedException();
        }

        public override bool ReadInt16(string address, out short value)
        {
            throw new NotImplementedException();
        }

        public override bool WriteInt16(string address, short value)
        {
            OperateResult operate = client.Write(address, Convert.ToInt16(value));
            bool flag = operate.IsSuccess;
            return flag;
            ;
        }

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
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            client?.Dispose();
        }

        public bool ReadAlarm(string adr, out bool[] value)
        {
            value = new bool[16];
            bool flag = true;
            try
            {

                OperateResult<bool[]> operate = client.ReadBool(adr, 16);
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
