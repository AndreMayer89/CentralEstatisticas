using CentralEstatisticas.Util.Enum;
using System.Collections.Generic;

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
