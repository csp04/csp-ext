namespace Csp.Extensions.Reflections
{
    public static partial class Extensions
    {
        public static object Read(this object @this, string propertyName, object[] index = null) => @this?.GetType().GetProperty(propertyName).GetValue(@this, index);

        public static void Write(this object @this, string propertyName, object value, object[] index = null) => @this?.GetType().GetProperty(propertyName).SetValue(@this, value, index);

        public static bool CanWrite(this object @this, string propertyName) => @this != null ? @this.GetType().GetProperty(propertyName).CanWrite : false;

        public static bool CanRead(this object @this, string propertyName) => @this != null ? @this.GetType().GetProperty(propertyName).CanRead : false;

    }
}
