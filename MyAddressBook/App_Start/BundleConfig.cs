using System.Web;
using System.Web.Optimization;

namespace MyAddressBook
{
    public class BundleConfig
    {        
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {            
            bundles.UseCdn = true; //enable CDN support            
            var jqueryCdnPath = "http://ajax.gooogleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js";
            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include("~/Scripts/jquery-{version}.js"));            

            // Code removed for clarity.
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

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

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                       "~/Scripts/kendo/2013.3.1119/kendo.web.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                        "~/Content/kendo/2013.3.1119/kendo.common-bootstrap.min.css",
                        "~/Content/kendo/2013.3.1119/kendo.bootstrap.min.css"));

            bundles.IgnoreList.Clear();

        }
    }
}
