using Microsoft.Practices.Unity;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace CommonLegacy
{
    public class Global : HttpApplication
    {
        //ef core needs to stay 3.1.*! anything else is incompatible or deprecated
        void Application_Start(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            //var container = new UnityContainer();
            container.RegisterType<UsersDbContext>();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var dbContext = container.Resolve<UsersDbContext>();

            var userControl = new UsersDataTable(dbContext);
            //HttpContext.Current.Items["DbContext"] = dbContext;
            //Application["UnityContainer"] = container;
        }
    }
}