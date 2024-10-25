namespace DWZ_Scada.Pages.StationPages.OP60
{
    public class OP60Address
    {

        #region 进站请求
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "";


        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn = "";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "";
        #endregion

        #region 静态测试
        /// <summary>
        /// 静态测试开始信号
        /// </summary>
        public static readonly string StaticStartSignal = "";

        /// <summary>
        /// 静态测试1 SN
        /// </summary>
        public static readonly string StaticSN1 = "";

        /// <summary>
        /// 静态测试1结果
        /// </summary>
        public static readonly string StaticResult1 = "";

        /// <summary>
        /// 静态测试2 SN
        /// </summary>
        public static readonly string StaticSN2 = "";

        /// <summary>
        /// 静态测试2结果
        /// </summary>
        public static readonly string StaticResult2 = "";
        #endregion

        #region 动态测试
        /// <summary>
        /// 动态测试开始信号
        /// </summary>
        public static readonly string DynamicsStartSignal = "";

        /// <summary>
        /// 动态测试1 SN
        /// </summary>
        public static readonly string DynamicsSN1 = "";

        /// <summary>
        /// 动态测试1结果
        /// </summary>
        public static readonly string DynamicsResult1 = "";

        /// <summary>
        /// 动态测试2 SN
        /// </summary>
        public static readonly string DynamicsSN2 = "";

        /// <summary>
        /// 动态测试2结果
        /// </summary>
        public static readonly string DynamicsResult2 = "";
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
        #endregion

    }
}
