using System;

namespace CentralEstatisticas.Entidades
{
    public class IndicadorNegocioEntidade
    {
        public int IdSistema { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
