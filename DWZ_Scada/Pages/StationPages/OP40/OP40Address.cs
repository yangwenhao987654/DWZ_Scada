namespace DWZ_Scada.Pages.StationPages.OP40
{
    public class OP40Address
    {
        #region 进站请求
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static string EntrySignal = "D3100";

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "D1100";

        /// <summary>
        /// 进站结果
        /// </summary>
        public static string EntryResult = "D3200";
        #endregion

        #region 视觉检测
        /// <summary>
        /// 视觉开始信号
        /// </summary>
        public static readonly string VisionStart = "D302";

        /// <summary>
        /// 视觉完成信号
        /// </summary>
        public static readonly string VisionFinish = "D303";

        /// <summary>
        /// 视觉SN
        /// </summary>
        public static readonly string VisionSn = "D100";

        /// <summary>
        /// 视觉出站复位
        /// </summary>
        public static readonly string VisionOut = "D300";
        #endregion

        #region 焊接测试
        /// <summary>
        /// 绕线视觉检测结果
        /// </summary>
        public static readonly string VisionResult = "D200";

        /// <summary>
        /// 大电流放电次数
        /// </summary>
        public static readonly string DisChargeCount = "D5000";

        /// <summary>
        /// 焊接SN码
        /// </summary>
        public static readonly string WeldingSn = "D1120";

        /// <summary>
        /// 焊接完成
        /// </summary>
        public static readonly string WeldingFinish = "D3102";


        /// <summary>
        /// 焊接请求
        /// </summary>
        public static readonly string WeldingStart = "D3101";

        /// <summary>
        /// 允许焊接信号
        /// </summary>
        public static readonly string WeldingConfirm = "D3201";

        /// <summary>
        /// 大电流放电信号
        /// </summary>
        public static readonly string ChargeStart = "D3103";

        /// <summary>
        /// 探针使用次数
        /// </summary>
        public static readonly string ProbeUseCount = "D316";


        /// <summary>
        /// 电极使用次数
        /// </summary>
        public static readonly string ElecUseCount = "D318";


        /// <summary>
        /// 焊接结果
        ///PLC->上位机
        /// </summary>
        public static readonly string WeldingResult = "D1129";


        /// <summary>
        /// 焊接数据起始地址
        /// </summary>
        public static readonly string Welding_A_DataStart = "D1201";

        /// <summary>
        /// 焊接数据起始地址
        /// </summary>
        public static readonly string Welding_B_DataStart = "D1211";

        /// <summary>
        /// 焊接数据起始地址
        /// </summary>
        public static readonly string Welding_C_DataStart = "D1221";

        #endregion

        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "D3000";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "D3030";

    }
}
