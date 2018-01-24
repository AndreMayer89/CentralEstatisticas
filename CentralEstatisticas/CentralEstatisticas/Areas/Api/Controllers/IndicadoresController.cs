using CentralEstatisticas.Business;
using System;
using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [RoutePrefix("api/indicadores")]
    public class IndicadoresController : BaseApiController
    {
        [HttpGet]
        [Route("todos")]
        public object ObterIndicadores(int idSistema, DateTime dataInicio, DateTime dataFim)
        {
            return new
            {
                IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema),
                IndicadoresNegocio = new IndicadoresNegocioBusiness().ObterIndicadoresNoPeriodo(dataInicio, dataFim, idSistema)
            };
        }

        [HttpGet]
        [Route("tecnicos")]
        public object ObterIndicadoresTecnicos(int idSistema)
        {
            return new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema);
        }

        [HttpGet]
        [Route("negocio")]
        public object ObterIndicadoresNegocio(int idSistema, DateTime dataInicio, DateTime dataFim)
        {
            return new IndicadoresNegocioBusiness().ObterIndicadoresNoPeriodo(dataInicio, dataFim, idSistema);
        }
    }
}