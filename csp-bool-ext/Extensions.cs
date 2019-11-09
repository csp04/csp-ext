using System;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        public static bool Not(this bool @this) => !@this;

        public static bool And(this bool @this, bool and) => @this && and;

        public static bool Or(this bool @this, bool or) => @this || or;

        public static void Then(this bool @this, Action action)
        {
            if (@this)
            {
                action?.Invoke();
            }
        }

        public static T Return<T>(this bool @this, T trueValue, T falseValue) => @this ? trueValue : falseValue;
    }
}
