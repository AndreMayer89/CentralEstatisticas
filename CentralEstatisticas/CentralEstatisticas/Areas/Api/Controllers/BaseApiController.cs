using CentralEstatisticas.Entidades.Dto;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CentralEstatisticas.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage CriarRespostaOk()
        {
            return CriarRespostaOk(new SaidaWebApiBaseDto());
        }

        protected HttpResponseMessage CriarRespostaOk(SaidaWebApiBaseDto resposta)
        {
            return Request.CreateResponse(HttpStatusCode.OK, resposta, "application/json");
        }
    }
}