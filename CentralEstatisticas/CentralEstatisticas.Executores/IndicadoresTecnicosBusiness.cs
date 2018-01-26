using CentralEstatisticas.Entidades;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Repositorios.Indicadores;
using CentralEstatisticas.Repositorios.Sistema;
using CentralEstatisticas.Util.Enum;
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
                if (!retorno.Indicadores.Any(i => i.Data == indicador.Data))
                {
                    retorno.Indicadores.Add(new IndicadorDto { Data = indicador.Data, Valores = new List<IndicadorDto.ValorIndicador>() });
                }
                var indicadorRetorno = retorno.Indicadores.FirstOrDefault(i => i.Data == indicador.Data);
                indicadorRetorno.Valores.Add(new IndicadorDto.ValorIndicador { Tipo = TipoIndicadorTecnico.Obter(indicador.IdTipo), Valor = indicador.Valor });
            }
            return retorno;
        }
    }
}
