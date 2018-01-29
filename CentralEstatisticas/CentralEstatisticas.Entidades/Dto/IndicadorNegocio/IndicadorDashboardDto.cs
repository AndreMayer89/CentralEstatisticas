using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Entidades.Dto.IndicadorNegocio
{
    public class IndicadorDashboardDto
    {
        public string Nome { get; set; }
        public List<ValorIndicador> Valores { get; set; }

        public class ValorIndicador
        {
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }
            public string DataInicioString { get { return DataInicio.ToString("dd/MM/yyyy"); } }
            public string DataFimString { get { return DataFim.ToString("dd/MM/yyyy"); } }
            public object Valor { get; set; }
        }
    }
}
