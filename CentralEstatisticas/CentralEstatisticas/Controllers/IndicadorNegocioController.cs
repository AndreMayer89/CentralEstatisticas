using CentralEstatisticas.Business;
using CentralEstatisticas.Entidades.Dto.IndicadorNegocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class IndicadorNegocioController : BaseMvcController
    {
        private IndicadoresNegocioBusiness Business { get; set; }

        public IndicadorNegocioController()
        {
            Business = new IndicadoresNegocioBusiness();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Cadastro(int? idMedicao)
        {
            if (idMedicao.HasValue)
            {
                Business.ObterMedicao(idMedicao.Value);
            }
            return View();
        }

        [HttpPost]
        public JsonResult ListarMedicoes(int idSistema)
        {
            return Json(new { Medicoes = Business.ListarMedicoes(idSistema) });
        }

        [HttpPost]
        public JsonResult SalvarMedicao(int? idMedicao, int idSistema, DateTime dataInicio, DateTime dataFim, 
            IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            Business.SalvarMedicao(idMedicao, idSistema, dataInicio, dataFim, listaIndicadores);
            return ObterJsonSucessoPadrao();
        }

        public JsonResult RemoverMedicao(int idMedicao)
        {
            Business.RemoverMedicao(idMedicao);
            return ObterJsonSucessoPadrao();
        }
    }
}