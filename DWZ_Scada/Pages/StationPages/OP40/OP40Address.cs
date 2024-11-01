namespace DWZ_Scada.Pages.StationPages.OP40
{
    public class OP40Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static  string EntrySignal = "M30";

        /// <summary>
        /// 视觉开始信号
        /// </summary>
        public static readonly string VisionStart = "M32";

        /// <summary>
        /// 视觉完成信号
        /// </summary>
        public static readonly string VisionFinish = "M32";

        /// <summary>
        /// 视觉SN
        /// </summary>
        public static readonly string VisionSn = "D100";

        /// <summary>
        /// 绕线视觉检测结果
        /// </summary>
        public static readonly string VisionResult = "D200";

        /// <summary>
        /// 视觉出站复位
        /// </summary>
        public static readonly string VisionOut = "D300";

        /// <summary>
        /// 报警信息地址 起始地址
        /// </summary>
        public static readonly string AlarmAddress = "";

        /// <summary>
        /// 大电流放电次数
        /// </summary>
        public static readonly string DisChargeCount = "";

        /// <summary>
        /// 报警地址长度 
        /// </summary>
        public const int AlarmAddressLength = 50;

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D310";

        /// <summary>
        /// 焊接SN码
        /// </summary>
        public static readonly string WeldingSn = "D310";

        /// <summary>
        /// 焊接完成
        /// </summary>
        public static readonly string WeldingFinish = "M31";


        /// <summary>
        /// 焊接请求
        /// </summary>
        public static readonly string WeldingStart = "M31";

        /// <summary>
        /// 允许焊接信号
        /// </summary>
        public static readonly string WeldingConfirm = "M31";


        /// <summary>
        /// 焊接结果
        /// 上位机-》PLC
        /// </summary>
        public static readonly string WeldingResult = "D330";


        /// <summary>
        /// 焊接数据起始地址
        /// </summary>
        public static readonly string WeldingDataStart = "D330";

        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "M1";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "";

        /// <summary>
        /// 采集信号
        /// </summary>
        public static readonly string Collect = "";

        public static string EntryResult { get; set; } = "";
    }
}
