using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static byte[] ToBytes(this string @this, Encoding encoding) => encoding?.GetBytes(@this);

        public static byte[] ToBytes(this string @this, string encodingName) => @this.ToBytes(Encoding.GetEncoding(encodingName));

        public static byte[] ToBytes(this string @this) => @this.ToBytes(Encoding.Default);

        public static string FromBytes(this byte[] @this, Encoding encoding) => encoding?.GetString(@this);

        public static string FromBytes(this byte[] @this, string encodingName) => @this.FromBytes(Encoding.GetEncoding(encodingName));

        public static string FromBytes(this byte[] @this) => @this.FromBytes(Encoding.Default);

        public static string FromBytes(this IEnumerable<byte> @this, Encoding encoding) => encoding?.GetString(@this.ToArray());

        public static string FromBytes(this IEnumerable<byte> @this, string encodingName) => @this.FromBytes(Encoding.GetEncoding(encodingName));

        public static string FromBytes(this IEnumerable<byte> @this) => @this.FromBytes(Encoding.Default);
    }

}
