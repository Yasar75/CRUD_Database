﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Crud_database
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            

            //if (HttpContext.Current.IsDebuggingEnabled)
            //{
            //    System.Web.Optimization.BundleTable.EnableOptimizations = false;
            //}
            //else
            //{
            //    System.Web.Optimization.BundleTable.EnableOptimizations = true;
            //}
        }
    }
}