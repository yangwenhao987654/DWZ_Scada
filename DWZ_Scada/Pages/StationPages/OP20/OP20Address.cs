namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class OP20Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal = "";

        /// <summary>
        /// 绕线放置完成位置 1-12 写0表示清空
        /// </summary>
        public static readonly string WindingPos = "";

        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly string Winding01Start = "M101";

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
        /// 绕线SN码起始地址 绕线机1A
        /// </summary>
        public static readonly string WindingStartSn = "";

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
