namespace DWZ_Scada.Pages.StationPages.OP70
{
    public class OP70Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "M30";

        /// <summary>
        /// 视觉完成信号
        /// </summary>
        public static readonly string VisionFinish = "M31";


        /// <summary>
        /// 绕线视觉检测结果
        /// </summary>
        public static readonly string VisionResult = "D200";

        /// <summary>
        /// 视觉出站复位
        /// </summary>
        public static readonly string VisionOut = "D300";

        /// <summary>
        /// 最终码完成
        /// </summary>
        public static readonly string FinalCodeFinish = "M32";

        /// <summary>
        /// 最终码内容
        /// </summary>
        public static readonly string FinalCodeInfo = "D220";

        /// <summary>
        /// 最终码等级
        /// </summary>
        public static readonly string FinalCodeType = "D350";

        /// <summary>
        /// 最终码结果 上位机根据码等级判断 返回PLC OK/NG
        /// </summary>
        public static readonly string FinalCodeResult = "D320";

        /// <summary>
        /// 报警信息地址 起始地址
        /// </summary>
        public static readonly string AlarmAddress = "";

        /// <summary>
        /// 报警地址长度 
        /// </summary>
        public const int AlarmAddressLength = 50;

        /// <summary>
        /// 进站SN码
        /// 一次进一个: 进站 画像 最终码 同一个SN
        /// </summary>
        public static readonly string EntrySn = "D310";


        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "M1";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "M30";


        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "M20";
    }
}
