using System;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static int ToInt(this object @this, CultureInfo cultureInfo) => Convert.ToInt32(@this, cultureInfo);
        public static int ToInt(this object @this) => @this.ToInt(CultureInfo.CurrentCulture);
    }
}
