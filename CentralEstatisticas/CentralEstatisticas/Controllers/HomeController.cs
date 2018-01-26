using CentralEstatisticas.Business;
using CentralEstatisticas.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel model = new HomeModel()
            {
                Empresas = new List<HomeModel.Empresa>
                {
                    new HomeModel.Empresa
                    {
                        Nome = "Localiza",
                        Areas = new List<HomeModel.AreaEmpresa>
                        {
                            new HomeModel.AreaEmpresa
                            {
                                Nome = "Operações",
                                Sistemas = new List<HomeModel.Sistema>
                                {
                                    new HomeModel.Sistema { Id = 1, Nome = "Monitoramento" },
                                    new HomeModel.Sistema { Id = 2, Nome = "Núcleo Manutenção e Compra Peças" },
                                    new HomeModel.Sistema { Id = 3, Nome = "Análise Orçamento" },
                                    new HomeModel.Sistema { Id = 4, Nome = "Administração Fornecedor" }
                                }
                            }
                        }
                    }
                }
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult ObterIndicadoresTecnicos(int idSistema)
        {
            return Json(new { IndicadoresTecnicos = new IndicadoresTecnicosBusiness().ObterIndicadores(idSistema) });
        }
    }
}