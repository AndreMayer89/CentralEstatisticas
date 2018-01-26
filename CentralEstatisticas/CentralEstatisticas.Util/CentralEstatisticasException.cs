using System;

namespace CentralEstatisticas.Util
{
    public class CentralEstatisticasException : Exception
    {
        public CentralEstatisticasException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
