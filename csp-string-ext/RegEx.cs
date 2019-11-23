using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static string RegExReplace(this string @this, string regEx, string replace)
        {
            return Regex.Replace(@this, regEx, replace);
        }

        public static Match RegExMatch(this string @this, string regEx)
        {
            return Regex.Match(@this, regEx);
        }

        public static bool RegExIsMatch(this string @this, string regEx)
        {
            return Regex.IsMatch(@this, regEx);
        }

        public static IEnumerable<Match> RegExMatches(this string @this, string regEx)
        {
            foreach(Match match in Regex.Matches(@this, regEx))
            {
                yield return match;
            }
        }

        public static string[] RegExSplit(this string @this, string regEx)
        {
            return Regex.Split(@this, regEx);
        }
    }
}
