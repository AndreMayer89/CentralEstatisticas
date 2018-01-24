using CentralEstatisticas.Entidades;
using System.Collections.Generic;
using CentralEstatisticas.Util.Conexao;

namespace CentralEstatisticas.Repositorios
{
    public class IndicadoresTecnicosRepositorio : AdoHelper
    {
        public IndicadoresTecnicosRepositorio() : base(TipoConexao.DbCentral)
        {
        }

        public IEnumerable<IndicadorTecnicoEntidade> ListarIndicadores()
        {
            return Query<IndicadorTecnicoEntidade>("SELECT * FROM indicador_tecnico");
        }
    }
}
