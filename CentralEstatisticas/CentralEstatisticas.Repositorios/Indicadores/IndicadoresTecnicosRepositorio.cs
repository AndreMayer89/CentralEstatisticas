using CentralEstatisticas.Entidades;
using CentralEstatisticas.Util.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private const string SQL_INSERIR_MEDICAO = @"
            INSERT INTO dbo.medicao_indicador_tecnico
	            (
	            id_sistema,
	            data
	            )
            VALUES 
	            (
	            @id_sistema,
	            @data
	            )
            SELECT @@IDENTITY
            ";

        private const string SQL_ATUALIZAR_MEDICAO = @"
                UPDATE 
                    dbo.medicao_indicador_tecnico
                SET
                    id_sistema = @id_sistema,
                    data = @data
                WHERE
                    id_medicao_indicador_tecnico = @id_medicao_indicador_tecnico
            ";

        private const string SQL_INSERIR_INDICADOR = @"
            INSERT INTO dbo.indicador_tecnico
	            (
	            id_medicao_indicador_tecnico,
	            id_tipo_indicador_tecnico,
	            valor
	            )
            VALUES 
	            (
	            @id_medicao_indicador_tecnico,
	            @id_tipo_indicador_tecnico,
	            @valor
	            )
            ";

        private const string SQL_REMOVER_INDICADORES_MEDICAO = @"
            DELETE FROM dbo.indicador_tecnico WHERE id_medicao_indicador_tecnico = @id_medicao_indicador_tecnico
        ";

        private const string SQL_REMOVER_MEDICAO = @"
            DELETE FROM dbo.medicao_indicador_tecnico WHERE id_medicao_indicador_tecnico = @id_medicao_indicador_tecnico
        ";

        private const string SQL_LISTAR_MEDICOES = @"
            SELECT 
	            id_medicao_indicador_tecnico IdMedicao,
	            id_sistema IdSistema,
	            data Data
            FROM 
                dbo.medicao_indicador_tecnico
            WHERE
                id_sistema = @id_sistema
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

        public int SalvarMedicao(int? idMedicao, int idSistema, DateTime data)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            parametros.Add("@data", data, System.Data.DbType.DateTime);
            if (idMedicao.HasValue)
            {
                parametros.Add("@id_medicao_indicador_tecnico", idMedicao, System.Data.DbType.Int32);
                Execute(SQL_ATUALIZAR_MEDICAO, parametros);
                return idMedicao.Value;
            }
            else
            {
                return Query<int>(SQL_INSERIR_MEDICAO, parametros).FirstOrDefault();
            }
        }

        public void SalvarIndicador(int idMedicao, int idTipo, double valor)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_tecnico", idMedicao, System.Data.DbType.Int32);
            parametros.Add("@id_tipo_indicador_tecnico", idTipo, System.Data.DbType.Int32);
            parametros.Add("@valor", valor, System.Data.DbType.Double);
            Execute(SQL_INSERIR_INDICADOR, parametros);
        }

        public void RemoverIndicadores(int idMedicao)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_tecnico", idMedicao, System.Data.DbType.Int32);
            Execute(SQL_REMOVER_INDICADORES_MEDICAO, parametros);
        }

        public void RemoverMedicao(int idMedicao)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_medicao_indicador_tecnico", idMedicao, System.Data.DbType.Int32);
            Execute(SQL_REMOVER_MEDICAO, parametros);
        }

        public IEnumerable<MedicaoIndicadorTecnicoEntidade> ListarMedicoes(int idSistema)
        {
            Dapper.DynamicParameters parametros = new Dapper.DynamicParameters();
            parametros.Add("@id_sistema", idSistema, System.Data.DbType.Int32);
            return Query<MedicaoIndicadorTecnicoEntidade>(SQL_LISTAR_MEDICOES, parametros);
        }
    }
}
