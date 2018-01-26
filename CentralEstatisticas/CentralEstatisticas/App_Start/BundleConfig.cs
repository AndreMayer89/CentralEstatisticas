using System.Web;
using System.Web.Optimization;

namespace CentralEstatisticas
{
    public class BundleConfig
    {
        private const string SCRIPT_GERAL_AJAX = "~/Scripts/script-geral-ajax.js";

        private const string CSS_GERAL_SITE = "~/Content/Site.css";

        private const string BUNDLE_JS_GERAL = "~/Content/scriptsGerais";

        private const string BUNDLE_CSS_GERAL = "~/Content/css";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(BUNDLE_JS_GERAL)
                .Include(SCRIPT_GERAL_AJAX)
            );

            bundles.Add(new StyleBundle(BUNDLE_CSS_GERAL)
                .Include(CSS_GERAL_SITE)
            );
        }
    }
}
