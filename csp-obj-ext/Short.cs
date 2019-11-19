using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static short ToShort(this object @this, CultureInfo cultureInfo) => Convert.ToInt16(@this, cultureInfo);
        public static short ToShort(this object @this) => @this.ToShort(CultureInfo.CurrentCulture);
    }
}
