using System.Web;
using System.Web.Optimization;

namespace JobBoard.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                "~/scripts/vendor/angular.js",
                "~/scripts/vendor/jquery-2.0.3.js",
                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/vendor/ng-table.js",
                "~/scripts/vendor/jquery.maskedinput.js",
                "~/app/app.js",
                "~/app/components/404/404Controller.js",
                "~/app/components/job/jobController.js",
                "~/app/components/job/jobFactory.js",
                "~/app/shared/services.js",
                "~/app/shared/directives.js",
                "~/app/shared/filters.js"));

            bundles.Add(new ScriptBundle("~/js/appTests").Include(
                "~/app/components/404/404Controller.spec.js",
                "~/app/components/home/homeController.spec.js",
                "~/app/components/customer/customerController.spec.js",
                "~/app/components/customer/customerCreateController.spec.js",
                "~/app/components/customer/customerFactory.spec.js",
                "~/app/components/customer/customerCreateService.spec.js",
                "~/app/shared/services.spec.js",
                "~/app/shared/directives.spec.js",
                "~/app/shared/filters.spec.js"));

        }
    }
}
