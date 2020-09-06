using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GameesStore_client.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(

                         "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're

            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/Scripts/customScript").Include(
                "~/Scripts/custom/script.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrapScripts").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/popperScripts").Include(
                "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryScripts").Include(
                "~/Scripts/jquery-3.0.0.js"));

            bundles.Add(new StyleBundle("~/Content/bootrstrapStyles").Include(
                "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/customForLogin").Include(
                "~/Content/styleForLogin.css"));

            bundles.Add(new StyleBundle("~/Content/customStyles").Include(
               "~/Content/style.css"));

        }
    }
}