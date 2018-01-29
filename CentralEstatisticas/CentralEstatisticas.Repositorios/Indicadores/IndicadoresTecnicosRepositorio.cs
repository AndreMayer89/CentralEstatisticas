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

        private IEnumerable<IndicadorTecnicoEntidade> ListarIndicadoresMonitoramento()
        {
            var lista = new List<IndicadorTecnicoEntidade>();
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2017, 11, 1), 67109, 67, 7, 101, 296, 22.83, 6, 3.3));
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2017, 11, 16), 68207, 67, 5, 85, 312, 15.96, 7, 3.2));
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2017, 12, 1), 67884, 67, 5, 70, 306, 16.07, 7, 3.2));
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2017, 12, 16), 63858, 67, 0, 54, 168, 16.34, 4, 2.9));
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2018, 1, 1), 63858, 67, 0, 54, 168, 16.34, 4, 2.9));
            lista.AddRange(CriarIndicadoresData(1, new DateTime(2018, 1, 15), 63858, 67, 0, 54, 168, 16.34, 4, 2.9));
            return lista;
        }

        private IEnumerable<IndicadorTecnicoEntidade> ListarIndicadoresManutencaoECompraPeca()
        {
            var lista = new List<IndicadorTecnicoEntidade>();
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2017, 11, 1), 46239, 217, 2, 1, 170, 45.35, 6, 2.9));
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2017, 11, 16), 50649, 233, 2, 3, 182, 47.84, 7, 2.6));
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2017, 12, 1), 50993, 233, 2, 3, 192, 45.36, 7, 2.5));
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2017, 12, 16), 51182, 231, 2, 3, 192, 47.85, 7, 2.5));
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2018, 1, 1), 51182, 231, 2, 3, 192, 47.85, 7, 2.5));
            lista.AddRange(CriarIndicadoresData(2, new DateTime(2018, 1, 15), 51426, 231, 2, 3, 193, 51.15, 7, 2.5));
            return lista;
        }

        private IEnumerable<IndicadorTecnicoEntidade> ListarIndicadoresAnaliseOrcamento()
        {
            var lista = new List<IndicadorTecnicoEntidade>();
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2017, 11, 1), 20094, 94, 1, 1, 60, 65.69, 2, 0.7));
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2017, 11, 16), 23312, 101, 2, 17, 111, 63, 3, 0.9));
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2017, 12, 1), 24700, 101, 2, 20, 125, 60.52, 4, 0.8));
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2017, 12, 16), 24686, 101, 2, 20, 125, 58.16, 4, 0.8));
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2018, 1, 1), 24686, 101, 2, 20, 125, 58.16, 4, 0.8));
            lista.AddRange(CriarIndicadoresData(3, new DateTime(2018, 1, 15), 24686, 101, 2, 20, 125, 58.16, 4, 0.8));
            return lista;
        }

        private IEnumerable<IndicadorTecnicoEntidade> CriarIndicadoresData(int idSistema, DateTime data, int linhasDeCodigo,
            int qtdTestesUnitarios, int qtdBugs, int qtdVulnerabilidades, int qtdCodeSmells, double coberturaDeCodigo, int diasDebitoTecnico,
            double codigoDuplicado)
        {
            return new List<IndicadorTecnicoEntidade>
            {
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.LinhasDeCodigo.Id, Valor = linhasDeCodigo },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.QtdTestesUnitarios.Id, Valor = qtdTestesUnitarios },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.QtdBugs.Id, Valor = qtdBugs },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.QtdVulnerabilidades.Id, Valor = qtdVulnerabilidades },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.QtdCodeSmells.Id, Valor = qtdCodeSmells },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.CoberturaDeCodigo.Id, Valor = coberturaDeCodigo },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.DiasDebitoTecnico.Id, Valor = diasDebitoTecnico },
                new IndicadorTecnicoEntidade { Data = data, IdSistema = idSistema, IdTipo = TipoIndicadorTecnico.CodigoDuplicado.Id, Valor = codigoDuplicado }
            };
        }
    }
}
