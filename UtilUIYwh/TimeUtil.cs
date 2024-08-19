using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilYwh
{
    public class TimeUtil
    {
        public static bool SetLocalTime(DateTime currentTime)
        {
            ImportKernel32.SYSTEMTIME st = new ImportKernel32.SYSTEMTIME();
            st.wYear = (short)currentTime.Year;
            st.wMonth = (short)currentTime.Month;
            st.wDay = (short)currentTime.Day;
            st.wHour = (short)currentTime.Hour;
            st.wMinute = (short)currentTime.Minute;
            st.wSecond = (short)currentTime.Second;
            st.wMilliseconds = (short)currentTime.Millisecond;
            return ImportKernel32.SetSystemTime(ref st);
        }
    }
}
