using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Entidades
{
    public class IndicadoresTecnicosSistemaEntidade
    {
        public SistemaEntidade Sistema { get; set; }
        public List<Indicador> Indicadores { get; set; }

        public class Indicador
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
}
