using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        #region Each
        public static void Each(this IEnumerable items, Action<object> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each<T>(this IEnumerable items, Action<T> fn)
        {
            foreach (var item in items)
            {
                if (item is T converted)
                    fn(converted);
                else
                    throw new Exception($"Cannot convert {item.GetType().FullName} to {typeof(T).GetType().FullName}.");
            }
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each(this IEnumerable items, Action<object, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each(this IList items, Action<object> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each<T>(this IList items, Action<T> fn)
        {
            foreach (var item in items)
            {
                if (item is T converted)
                    fn(converted);
                else
                    throw new Exception($"Cannot convert {item.GetType().FullName} to {typeof(T).GetType().FullName}.");
            }
        }

        public static void Each<T>(this IList<T> items, Action<T> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each(this IList items, Action<object, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each<T>(this IList<T> items, Action<T, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each(this ICollection items, Action<object> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each<T>(this ICollection items, Action<T> fn)
        {
            foreach (var item in items)
            {
                if (item is T converted)
                    fn(converted);
                else
                    throw new Exception($"Cannot convert {item.GetType().FullName} to {typeof(T).GetType().FullName}.");
            }
        }

        public static void Each<T>(this ICollection<T> items, Action<T> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each(this ICollection items, Action<object, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each<T>(this ICollection<T> items, Action<T, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }
        #endregion

        #region Get

        public static IEnumerable<T> Get<T>(this IEnumerable @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        public static IEnumerable<T> Get<T>(this IList @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        public static IEnumerable<T> Get<T>(this ICollection @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        public static IEnumerable<T> Get<T>(this Array @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        public static IEnumerable<T> Get<T>(this ArrayList @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        public static IEnumerable<T> Get<T>(this Hashtable @this)
        {
            foreach (var item in @this)
                if (item is T _this) yield return _this;
        }

        #endregion


    }



}
