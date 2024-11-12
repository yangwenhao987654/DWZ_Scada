namespace DWZ_Scada.Pages.PLCAlarm
{
    public class SingleAlarmAddress
    {
        /// <summary>
        /// 连续地址索引 索引从开始
        /// </summary>
        public int Index;

        /// <summary>
        /// 全地址
        /// </summary>
        public string SubAddress;

        /// <summary>
        /// 报警名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlarmType;

        public SingleAlarmAddress(int index)
        {
            Index = index;
        }

        public SingleAlarmAddress()
        {

        }
    }
}
