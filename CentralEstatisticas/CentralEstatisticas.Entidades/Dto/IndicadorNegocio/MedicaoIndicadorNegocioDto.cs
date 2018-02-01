using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorNegocio
{
    public class MedicaoIndicadorNegocioDto
    {
        public int IdSistema { get; set; }
        public int IdMedicao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public IEnumerable<IndicadorMedicaoDto> Indicadores { get; set; }

        public class IndicadorMedicaoDto
        {
            public string Nome { get; set; }
            public double Valor { get; set; }
        }
    }
}
