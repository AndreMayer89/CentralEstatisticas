using CentralEstatisticas.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralEstatisticas.Entidades
{
    public class IndicadoresSistemaEntidade
    {
        public SistemaEntidade Sistema { get; set; }
        public List<IndicadorEntidade> ListaIndicadores { get; set; }
        public string MensagemErro { get; set; }
        public TipoErro TipoErro { get; set; }
    }
}
