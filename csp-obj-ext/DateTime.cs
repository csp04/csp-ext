using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static DateTime ToDateTime(this object @this, CultureInfo cultureInfo) => Convert.ToDateTime(@this, cultureInfo);
        public static DateTime ToDateTime(this object @this) => @this.ToDateTime(CultureInfo.CurrentCulture);

    }
}
