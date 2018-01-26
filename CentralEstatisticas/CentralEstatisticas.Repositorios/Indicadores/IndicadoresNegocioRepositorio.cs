using CentralEstatisticas.Entidades.Dto.IndicadorNegocio;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios.Indicadores
{
    public class IndicadoresNegocioRepositorio : ApiBaseRepositorio<ResultadoIndicadoresDto>
    {
        public IndicadoresNegocioRepositorio(string urlBase, string rota) : base(urlBase, rota)
        {
        }

        public ResultadoIndicadoresDto Executar(DateTime dataInicio, DateTime dataFim)
        {
            return ExecutarChamadaGet(new Dictionary<string, object>
            {
                { "dataInicio", dataInicio },
                { "dataFim", dataFim }
            });
        }
    }
}
