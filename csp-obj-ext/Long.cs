using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static long ToLong(this object @this, CultureInfo cultureInfo) => Convert.ToInt64(@this, cultureInfo);
        public static long ToLong(this object @this) => @this.ToLong(CultureInfo.CurrentCulture);

    }
}
