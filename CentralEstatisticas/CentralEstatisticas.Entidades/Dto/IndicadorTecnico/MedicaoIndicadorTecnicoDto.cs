using System;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class MedicaoIndicadorTecnicoDto
    {
        public int IdSistema { get; set; }
        public int IdMedicao { get; set; }
        public DateTime Data { get; set; }
    }
}
