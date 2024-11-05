using HslCommunication.Profinet.Keyence;
using HslCommunication;
using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationUtilYwh.Communication.PLC
{
    public abstract class MyPlc
    {
        public string IP { get; set; }

        public int Port { get; set; }

        public abstract bool Connect(string ip, int port);

        public abstract bool ReadBool(string address, out bool value);

        public abstract bool ReadInt16(string address, out short value);

        public abstract bool ReadInt16(string address, ushort length ,out short[] value);

        public abstract bool ReadInt32(string address, ushort length, out int[] value);

        public abstract bool WriteInt16(string address,  short value);

        public abstract bool Read(string adr, string type, out string value);

        public abstract bool Write(string adr, string type, object value);


        public abstract bool WriteFloat(string adr, float value);


        public abstract bool ReadAlarm(string adr, out bool[] value, int length);

        public abstract void Dispose();

        /// <summary>
        /// 移除所有包含\\ \r \0 字符之后的所有字符 
        /// 去尾部
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAllCharactersAfterBackslashOrNull(string input)
        {
            // 查找反斜杠或空字符的位置
            //查找到第一个包含所有\\ 普通反斜杠 \0 空字符 \r回车 的索引 
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\0', '\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }

        public abstract bool ReadInt32(string address, out int value);
    }

    public enum DataType
    {
        String,
        Int16,
        Float,
        Boolean,
        Int32,
        Double,
    }
}
