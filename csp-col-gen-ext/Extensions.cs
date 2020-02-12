

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            items.OfType<T>().Each(fn);
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

        public static void Each(this IQueryable items, Action<object> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each<T>(this IQueryable items, Action<T> fn)
        {
            items.OfType<T>().Each(fn);
        }

        public static void Each<T>(this IQueryable<T> items, Action<T> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each(this IQueryable items, Action<object, int> fn)
        {
            int index = 0;
            foreach (var item in items)
            {
                fn(item, index++);
            }
        }

        public static void Each<T>(this IQueryable<T> items, Action<T, int> fn)
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
            items.OfType<T>().Each(fn);
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
            items.OfType<T>().Each(fn);
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

        public static void Each<TKey, TValue>(this IDictionary<TKey, TValue> items, Action<TKey, TValue> fn)
        {
            foreach (var kvp in items)
                fn(kvp.Key, kvp.Value);
        }

        public static void Each<TKey, TValue>(this IDictionary<TKey, TValue> items, Action<TKey, TValue, int> fn)
        {
            int index = 0;
            foreach (var kvp in items)
                fn(kvp.Key, kvp.Value, index++);
        }
        #endregion

        #region Page

        public static IQueryable<T> Page<T>(this IQueryable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        //used by LINQ
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
        {
            int count = source.Count();
            int batches = (count / batchSize) + (count % batchSize == 0 ? 0 : 1);

            return Enumerable.Range(1, batches).Select(n => source.Page<T>(n, batchSize));
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IQueryable<T> source, int batchSize)
        {
            int count = source.Count();
            int batches = (count / batchSize) + (count % batchSize == 0 ? 0 : 1);

            return Enumerable.Range(1, batches).Select(n => source.Page<T>(n, batchSize));
        }

        #endregion
    }



}
