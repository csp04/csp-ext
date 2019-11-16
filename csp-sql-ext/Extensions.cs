using System;
using System.Collections.Generic;
using System.Data;

namespace Csp.Extensions
{
    public static partial class Extensions
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

                return cmd.ExecuteReader().ToEntities<T>();
            }
        }

        public static IEnumerable<T> Query<T>(this IDbConnection @this, string sql, CommandType commandType) where T : new()
        {
            return @this.Query<T>(sql, commandType, null);
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

        public static void BeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<int> commit,
                                                  Action<Exception> rollback)
        {
            using (var transaction = @this.BeginTransaction())
            {
                try
                {
                    int rowsAffected = 0;
                    foreach (var entity in entities)
                    {
                        var parms = entity.AsParameters();
                        rowsAffected += @this.Execute(sql, commandType, parms);
                    }
                    transaction.Commit();
                    commit?.Invoke(rowsAffected);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    rollback?.Invoke(ex);
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

        public static int OpenExecute(this IDbConnection @this, string sql, CommandType commandType, IDictionary<string, object> values)
        {
            using(@this._Open())
            {
                return @this.Execute(sql, commandType, values);
            }
        }

        public static void OpenBeginTransactions<T>(this IDbConnection @this,
                                                  String sql,
                                                  CommandType commandType,
                                                  IEnumerable<T> entities,
                                                  Action<int> commit,
                                                  Action<Exception> rollback)
        {
            using (@this._Open())
            {
                @this.BeginTransactions<T>(sql, commandType, entities, commit, rollback);
            }
        }
    }
}
