using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static byte ToByte(this object @this, CultureInfo cultureInfo) => Convert.ToByte(@this, cultureInfo);
        public static byte ToByte(this object @this) => @this.ToByte(CultureInfo.CurrentCulture);
        public static byte ToByte(this object @this, int fromBase) => Convert.ToByte(@this.ToString(), fromBase);
    }
}
