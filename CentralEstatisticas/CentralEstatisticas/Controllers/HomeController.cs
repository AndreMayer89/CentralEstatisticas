using CentralEstatisticas.Business;
using CentralEstatisticas.Models;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaSistemasAgrupados = new SistemaBusiness().ListarSistemasAgrupadosPorEmpresaEArea();
            HomeModel model = new HomeModel();
            foreach (var empresa in listaSistemasAgrupados)
            {
                HomeModel.Empresa empresaModel = new HomeModel.Empresa { Nome = empresa.Nome };
                foreach (var area in empresa.ListaAreas)
                {
                    HomeModel.AreaEmpresa areaModel = new HomeModel.AreaEmpresa { Nome = area.Nome };
                    foreach (var sistema in area.ListaSistemas)
                    {
                        areaModel.Sistemas.Add(new HomeModel.Sistema { Id = sistema.Id, Nome = sistema.Nome });
                    }
                    empresaModel.Areas.Add(areaModel);
                }
                model.Empresas.Add(empresaModel);
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult ObterIndicadoresTecnicos(int idSistema)
        {
            return Json(new { IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema) });
        }
    }
}