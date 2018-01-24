using CentralEstatisticas.Entidades;
using CentralEstatisticas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        public List<IndicadoresTecnicosSistemaEntidade> ListarIndicadores()
        {
            var lista = new List<IndicadoresTecnicosSistemaEntidade>();
            var listaSistemas = new SistemaRepositorio().ListarTodos();
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
