﻿using HslCommunication.Profinet.Keyence;
using HslCommunication;
using LogTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchSocket.Sockets;

namespace CommunicationUtilYwh.Communication.PLC
{
    public abstract class MyPlc
    {
        public string IP { get; set; }

        public int Port { get; set; }

        public bool IsConnect { get; set; }

        public abstract bool Connect(string ip, int port);

        #region 读取数据
        public abstract bool ReadBool(string address, out bool value);

        public abstract bool ReadBool(string address, ushort length, out bool[] value);


        public abstract bool ReadInt16(string address, out short value);

        public abstract bool ReadInt16(string address, ushort length, out short[] value);

        public abstract bool ReadUInt16(string address, out ushort value);

        public abstract bool ReadUInt16(string address, ushort length, out ushort[] value);


        public abstract bool ReadInt32(string address, out int value);
        public abstract bool ReadInt32(string address, ushort length, out int[] value);

        public abstract bool ReadUInt32(string address, out uint value);

        public abstract bool ReadUInt32(string address, ushort length, out uint[] value);


        public abstract bool ReadInt64(string address, out long value);

        public abstract bool ReadInt64(string address, ushort length, out long[] value);

        public abstract bool ReadUInt64(string address, out ulong value);

        public abstract bool ReadUInt64(string address, ushort length, out ulong[] value);


        public abstract bool ReadFloat(string address, out float value);


        public abstract bool ReadDouble(string address, out double value);

        public abstract bool ReadString(string address, ushort length, out string value);


        public abstract bool Read(string adr, string type, out string value);

        #endregion

        #region 写入数据
        public abstract bool WriteInt16(string address, short value);

        public abstract bool Write(string adr, string type, object value);

        public abstract bool WriteBool(string address, bool value);

        public abstract bool WriteFloat(string adr, float value);

        public abstract bool WriteInt32(string address, int parse);

        public abstract bool WriteInt64(string address, long value);

        public abstract bool WriteUInt16(string address, ushort value);
        public abstract bool WriteUInt32(string address, uint value);
        public abstract bool WriteUInt64(string address, ulong value);
        public abstract bool WriteString(string address, string value);

        #endregion

        public abstract void Dispose();

        /// <summary>
        /// 移除所有包含\\ \r \0 字符之后的所有字符 
        /// 去尾部
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAllCharactersAfterBackslashOrNull( string input)
        {
            // 查找反斜杠或空字符的位置
            //查找到第一个包含所有\\ 普通反斜杠 \0 空字符 \r回车 的索引 
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\0', '\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }

        /// <summary>
        /// 移除所有包含\\ \r \0 字符之后的所有字符 
        /// 去尾部
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveBackslashOrNull(string input)
        {
            // 查找反斜杠或空字符的位置
            //查找到第一个包含所有\\ 普通反斜杠 \0 空字符 \r回车 的索引 
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }
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
