using CentralEstatisticas.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Repositorios.Sistema
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
                    Empresa = "Localiza",
                    Area = "Operações",
                    Nome = "Monitoramento",
                    UrlBase = "https://wapps.localiza.com/GestaoFrotasMonitoramento/",
                    UrlBaseHom = "https://wapps-h.localiza.com/GestaoFrotasMonitoramento/",
                    UrlBaseDev = "https://wapps-d.localiza.com/GestaoFrotasMonitoramento/",
                    RotaApiIndicadores = "api/indicadores/obter",
                    Ativo = true
                },
                new SistemaEntidade
                {
                    Id = 2,
                    Empresa = "Localiza",
                    Area = "Operações",
                    Nome = "Núcleo Manutenção e Compra Peça",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.CompraPecas/",
                    UrlBaseHom = "https://wapps-h.localiza.com/Manutencao/OP.ManutencaoCarro.CompraPecas/",
                    UrlBaseDev = "https://wapps-d.localiza.com/Manutencao/OP.ManutencaoCarro.CompraPecas/",
                    RotaApiIndicadores = "api/indicadores/obter",
                    Ativo = true
                },
                new SistemaEntidade
                {
                    Id = 3,
                    Empresa = "Localiza",
                    Area = "Operações",
                    Nome = "Análise Orçamento",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.AnaliseOrcamento/",
                    UrlBaseHom = "https://wapps-h.localiza.com/Manutencao/OP.ManutencaoCarro.AnaliseOrcamento/",
                    UrlBaseDev = "https://wapps-d.localiza.com/Manutencao/OP.ManutencaoCarro.AnaliseOrcamento/",
                    RotaApiIndicadores = "api/indicadores/obter",
                    Ativo = true
                },
                new SistemaEntidade
                {
                    Id = 4,
                    Empresa = "Localiza",
                    Area = "Operações",
                    Nome = "Administração Fornecedor",
                    UrlBase = "https://wapps.localiza.com/Manutencao/OP.ManutencaoCarro.AdministracaoFornecedor/",
                    UrlBaseHom = "https://wapps-h.localiza.com/Manutencao/OP.ManutencaoCarro.AdministracaoFornecedor/",
                    UrlBaseDev = "https://wapps-d.localiza.com/Manutencao/OP.ManutencaoCarro.AdministracaoFornecedor/",
                    RotaApiIndicadores = "api/indicadores/obter",
                    Ativo = true
                }
            };
        }

        public SistemaEntidade ObterSistema(int idSistema)
        {
            return ListarTodos().FirstOrDefault(s => s.Id == idSistema);
        }
    }
}
