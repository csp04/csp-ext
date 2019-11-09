using System.Linq;
using System.Text;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static string ToRawString(this string @this, Encoding encoding) => @this.ToBytes(encoding).Select(b => (char)b).Join();

        public static string ToRawString(this string @this, string encodingName) => @this.ToRawString(Encoding.GetEncoding(encodingName));

        public static string ToRawString(this string @this) => @this.ToRawString(Encoding.Default);

        public static string FromRawString(this string @this, Encoding encoding) => @this.Select(c => (byte)c).FromBytes(encoding);

        public static string FromRawString(this string @this, string encodingName) => @this.FromRawString(Encoding.GetEncoding(encodingName));

        public static string FromRawString(this string @this) => @this.FromRawString(Encoding.Default);
    }
}
