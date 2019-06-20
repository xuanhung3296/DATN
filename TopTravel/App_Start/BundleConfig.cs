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

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
              "~/Scripts/jquery.date-dropdowns.js",
                "~/Scripts/jquery.dotdotdot.min.js",
                "~/Scripts/jquery-ui-1.10.4.custom.js"));


            bundles.Add(new ScriptBundle("~/bundles/sb_admin").Include(
                "~/Content/SB_Admin/vendor/jquery/jquery.min.js",
                "~/Content/SB_Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/SB_Admin/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/SB_Admin/js/sb-admin-2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sb_admin/table").Include(
            "~/Content/SB_Admin/vendor/datatables/jquery.dataTables.min.js",
            "~/Content/SB_Admin/vendor/datatables/dataTables.bootstrap4.min.js",
            "~/Content/SB_Admin/js/demo/datatables-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/travelix").Include(
                "~/Content/travelix/styles/bootstrap4/popper.js",
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.js",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
                "~/Content/travelix/plugins/easing/easing.js",
                "~/Content/travelix/js/custom.js"));
            bundles.Add(new ScriptBundle("~/bundles/booking").Include(
                "~/Scripts/BaseFuction.js",
                "~/Scripts/hoverIntent.js",
                "~/Scripts/jquery.date-dropdowns.js",
                "~/Scripts/jquery.dotdotdot.min.js",
                "~/Scripts/jquery-ui-1.10.4.custom.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/travelix/search").Include(
                "~/Content/travelix/plugins/Isotope/isotope.pkgd.min.js",
                "~/Content/travelix/plugins/parallax-js-master/parallax.min.js",
                "~/Content/travelix/js/offers_custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/travelix/single").Include(
                "~/Content/travelix/styles/bootstrap4/popper.js",
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.js",
                "~/Content/travelix/plugins/easing/easing.js",
                "~/Content/travelix/plugins/parallax-js-master/parallax.min.js",
                "~/Content/travelix/plugins/colorbox/jquery.colorbox-min.js",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.carousel.js",
               "~/Content/travelix/plugins/easing/single_listing_custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                "~/Content/ckeditor/ckeditor.js"));

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

            bundles.Add(new StyleBundle("~/Content/PagedList").Include(
                "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/sb_admin").Include(
            "~/Content/SB_Admin/vendor/fontawesome-free/css/all.min.css",
            "~/Content/SB_Admin/css/sb-admin-2.min.css",
            "~/Content/SB_Admin/vendor/datatables/dataTables.bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/Content/booking").Include(
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.css",
                "~/Content/SB_Admin/vendor/fontawesome-free/css/all.min.css",
                "~/Content/pager_simple_orange.css",
                "~/Content/style.css"
               ));

            bundles.Add(new StyleBundle("~/Content/travelix").Include(
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.css",
                "~/Content/travelix/plugins/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/animate.css",
                "~/Content/travelix/styles/main_styles.css",
                "~/Content/travelix/styles/responsive.css"
                ));

            bundles.Add(new StyleBundle("~/Content/travelix/single").Include(
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.css",
                "~/Content/travelix/plugins/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/travelix/plugins/colorbox/colorbox.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
                "~/Content/travelix/plugins/OwlCarousel2-2.2.1/animate.css",
                "~/Content/travelix/styles/single_listing_styles.css",
                "~/Content/travelix/styles/single_listing_responsive.css"
                ));

            bundles.Add(new StyleBundle("~/Content/travelix/search").Include(
                "~/Content/travelix/styles/bootstrap4/bootstrap.min.css",
                "~/Content/travelix/plugins/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/PagedList.css",
                "~/Content/travelix/styles/offers_styles.css",
                "~/Content/travelix/styles/offers_responsive.css"
            ));


            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}
