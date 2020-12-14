using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SourceControlAssignment1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
       
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            logger.Info(ex.Message.ToString() + Environment.NewLine + DateTime.Now);
            HttpContext.Current.ClearError();
            Response.Redirect("~/Error/NotFound", false);
        }
    }
}
