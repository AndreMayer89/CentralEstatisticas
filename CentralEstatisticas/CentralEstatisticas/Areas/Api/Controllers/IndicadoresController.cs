using CentralEstatisticas.Business;
using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [RoutePrefix("api/v1/indicadores")]
    public class IndicadoresController : BaseApiController
    {
        [HttpGet]
        [Route("")]
        public object ObterIndicadores(int idSistema)
        {
            return new
            {
                IndicadoresNegocio = new IndicadoresNegocioBusiness().ObterIndicadores(idSistema),
                IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema)
            };
        }
    }
}