using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.Utils
{
    public class BoolListConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType==typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType==typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string strValue)
            {
                return strValue.Split(',')
                    .Select(s => bool.TryParse(s.Trim(), out bool result) && result)
                    .ToList();
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType ==typeof(string) && value is List<bool> boolList)
            {
                return string.Join(',', boolList.Select(b => b.ToString()));
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
