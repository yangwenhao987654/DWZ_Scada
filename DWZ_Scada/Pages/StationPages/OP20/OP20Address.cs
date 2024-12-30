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
        /// 请求放入的绕线机
        /// </summary>

        public static readonly string PutPos = "D3103";

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
        public static readonly string WindingPos = "D3102";

        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly string Winding01Start = "D3110";

        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly string Winding01Finish = "D3130";


        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly List<string> WindingStartList = new List<string>()
        {
            "D3110",
            "D3111",
            "D3112",
            "D3113",
            "D3114",
            "D3115",
            "D3116",
            "D3117",
            "D3118",
            "D3119",
            "D3120",
            "D3121"
        };

        /// <summary>
        /// 绕线开始信号 上位机收到复位
        /// </summary>
        public static readonly List<string> WindingFinishList = new List<string>()
        {
            "D3130",
            "D3131",
            "D3132",
            "D3133",
            "D3134",
            "D3135",
            "D3136",
            "D3137",
            "D3138",
            "D3139",
            "D3140",
            "D3141"
        };

        /// <summary>
        /// SN-A地址集合
        /// </summary>
        public static readonly List<string> SNAddrList = new List<string>()
        {
            "D1200",
            "D1210",
            "D1220",
            "D1230",
            "D1240",
            "D1250",
            "D1260",
            "D1270",
            "D1280",
            "D1290",
            "D1300",
            "D1310",
            "D1320",
            "D1330",
            "D1340",
            "D1350",
            "D1360",
            "D1370",
            "D1380",
            "D1390",
            "D1400",
            "D1410",
            "D1420",
            "D1430",
        };



        /// <summary>
        /// 绕线SN码起始地址 绕线机1A
        /// </summary>
        public static readonly string WindingStartSn = "D1200";

        /// <summary>
        /// 读取PLC状态地址
        /// </summary>
        public static string State = "D3000";

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
