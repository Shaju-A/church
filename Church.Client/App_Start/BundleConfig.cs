﻿using System.Web;
using System.Web.Optimization;

namespace Church.Client
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
                      "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other").Include(
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/jquery.dcjqaccordion.2.7.js",
                      "~/Scripts/jquery.scrollTo.min.js",
                      "~/Scripts/slidebars.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ourcode").Include(
                      "~/Scripts/ourcode/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/0thirdparty/style.css",
                      "~/Content/0thirdparty/style-responsive.css",
                      "~/Content/0thirdparty/font-awesome.min.css",
                      "~/Content/site.css"));
            
        }
    }
}
