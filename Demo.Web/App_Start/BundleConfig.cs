using System.Web;
using System.Web.Optimization;

namespace Demo.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jqueryui").Include(
                     "~/dist/js/jquery-ui/jquery.ui.touch-punch.min.js",
                     "~/dist/js/jquery-ui/jquery-ui-v1.12.0.min.js"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include(
                      "~/dist/js/jquery/jquery.min.js",
                      "~/dist/js/jquery/jquery.cookie.min.js"));

            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                      "~/dist/js/bootstrap/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                      "~/dist/css/bootstrap/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/js/angular2").Include(
                      "~/node_modules/es6-shim/es6-shim.min.js",
                      "~/node_modules/angular2/bundles/angular2-polyfills.min.js",
                      "~/node_modules/rxjs/bundles/Rx.js",
                      "~/node_modules/angular2/bundles/angular2.dev.js"));
        }
    }
}
