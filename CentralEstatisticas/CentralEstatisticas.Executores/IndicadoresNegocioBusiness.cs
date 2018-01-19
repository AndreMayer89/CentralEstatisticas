using CentralEstatisticas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Business
{
    public class IndicadoresNegocioBusiness
    {
        public List<dynamic> ListarIndicadores()
        {
            var lista = new List<dynamic>();
            var listaSistemas = new SistemaRepositorio().ListarTodos();
            foreach (var sistema in listaSistemas)
            {
                using (var cliente = new WebClient())
                {

                }
            }
            return lista;
        }
    }
}
