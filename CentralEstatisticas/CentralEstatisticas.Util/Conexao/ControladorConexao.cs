using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Util.Conexao
{
    public class ControladorConexao : IDisposable
    {
        private Dictionary<TipoConexao, IDbConnection> _currentConnectionDic = new Dictionary<TipoConexao, IDbConnection>();
        private Dictionary<TipoConexao, IDbTransaction> _currentTransactionDic = new Dictionary<TipoConexao, IDbTransaction>();

        public IDbConnection this[TipoConexao index]
        {
            get
            {
                if (!_currentConnectionDic.ContainsKey(index))
                {
                    _currentConnectionDic[index] = FabricaConexao.CreateNewConnection(index);
                }

                return _currentConnectionDic[index];
            }
        }

        public IDbTransaction GetCurrentTransaction(TipoConexao index)
        {
            return !_currentTransactionDic.ContainsKey(index) ? null : _currentTransactionDic[index];
        }

        public IDbTransaction BeginTransaction(TipoConexao index)
        {
            if (!_currentTransactionDic.ContainsKey(index))
            {
                _currentTransactionDic[index] = this[index].BeginTransaction();
            }

            return _currentTransactionDic[index];
        }

        public void Dispose()
        {
            if (_currentConnectionDic != null)
            {
                foreach (KeyValuePair<TipoConexao, IDbConnection> valuePair in _currentConnectionDic)
                {
                    SafeDisposeConnection(valuePair.Value);
                }

                _currentConnectionDic.Clear();
            }
        }

        private void SafeDisposeConnection(IDbConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch
            {
                //Aqui foi colocado o try catch para evitar efeitos colaterais de um erro no fechamento da conexão
            }
        }

        public void RollBackTransactions()
        {
            foreach (KeyValuePair<TipoConexao, IDbTransaction> valuePair in _currentTransactionDic)
            {
                valuePair.Value.Rollback();
            }
        }

        public void CommitTransactions()
        {
            foreach (KeyValuePair<TipoConexao, IDbTransaction> valuePair in _currentTransactionDic.OrderBy(kv => kv.Key))
            {
                valuePair.Value.Commit();
            }
        }
    }
}
