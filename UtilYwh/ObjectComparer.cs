using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilYwh
{
    public class ObjectComparer
    {
        public static List<string> GetDifferences<T>(T obj1, T obj2)
        {
            var diffs = new List<string>();
            if (obj1==null || obj2==null)
            {
                diffs.Add("One of the Objects is null");
                return diffs;
            }

            var type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);
                if (value1==null && null==value2)
                {
                    continue;
                }
                else if (value1==null || value2==null || !value1.Equals(value2))
                {
                    diffs.Add($"Property: {property.Name}:{value1}->{value2}");   
                }
            }
            return diffs;
        }
    }
}
