using System.Web.Optimization;

namespace Tibox.Mvc.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Site.css"));
            bundles.Add(
                new ScriptBundle("~/bundles/required")
                .Include("~/Scripts/jquery-1.10.2.js")
                .Include("~/Scripts/modernizr-2.6.2.js")
                .Include("~/Scripts/bootstrap.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/shared")
                .Include("~/Scripts/app/shared/modal.js"));

            bundles.Add(new DynamicFolderBundle("js", "*.js", false, new JsMinify()));
            bundles.Add(new DynamicFolderBundle("css", "*.css", false, new CssMinify()));


#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }

    }
}