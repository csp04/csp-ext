using System;
using System.Data;

namespace Csp.Extensions
{
    internal class DisposableOpenConnection : IDisposable
    {
        private readonly IDbConnection _connection;

        public DisposableOpenConnection(IDbConnection connection)
        {
            _connection = connection;

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection.State != ConnectionState.Closed)
                    {
                        _connection.Close();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
