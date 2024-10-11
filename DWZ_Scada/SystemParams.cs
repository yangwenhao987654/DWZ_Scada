using LogTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Newtonsoft.Json;

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
    public class SystemParams
    {
        //用json格式保存,方便在程序未启动时手动修改配置

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
            无,
            所有,
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

        #region OP10工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("1.OP10工站"), Description("PLC的IP地址")]
        public string OP10_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("1.OP10工站"), Description("PLC的端口号")]
        public int OP10_PlcPort { get; set; }
        #endregion

        #region OP20工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("2.OP20工站"), Description("PLC的IP地址")]
        public string OP20_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("2.OP20工站"), Description("PLC的端口号")]
        public int OP20_PlcPort { get; set; }
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
        #endregion



        #region OP60工站参数
        [Permission(3), ReadOnly(false)]
        [DisplayName("1.PLC IP地址"), Category("6.OP60工站"), Description("PLC的IP地址")]
        public string OP60_PlcIP { get; set; }
        [Permission(3), ReadOnly(false)]
        [DisplayName("2.PLC 端口号"), Category("6.OP60工站"), Description("PLC的端口号")]
        public int OP60_PlcPort { get; set; }
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
                    fileInfo.CopyTo(PathBackup, true);
                }

                string json = JsonConvert.SerializeObject(Instance, Formatting.Indented);
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
    }
}
