using System.Web;
using System.Web.Optimization;

namespace TopTravel
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/sb_admin").Include(
                "~/Content/SB_Admin/vendor/jquery/jquery.min.js",
                "~/Content/SB_Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/SB_Admin/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/SB_Admin/js/sb-admin-2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sb_admin/table").Include(
           "~/Content/SB_Admin/vendor/datatables/jquery.dataTables.min.js",
            "~/Content/SB_Admin/vendor/datatables/dataTables.bootstrap4.min.js",
            "~/Content/SB_Admin/js/demo/datatables-demo.js"));



            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/sb_admin").Include(
            "~/Content/SB_Admin/vendor/fontawesome-free/css/all.min.css",
            "~/Content/SB_Admin/css/sb-admin-2.min.css",
            "~/Content/SB_Admin/vendor/datatables/dataTables.bootstrap4.min.css"));
        }
    }
}
