using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TP_Integrador.Clases;
using TP_Integrador.Helpers;


namespace TP_Integrador
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CategoriaHandler categoriaHandler = CategoriaHandler.getInstance();
            UserHandler userHandler = UserHandler.GetInstance();

            Logger log = new Logger();
            log.LogMessage("Se ha iniciado la app.");
        }
    }
}