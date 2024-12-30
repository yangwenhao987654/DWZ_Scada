using DWZ_Scada.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms.Design;

namespace DWZ_Scada
{
    public enum BrowasableEnum
    {
        操作员 = 1,
        工程师 = 2,
        管理员 = 3,
    }

    #region 自定义特性

    /// <summary>
    /// 权限管控特性,用来决定不同用户看到不同的属性,必须与Browsable同时出现,因为默认Browsable的值无法修改
    /// </summary>
    class PermissionAttribute : Attribute
    {
        private int lvl;
        public int Lvl
        {

            get { return lvl; }

        }
        public PermissionAttribute(int des)
        {
            this.lvl = des;
        }
    }
    #endregion

    [Serializable]
    public class SystemParams :INotifyPropertyChanged
    {
        //用json格式保存,方便在程序未启动时手动修改配置

        public SystemParams Clone()
        {
            //浅拷贝
            return this.MemberwiseClone() as SystemParams;
        }

        public enum VoiceSpeedLvl
        {
            特慢 = -2,
            慢 = -1,
            一般 = 0,
            快 = 1,
            特快 = 2,
        }

        public enum DBConfigType
        {
            默认,
            生产环境,
            测试环境
        }
        //用json格式保存,方便在程序未启动时手动修改配置
        public enum StationEnum
        {
            OP10上料打码工站,
            OP20机械手绕线工站,
            OP30绕线检查工站,
            OP40TIG电焊工站,
            OP60电测工站,
            OP70出料打码工站,
        }

        public static SystemParams Instance = new SystemParams();
        public static string Path = $@"{AppDomain.CurrentDomain.BaseDirectory}Params\Params.json";
        public static string PathBackup = $@"{AppDomain.CurrentDomain.BaseDirectory}Params\Params-backup.json";

        public static string ParamsBackupDirectory =System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Params","BackUp");

        [field: NonSerialized]
        public event Action RefreshResultEvent;

        /// <summary>
        /// 站别切换事件
        /// </summary>
        [field: NonSerialized]
        public static event Action StationChanged;
        [field: NonSerialized]
        private StationEnum _station;

        [Permission(3), ReadOnly(false)]
        [DisplayName("0.所属站别"), Category("0.设备配置参数"), Description("只允许启用选用的站别")]
        public StationEnum Station
        {
            get { return _station; }
            set
            {
                if (_station != value)
                {
                    _station = value;
                    OnStationChanged();
                }
            }
        }
        private void OnStationChanged()
        {
            StationChanged?.Invoke();
        }


        [Permission(3), ReadOnly(false)]
        [DisplayName("1.设备厂商"), Category("A.其他配置"), Description("设备厂商名称展示")]
        public string DeviceCompany { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("2.设备名称"), Category("A.其他配置"), Description("设备名称展示")]
        public string DeviceName { get; set; }

        [Permission(3), ReadOnly(true)]
        [DisplayName("A.Logo文件路径"), Category("A.其他配置"), Description("主页公司Logo图片路径")]
        public string LogoFilePath { get; set; }


        [Browsable(false)]
        [Permission(3), ReadOnly(false)]
        [DisplayName("B.公司名称"), Category("A.其他配置"), Description("主页公司名称展示")]
        public string CompanyName { get; set; }

        [EditorAttribute(typeof(FileNameEditor), typeof(UITypeEditor))]
        [Permission(3), ReadOnly(false)]
        [DisplayName("$$.1.更新信息文件路径"), Category("A.其他配置"), Description("自动更新程序文件路径")]
        public string UpdateInfoPath { get; set; }

        [Permission(3), ReadOnly(true)]
        [DisplayName("$$.2.本地版本号"), Category("A.其他配置"), Description("本地程序版本号")]
        public string LocalVersion { get; set; }


        [Permission(3), ReadOnly(false)]
        [DisplayName("0.Mes服务器 IP地址"), Category("0.Mes服务器"), Description("Mes服务器的IP地址")]
        public string MesIP { get; set; }

        #region OP10工站参数

        [Permission(3), ReadOnly(false)]
        [DisplayName("1.温度采集模块串口名称"), Category("1.OP10工站"), Description("温度控制模块的Com口")]
        public string OP10_ComName{ get; set; }


