using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios;
using System;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        public IndicadoresTecnicosSistemaEntidade ObterIndicadores(int idSistema)
        {
            return ObterIndicadores(new SistemaRepositorio().ObterSistema(idSistema));
        }

        private IndicadoresTecnicosSistemaEntidade ObterIndicadores(SistemaEntidade sistema)
        {
            throw new NotImplementedException();
        }
    }
}
