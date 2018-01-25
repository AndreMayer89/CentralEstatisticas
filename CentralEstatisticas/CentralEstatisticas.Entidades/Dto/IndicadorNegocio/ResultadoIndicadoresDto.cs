using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorNegocio
{
    public class ResultadoIndicadoresDto : SaidaWebApiBaseDto
    {
        public List<IndicadorDto> Indicadores { get; set; }

        public ResultadoIndicadoresDto()
        {
            Indicadores = new List<IndicadorDto>();
        }
    }
}
