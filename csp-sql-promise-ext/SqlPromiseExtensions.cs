using System;
using System.Collections.Generic;
using System.Data;
using RSG;

namespace Csp.Extensions
{
    public static partial class SqlPromiseExtensions
    {
        #region Queries
        private static IPromise<IEnumerable<T>> onQuery<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            Func<IEnumerable<T>> invoker = () => SqlExtensions.Query<T>(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        private static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> onQuery(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values)
        {
            Func<IEnumerable<IEnumerable<(string name, object value)>>> invoker = () => SqlExtensions.Query(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        public static IPromise<IEnumerable<T>> Query<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            return @this.onQuery<T>(sql, commandType, values);
        }

        public static IPromise<IEnumerable<T>> Query<T>(this IDbConnection @this, string sql, CommandType commandType) where T : new()
        {
            return @this.onQuery<T>(sql, commandType, null);
        }

        public static IPromise<IEnumerable<T>> Query<T>(this IDbConnection @this, string sql) where T : new()
        {
            return @this.onQuery<T>(sql, CommandType.Text, null);
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> Query(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values)
        {
            return @this.onQuery(sql, commandType, values);
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> Query(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.onQuery(sql, commandType, null);
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> Query(this IDbConnection @this, string sql)
        {
            return @this.onQuery(sql, CommandType.Text, null);
        }
        #endregion

        #region Executes
        private static IPromise<int> onExecute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            Func<int> invoker = () => SqlExtensions.Execute(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        public static IPromise<int> Execute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            return @this.onExecute(sql, commandType, values);
        }

        public static IPromise<int> Execute(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.onExecute(sql, commandType, null);
        }

        public static IPromise<int> Execute(this IDbConnection @this, string sql)
        {
            return @this.onExecute(sql, CommandType.Text, null);
        }
        #endregion


        #region Open Queries
        private static IPromise<IEnumerable<T>> onOpenQuery<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            Func<IEnumerable<T>> invoker = () => SqlExtensions.OpenQuery<T>(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        public static IPromise<IEnumerable<T>> OpenQuery<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            return @this.onOpenQuery<T>(sql, commandType, values);
        }

        public static IPromise<IEnumerable<T>> OpenQuery<T>(this IDbConnection @this, string sql, CommandType commandType) where T : new()
        {
            return @this.onOpenQuery<T>(sql, commandType, null);
        }

        public static IPromise<IEnumerable<T>> OpenQuery<T>(this IDbConnection @this, string sql) where T : new()
        {
            return @this.onOpenQuery<T>(sql, CommandType.Text, null);
        }

        //--
        private static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> onOpenQuery(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values)
        {
            Func<IEnumerable<IEnumerable<(string name, object value)>>> invoker = () => SqlExtensions.OpenQuery(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> OpenQuery(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) 
        {
            return @this.onOpenQuery(sql, commandType, values);
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> OpenQuery(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.onOpenQuery(sql, commandType, null);
        }

        public static IPromise<IEnumerable<IEnumerable<(string name, object value)>>> OpenQuery(this IDbConnection @this, string sql)
        {
            return @this.onOpenQuery(sql, CommandType.Text, null);
        }
        #endregion

        #region Open Executes
        private static IPromise<int> onOpenExecute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            Func<int> invoker = () => SqlExtensions.OpenExecute(@this, sql, commandType, values);
            return invoker.AsyncInvokeAsPromise();
        }

        public static IPromise<int> OpenExecute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            return @this.onOpenExecute(sql, commandType, values);
        }

        public static IPromise<int> OpenExecute(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.onOpenExecute(sql, commandType, null);
        }

        public static IPromise<int> OpenExecute(this IDbConnection @this, string sql)
        {
            return @this.onOpenExecute(sql, CommandType.Text, null);
        }
        #endregion

        #region BeginTransactions

        public static IPromise BeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<T, int> progress,
                                                  Action<int> committed,
                                                  Action<Exception> rollbacked)
        {
            return RSGExtensions.AsyncInvokeAsPromise(() =>
                        SqlExtensions.BeginTransactions(@this, sql, commandType, entities, progress, committed, rollbacked));
        }

        public static IPromise OpenBeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<T, int> progress,
                                                  Action<int> committed,
                                                  Action<Exception> rollbacked)
        {
            return RSGExtensions.AsyncInvokeAsPromise(() =>
                        SqlExtensions.OpenBeginTransactions(@this, sql, commandType, entities, progress, committed, rollbacked));
        }

        #endregion
    }
}
