using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorNegocio
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
