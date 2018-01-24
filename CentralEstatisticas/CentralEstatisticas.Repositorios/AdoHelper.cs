using CentralEstatisticas.Util;
using CentralEstatisticas.Util.Conexao;
using System.Collections.Generic;
using System.Data;

namespace CentralEstatisticas.Repositorios
{
    public class AdoHelper
    {
        private TipoConexao _connectionIndex;

        protected IDbConnection Connection
        {
            get
            {
                return ContextoCentral.Contexto.ConnectionManager[_connectionIndex];
            }
        }

        protected IDbTransaction CurrentTransaction
        {
            get
            {
                return ContextoCentral.Contexto.ConnectionManager.GetCurrentTransaction(_connectionIndex);
            }
        }

        protected AdoHelper(TipoConexao connectionIndex)
        {
            _connectionIndex = connectionIndex;
        }

        protected IEnumerable<T> Query<T>(string sql)
        {
            return Dapper.SqlMapper.Query<T>(this.Connection, sql, null, null, true, null, null);
        }

        protected IEnumerable<T> Query<T>(string sql, object param)
        {
            return Dapper.SqlMapper.Query<T>(this.Connection, sql, param, null, true, null, null);
        }

        protected IEnumerable<T> Query<T>(string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Dapper.SqlMapper.Query<T>(this.Connection, sql, param, transaction, buffered, commandTimeout, commandType);
        }

        protected int Execute(string sql, object param)
        {
            return Dapper.SqlMapper.Execute(this.Connection, sql, param, null, null, null);
        }

        protected int Execute(string sql, object param, IDbTransaction transaction)
        {
            return Dapper.SqlMapper.Execute(this.Connection, sql, param, transaction, null, null);
        }

        protected int Execute(string sql, object param, CommandType commandType)
        {
            return Dapper.SqlMapper.Execute(this.Connection, sql, param, null, null, commandType);
        }

        protected int Execute(string sql, object param, IDbTransaction transaction, CommandType commandType)
        {
            return Dapper.SqlMapper.Execute(this.Connection, sql, param, transaction, null, commandType);
        }
    }
}
