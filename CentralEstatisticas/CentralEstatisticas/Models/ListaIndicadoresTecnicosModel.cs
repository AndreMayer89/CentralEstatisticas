using System.Collections.Generic;
using System.Web.Mvc;

namespace CentralEstatisticas.Models
{
    public class ListaIndicadoresTecnicosModel
    {
        public IEnumerable<SelectListItem> ListaSistemas { get; set; }
    }
}