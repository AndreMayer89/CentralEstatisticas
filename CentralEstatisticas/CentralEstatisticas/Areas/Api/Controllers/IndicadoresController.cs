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
            dynamic retorno = new { };
            if (dataInicio.HasValue && dataFim.HasValue)
            {
                retorno.IndicadoresNegocio = new IndicadoresNegocioBusiness().ObterIndicadoresNoPeriodo(dataInicio.Value, dataFim.Value, idSistema);
            }
            retorno.IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema);
            return retorno;
        }
    }
}