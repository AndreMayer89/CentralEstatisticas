using CentralEstatisticas.Entidades;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios
{
    public class SistemaRepositorio
    {
        public IEnumerable<SistemaEntidade> ListarTodos()
        {
            return new List<SistemaEntidade>
            {
                new SistemaEntidade
                {
                    Id = 1,
                    Nome = "Localiza - Operações - Monitoramento",
                    UrlBase = "https://wapps.localiza.com/GestaoFrotasMonitoramento",
                    RotaApiIndicadores = "api/indicadores/obter"
                },
                new SistemaEntidade
                {
                    Id = 2,
                    Nome = "Localiza - Operações - Compra Peça",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.CompraPecas/",
                    RotaApiIndicadores = "api/indicadores/obter"
                },
                new SistemaEntidade
                {
                    Id = 3,
                    Nome = "Localiza - Operações - Análise Orçamento",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.AnaliseOrcamento",
                    RotaApiIndicadores = "api/indicadores/obter"
                },
                new SistemaEntidade
                {
                    Id = 4,
                    Nome = "Localiza - Operações - Administração Fornecedor",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.AdministracaoFornecedor",
                    RotaApiIndicadores = "api/indicadores/obter"
                }
            };
        }
    }
}
