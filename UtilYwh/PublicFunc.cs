
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;

namespace UtilYwh
{
    [Serializable]
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point2D()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Point2D(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point2D(object x, object y)
        {
            try
            {
                this.X = (double)x;
                this.Y = (double)y;
            }
            catch
            {
                this.X = 0;
                this.Y = 0;
            }
            
        }
        public Point2D(PointF p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }
        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }
        public static bool operator ==(Point2D b, Point2D c)
        {
            if ((object)b==null|| (object)c ==null)
            {
                return false;
            }
            if (b.X == c.X && b.Y == c.Y)
            {
                return true;
            }

            return false;
        }
        public static bool operator !=(Point2D b, Point2D c)
        {
            return !(b == c);
        }
        public static Point2D operator +(Point2D b, Point2D c)
        {
            return new Point2D(b.X + c.X, b.Y + c.Y);
        }
        public static Point2D operator -(Point2D b, Point2D c)
        {
            return new Point2D(b.X - c.X, b.Y - c.Y);
        }
        public double GetDistance()
        {
            return Sqrt(X * X + Y * Y);
        }
        public override string ToString()
        {
            return $"{X.ToString().PadRight(10,' ')},{Y.ToString().PadRight(10, ' ')}";
        }
        private static string padRightEx(string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if ((Point2D)obj==null)
            {
                return false;
            }
            return this==(Point2D)obj ;
        }
        public override int GetHashCode()
        {
            return (X.ToString()+Y.ToString()).GetHashCode();
        }
    }
    [Serializable]
    public struct Point3D
    {
        public double X;
        public double Y;
        public double U;
        public Point3D(double x, double y,double u)
        {
            this.X = x;
            this.Y = y;
            this.U = u;
        }
    }
    [Serializable]
    public struct Point4D
    {
        public double X;
        public double Y;
        public double U;
        public double Z;
        public Point4D(double x, double y, double u,double z)
        {
            this.X = x;
            this.Y = y;
            this.U = u;
            this.Z = z;
        }
    }
    public class ResetClass
    {
      
    }
    public static class PublicFunc
    {
        public static PerformanceCounter PerformanceCounter1;
        public static PerformanceCounter PerformanceCounter2;

        public static int GetMemorySize()
        {
            if (PerformanceCounter1 == null)
            {
                PerformanceCounter1 = new PerformanceCounter("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName);
            }
            //long num = Process.GetCurrentProcess().WorkingSet64;
            var num = PerformanceCounter1.NextValue();
            num = num / 1024;
            num = num / 1024;
            //return p1.NextValue().
            return (int)num;
        }

        public static float GetCpuRate()
        {
            if (PerformanceCounter2 == null)
            {
                PerformanceCounter2 = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
                //PerformanceCounter2 = new PerformanceCounter("Processor Information", "% Processor Utility", Process.GetCurrentProcess().ProcessName);
            }
            var value = PerformanceCounter2.NextValue();
            value = value / Environment.ProcessorCount;
            return (float)Math.Round(value, 2);

        }
       
        public static int GetEnumIndex(Type type, string s)
        {
            try
            {
                return (int)(Enum.Parse(type, s));
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static double GetSqrt(double x,double y,int roundNum=3)
        {
            if (roundNum<0)
            {
                roundNum = 0;
            }
            if (roundNum>10)
            {
                roundNum =10;
            }
            return Round( Sqrt(x * x + y * y),roundNum);
        }


      

        public static double GetRate(int okCount, params int[] ngList)
        {
            int ngCount = 0;
            foreach (var item in ngList)
            {
                ngCount += item;
            }
            double rate = 100;
            if (okCount == 0)
            {
                if (ngCount == 0)
                {
                    rate = 100;
                }
                else
                {
                    rate = 0;
                }
            }
            else
            {
                rate = Round(okCount * 100.0 / (okCount + ngCount), 2);
            }
            return rate;
        }

        internal static string GetString(this string s)
        {
            string outStr = "";
            var ss = s.Split(new string[] { @"f" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in ss)
            {
                try
                {
                    outStr += (char)(item.ToInt()- 68473);

                }
                catch (Exception)
                {
                }
            }
            return outStr;

        }
 
        public static bool WriteCsv(string filename, string title, string data)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                fi.Directory.Create();
                bool flag = fi.Exists;
                using (StreamWriter sw = new StreamWriter(fi.FullName,true,Encoding.Default))
                {
                    if (!flag)
                    {
                        sw.WriteLine(title);
                    }
                    sw.WriteLine(data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string ToFormatString(this float x,int length=6)
        {
            string format = $"{{0,-{length}}}";
            var result= string.Format(format, x);
            if (x>=0)
            {
                result = " " + result;
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }
        public static string ToFormatString(this double x, int length = 6)
        {
            string format = $"{{0,-{length}}}";
            var result = string.Format(format, x);
            if (x >= 0)
            {
                result = " " + result;
                result = result.Substring(0, result.Length - 1);
            }
            return result;
        }

        #region 字符串的扩展方法

        public static string ToHex(this int s)
        {
            return s.ToString("X").ToUpper();

        }
        public static byte[] ToBytes(this string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }


        public static int ToInt(this string s)
        {
          
                return (int)ToDouble(s);
         
          
        }
        public static int ToInt(this string s, bool isHex)
        {
            if (!isHex)
            {
                return (int)ToDouble(s);
            }
            try
            {
                return Convert.ToInt32(s, 16);
            }
            catch (Exception ex)
            {
                return int.MinValue;
            }
        }
        public static double ToDouble(this string s, int i = 4)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(s);
                d = Math.Round(d, i);
            }
            catch (Exception)
            {
                d = int.MinValue;
            }
            return d;
        }
        public static UInt64 ToUInt64(this string s)
        {
            UInt64 d = 0;
            try
            {
                d = Convert.ToUInt64(s);
            }
            catch (Exception)
            {
                d = int.MaxValue;
            }
            return d;
        }
      

        public static DateTime ToDateTime(this string s, string type = "yyyy-MM-dd HH:mm:ss:ff")
        {
            DateTime d = new DateTime();
            try
            {
                d = DateTime.ParseExact(s, type, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {

            }
            return d;
        }


        public static string AddComma(this string s, int count = 1)
        {
            if (count < 1)
            {
                return s;
            }
            for (int i = 0; i < count; i++)
            {
                s += ",";
            }
            return s;
        }
        #endregion


        public static string GetString(object o,string  defaultValue="")
        {
            if (o == null)
            {
                return defaultValue;
            }
            return o.ToString();
        }


        public static bool ToBool(this string s) 
        {
            s = s.ToUpper();
            if (s == "TRUE" || s == "1" || s == "OK")
            {
                return true;
            }
            return false;

        }


        public static bool IsVialidIp(string ip, int port)
        {

            try
            {
                IPAddress.Parse(ip);
                if (port < 1 || port > 65535)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }




     


        public static int[] ToIntArray(this double[] d)
        {
            if (d == null || d.Length == 0)
            {
                return null;
            }
            List<int> result = new List<int>();
            foreach (var item in d)
            {
                result.Add((int)item);//强制转换
            }
            return result.ToArray();

        }


        public static double[] ToDoubleArray(this int[] d)
        {
            if (d == null || d.Length == 0)
            {
                return null;
            }
            List<double> result = new List<double>();
            foreach (var item in d)
            {
                result.Add(item);
            }
            return result.ToArray();

        }
        public static float ToFloat(this string s, int i = 4)
        {
            float d = 0;
            try
            {
                d = (float)Convert.ToDouble(s);
                d = (float)Math.Round(d, i);
            }
            catch (Exception)
            {
                d = int.MinValue;
            }
            return d;
        }

        public static T ConvertType<T>(this ushort[] ushortBuff, out string errMsg, bool isLittle = true)
        {


            byte[] tmp;//中间变量
            T result = default(T);
            errMsg = "";
      

            byte[] buff = new byte[ushortBuff.Length * 2];
            for (int i = 0; i < ushortBuff.Length; i++)
            {
                if (isLittle)
                {
                    buff[i * 2] = (byte)(ushortBuff[i] & 0xFF);
                    buff[i * 2 + 1] = (byte)((ushortBuff[i] >> 8) & 0xFF);
                }
                else
                {
                    buff[i * 2] = (byte)((ushortBuff[i] >> 8) & 0xFF);
                    buff[i * 2 + 1] = (byte)(ushortBuff[i] & 0xFF);
                }
            }



            if (typeof(T) == typeof(byte[]))
            {
                result = (T)Convert.ChangeType(buff, typeof(T));
            }

            else if (typeof(T) == typeof(int))
            {
                if (buff.Length < 4)
                {
                    tmp = new byte[4];
                    buff.CopyTo(tmp, 0);
                    buff = tmp;
                }
                int i = BitConverter.ToInt32(buff, 0);
                result = (T)Convert.ChangeType(i, typeof(T));
            }

            else if (typeof(T) == typeof(int[]))
            {
                if (buff.Length % 4 != 0)
                {
                    tmp = new byte[(buff.Length / 4 + 1) * 4];
                    buff.CopyTo(tmp, 0);
                    buff = tmp;
                }
                int[] tmp1 = new int[buff.Length / 4];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp1[i] = BitConverter.ToInt32(buff, i * 4);

                }
                result = (T)(object)tmp1;

            }

            else if (typeof(T) == typeof(short))
            {
                short st = BitConverter.ToInt16(buff, 0);
                result = (T)Convert.ChangeType(st, typeof(T));
            }

            else if (typeof(T) == typeof(short[]))
            {
                short[] tmp1 = new short[buff.Length / 2];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp1[i] = BitConverter.ToInt16(buff, i * 2);
                }
                result = (T)(object)tmp1;
            }


            else if (typeof(T) == typeof(float))
            {
                if (buff.Length < 4)
                {
                    tmp = new byte[4];
                    buff.CopyTo(tmp, 0);
                    buff = tmp;
                }
                float st = BitConverter.ToSingle(buff, 0);
                result = (T)(object)st;
            }

            else if (typeof(T) == typeof(float[]))
            {
                if (buff.Length % 4 != 0)
                {
                    tmp = new byte[(buff.Length / 4 + 1) * 4];
                    buff.CopyTo(tmp, 0);
                    buff = tmp;
                }
                float[] tmp1 = new float[buff.Length / 4];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp1[i] = BitConverter.ToSingle(buff, i * 4);
                }
                result = (T)(object)tmp1;
            }
            else if (typeof(T) == typeof(double[]))
            {
                if (buff.Length % 8 != 0)
                {
                    tmp = new byte[(buff.Length / 8 + 1) * 8];
                    buff.CopyTo(tmp, 0);
                    buff = tmp;
                }
                double[] tmp1 = new double[buff.Length / 8];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp1[i] = BitConverter.ToDouble(buff, i * 8);
                }
                result = (T)(object)tmp1;
            }

            else if (typeof(T) == typeof(string))
            {
                string s = Encoding.ASCII.GetString(buff);
                result = (T)(object)s;
            }
            else
            {
                errMsg = $"No Type:{typeof(T)}";
            }
            return result;
        }


        public static T ConvertType<T>(this List<ushort> ushortBuff, out string errMsg, bool isLittle = true)
        {
            return ushortBuff.ToArray().ConvertType<T>(out errMsg, isLittle);
        }

        public static ushort[] GetUShortFormObject<T>(T t1, out string errMsg, bool isLittle = true)
        {
            errMsg = "";
            ushort[] result;
            byte[] tmp;
            if (typeof(T) == typeof(byte[]))
            {
                tmp = t1 as byte[];
                if (tmp.Length % 2 != 0)
                {
                    var tmp1 = new byte[tmp.Length + 1];
                    tmp.CopyTo(tmp1, 0);
                    tmp = tmp1;
                }
                result = new ushort[tmp.Length / 2];
                for (int i = 0; i < result.Length; i++)
                {
                    if (isLittle)
                    {
                        result[i] = (ushort)(tmp[i * 2] + (tmp[i * 2 + 1] << 8));
                    }
                    else
                    {
                        result[i] = (ushort)((tmp[i * 2] << 8) + (tmp[i * 2 + 1]));
                    }
                }
                return result;
            }
            if (typeof(T) == typeof(short))
            {
                tmp = BitConverter.GetBytes((short)(object)t1);
                return GetUShortFormObject<byte[]>(tmp, out errMsg, isLittle);
            }

            if (typeof(T) == typeof(short[]))
            {
                short[] tmp1 = t1 as short[];
                tmp = new byte[tmp1.Length * 2];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp[i * 2] = BitConverter.GetBytes(tmp1[i])[0];
                    tmp[i * 2 + 1] = BitConverter.GetBytes(tmp1[i])[1];
                }
                tmp = BitConverter.GetBytes((short)(object)t1);
                return GetUShortFormObject<byte[]>(tmp, out errMsg, isLittle);
            }


            if (typeof(T) == typeof(int))
            {
                tmp = BitConverter.GetBytes((int)(object)t1);
                return GetUShortFormObject<byte[]>(tmp, out errMsg, true);
            }

            if (typeof(T) == typeof(int[]))
            {
                int[] tmp1 = t1 as int[];
                tmp = new byte[tmp1.Length * 4];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp[i * 4] = BitConverter.GetBytes(tmp1[i])[0];
                    tmp[i * 4 + 1] = BitConverter.GetBytes(tmp1[i])[1];
                    tmp[i * 4 + 2] = BitConverter.GetBytes(tmp1[i])[2];
                    tmp[i * 4 + 3] = BitConverter.GetBytes(tmp1[i])[3];
                }
                return GetUShortFormObject<byte[]>(tmp, out errMsg, true);//int转Ushort全是小端模式,跟设备无关
            }

            if (typeof(T) == typeof(int))
            {
                tmp = BitConverter.GetBytes((float)(object)t1);
                return GetUShortFormObject<byte[]>(tmp, out errMsg, isLittle);
            }

            if (typeof(T) == typeof(float[]))
            {
                float[] tmp1 = t1 as float[];
                tmp = new byte[tmp1.Length * 4];
                for (int i = 0; i < tmp1.Length; i++)
                {
                    tmp[i * 4] = BitConverter.GetBytes(tmp1[i])[0];
                    tmp[i * 4 + 1] = BitConverter.GetBytes(tmp1[i])[1];
                    tmp[i * 4 + 2] = BitConverter.GetBytes(tmp1[i])[2];
                    tmp[i * 4 + 3] = BitConverter.GetBytes(tmp1[i])[3];
                }
                return GetUShortFormObject<byte[]>(tmp, out errMsg, isLittle);
            }



            if (typeof(T) == typeof(string))
            {
                string s = t1 as string;
                return GetUShortFormObject<byte[]>(Encoding.ASCII.GetBytes(s), out errMsg, isLittle);
            }
            errMsg = $"[No Type:{t1.GetType()}]:";
            return null;
        }

   
        public static byte[] AddCRC16Bytes(this byte[] bytes,bool isBig=true)
        {
            int len = bytes.Length;
            if (len > 0)
            {
                ushort crc = 0xFFFF;

                for (int i = 0; i < len; i++)
                {
                    crc = (ushort)(crc ^ (bytes[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }
                byte hi = (byte)((crc>>8) & 0xFF) ; 
                byte lo = (byte)(crc & 0xFF); 

                byte[] result = new byte[bytes.Length + 2];
                bytes.CopyTo(result, 0);
                if (isBig)
                {
                    result[bytes.Length] = lo;
                    result[bytes.Length + 1] = hi;
                }
                else
                {
                    result[bytes.Length] = hi;
                    result[bytes.Length + 1] = lo;
                }
              
                return result;
            }
            return bytes;

        }
   
        public static bool CheckCRC16(this byte[] bytes)
        {
            if (bytes.Length < 3)
            {
                return false;
            }
            byte[] tmp = bytes.ToList().GetRange(0, bytes.Length - 2).ToArray();
            byte[] result = tmp.AddCRC16Bytes();
            if (result.Length == bytes.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] != bytes[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static byte[] RemoveCRC16(this byte[] bytes)
        {
            if (!bytes.CheckCRC16())
            {
                return null;
            }
            return bytes.ToList().GetRange(0, bytes.Length - 2).ToArray();
        }

    }
}
