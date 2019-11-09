using System;
using System.Linq;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static string ToBinary(this string @this) => @this.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).Join();

        public static string FromBinary(this string @this) => @this.Split(8).Select(s => (char)Convert.ToByte(s, 2)).Join();
    }
}
