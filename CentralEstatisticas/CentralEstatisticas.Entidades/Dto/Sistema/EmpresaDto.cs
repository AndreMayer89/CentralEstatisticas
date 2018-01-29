using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.Sistema
{
    public class EmpresaDto
    {
        public string Nome { get; set; }
        public List<AreaDto> ListaAreas { get; set; }
    }
}
