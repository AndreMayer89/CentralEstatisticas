using CentralEstatisticas.Business;
using CentralEstatisticas.Models;
using System;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listaSistemasAgrupados = new SistemaBusiness().ListarAgrupadosPorEmpresaEArea();
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
        public JsonResult ObterIndicadores(int idSistema, DateTime? dataInicio, DateTime? dataFim)
        {
            return Json(new
            {
                Sistema = new SistemaBusiness().Obter(idSistema),
                IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema),
                IndicadoresNegocio = new IndicadoresNegocioBusiness().ObterIndicadores(idSistema)
            });
        }
    }
}