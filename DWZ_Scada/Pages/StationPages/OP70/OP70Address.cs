namespace DWZ_Scada.Pages.StationPages.OP70
{
    public class OP70Address
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
        /// 一次进一个: 进站 画像 最终码 同一个SN
        /// </summary>
        public static readonly string EntrySn = "D1100";


        /// <summary>
        /// 视觉开始信号
        /// </summary>
        public static readonly string VisionStart = "D3110";


        /// <summary>
        /// 视觉完成信号
        /// </summary>
        public static readonly string VisionFinish = "D3111";


        /// <summary>
        /// 视觉检测结果
        /// </summary>
        public static readonly string VisionResult = "D1159";

        /// <summary>
        /// 视觉出站复位
        /// </summary>
        public static readonly string VisionOut = "D3210";



        /// <summary>
        /// 最终码完成
        /// </summary>
        public static readonly string FinalCodeFinish = "D3120";

        /// <summary>
        /// 最终码内容
        /// </summary>
        public static readonly string FinalCodeInfo = "D1100";

        /// <summary>
        /// 最终码等级
        /// </summary>
        public static readonly string FinalCodeType = "D3121";

        /// <summary>
        /// 最终码结果 上位机根据码等级判断 返回PLC OK/NG
        /// </summary>
        public static readonly string FinalCodeResult = "D3220";


   


        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "D3000";







    }
}
