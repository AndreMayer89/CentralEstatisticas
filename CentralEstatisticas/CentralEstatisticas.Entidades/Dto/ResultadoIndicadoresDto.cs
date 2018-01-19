using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto
{
    public class ResultadoIndicadoresDto : SaidaWebApiBaseDto
    {
        public string NomeSistema { get; set; }
        public List<IndicadorDto> Indicadores { get; set; }

        public ResultadoIndicadoresDto()
        {
            Indicadores = new List<IndicadorDto>();
        }
    }
}
