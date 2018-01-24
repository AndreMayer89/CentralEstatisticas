using System;

namespace CentralEstatisticas.Entidades
{
    public class IndicadorTecnicoEntidade
    {
        public int IdSistema { get; set; }
        public DateTime Data { get; set; }
        public int IdTipo { get; set; }
        public double Valor { get; set; }
    }
}
