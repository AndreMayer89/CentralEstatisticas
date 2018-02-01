using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class MedicaoIndicadorTecnicoDto
    {
        public int IdSistema { get; set; }
        public int IdMedicao { get; set; }
        public DateTime Data { get; set; }

        public IEnumerable<IndicadorMedicaoDto> Indicadores { get; set; }

        public class IndicadorMedicaoDto
        {
            public int IdTipo { get; set; }
            public double Valor { get; set; }
        }
    }
}
