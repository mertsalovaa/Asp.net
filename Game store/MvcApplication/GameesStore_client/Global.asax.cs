using GameesStore_client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using GameesStore_client.App_Start;

namespace GameesStore_client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfiguration.ConfigurateContainer();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
