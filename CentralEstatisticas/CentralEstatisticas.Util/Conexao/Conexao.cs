using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CentralEstatisticas.Util.Conexao
{
    internal class Conexao : ConexaoBaseGF
    {
        public Conexao(TipoConexao connEnum) : base(connEnum.Nome, 1)
        {
        }

        internal override IDbConnection CreateNewConnection()
        {
            var configuration = ConfigurationManager.ConnectionStrings[NomeConexao];
            var factory = DbProviderFactories.GetFactory(configuration.ProviderName);
            var connection = factory.CreateConnection();

            if (connection == null)
                throw new Exception(string.Format("Não foi possível criar uma conexão para a connectionstring ( {0} )", configuration.Name));

            connection.ConnectionString = configuration.ConnectionString;
            return connection;
        }
    }
}
