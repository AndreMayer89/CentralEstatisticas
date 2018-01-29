using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util.Conexao;
using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios.Indicadores
{
    public class IndicadoresTecnicosRepositorio : AdoHelper
    {
        private const string SQL_LISTAR_INDICADORES_SISTEMA = @"
            SELECT
	            mit.id_sistema IdSistema,
	            mit.data Data,
	            it.id_tipo_indicador_tecnico IdTipo,
	            tit.nome Tipo,
	            it.valor Valor
            FROM 
	            dbo.medicao_indicador_tecnico mit
	            INNER JOIN indicador_tecnico it ON mit.id_medicao_indicador_tecnico = it.id_medicao_indicador_tecnico
	            INNER JOIN tipo_indicador_tecnico tit ON tit.id_tipo_indicador_tecnico = it.id_tipo_indicador_tecnico
            WHERE
	            mit.id_sistema = @id_sistema
            ";

        public IndicadoresTecnicosRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<IndicadorTecnicoEntidade> ListarIndicadores(int id)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", id, System.Data.DbType.Int32);
            return Query<IndicadorTecnicoEntidade>(SQL_LISTAR_INDICADORES_SISTEMA, parametros);
        }
    }
}
