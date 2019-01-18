using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

namespace APIQueryLibrary.Converters
{
    /// <summary>
    /// <see cref="APIs.QueryRequest"/>에서 적용할 수 있는 컨버터입니다.
    /// </summary>
    internal sealed class BoolToStringConverter : TypeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// 문자열 -> bool
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                switch (value as string)
                {
                    case "true":
                        return true;
                    case "false":
                        return false;
                    default:
                        throw new InvalidCastException();
                }
            }
            throw new InvalidCastException();
        }

        /// <summary>
        /// bool -> string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) => value.ToString();
    }
}
