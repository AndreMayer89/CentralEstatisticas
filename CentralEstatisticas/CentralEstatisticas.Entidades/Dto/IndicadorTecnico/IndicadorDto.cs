using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;

namespace CentralEstatisticas.Entidades.Dto.IndicadorTecnico
{
    public class IndicadorDto
    {
        public DateTime Data { get; set; }
        public List<ValorIndicador> Valores { get; set; }

        public class ValorIndicador
        {
            public TipoIndicadorTecnico Tipo { get; set; }
            public object Valor { get; set; }
        }
    }
}
