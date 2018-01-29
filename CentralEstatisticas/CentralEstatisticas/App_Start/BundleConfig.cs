using System.Web.Optimization;

namespace CentralEstatisticas
{
    public static class BundleConfig
    {
        private const string SCRIPT_GERAL_AJAX = "~/Scripts/script-geral-ajax.js";

        private const string SCRIPT_DASHBOARD_GERAL = "~/Scripts/Dashboard/dashboard-geral.js";
        private const string SCRIPT_DASHBOARD_INDICADORES_TECNICOS = "~/Scripts/Dashboard/dashboard-indicadores-tecnicos.js";
        private const string SCRIPT_DASHBOARD_INDICADORES_NEGOCIO = "~/Scripts/Dashboard/dashboard-indicadores-negocio.js";

        private const string SCRIPT_SISTEMA_LISTA = "~/Scripts/Sistema/sistema-lista.js";
        private const string SCRIPT_SISTEMA_CADASTRO = "~/Scripts/Sistema/sistema-cadastro.js";

        private const string SCRIPT_INDICADORES_NEGOCIO_LISTA = "~/Scripts/Sistema/indicadores-negocio-lista.js";
        private const string SCRIPT_INDICADORES_NEGOCIO_CADASTRO = "~/Scripts/Sistema/indicadores-negocio-cadastro.js";

        private const string SCRIPT_INDICADORES_TECNICOS_LISTA = "~/Scripts/Sistema/indicadores-tecnicos-lista.js";
        private const string SCRIPT_INDICADORES_TECNICOS_CADASTRO = "~/Scripts/Sistema/indicadores-tecnicos-cadastro.js";

        private const string CSS_GERAL_SITE = "~/Content/Site.css";

        private const string BUNDLE_JS_GERAL = "~/bundles/scriptsGerais";
        private const string BUNDLE_JS_DASHBOARD = "~/bundles/scriptsDashboard";
        private const string BUNDLE_JS_SISTEMA = "~/bundles/scriptsSistema";
        private const string BUNDLE_JS_INDICADORES_NEGOCIO = "~/bundles/scriptsIndicadoresNegocio";
        private const string BUNDLE_JS_INDICADORES_TECNICOS = "~/bundles/scriptsIndicadoresTecnicos";

        private const string BUNDLE_CSS_GERAL = "~/bundles/css";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(BUNDLE_JS_GERAL)
                .Include(SCRIPT_GERAL_AJAX)
            );

            bundles.Add(new ScriptBundle(BUNDLE_JS_DASHBOARD)
                .Include(SCRIPT_DASHBOARD_GERAL)
                .Include(SCRIPT_DASHBOARD_INDICADORES_TECNICOS)
                .Include(SCRIPT_DASHBOARD_INDICADORES_NEGOCIO)
            );

            bundles.Add(new ScriptBundle(BUNDLE_JS_SISTEMA)
                .Include(SCRIPT_SISTEMA_LISTA)
                .Include(SCRIPT_SISTEMA_CADASTRO)
            );

            bundles.Add(new ScriptBundle(BUNDLE_JS_INDICADORES_NEGOCIO)
                .Include(SCRIPT_INDICADORES_NEGOCIO_LISTA)
                .Include(SCRIPT_INDICADORES_NEGOCIO_CADASTRO)
            );

            bundles.Add(new ScriptBundle(BUNDLE_JS_INDICADORES_TECNICOS)
                .Include(SCRIPT_INDICADORES_TECNICOS_LISTA)
                .Include(SCRIPT_INDICADORES_TECNICOS_CADASTRO)
            );

            bundles.Add(new StyleBundle(BUNDLE_CSS_GERAL)
                .Include(CSS_GERAL_SITE)
            );
        }
    }
}
