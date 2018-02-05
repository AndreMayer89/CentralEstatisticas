using CentralEstatisticas.Business;
using CentralEstatisticas.Entidades.Dto.IndicadorTecnico;
using CentralEstatisticas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CentralEstatisticas.Controllers
{
    public class IndicadorTecnicoController : BaseMvcController
    {
        private IndicadoresTecnicosBusiness Business { get; set; }

        public IndicadorTecnicoController()
        {
            Business = new IndicadoresTecnicosBusiness();
        }

        public ViewResult Index()
        {
            return View(new ListaIndicadoresTecnicosModel
            {
                ListaSistemas = new SistemaBusiness().Listar().Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Nome })
            });
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
        public JsonResult SalvarMedicao(int? idMedicao, int idSistema, DateTime data, IEnumerable<IndicadorParaSalvarDto> listaIndicadores)
        {
            Business.SalvarMedicao(idMedicao, idSistema, data, listaIndicadores);
            return ObterJsonSucessoPadrao();
        }

        public JsonResult RemoverMedicao(int idMedicao)
        {
            Business.RemoverMedicao(idMedicao);
            return ObterJsonSucessoPadrao();
        }
    }
}