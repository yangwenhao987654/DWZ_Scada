using LogTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DWZ_Scada.Pages.PLCAlarm
{
    public class PlcAlarmLoader
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        public static void Load()
        {
            #region    读取参数
            string path = $"Config\\{SystemParams.Instance.Station}-PLC参数设置.XML";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode("参数");
                XmlNodeList xnl = xn.ChildNodes;
                Global.PlcAlarmList.Clear();
                for (int i = 0; i < xnl.Count; i++)
                {
                    try
                    {
                        XmlElement xe = (XmlElement)xnl[i];
                        PLCAlarmData pLC_DATA_ = new PLCAlarmData();
                        //节点名称 
                        string name = xe.Name;
                        string[] strings = name.Split("-");
                        if (strings.Length>1)
                        {
                            pLC_DATA_.ID = Convert.ToInt32(strings[1]);
                        }
                        pLC_DATA_.Name = Convert.ToString(xe.GetAttribute("报警名称"));
                        pLC_DATA_.Address = Convert.ToString(xe.GetAttribute("地址"));
                        bool isArray = Convert.ToBoolean(xe.GetAttribute("是否数组"));
                        pLC_DATA_.IsArray = isArray;
                        if (isArray)
                        {
                            pLC_DATA_.Length = Convert.ToInt32(xe.GetAttribute("数组长度"));
                            pLC_DATA_.AlarmList = new List<SingleAlarmAddress>();
                            foreach (var subNode in xe.ChildNodes)
                            {
                                XmlElement subElement = (XmlElement)subNode;
                                SingleAlarmAddress alarmDto = new SingleAlarmAddress();
                                alarmDto.Index = Convert.ToInt32(subElement.GetAttribute("索引"));
                                alarmDto.SubAddress = subElement.GetAttribute("全地址");
                                alarmDto.AlarmType = subElement.GetAttribute("报警类型");
                                alarmDto.Name = subElement.GetAttribute("报警名称");
                                pLC_DATA_.AlarmList.Add(alarmDto);
                            }
                        }
                        else
                        {
                            pLC_DATA_.AlarmType = Convert.ToString(xe.GetAttribute("报警类型"));
                        }
                        Global.PlcAlarmList.Add(pLC_DATA_);
                    }
                    catch (Exception ex)
                    {
                        LogMgr.Instance.Error($"读取PLC报警配置失败: 路径:{path} 异常信息:{ex.Message}\n调用堆栈：{ex.StackTrace}");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                //  my_object.LOGS_disp(ex.Message);
                LogMgr.Instance.Error($"读取PLC报警配置失败: 路径:{path} 异常信息:{ex.Message}\n调用堆栈：{ex.StackTrace}");
            }
            #endregion
        }

        public static void Save()
        {
            string path = $"Config\\{SystemParams.Instance.Station}-PLC参数设置.XML";

            try
            {
                if (Directory.Exists("Config") == false)//如果不存在就创建LOGS文件夹
                {
                    Directory.CreateDirectory("Config");
                }
                #region  保存XML
                //使用XmlDocument创建xml
                XmlDocument xmldoc = new XmlDocument();
                XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                xmldoc.AppendChild(xmldec);
                //添加根节点
                XmlElement rootElement = xmldoc.CreateElement("参数");
                /*       rootElement.SetAttribute("IP", IP);
                       rootElement.SetAttribute("端口号", DK);
                       rootElement.SetAttribute("设备号", ID);
                       rootElement.SetAttribute("字符顺序", shunxv);*/
                xmldoc.AppendChild(rootElement);
                List<PLCAlarmData> list = Global.PlcAlarmList;
                for (var i = 0; i < list.Count; i++)
                {
                    XmlElement classElement = xmldoc.CreateElement($"ID-{list[i].ID.ToString()}");
                    classElement.SetAttribute("地址", list[i].Address);
                    classElement.SetAttribute("报警名称", list[i].Name);
                    classElement.SetAttribute("是否数组", list[i].IsArray.ToString());
                    if (list[i].IsArray)
                    {
                        classElement.SetAttribute("数组长度", list[i].Length.ToString());
                        //子节点记录连续地址长度
                        //在classElement上增加子节点List
                        foreach (var data in list[i].AlarmList)
                        {
                            XmlElement subElement = xmldoc.CreateElement($"Name{list[i].ID}_{data.Index}");
                            subElement.SetAttribute("索引", data.Index.ToString());
                            subElement.SetAttribute("全地址", data.SubAddress);
                            subElement.SetAttribute("报警名称", data.Name);
                            subElement.SetAttribute("报警类型", data.AlarmType);
                            classElement.AppendChild(subElement);
                        }
                    }
                    else
                    {
                        classElement.SetAttribute("报警类型", list[i].AlarmType);
                    }
                    rootElement.AppendChild(classElement);
                }
                //保存文件
                xmldoc.Save(path);
                #endregion
            }
            catch (Exception ex)
            {
                LogMgr.Instance.Error($"报错PLC报警配置失败: 路径:{path} 异常信息:{ex.Message}\n调用堆栈：{ex.StackTrace}");
            }
        }
    }
}
