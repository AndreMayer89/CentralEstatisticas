using CentralEstatisticas.Business;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class SistemaController : BaseMvcController
    {
        private SistemaBusiness Business { get; set; }

        public SistemaController()
        {
            Business = new SistemaBusiness();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Cadastro(int? idSistema)
        {
            if (idSistema.HasValue)
            {
                Business.Obter(idSistema.Value);
            }
            return View();
        }

        [HttpPost]
        public JsonResult Listar()
        {
            return Json(new { Sistemas = Business.Listar() });
        }

        [HttpPost]
        public JsonResult Salvar(int? idSistema, string empresa, string area, string nome, int idUsuarioResponsavel, bool ativo)
        {
            Business.Salvar(idSistema, empresa, area, nome, idUsuarioResponsavel, ativo);
            return ObterJsonSucessoPadrao();
        }
    }
}