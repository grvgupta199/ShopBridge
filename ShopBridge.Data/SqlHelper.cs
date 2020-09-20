using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data
{
    public sealed class SqlHelper : IDisposable
    {
        readonly DbContext _dbContext;
        DbCommand _dbCommand;
        DbDataReader _dbDataReader;
        bool _isConnectionNeedToClosed;
        public SqlHelper(string query, params SqlParameter[] parameters)
        {
            _dbContext = new ShopBridgeContext();
            _dbCommand = _dbContext.Database.Connection.CreateCommand();
            _dbCommand.CommandText = query;
            _dbCommand.CommandTimeout = 0;
            if (parameters != null && parameters.Any())
                _dbCommand.Parameters.AddRange(parameters);
        }

        public static SqlHelper ExcuteProcedure(string query, params SqlParameter[] parameters)
        {
            return new SqlHelper(query,parameters);
        }

        public ObjectResult<T> ResultSetFor<T>()
        {
            if (_dbDataReader == null)
            {
                _dbDataReader = GetReader();
            }
            else
            {
                _dbDataReader.NextResult();
            }

            var objContext = ((IObjectContextAdapter)_dbContext).ObjectContext;

            return objContext.Translate<T>(_dbDataReader);
        }

        DbDataReader GetReader()
        {
            if (_dbContext.Database.Connection.State!=ConnectionState.Open)
            {
                _dbContext.Database.Connection.Open();
                _isConnectionNeedToClosed = true;
            }

            return _dbCommand.ExecuteReader();
        }



        public void Dispose()
        {
            if (_dbDataReader != null)
            {
                _dbDataReader.Dispose();
                _dbDataReader = null;
            }

            if (_isConnectionNeedToClosed)
            {
                _dbContext.Database.Connection.Close();
                _isConnectionNeedToClosed = false;
            }
        }

    }
}
