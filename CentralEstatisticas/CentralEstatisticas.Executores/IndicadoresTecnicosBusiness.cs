using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralEstatisticas.Business
{
    public class IndicadoresTecnicosBusiness
    {
        public IndicadoresParaDashboardDto ObterIndicadores(int idSistema)
        {
            return ObterIndicadores(new SistemaRepositorio().ObterSistema(idSistema));
        }

        private IndicadoresParaDashboardDto ObterIndicadores(SistemaEntidade sistema)
        {
            IEnumerable<IndicadorTecnicoEntidade> listaIndicadores = new IndicadoresTecnicosRepositorio().ListarIndicadores(sistema.Id);
            var retorno = new IndicadoresParaDashboardDto();
            foreach (var indicador in listaIndicadores)
            {
                if (!retorno.Indicadores.Any(i => i.IdTipo == indicador.IdTipo))
                {
                    retorno.Indicadores.Add(new IndicadorDashboardDto
                    {
                        Tipo = indicador.Tipo,
                        IdTipo = indicador.IdTipo,
                        Valores = new List<IndicadorDashboardDto.ValorIndicador>()
                    });
                }
                var indicadorRetorno = retorno.Indicadores.FirstOrDefault(i => i.IdTipo == indicador.IdTipo);
                indicadorRetorno.Valores.Add(new IndicadorDashboardDto.ValorIndicador { Data = indicador.Data, Valor = indicador.Valor });
            }
            return retorno;
        }

        public void Salvar(int idSistema, DateTime data, IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            int idMedicao = new IndicadoresTecnicosRepositorio().SalvarMedicao(idSistema, data);
            foreach (var indicador in listaIndicadores)
            {
                new IndicadoresTecnicosRepositorio().SalvarIndicador(idMedicao, indicador.IdTipo, indicador.Valor);
            }
        }
    }
}
