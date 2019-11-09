using System;
using System.Globalization;
using System.Linq;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static string ToHex(this string @this)
        {

            return @this.Select(c => ((int)c).ToString("X2", CultureInfo.CurrentCulture)).Join();
        }

        public static string FromHex(this string @this) => Enumerable.Range(0, (!@this.IsNullOrEmpty() ? @this.Length : 0) / 2)
                             .Select(i => (char)Convert.ToByte(@this.Substring(i * 2, 2), 16))
                             .Join();
    }
}
