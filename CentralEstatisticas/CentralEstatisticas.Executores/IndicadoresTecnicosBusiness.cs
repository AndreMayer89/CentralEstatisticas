using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        public List<IndicadoresTecnicosSistemaEntidade> ListarIndicadores()
        {
            var lista = new List<IndicadoresTecnicosSistemaEntidade>();
            IEnumerable<SistemaEntidade> listaSistemas = new SistemaRepositorio().ListarTodos();
            foreach (var sistema in listaSistemas)
            {
                lista.Add(ObterIndicador(sistema));
            }
            return lista;
        }

        private IndicadoresTecnicosSistemaEntidade ObterIndicador(SistemaEntidade sistema)
        {
            throw new NotImplementedException();
        }
    }
}
