using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private const string SQL_INSERIR_MEDICAO = @"
            INSERT INTO dbo.medicao_indicador_negocio
	            (
	            id_sistema,
	            data_inicio,
	            data_fim
	            )
            VALUES 
	            (
	            @id_sistema,
	            @data_inicio,
	            @data_fim
	            )
            ";

        private const string SQL_INSERIR_INDICADOR = @"
            INSERT INTO dbo.indicador_negocio
	            (
	            id_medicao_indicador_negocio,
	            nome_indicador_negocio,
	            valor
	            )
            VALUES 
	            (
	            @id_medicao_indicador_negocio,
	            @nome_indicador_negocio,
	            @valor
	            )
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

        public int SalvarMedicao(int idSistema, DateTime dataInicio, DateTime dataFim)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            parametros.Add("@data_inicio", dataInicio, System.Data.DbType.DateTime);
            parametros.Add("@data_fim", dataFim, System.Data.DbType.DateTime);
            return Query<int>(SQL_INSERIR_MEDICAO, parametros).FirstOrDefault();
        }

        public void SalvarIndicador(int idMedicao, string nome, double valor)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_negocio", idMedicao, System.Data.DbType.Int32);
            parametros.Add("@nome_indicador_negocio", nome, System.Data.DbType.AnsiString);
            parametros.Add("@valor", valor, System.Data.DbType.Double);
            Execute(SQL_INSERIR_INDICADOR, parametros);
        }
    }
}
