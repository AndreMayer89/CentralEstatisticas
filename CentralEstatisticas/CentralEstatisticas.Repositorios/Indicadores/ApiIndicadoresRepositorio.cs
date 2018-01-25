using CentralEstatisticas.Entidades.Dto;
using CentralEstatisticas.Entidades.Dto.IndicadorNegocio;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Repositorios.Indicadores
{
    public class ApiIndicadoresRepositorio : ApiBaseRepositorio<ResultadoIndicadoresDto>
    {
        public ApiIndicadoresRepositorio(string urlBase, string rota) : base(urlBase, rota)
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
