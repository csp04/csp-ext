using System;
using System.Collections.Generic;
using System.Data;

namespace Csp.Extensions
{
    public static partial class SqlExtensions
    {
        public static IEnumerable<T> Query<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            using (var cmd = @this.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;

                if (values != null)
                {
                    cmd.AddParameters(values);
                }

                using(var reader = cmd.ExecuteReader())
                {
                    return reader.ToEntities<T>();
                }
            }
        }

        public static IEnumerable<T> Query<T>(this IDbConnection @this, string sql, CommandType commandType) where T : new()
        {
            return @this.Query<T>(sql, commandType, null);
        }

        public static IEnumerable<T> Query<T>(this IDbConnection @this, string sql) where T : new()
        {
            return @this.Query<T>(sql, CommandType.Text);
        }

        public static IEnumerable<IEnumerable<(string name, object value)>> Query(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values)
        {
            using (var cmd = @this.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;

                if (values != null)
                {
                    cmd.AddParameters(values);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.ToNameValueLists();
                }
            }
        }

        public static IEnumerable<IEnumerable<(string name, object value)>> Query(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.Query(sql, commandType, null);
        }

        public static IEnumerable<IEnumerable<(string name, object value)>> Query(this IDbConnection @this, string sql)
        {
            return @this.Query(sql, CommandType.Text);
        }

        public static int Execute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            using (var cmd = @this.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;

                if (values != null)
                {
                    cmd.AddParameters(values);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        public static int Execute(this IDbConnection @this, string sql, CommandType commandType)
        {
            return @this.Execute(sql, commandType, null);
        }

        public static int Execute(this IDbConnection @this, string sql)
        {
            return @this.Execute(sql, CommandType.Text, null);
        }

        public static void BeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<T, int> progress,
                                                  Action<int> committed,
                                                  Action<Exception> rollbacked)
        {
            using (var transaction = @this.BeginTransaction())
            {
                bool completed = false;
                int rowsAffected = 0;
                Exception _ex = default;
                try
                {
                    
                    int cnt = 0;
                    foreach (var entity in entities)
                    {
                        var parms = entity.AsParameters();
                        rowsAffected += @this.Execute(sql, commandType, parms);
                        progress?.Invoke(entity, ++cnt);
                    }
                    transaction.Commit();
                    completed = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _ex = ex;
                }
                finally
                {
                    if(completed)
                    {
                        committed?.Invoke(rowsAffected);
                    }
                    else
                    {
                        rollbacked?.Invoke(_ex);
                    }
                }
            }
        }

        
        public static IEnumerable<T> OpenQuery<T>(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values) where T : new()
        {
            
            using(@this._Open())
            {
                return @this.Query<T>(sql, commandType, values);
            }
        }

        public static IEnumerable<T> OpenQuery<T>(this IDbConnection @this, string sql, CommandType commandType) where T : new()
        {
            using (@this._Open())
            {
                return @this.Query<T>(sql, commandType);
            }
        }

        public static IEnumerable<IEnumerable<(string name, object value)>> 
            OpenQuery(this IDbConnection @this, string sql, CommandType commandType, Dictionary<string, object> values)
        {
            using(@this._Open())
            {
                return @this.Query(sql, commandType, values);
            }
        }

        public static IEnumerable<IEnumerable<(string name, object value)>>
            OpenQuery(this IDbConnection @this, string sql, CommandType commandType)
        {
            using (@this._Open())
            {
                return @this.Query(sql, commandType);
            }
        }

        public static IEnumerable<IEnumerable<(string name, object value)>>
            OpenQuery(this IDbConnection @this, string sql)
        {
            using (@this._Open())
            {
                return @this.Query(sql, CommandType.Text);
            }
        }

        public static int OpenExecute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            using(@this._Open())
            {
                return @this.Execute(sql, commandType, values);
            }
        }

        public static int OpenExecute(this IDbConnection @this, string sql, CommandType commandType)
        {
            using (@this._Open())
            {
                return @this.Execute(sql, commandType);
            }
        }

        public static int OpenExecute(this IDbConnection @this, string sql)
        {
            using (@this._Open())
            {
                return @this.Execute(sql);
            }
        }

        public static void OpenBeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<T, int> progress,
                                                  Action<int> committed,
                                                  Action<Exception> rollbacked)
        {
            using (@this._Open())
            {
                @this.BeginTransactions<T>(sql, commandType, entities, progress, committed, rollbacked);
            }
        }
    }
}
