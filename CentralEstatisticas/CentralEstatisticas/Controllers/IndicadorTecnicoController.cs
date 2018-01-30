using CentralEstatisticas.Entidades.Dto.IndicadorNegocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class IndicadorTecnicoController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Cadastro()
        {
            return View();
        }

        public JsonResult ListarMedicoes(int idSistema)
        {
            throw new NotImplementedException();
        }

        public JsonResult SalvarMedicao(int? idMedicao, int idSistema, DateTime data, IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            throw new NotImplementedException();
        }

        public JsonResult RemoverMedicao(int idMedicao)
        {
            throw new NotImplementedException();
        }
    }
}