using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNull(this object @this) => @this == null;
        public static bool IsNotNull(this object @this) => !@this.IsNull();
        public static object ToObject(this object @this) => @this;
        public static T CastTo<T>(this object @this) => (T)@this;
        public static bool Between<T>(this T @this, T minValue, T maxValue) where T : IComparable<T> => minValue.CompareTo(@this) == -1 && @this.CompareTo(maxValue) == -1;
        public static bool InRange<T>(this T @this, T minValue, T maxValue) where T : IComparable<T> => @this.CompareTo(minValue) >= 0 && @this.CompareTo(maxValue) <= 0;

        public static bool In<T>(this T @this, params T[] values) => Array.IndexOf(values, @this) != -1;

        public static T DeepClone<T>(this T @this)
        {
            IFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, @this);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);

            }
        }

    }
}
