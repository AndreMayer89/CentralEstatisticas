using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util;
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
            SELECT @@IDENTITY
            ";

        private const string SQL_ATUALIZAR_MEDICAO = @"
                UPDATE 
                    dbo.medicao_indicador_negocio
                SET
                    id_sistema = @id_sistema,
                    data_inicio = @data_inicio,
                    data_fim = @data_fim
                WHERE
                    id_medicao_indicador_negocio = @id_medicao_indicador_negocio
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

        private const string SQL_REMOVER_INDICADORES_MEDICAO = @"
            DELETE FROM dbo.indicador_negocio WHERE id_medicao_indicador_negocio = @id_medicao_indicador_negocio
        ";

        private const string SQL_REMOVER_MEDICAO = @"
            DELETE FROM dbo.medicao_indicador_negocio WHERE id_medicao_indicador_negocio = @id_medicao_indicador_negocio
        ";

        private const string SQL_LISTAR_MEDICOES = @"
            SELECT 
	            id_medicao_indicador_negocio IdMedicao,
	            id_sistema IdSistema,
	            data_inicio DataInicio,
	            data_fim DataFim
            FROM 
                dbo.medicao_indicador_negocio
            WHERE
                id_sistema = @id_sistema
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

        public int SalvarMedicao(int? idMedicao, int idSistema, DateTime dataInicio, DateTime dataFim)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            parametros.Add("@data_inicio", dataInicio, System.Data.DbType.DateTime);
            parametros.Add("@data_fim", dataFim, System.Data.DbType.DateTime);
            if (idMedicao.HasValue)
            {
                parametros.Add("@id_medicao_indicador_negocio", idMedicao, System.Data.DbType.Int32);
                Execute(SQL_ATUALIZAR_MEDICAO, parametros);
                return idMedicao.Value;
            }
            else
            {
                return Query<int>(SQL_INSERIR_MEDICAO, parametros).FirstOrDefault();
            }
        }

        public void SalvarIndicador(int idMedicao, string nome, double valor)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_negocio", idMedicao, System.Data.DbType.Int32);
            parametros.Add("@nome_indicador_negocio", CentralEstatisticasUtil.Truncar(nome, 100), System.Data.DbType.AnsiString);
            parametros.Add("@valor", valor, System.Data.DbType.Double);
            Execute(SQL_INSERIR_INDICADOR, parametros);
        }

        public void RemoverIndicadores(int idMedicao)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_negocio", idMedicao, System.Data.DbType.Int32);
            Execute(SQL_REMOVER_INDICADORES_MEDICAO, parametros);
        }

        public void RemoverMedicao(int idMedicao)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_negocio", idMedicao, System.Data.DbType.Int32);
            Execute(SQL_REMOVER_MEDICAO, parametros);
        }

        public IEnumerable<MedicaoIndicadorNegocioEntidade> ListarMedicoes(int idSistema)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            return Query<MedicaoIndicadorNegocioEntidade>(SQL_LISTAR_MEDICOES, parametros);
        }
    }
}
