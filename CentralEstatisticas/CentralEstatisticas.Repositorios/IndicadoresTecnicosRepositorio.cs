using CentralEstatisticas.Entidades;
using System.Collections.Generic;
using CentralEstatisticas.Util.Conexao;
using System;

namespace CentralEstatisticas.Repositorios
{
    public class IndicadoresTecnicosRepositorio : AdoHelper
    {
        public IndicadoresTecnicosRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<IndicadorTecnicoEntidade> ListarIndicadores(int id)
        {
            return Query<IndicadorTecnicoEntidade>("SELECT * FROM indicador_tecnico");
        }
    }
}
