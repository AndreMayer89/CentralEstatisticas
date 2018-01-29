using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using System.Collections.Generic;
using System.Linq;

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
                if (!retorno.Indicadores.Any(i => i.IdTipo == indicador.IdTipo))
                {
                    retorno.Indicadores.Add(new IndicadorDto
                    {
                        Tipo = indicador.Tipo,
                        IdTipo = indicador.IdTipo,
                        Valores = new List<IndicadorDto.ValorIndicador>()
                    });
                }
                var indicadorRetorno = retorno.Indicadores.FirstOrDefault(i => i.IdTipo == indicador.IdTipo);
                indicadorRetorno.Valores.Add(new IndicadorDto.ValorIndicador { Data = indicador.Data, Valor = indicador.Valor });
            }
            return retorno;
        }
    }
}
