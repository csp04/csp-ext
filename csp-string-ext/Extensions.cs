using System;
using System.Collections.Generic;
using System.Globalization;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static bool LessThan(this string str1, string str2) => string.Compare(str1, str2, StringComparison.CurrentCulture) < 0;

        public static bool GreaterThan(this string str1, string str2) => string.Compare(str1, str2, StringComparison.CurrentCulture) > 0;

        public static bool LessThanOrEqual(this string str1, string str2) => string.Compare(str1, str2, StringComparison.CurrentCulture) <= 0;

        public static bool GreaterThanOrEqual(this string str1, string str2) => string.Compare(str1, str2, StringComparison.CurrentCulture) >= 0;

        public static IEnumerable<string> Split(this string @this, int size)
        {
            for (int i = 0; i < @this.Length; i += size)
                yield return @this.Substring(i, Math.Min(size, @this.Length - i));
        }

        public static bool IsNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this);

        public static string Capitalize(this string @this) => @this.IsNullOrEmpty() ? @this :
                @this.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + (@this.Length > 1 ? @this.Substring(1).ToLower(CultureInfo.CurrentCulture) : string.Empty);

        public static string SubStringBefore(this string @this, string search)
        {
            var index = @this.IndexOf(search);

            return index < 0 ? @this : @this.Substring(0, index);
        }

        public static string SubstringAfter(this string @this, string search)
        {
            var index = @this.IndexOf(search);

            return index < 0 ? @this : @this.Substring(index + 1, @this.Length - (index + 1));
        }

        public static string Reverse(this string @this)
        {
            char[] charArray = @this.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
