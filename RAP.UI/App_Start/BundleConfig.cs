using System.Web;
using System.Web.Optimization;

namespace RAP.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/InitDataTables.js"));

            //TODO: Bandle did not connnected to page (Create Patient)?????????
            bundles.Add(new ScriptBundle("~/bundles/intl-tel-input").Include(
                      "~/Scripts/IntlTelInput_js/utils.js",
                      "~/Scripts/IntlTelInput_js/intlTelInput.min.js",
                      "~/Scripts/InitIntlTelInput.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                     "~/Content/DataTables/css/jquery.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/intl-tel-input").Include(
                      "~/Content/IntlTelInput_css/demo.css",
                      "~/Content/IntlTelInput_css/intlTelInput.css"));
        }
    }
}
