using System.Collections.Generic;

namespace DWZ_Scada.Pages.StationPages.OP20
{
    public class OP20Address
    {
        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal01 = "D3100";

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn01 = "D1100";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult01 = "D3200";


        /// <summary>
        /// 进站请求信号
        /// </summary>
        public static readonly string EntrySignal02 = "D3101";

        /// <summary>
        /// 进站SN码
        /// </summary>
        public static readonly string EntrySn02 = "D1110";

        /// <summary>
        /// 进站结果信号
        /// 上位机判断是否允许进站 返回Mes
        /// </summary>
        public static readonly string EntryResult02 = "D3201";

        /// <summary>
        /// 绕线放置完成位置 1-12 写0表示清空
        /// </summary>
        public static readonly string WindingPos = "";

        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly string Winding01Start = "M101";


        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly List<string> WindingStartList = new List<string>()
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        };



        /// <summary>
        /// 绕线SN码起始地址 绕线机1A
        /// </summary>
        public static readonly string WindingStartSn = "D1200";

        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "M1";

        /// <summary>
        /// 点检模式地址
        /// </summary>
        public static string SpotCheck = "";

        /// <summary>
        /// 进站机台号1-2
        /// </summary>
        public static readonly string EntryStationNumber = "";

        /// <summary>
        /// 进站工位 A-B
        /// </summary>
        public static readonly string EntryStationPos = "";

    }
}
