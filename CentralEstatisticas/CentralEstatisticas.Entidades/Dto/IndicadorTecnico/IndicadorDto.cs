using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class IndicadorDto
    {
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public List<ValorIndicador> Valores { get; set; }

        public class ValorIndicador
        {
            public DateTime Data { get; set; }
            public string DataString { get { return Data.ToString("dd/MM/yyyy"); } }
            public object Valor { get; set; }
        }
    }
}
