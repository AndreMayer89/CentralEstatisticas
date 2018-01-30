using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class SistemaController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Cadastro(int? idSistema)
        {
            return View();
        }

        public JsonResult Listar()
        {
            throw new NotImplementedException();
        }

        public JsonResult Salvar(int? idSistema, string empresa, string area, string nome, int idUsuarioResponsavel, bool ativo)
        {
            throw new NotImplementedException();
        }
    }
}