using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SearchService.Util;
using SearchService.Config;
using SearchService.Facade;


namespace SearchService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RecordContextInitializer db = new RecordContextInitializer();
            System.Data.Entity.Database.SetInitializer(db);

            AutofacConfig.ConfigureContainer();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }
    }
}
