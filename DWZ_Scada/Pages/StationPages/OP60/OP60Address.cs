namespace DWZ_Scada.Pages.StationPages.OP60
{
    public class OP60Address
    {

        #region 进站请求
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "D3100";


        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D1100";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "D3200";
        #endregion

        #region 静态测试
        /// <summary>
        /// 静态测试开始信号
        /// </summary>
        public static readonly string SafetyStartSignal = "D3110";

        /// <summary>
        /// 静态测试1 SN
        /// </summary>
        public static readonly string SafetyTestSN1 = "D1150";

        /// <summary>
        /// 静态测试1结果
        /// </summary>
        public static readonly string SafetyResult1 = "D3210";

        /// <summary>
        /// 静态测试开始信号
        /// </summary>
        public static readonly string SafetyStartSignal2 = "D3111";


        /// <summary>
        /// 静态测试2 SN
        /// </summary>
        public static readonly string SafetyTestSN2 = "D1160";

        /// <summary>
        /// 静态测试2结果
        /// </summary>
        public static readonly string SafetyResult2 = "D3211";
        #endregion

        #region 动态测试
        /// <summary>
        /// 动态测试开始信号
        /// </summary>
        public static readonly string AtlBrxStartSignal = "D3120";

        /// <summary>
        /// 动态测试1 SN
        /// </summary>
        public static readonly string AtlBrxTestSN1 = "D1170";

        /// <summary>
        /// 动态测试1结果
        /// </summary>
        public static readonly string AtlBrxResult1 = "D3220";

        /// <summary>
        /// 动态测试2开始信号
        /// </summary>
        public static readonly string AtlBrxStartSignal2 = "D3121";

        /// <summary>
        /// 动态测试2 SN
        /// </summary>
        public static readonly string AtlBrxTestSN2 = "D1180";

        /// <summary>
        /// 动态测试2结果
        /// </summary>
        public static readonly string AtlBrxResult2 = "D3221";
        #endregion

        #region 其他信号
        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "M1";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "";

        /// <summary>
        /// 心跳地址
        /// </summary>
        public static string HeartBeat = "D3010";
        #endregion

    }
}
