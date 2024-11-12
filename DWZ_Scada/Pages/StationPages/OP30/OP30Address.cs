namespace DWZ_Scada.Pages.StationPages.OP30
{
    public class OP30Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "D3100";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "D3200";

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D1100";

        /// <summary>
        /// 视觉开始信号
        /// </summary>
        public static string Vision1Start = "D3101";

        /// <summary>
        /// 视觉完成信号
        /// </summary>
        public static readonly string VisionFinish = "D3102";

        /// <summary>
        /// 视觉SN
        /// </summary>
        public static readonly string VisionSn = "D1110";

        /// <summary>
        /// 绕线视觉检测结果
        /// </summary>
        public static readonly string VisionResult = "D1109";


        /// <summary>
        /// 视觉出站复位
        /// </summary>
        public static readonly string VisionOut = "D3201";

     


        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "D3000";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "D3030";


      



        public static string HeartBeat = "D3010";
    }
}
