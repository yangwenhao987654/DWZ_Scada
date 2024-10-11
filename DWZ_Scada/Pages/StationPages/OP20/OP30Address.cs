namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class OP30Address
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
        public static readonly string AlarmAddress="";

        /// <summary>
        /// 报警地址长度 
        /// </summary>
        public  const  int AlarmAddressLength = 50;

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D310";


        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "M1";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "";


        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "";
    }
}
