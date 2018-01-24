using CentralEstatisticas.Util.Conexao;
using System;

namespace CentralEstatisticas.Util
{
    public class ContextoCentral : IDisposable
    {
        [ThreadStatic]
        private static ContextoCentral CONTEXTO_ATUAL;

        private DateTime horario;

        public static ContextoCentral Contexto
        {
            get
            {
                if (CONTEXTO_ATUAL == null)
                {
                    CONTEXTO_ATUAL = new ContextoCentral();
                }
                return CONTEXTO_ATUAL;
            }
        }

        public ControladorConexao ConnectionManager { get; private set; }

        private ContextoCentral()
        {
            ConnectionManager = new ControladorConexao();
            horario = DateTime.Now;
        }

        public void Dispose()
        {
            ConnectionManager.Dispose();
            CONTEXTO_ATUAL = null;
        }

        public void Commit()
        {
            ConnectionManager.CommitTransactions();
        }

        public void RollBack()
        {
            ConnectionManager.RollBackTransactions();
        }

        public void BeginTransaction(TipoConexao connectionIndex)
        {
            ConnectionManager.BeginTransaction(connectionIndex);
        }

        public DateTime Horario()
        {
            return horario;
        }
    }
}
