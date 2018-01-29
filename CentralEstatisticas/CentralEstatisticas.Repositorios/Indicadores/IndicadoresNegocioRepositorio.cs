using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Repositorios.Indicadores
{
    public class IndicadoresNegocioRepositorio : AdoHelper
    {
        private const string SQL_LISTAR_INDICADORES_SISTEMA = @"
            SELECT
	            min.id_sistema IdSistema,
	            min.data_inicio DataInicio,
	            min.data_fim DataFim,
	            ind.nome_indicador_negocio Nome,
	            ind.valor Valor
            FROM 
                dbo.medicao_indicador_negocio min
                INNER JOIN indicador_negocio ind ON min.id_medicao_indicador_negocio = ind.id_medicao_indicador_negocio
            WHERE
	            min.id_sistema = @id_sistema
            ";

        public IndicadoresNegocioRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<IndicadorNegocioEntidade> ListarIndicadores(int id)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", id, System.Data.DbType.Int32);
            return Query<IndicadorNegocioEntidade>(SQL_LISTAR_INDICADORES_SISTEMA, parametros);
        }
    }
}
