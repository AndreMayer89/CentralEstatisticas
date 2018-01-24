using CentralEstatisticas.Business;
using System;
using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [RoutePrefix("api/indicadores")]
    public class SistemaController : BaseApiController
    {
        [HttpGet]
        [Route("todos")]
        public void ObterIndicadores(int idSistema, DateTime dataInicio, DateTime dataFim)
        {

        }

        [HttpGet]
        [Route("tecnicos")]
        public void ObterIndicadoresTecnicos(int idSistema)
        {

        }

        [HttpGet]
        [Route("negocio")]
        public object ObterIndicadoresNegocio(int idSistema, DateTime dataInicio, DateTime dataFim)
        {
            return new IndicadoresNegocioBusiness().ObterIndicador(dataInicio, dataFim, idSistema);
        }
    }
}