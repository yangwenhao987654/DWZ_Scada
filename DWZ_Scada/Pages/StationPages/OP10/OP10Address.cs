namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "";

        /// <summary>
        /// 出战请求信号
        /// </summary>
        public static readonly string ExitSignal = "";

        /// <summary>
        /// 进站结果信号
        /// </summary>
        public static readonly string EntryResult = "";

        /// <summary>
        /// 出站结果信号
        /// </summary>
        public static readonly string ExitResult = "";


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
        public static readonly string EntrySn = "";

        /// <summary>
        /// 出站SN码
        /// </summary>
        public static readonly string ExitSn = "";

        /// <summary>
        /// 视觉1 SN码
        /// </summary>
        public static readonly string Vision1_Sn = "";


        /// <summary>
        /// 视觉2 SN码
        /// </summary>
        public static readonly string Vision2_Sn = "";

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

        /// <summary>
        /// 视觉1完成
        /// </summary>
        public static readonly string Vision1Finish = "";

        /// <summary>
        /// 视觉2完成
        /// </summary>
        public static readonly string Vision2Finish = "";

        /// <summary>
        /// 视觉1结果信号
        /// </summary>
        public static readonly string Vision1Result = "";

        /// <summary>
        /// 视觉2结果信号
        /// </summary>
        public static readonly string Vision2Result = "";

        /// <summary>
        /// 视觉1写PLC出站采集结果
        /// </summary>
        public static readonly string Vision1_Out = "";

        /// <summary>
        /// 视觉2出站采集结果
        /// </summary>
        public static readonly string Vision2_Out = "";
    }
}
