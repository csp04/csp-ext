

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

        public static void Each(this IQueryable items, Action<object> fn)
        {
            foreach (var item in items)
            {
                fn(item);
            }
        }

        public static void Each<T>(this IQueryable items, Action<T> fn)
        {
            foreach (var item in items)
            {
                if (item is T converted)
                    fn(converted);
                else
                    throw new Exception($"Cannot convert {item.GetType().FullName} to {typeof(T).GetType().FullName}.");
            }
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

   

        #region Get

        public static IEnumerable<T> GetIf<T>(this IEnumerable @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if(condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this IQueryable @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this IList @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this ICollection @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this Array @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this ArrayList @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> GetIf<T>(this Hashtable @this, Func<T, bool> condition)
        {
            foreach (var item in @this)
                if (item is T _this)
                {
                    if (condition != null && condition(_this))
                    {
                        yield return _this;
                    }
                }
        }

        public static IEnumerable<T> Get<T>(this IEnumerable @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this IQueryable @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this IList @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this ICollection @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this Array @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this ArrayList @this)
        {
            return @this.GetIf<T>(x => true);
        }

        public static IEnumerable<T> Get<T>(this Hashtable @this)
        {
            return @this.GetIf<T>(x => true);
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
