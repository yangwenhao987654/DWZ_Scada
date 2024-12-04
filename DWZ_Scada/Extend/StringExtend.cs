using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Extend
{
    public static class StringExtend
    {
        /// <summary>
        /// 移除所有包含\\ \r \0 字符之后的所有字符 
        /// 去尾部
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAllCharactersAfterBackslashOrNull(this string input)
        {
            // 查找反斜杠或空字符的位置
            //查找到第一个包含所有\\ 普通反斜杠 \0 空字符 \r回车 的索引 
            int backslashIndex = input.IndexOfAny(new char[] { '\\', '\0', '\r' });

            // 如果找到了反斜杠或空字符，截取字符串，只保留其之前的部分
            return backslashIndex != -1 ? input.Substring(0, backslashIndex) : input;
        }
    }
}
