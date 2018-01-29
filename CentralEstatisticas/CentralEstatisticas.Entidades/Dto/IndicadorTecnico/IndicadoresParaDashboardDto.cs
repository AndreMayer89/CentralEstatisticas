using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class IndicadoresParaDashboardDto
    {
        public List<IndicadorDashboardDto> Indicadores { get; set; }

        public IndicadoresParaDashboardDto()
        {
            Indicadores = new List<IndicadorDashboardDto>();
        }
    }
}
