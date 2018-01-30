using System;

namespace CentralEstatisticas.Entidades.Dto.IndicadorNegocio
{
    public class MedicaoIndicadorNegocioDto
    {
        public int IdSistema { get; set; }
        public int IdMedicao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
