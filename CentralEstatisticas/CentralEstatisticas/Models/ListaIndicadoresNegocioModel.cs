using System.Collections.Generic;
using System.Web.Mvc;

namespace CentralEstatisticas.Models
{
    public class ListaIndicadoresNegocioModel
    {
        public IEnumerable<SelectListItem> ListaSistemas { get; set; }
    }
}