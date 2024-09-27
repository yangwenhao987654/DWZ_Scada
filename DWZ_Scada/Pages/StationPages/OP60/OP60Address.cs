namespace DWZ_Scada.Pages.StationPages.OP60
{
    public class OP60Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "";

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
        /// 进站机台号1-2
        /// </summary>
        public static readonly string EntryStationNumber = "";

        /// <summary>
        /// 进站工位 A-B
        /// </summary>
        public static readonly string EntryStationPos = "";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult = "";
    }
}
