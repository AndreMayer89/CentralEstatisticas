namespace CentralEstatisticas.Util.Cache
{
    public static class CeCache
    {
        private const string EstrategiaDeCacheNaoDefinida = "Estratégia de cache não definida.";

        private static CeCacheBase CACHE;

        public static CeCacheBase Obter()
        {
            if (CACHE == null)
            {
                throw new CentralEstatisticasException(EstrategiaDeCacheNaoDefinida);
            }
            return CACHE;
        }

        public static void RegistrarCache(CeCacheBase cache)
        {
            CACHE = cache;
        }
    }
}
