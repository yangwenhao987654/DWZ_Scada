namespace DWZ_Scada.Pages.StationPages.OP10
{
    public class OP10Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "D3100";

        /// <summary>
        /// 进站结果信号
        /// </summary>
        public static readonly string EntryResult = "D3200";

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D1100";


        /// <summary>
        /// 视觉1 SN码
        /// </summary>
        public static readonly string Vision1_Sn = "D1110";


        /// <summary>
        /// 视觉2 SN码
        /// </summary>
        public static readonly string Vision2_Sn = "D1120";

        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "D3000";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "D3030";


        /// <summary>
        /// 心跳地址
        /// </summary>
        public static string HeartBeat = "D3010";

        /// <summary>
        /// 采集信号
        /// </summary>
        public static readonly string Collect = "";

        /// <summary>
        /// 视觉1开始
        /// </summary>
        public static readonly string Vision1Start = "D3101";

        /// <summary>
        /// 视觉1完成
        /// </summary>
        public static readonly string Vision1Finish = "D3102";


        /// <summary>
        /// 视觉2开始
        /// </summary>
        public static readonly string Vision2Start = "D3103";

        /// <summary>
        /// 视觉2完成
        /// </summary>
        public static readonly string Vision2Finish = "D3104";

        /// <summary>
        /// 视觉1结果信号
        /// </summary>
        public static readonly string Vision1Result = "D1119";

        /// <summary>
        /// 视觉2结果信号
        /// </summary>
        public static readonly string Vision2Result = "D1129";

        /// <summary>
        /// 视觉1写PLC出站采集结果
        /// </summary>
        public static readonly string Vision1_Out = "D3201";

        /// <summary>
        /// 视觉2出站采集结果
        /// </summary>
        public static readonly string Vision2_Out = "D3202";

        /// <summary>
        /// 型号
        /// </summary>
        public static readonly string Product = "D3021";

        /// <summary>
        /// 切换型号
        /// </summary>
        public static readonly string ChangeProduct = "D3020";
    }
}
