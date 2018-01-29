using System.Web;
using System.Web.Optimization;

namespace CentralEstatisticas
{
    public class BundleConfig
    {
        private const string SCRIPT_GERAL_AJAX = "~/Scripts/script-geral-ajax.js";

        private const string SCRIPT_DASHBOARD_GERAL = "~/Scripts/Dashboard/dashboard-geral.js";
        private const string SCRIPT_DASHBOARD_INDICADORES_TECNICOS = "~/Scripts/Dashboard/dashboard-indicadores-tecnicos.js";
        private const string SCRIPT_DASHBOARD_INDICADORES_NEGOCIO = "~/Scripts/Dashboard/dashboard-indicadores-negocio.js";

        private const string CSS_GERAL_SITE = "~/Content/Site.css";

        private const string BUNDLE_JS_GERAL = "~/bundles/scriptsGerais";
        private const string BUNDLE_JS_DASHBOARD = "~/bundles/scriptsDashboard";

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

            bundles.Add(new StyleBundle(BUNDLE_CSS_GERAL)
                .Include(CSS_GERAL_SITE)
            );
        }
    }
}
