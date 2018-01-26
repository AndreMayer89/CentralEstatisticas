using System.Configuration;

namespace CentralEstatisticas.Util
{
    public static class ConfigCentralEstatisticas
    {
        public static class Cache
        {
            public static bool Desabilitar { get { return false; } }
            public static int PrazoCacheCurto { get { return 5; } }
        }

        public static string Ambiente { get { return ConfigurationManager.AppSettings["Ambiente"]; } }
    }
}
