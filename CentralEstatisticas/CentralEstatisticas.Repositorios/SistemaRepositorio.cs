using CentralEstatisticas.Entidades;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios
{
    public class SistemaRepositorio
    {
        public IEnumerable<SistemaEntidade> ListarTodos()
        {
            return new List<SistemaEntidade>()
            {
                new SistemaEntidade { Id = 1, Nome = "Localiza - Operações - Monitoramento", UrlIndicadoresNegocio = "" },
                new SistemaEntidade { Id = 1, Nome = "Localiza - Operações - Compra Peça", UrlIndicadoresNegocio = "" },
                new SistemaEntidade { Id = 1, Nome = "Localiza - Operações - Análise Orçamento", UrlIndicadoresNegocio = "" }
            };
        }
    }
}
