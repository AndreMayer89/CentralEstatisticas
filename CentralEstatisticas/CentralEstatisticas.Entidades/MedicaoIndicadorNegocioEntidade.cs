using System;

namespace CentralEstatisticas.Entidades
{
    public class MedicaoIndicadorNegocioEntidade
    {
        public int IdSistema { get; set; }
        public int IdMedicao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
