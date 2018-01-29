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

        private const string SQL_INSERIR = @"
            INSERT INTO dbo.sistema
	            (
	            empresa,
	            area,
	            nome,
	            url_base,
	            url_hom,
	            url_dev,
	            rota_api_indicadores_negocio,
	            id_usuario_responsavel,
	            ativo
	            )
            VALUES 
	            (
	            @empresa,
	            @area,
	            @nome,
	            @url_base,
	            @url_hom,
	            @url_dev,
	            @rota_api_indicadores_negocio,
	            @id_usuario_responsavel,
	            @ativo
	            )
            ";

        private const string SQL_ATUALIZAR = @"
            UPDATE 
	            dbo.sistema
            SET 
	            empresa = @empresa,
	            area = @area,
	            nome = @nome,
	            url_base = @url_base,
	            url_hom = @url_hom,
	            url_dev = @url_dev,
	            rota_api_indicadores_negocio = @rota_api_indicadores_negocio,
	            id_usuario_responsavel = @id_usuario_responsavel,
	            ativo = @ativo
            WHERE
                id_sistema = @id_sistema
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

        public int Salvar(int? idSistema, string empresa, string area, string nome, string url, string urlHom, string urlDev,
            string rotaApiIndicadoresNegocio, int idUsuarioResponsavel, bool ativo)
        {
            var parametros = new Dapper.DynamicParameters();
            parametros.Add("@empresa", empresa, System.Data.DbType.AnsiString);
            parametros.Add("@area", area, System.Data.DbType.AnsiString);
            parametros.Add("@nome", nome, System.Data.DbType.AnsiString);
            parametros.Add("@url_base", url, System.Data.DbType.AnsiString);
            parametros.Add("@url_hom", urlHom, System.Data.DbType.AnsiString);
            parametros.Add("@url_dev", urlDev, System.Data.DbType.AnsiString);
            parametros.Add("@rota_api_indicadores_negocio", rotaApiIndicadoresNegocio, System.Data.DbType.AnsiString);
            parametros.Add("@id_usuario_responsavel", idUsuarioResponsavel, System.Data.DbType.Int32);
            parametros.Add("@ativo", ativo ? 1 : 0, System.Data.DbType.Int32);
            if (idSistema.HasValue)
            {
                parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
                Execute(SQL_ATUALIZAR, parametros);
                return idSistema.Value;
            }
            else
            {
                return Query<int>(SQL_INSERIR, parametros).FirstOrDefault();
            }
        }
    }
}
