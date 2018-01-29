using CentralEstatisticas.Entidades.Dto;
using CentralEstatisticas.Util;
using CentralEstatisticas.Util.Cache;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios.Indicadores
{
    public class IndicadoresNegocioApiRepositorio : ApiBaseRepositorio<ResultadoIndicadoresDto>
    {
        public IndicadoresNegocioApiRepositorio(string urlBase, string rota)
            : base(urlBase, rota)
        {
        }

        public ResultadoIndicadoresDto Executar(DateTime dataInicio, DateTime dataFim)
        {
            return CeCache.Obter().ExecutarFuncaoBusca<ResultadoIndicadoresDto>(
                new Func<DateTime, DateTime, ResultadoIndicadoresDto>(ExecutarSemCache),
                ConfigCentralEstatisticas.Cache.PrazoCacheCurto, dataInicio.Date, dataFim.Date.AddDays(1).AddMilliseconds(-1));
        }

        private ResultadoIndicadoresDto ExecutarSemCache(DateTime dataInicio, DateTime dataFim)
        {
            return ExecutarChamadaGet(new Dictionary<string, object>
            {
                { "dataInicio", dataInicio },
                { "dataFim", dataFim }
            });
        }
    }

    public class ResultadoIndicadoresDto : SaidaWebApiBaseDto
    {
        public List<IndicadorDto> Indicadores { get; set; }

        public ResultadoIndicadoresDto()
        {
            Indicadores = new List<IndicadorDto>();
        }

        public class IndicadorDto
        {
            public string Nome { get; set; }
            public object Valor { get; set; }
        }
    }
}
