using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class BaseMvcController : Controller
    {
        protected JsonResult ObterJsonSucessoPadrao()
        {
            return Json(new { Sucesso = true });
        }
    }
}