using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.Sistema
{
    public class AreaDto
    {
        public string Nome { get; set; }
        public List<SistemaDto> ListaSistemas { get; set; }
    }
}
