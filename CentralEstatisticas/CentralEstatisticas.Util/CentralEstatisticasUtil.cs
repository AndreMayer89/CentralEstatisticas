namespace CentralEstatisticas.Util
{
    public static class CentralEstatisticasUtil
    {
        public static string Truncar(string texto, int tamanhoMaximo)
        {
            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto.Length > tamanhoMaximo ? texto.Substring(0, tamanhoMaximo) : texto;
            }
            return texto;
        }
    }
}
