using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Repositorios;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        public ResultadoIndicadoresDto ObterIndicadores(int idSistema)
        {
            return ObterIndicadores(new SistemaRepositorio().ObterSistema(idSistema));
        }

        private ResultadoIndicadoresDto ObterIndicadores(SistemaEntidade sistema)
        {
            IEnumerable<IndicadorTecnicoEntidade> listaIndicadores = new IndicadoresTecnicosRepositorio().ListarIndicadores(sistema.Id);
            var retorno = new ResultadoIndicadoresDto();
            foreach (var indicador in listaIndicadores)
            {

            }
            return retorno;
        }
    }
}
