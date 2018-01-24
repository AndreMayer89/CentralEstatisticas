using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [RoutePrefix("api/indicadores")]
    public class SistemaController
    {
        [HttpGet]
        [Route("todos")]
        public void ObterIndicadores(int idSistema)
        {

        }

        [HttpGet]
        [Route("tecnicos")]
        public void ObterIndicadoresTecnicos(int idSistema)
        {

        }

        [HttpGet]
        [Route("negocio")]
        public void ObterIndicadoresNegocio(int idSistema)
        {

        }
    }
}