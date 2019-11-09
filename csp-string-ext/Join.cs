using System.Collections.Generic;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static string Join(this IEnumerable<string> @this, string seperator) => string.Join(seperator, @this);
        public static string Join(this IEnumerable<string> @this) => string.Join("", @this);

        public static string Join(this string[] @this, string seperator) => string.Join(seperator, @this);
        public static string Join(this string[] @this) => string.Join("", @this);

        public static string Join(this IEnumerable<char> @this, string seperator) => string.Join(seperator, @this);
        public static string Join(this IEnumerable<char> @this) => string.Join("", @this);

        public static string Join(this char[] @this, string seperator) => string.Join(seperator, @this);
        public static string Join(this char[] @this) => string.Join("", @this);
    }
}
