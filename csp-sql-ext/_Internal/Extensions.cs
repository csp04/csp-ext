using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Csp.Extensions
{
    public static partial class Extensions
    {
        #region Internals
        internal static T ToEntity<T>(this IDataReader @this) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var entity = new T();

            var hash = new HashSet<string>(Enumerable.Range(0, @this.FieldCount)
                .Select(@this.GetName));

            foreach (PropertyInfo property in properties)
            {
                if (hash.Contains(property.Name))
                {
                    Type valueType = property.PropertyType;
                    property.SetValue(entity, @this[property.Name].To(valueType), null);
                }
            }

            foreach (FieldInfo field in fields)
            {
                if (hash.Contains(field.Name))
                {
                    Type valueType = field.FieldType;
                    field.SetValue(entity, @this[field.Name].To(valueType));
                }
            }

            return entity;
        }

        internal static IEnumerable<T> ToEntities<T>(this IDataReader @this) where T : new()
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var list = new List<T>();

            var hash = new HashSet<string>(Enumerable.Range(0, @this.FieldCount)
                .Select(@this.GetName));

            while (@this.Read())
            {
                var entity = new T();

                foreach (PropertyInfo property in properties)
                {
                    if (hash.Contains(property.Name))
                    {
                        Type valueType = property.PropertyType;
                        property.SetValue(entity, @this[property.Name].To(valueType), null);
                    }
                }

                foreach (FieldInfo field in fields)
                {
                    if (hash.Contains(field.Name))
                    {
                        Type valueType = field.FieldType;
                        field.SetValue(entity, @this[field.Name].To(valueType));
                    }
                }

                list.Add(entity);
            }

            return list;
        }

        internal static IEnumerable<(string name, object value)> ToNameValueList(this IDataReader @this)
        {
            return Enumerable.Range(0, @this.FieldCount)
                .Select(@this.GetName)
                .Select(name =>
                {
                    var value = @this[name];
                    return (name, value == DBNull.Value ? null : value);
                }).ToList();
        }

        internal static IEnumerable<IEnumerable<(string name, object value)>> ToNameValueLists(this IDataReader @this)
        {
            var list = new List<IEnumerable<(string name, object value)>>();
            while (@this.Read())
                list.Add(@this.ToNameValueList());
            return list;
        }

        internal static void AddParameters(this IDbCommand @this, IDictionary<string, object> values)
        {
            foreach (var kvp in values)
            {
                var param = @this.CreateParameter();
                param.ParameterName = kvp.Key;
                param.Value = kvp.Value ?? DBNull.Value;
                @this.Parameters.Add(param);
            }
        }

        internal static IDictionary<string, object> AsParameters<T>(this T @this)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var parameters = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                var value = property.GetValue(@this, null);
                parameters.Add(property.Name, value);
            }

            foreach (var field in fields)
            {
                var value = field.GetValue(@this);
                parameters.Add(field.Name, value);
            }

            return parameters;
        }

        internal static IDisposable _Open(this IDbConnection @this)
        {
            return new DisposableOpenConnection(@this);
        }

        #endregion

    }
}
