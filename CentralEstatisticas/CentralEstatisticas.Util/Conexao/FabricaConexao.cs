using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Util.Conexao
{
    public class FabricaConexao
    {
        private static ConcurrentDictionary<TipoConexao, ConexaoBaseGF> DICIONARIO_CONEXOES = new ConcurrentDictionary<TipoConexao, ConexaoBaseGF>();

        public static void RegistryConnectionFactory(bool sybase, TipoConexao connEnum, string connString)
        {
            DICIONARIO_CONEXOES[connEnum] = CreateNewFactory(connEnum);
        }

        internal static IDbConnection CreateNewConnection(TipoConexao _connEnum)
        {
            IDbConnection connection = DICIONARIO_CONEXOES[_connEnum].CreateNewConnection();
            connection.Open();
            return connection;
        }

        private static ConexaoBaseGF CreateNewFactory(TipoConexao connEnum)
        {
            DICIONARIO_CONEXOES[connEnum] = new Conexao(connEnum);
            return DICIONARIO_CONEXOES[connEnum];
        }
    }
}
