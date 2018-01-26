using CentralEstatisticas.Business;
using System;
using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [RoutePrefix("api/v1/indicadores")]
    public class IndicadoresController : BaseApiController
    {
        [HttpGet]
        [Route("")]
        public object ObterIndicadores(int idSistema, DateTime? dataInicio, DateTime? dataFim)
        {
            if (dataInicio.HasValue && dataFim.HasValue)
            {
                return new
                {
                    IndicadoresNegocio = new IndicadoresNegocioBusiness().ObterIndicadoresNoPeriodo(dataInicio.Value, dataFim.Value, idSistema),
                    IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema)
                };
            }
            return new
            {
                IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema)
            };
        }
    }
}