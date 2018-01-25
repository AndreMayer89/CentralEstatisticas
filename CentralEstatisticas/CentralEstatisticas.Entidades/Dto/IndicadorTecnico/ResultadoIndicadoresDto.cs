using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class ResultadoIndicadoresDto
    {
        public List<IndicadorDto> Indicadores { get; set; }

        public ResultadoIndicadoresDto()
        {
            Indicadores = new List<IndicadorDto>();
        }
    }
}
