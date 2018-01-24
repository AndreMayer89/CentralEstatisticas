using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Util.Conexao
{
    internal abstract class ConexaoBaseGF
    {
        protected string NomeConexao { get; private set; }

        public int CommitOrder { get; set; }

        public ConexaoBaseGF(string nomeConexao, int commitOrder)
        {
            NomeConexao = nomeConexao;
            CommitOrder = commitOrder;
        }

        internal abstract IDbConnection CreateNewConnection();
    }
}
