using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static double ToDouble(this object @this, CultureInfo cultureInfo) => Convert.ToDouble(@this, cultureInfo);
        public static double ToDouble(this object @this) => @this.ToDouble(CultureInfo.CurrentCulture);

    }
}
