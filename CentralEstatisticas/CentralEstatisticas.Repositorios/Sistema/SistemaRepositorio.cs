using CentralEstatisticas.Entidades;
using System.Collections.Generic;
using System.Linq;
using CentralEstatisticas.Util.Conexao;

namespace CentralEstatisticas.Repositorios.Sistema
{
    public class SistemaRepositorio : AdoHelper
    {
        private const string SQL_LISTAR = @"
            SELECT 
	            id_sistema Id,
	            empresa Empresa,
	            area Area,
	            nome Nome,
	            url_base UrlBase,
	            url_hom UrlBaseHom,
	            url_dev UrlBaseDev,
	            rota_api_indicadores_negocio RotaApiIndicadores,
	            id_usuario_responsavel IdUsuarioResponsavel,
	            ativo Ativo
            FROM dbo.sistema
            ";

        public SistemaRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<SistemaEntidade> ListarTodos()
        {
            return Query<SistemaEntidade>(SQL_LISTAR);
        }

        public SistemaEntidade ObterSistema(int idSistema)
        {
            var parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            return Query<SistemaEntidade>(SQL_LISTAR + "WHERE id_sistema = @id_sistema ", parametros).FirstOrDefault();
        }
    }
}