        [field: NonSerialized]
        private string _op10_PlcIP;


        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("1.OP10工站"), Description("PLC的IP地址")]
        public string OP10_PlcIP
        {
            get => _op10_PlcIP;
            set
            {
                if (_op10_PlcIP != value) // 检查是否有变化
                {
                    _op10_PlcIP = value;
                    OnPropertyChanged(); // 触发事件
                }
            }
        }

        [field: NonSerialized]
        private int _op10_PlcPort;


        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("1.OP10工站"), Description("PLC的端口号")]
        public int OP10_PlcPort
        {
            get => _op10_PlcPort;
            set
            {
                if (_op10_PlcPort != value) // 检查是否有变化
                {
                    _op10_PlcPort = value;
                    OnPropertyChanged(); // 触发事件
                }
            }
        }
        #endregion

        #region OP20工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_PlcPort { get; set; }

        [Browsable(false)]
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机1工位物料list"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public List<string> OP20_WuliaoList1 { get; set; }


        [Browsable(false)]
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机2工位物料list"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public List<string> OP20_WuliaoList2 { get; set; }


        [field: NonSerialized]
        private string _op20_Winding1_IP;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机1 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding1_IP
        {
            get
            {
                return _op20_Winding1_IP;
            }
            set
            {
                if (_op20_Winding1_IP!=value)
                {
                    _op20_Winding1_IP =value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private int _op20_Winding1_Port;


        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机1_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding1_Port
        {
            get
            {
                return _op20_Winding1_Port;
            }
            set
            {
                if (_op20_Winding1_Port!=value)
                {
                    _op20_Winding1_Port =value;
                    OnPropertyChanged();
                }
            }
        }

        [field: NonSerialized]
        private byte _op20_Winding1_StationNum;


        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机1_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding1_StationNum
        {
            get
            {
                return _op20_Winding1_StationNum;
            }
            set
            {
                if (value!=_op20_Winding1_StationNum)
                {
                    _op20_Winding1_StationNum =value;
                    OnPropertyChanged();
                }
            }
        }

        [field: NonSerialized]
        private string _op20_Winding2_IP;


        [field: NonSerialized]
        private int _op20_Winding2_Port;

        [field: NonSerialized]
        private byte _op20_Winding2_StationNum;


        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机2 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding2_IP
        {
            get
            {
                return _op20_Winding2_IP;
            }
            set
            {
                if (_op20_Winding2_IP != value)
                {
                    _op20_Winding2_IP = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机2_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding2_Port
        {
            get
            {
                return _op20_Winding2_Port;
            }
            set
            {
                if (_op20_Winding2_Port != value)
                {
                    _op20_Winding2_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机2_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding2_StationNum
        {
            get
            {
                return _op20_Winding2_StationNum;
            }
            set
            {
                if (_op20_Winding2_StationNum != value)
                {
                    _op20_Winding2_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }

        [field: NonSerialized]
        private string _op20_Winding3_IP;


        [field: NonSerialized]
        private int _op20_Winding3_Port;

        [field: NonSerialized]
        private byte _op20_Winding3_StationNum;



        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机3 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding3_IP
        {
            get
            {
                return _op20_Winding3_IP;
            }
            set
            {
                if (_op20_Winding3_IP != value)
                {
                    _op20_Winding3_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机3_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding3_Port
        {
            get
            {
                return _op20_Winding3_Port;
            }
            set
            {
                if (_op20_Winding3_Port != value)
                {
                    _op20_Winding3_Port = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机3_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding3_StationNum
        {
            get
            {
                return _op20_Winding3_StationNum;
            }
            set
            {
                if (_op20_Winding3_StationNum != value)
                {
                    _op20_Winding3_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }

        [field: NonSerialized]
        private string _op20_Winding4_IP;


        [field: NonSerialized]
        private int _op20_Winding4_Port;

        [field: NonSerialized]
        private byte _op20_Winding4_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机4 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding4_IP
        {
            get
            {
                return _op20_Winding4_IP;
            }
            set
            {
                if (_op20_Winding4_IP != value)
                {
                    _op20_Winding4_IP = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机4_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding4_Port
        {
            get
            {
                return _op20_Winding4_Port;
            }
            set
            {
                if (_op20_Winding4_Port != value)
                {
                    _op20_Winding4_Port = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机4_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding4_StationNum
        {
            get
            {
                return _op20_Winding4_StationNum;
            }
            set
            {
                if (_op20_Winding4_StationNum != value)
                {
                    _op20_Winding4_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding5_IP;


        [field: NonSerialized]
        private int _op20_Winding5_Port;

        [field: NonSerialized]
        private byte _op20_Winding5_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机5 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding5_IP
        {
            get
            {
                return _op20_Winding5_IP;
            }
            set
            {
                if (_op20_Winding5_IP != value)
                {
                    _op20_Winding5_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机5_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding5_Port
        {
            get
            {
                return _op20_Winding5_Port;
            }
            set
            {
                if (_op20_Winding5_Port != value)
                {
                    _op20_Winding5_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机5_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding5_StationNum
        {
            get
            {
                return _op20_Winding5_StationNum;
            }
            set
            {
                if (_op20_Winding5_StationNum != value)
                {
                    _op20_Winding5_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding6_IP;


        [field: NonSerialized]
        private int _op20_Winding6_Port;

        [field: NonSerialized]
        private byte _op20_Winding6_StationNum;


        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机6 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding6_IP
        {
            get
            {
                return _op20_Winding6_IP;
            }
            set
            {
                if (_op20_Winding6_IP != value)
                {
                    _op20_Winding6_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机6_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding6_Port
        {
            get
            {
                return _op20_Winding6_Port;
            }
            set
            {
                if (_op20_Winding6_Port != value)
                {
                    _op20_Winding6_Port = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机6_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding6_StationNum
        {
            get
            {
                return _op20_Winding6_StationNum;
            }
            set
            {
                if (_op20_Winding6_StationNum != value)
                {
                    _op20_Winding6_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding7_IP;


        [field: NonSerialized]
        private int _op20_Winding7_Port;

        [field: NonSerialized]
        private byte _op20_Winding7_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机7 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding7_IP
        {
            get
            {
                return _op20_Winding7_IP;
            }
            set
            {
                if (_op20_Winding7_IP != value)
                {
                    _op20_Winding7_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机7_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding7_Port
        {
            get
            {
                return _op20_Winding7_Port;
            }
            set
            {
                if (_op20_Winding7_Port != value)
                {
                    _op20_Winding7_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机7_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding7_StationNum
        {
            get
            {
                return _op20_Winding7_StationNum;
            }
            set
            {
                if (_op20_Winding7_StationNum != value)
                {
                    _op20_Winding7_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding8_IP;


        [field: NonSerialized]
        private int _op20_Winding8_Port;

        [field: NonSerialized]
        private byte _op20_Winding8_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机8 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding8_IP
        {
            get
            {
                return _op20_Winding8_IP;
            }
            set
            {
                if (_op20_Winding8_IP != value)
                {
                    _op20_Winding8_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机8_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding8_Port
        {
            get
            {
                return _op20_Winding8_Port;
            }
            set
            {
                if (_op20_Winding8_Port != value)
                {
                    _op20_Winding8_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机8_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding8_StationNum
        {
            get
            {
                return _op20_Winding8_StationNum;
            }
            set
            {
                if (_op20_Winding8_StationNum != value)
                {
                    _op20_Winding8_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding9_IP;


        [field: NonSerialized]
        private int _op20_Winding9_Port;

        [field: NonSerialized]
        private byte _op20_Winding9_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机9 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding9_IP
        {
            get
            {
                return _op20_Winding9_IP;
            }
            set
            {
                if (_op20_Winding9_IP != value)
                {
                    _op20_Winding9_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机9_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding9_Port
        {
            get
            {
                return _op20_Winding9_Port;
            }
            set
            {
                if (_op20_Winding9_Port != value)
                {
                    _op20_Winding9_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机9_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding9_StationNum
        {
            get
            {
                return _op20_Winding9_StationNum;
            }
            set
            {
                if (_op20_Winding9_StationNum != value)
                {
                    _op20_Winding9_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding10_IP;


        [field: NonSerialized]
        private int _op20_Winding10_Port;

        [field: NonSerialized]
        private byte _op20_Winding10_StationNum;
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机@10 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding10_IP
        {
            get
            {
                return _op20_Winding10_IP;
            }
            set
            {
                if (_op20_Winding10_IP != value)
                {
                    _op20_Winding10_IP = value;
                    OnPropertyChanged();
                }
            }
        }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机@10_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding10_Port
        {
            get
            {
                return _op20_Winding10_Port;
            }
            set
            {
                if (_op20_Winding10_Port != value)
                {
                    _op20_Winding10_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机@10_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding10_StationNum
        {
            get
            {
                return _op20_Winding10_StationNum;
            }
            set
            {
                if (_op20_Winding10_StationNum != value)
                {
                    _op20_Winding10_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding11_IP;


        [field: NonSerialized]
        private int _op20_Winding11_Port;

        [field: NonSerialized]
        private byte _op20_Winding11_StationNum;
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_11 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding11_IP
        {
            get
            {
                return _op20_Winding11_IP;
            }
            set
            {
                if (_op20_Winding11_IP != value)
                {
                    _op20_Winding11_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_11_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding11_Port
        {
            get
            {
                return _op20_Winding11_Port;
            }
            set
            {
                if (_op20_Winding11_Port != value)
                {
                    _op20_Winding11_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_11_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding11_StationNum
        {
            get
            {
                return _op20_Winding11_StationNum;
            }
            set
            {
                if (_op20_Winding11_StationNum != value)
                {
                    _op20_Winding11_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [field: NonSerialized]
        private string _op20_Winding12_IP;


        [field: NonSerialized]
        private int _op20_Winding12_Port;

        [field: NonSerialized]
        private byte _op20_Winding12_StationNum;

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_12 IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_Winding12_IP
        {
            get
            {
                return _op20_Winding12_IP;
            }
            set
            {
                if (_op20_Winding12_IP != value)
                {
                    _op20_Winding12_IP = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_12_端口"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_Winding12_Port
        {
            get
            {
                return _op20_Winding12_Port;
            }
            set
            {
                if (_op20_Winding12_Port != value)
                {
                    _op20_Winding12_Port = value;
                    OnPropertyChanged();
                }
            }
        }
        [Permission(3), ReadOnly(false)]
        [DisplayName("3.绕线机_12_站号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public byte OP20_Winding12_StationNum
        {
            get
            {
                return _op20_Winding12_StationNum;
            }
            set
            {
                if (_op20_Winding12_StationNum != value)
                {
                    _op20_Winding12_StationNum = value;
                    OnPropertyChanged();
                }
            }
        }


        [Permission(3), ReadOnly(false)]
        [DisplayName("A.绕线机超时时间(s)"), Category("2.OP20工站"), Description("设置绕线机的超时时间,最低默认一分钟")]
        public int OP20_WindingTimeOut { get; set; }


        //设置属性只读，不可编辑
        [TypeConverter(typeof(BoolListConverter))]
        [Permission(3), ReadOnly(true)]
        [Browsable(false)]
        [DisplayName("B.绕线机禁用状态"), Category("2.OP20工站"), Description("设置绕线机禁用启用")]
        public List<bool> OP20_WeldingEnableList {
            get; 
            set; }
        #endregion

        #region OP30工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("3.OP30工站"), Description("PLC的IP地址")]
        public string OP30_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("3.OP30工站"), Description("PLC的端口号")]
        public int OP30_PlcPort { get; set; }
        #endregion


        #region OP40工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("4.OP40工站"), Description("PLC的IP地址")]
        public string OP40_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("4.OP40工站"), Description("PLC的端口号")]
        public int OP40_PlcPort { get; set; }



        [Permission(3), ReadOnly(false)]
        [DisplayName("3.ModbusTCP IP地址"), Category("4.OP40工站"), Description("ModbusTCP的IP地址")]
        public string OP40_ModbusIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("4.ModbusTCP 端口号"), Category("4.OP40工站"), Description("ModbusTCP的端口号")]
        public int OP40_ModbusPort { get; set; }


        [Permission(3), ReadOnly(false)]
        [DisplayName("5.氩气瓶压力下限值"), Category("4.OP40工站"), Description("压力下限报警值")]
        public double OP40_PressureMin { get; set; }


        [Permission(3), ReadOnly(false)]
        [DisplayName("5.氩气瓶压力上限值"), Category("4.OP40工站"), Description("压力上限报警值")]
        public double OP40_PressureMax { get; set; }
        #endregion



        #region OP60工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("6.OP60工站"), Description("PLC的IP地址")]
        public string OP60_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("6.OP60工站"), Description("PLC的端口号")]
        public int OP60_PlcPort { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("3.AtlBrx测试_01 IP地址"), Category("6.OP60工站"), Description("AtlBrx测试_01的IP地址")]
        public string OP60_AtlBrx_01_IP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("4.AtlBrx测试_01 端口号"), Category("6.OP60工站"), Description("AtlBrx测试_01的端口号")]
        public string OP60_AtlBrx_01_Port { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("5.AtlBrx测试_02 IP"), Category("6.OP60工站"), Description("AtlBrx测试_02的IP地址")]
        public string OP60_AtlBrx_02_IP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("6.AtlBrx测试_02 端口号"), Category("6.OP60工站"), Description("AtlBrx测试_02的端口号")]
        public string OP60_AtlBrx_02_Port { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("7.安规测试机_01 IP地址"), Category("6.OP60工站"), Description("安规测试机_01的IP地址")]
        public string OP60_Safety_01_IP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("8.安规测试机_01 端口号"), Category("6.OP60工站"), Description("安规测试机_01的端口号")]
        public string OP60_Safety_01_Port { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("9.1安规测试机_02 IP"), Category("6.OP60工站"), Description("安规测试机_02的IP地址")]
        public string OP60_Safety_02_IP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("9.2安规测试机_02 端口号"), Category("6.OP60工站"), Description("安规测试机_02的端口号")]
        public string OP60_Safety_02_Port { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("A.安规测试机_测试超时(秒)"), Category("6.OP60工站"), Description("A.安规测试机_测试超时(秒)")]
        public int OP60_Safety_TimeOut { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("B.电性能测试机_测试超时(秒)"), Category("6.OP60工站"), Description("A.电性能测试机_测试超时(秒)")]
        public int OP60_AtlBrx_TimeOut { get; set; }
        #endregion

        #region OP70工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("7.OP70工站"), Description("PLC的IP地址")]
        public string OP70_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("7.OP70工站"), Description("PLC的端口号")]
        public int OP70_PlcPort { get; set; }
        #endregion


        #region 软件配置参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.是否启用语音播报"), Category("A.软件配置"), Description("配置选择是否使用语音提示功能")]
        //[Browsable(false)]
        public bool IsUseVoicePrompt { get; set; }

        [Permission(3), ReadOnly(false)]
        [DisplayName("1.语速选择"), Category("A.软件配置"), Description("选择分拣机语音提示的播报速度")]
        //[Browsable(false)]
        public VoiceSpeedLvl VoiceSpeed { get; set; }

        #endregion

        #region 登陆参数

        [Browsable(false)]
        [JsonIgnore]
        public string Op { get; set; }

        /// <summary>
        /// OPLvl ==10 表示管理员 1贴签机 2分拣机
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public int OpLvl { get; set; }

        [Browsable(false)]
        [JsonIgnore]
        public string OPRule { get; set; }
        #endregion

        /// <summary>
        /// 用户登录事件
        /// </summary>
        public static event Action OPChangeEvent;

        public void ChangeBrowsable(BrowasableEnum lvl)
        {
            Type permissionType = typeof(PermissionAttribute);
            PropertyDescriptorCollection appSetingAttributes = TypeDescriptor.GetProperties(this);
            FieldInfo fieldInfo = permissionType.GetField("lvl", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            foreach (PropertyDescriptor item in appSetingAttributes)
            {
                //存在特性PermissionAttribute
                var att = item.Attributes[permissionType];
                if (att == null)
                {
                    continue;
                }
                var index = (int)fieldInfo.GetValue(att);
                if (index <= (int)lvl)
                {
                    SetPropertyReadOnly(item, false);
                }
                else
                {
                    SetPropertyReadOnly(item, true);
                }
            }
        }

        public static void SetPropertyReadOnly(PropertyDescriptor p, bool readOnly)
        {
            Type type = typeof(System.ComponentModel.ReadOnlyAttribute);
            FieldInfo fld = type.GetField("isReadOnly", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            fld.SetValue(p.Attributes[type], readOnly);
        }
        private void ChangeBrowsable(PropertyDescriptor p, bool result)
        {
            Type browsableType = typeof(BrowsableAttribute);
            FieldInfo fieldInfo = browsableType.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance);
            fieldInfo.SetValue(p.Attributes[browsableType], result);
        }

        /// <summary>
        /// 加载配置参数 Json
        /// </summary>
        /// <returns></returns>
        public static string Load()
        {
            var errMsg = "";
            try
            {
                if (!File.Exists(Path))
                {
                    errMsg = $"加载配置文件失败! [配置文件不存在] [{Path}]";
                    return errMsg;
                }
                using (StreamReader sr = new StreamReader(Path, Encoding.UTF8))
                {
                    var s = sr.ReadToEnd();
                    Instance = JsonConvert.DeserializeObject(s, typeof(SystemParams)) as SystemParams;
                    if (Instance == null)
                    {
                        Instance = new SystemParams();
                        errMsg = "加载配置文件失败! [{反序列化json失败}]";
                        return errMsg;
                    }
                }
                return errMsg;
            }
            catch (Exception ex)
            {
                errMsg = $"加载配置文件失败! [{ex.Message}]";
                return errMsg;
            }
            finally
            {

            }
        }
        public static string Save()
        {
            var errMsg = "";
            try
            {
                var fileInfo = new FileInfo(Path);
                if (fileInfo.Exists)
                {
                    //fileInfo.CopyTo(PathBackup, true);
                    Directory.CreateDirectory(ParamsBackupDirectory);
                    string path = System.IO.Path.Combine(ParamsBackupDirectory,
                        $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss-fff-}Params.json");
                    fileInfo.CopyTo(path, true);
                    AutoDeleteBackFile();
                }

                string json = JsonConvert.SerializeObject(Instance, Formatting.Indented);//1. 序列化 //2.设置缩进
                fileInfo.Directory.Create();
                using (StreamWriter sw = new StreamWriter(Path, false, Encoding.UTF8))
                {
                    sw.Write(json);
                }
            }
            catch (Exception ex)
            {
                errMsg = $"保存配置文件失败! [{ex.Message}]";
                return errMsg;
            }
            return errMsg;
        }

        private static void AutoDeleteBackFile()
        {
            int maxFiles = 50;
            if (Directory.Exists(ParamsBackupDirectory))
            {
                var files = Directory.GetFiles(ParamsBackupDirectory,"*Params.json")
                    .OrderByDescending(f => f)
                    .ToList();

                if (files.Count > maxFiles)
                {
                    foreach (var file in files.Skip(maxFiles))
                    {
                        try
                        {
                            File.Delete(file);
                            //Console.WriteLine($"Deleted: {file}");
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine($"Error deleting file {file}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("The number of files is within the limit.");
                }
            }
            else
            {
                //Console.WriteLine("Directory does not exist.");
            }
        }

        public void Login(string name, int lvl, string rule)
        {
            if (name == Op && lvl == OpLvl && rule == OPRule)
            {
                return;
            }
            Op = name;
            OpLvl = lvl;
            OPRule = rule;
            OPChangeEvent?.Invoke();
        }


        /// <summary>
        /// 使用反射进行深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        static T CreateDeepCopy<T>(T original)
        {
            if (original == null)
            {
                return default(T);
            }

            Type type = original.GetType();
            object newObject = Activator.CreateInstance(type);

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.IsStatic)
                {
                    continue;
                }

                object value = fieldInfo.GetValue(original);
                fieldInfo.SetValue(newObject, CreateDeepCopy(value));
            }

            return (T)newObject;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
