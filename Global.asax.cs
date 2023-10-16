using CommonLegacy.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace CommonLegacy
{
    public class Global : HttpApplication
    {
        //ef core needs to stay 3.1.*! anything else is incompatible or deprecated
        void Application_Start(object sender, EventArgs e)
        {
            IDbConnection conn = new SQLiteConnection(SQLiteAccess.LoadConnectionString());
            conn.Open();

            IUserRepository userRepository = new UserRepository();
            Application["UserRepository"] = userRepository;
            //var container = new UnityContainer();
            //var container = new UnityContainer();
            //var container = new UnityContainer();
            //container.RegisterType<UsersDbContext>();
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var dbContext = container.Resolve<UsersDbContext>();

//var userControl = new UsersDataTable(dbContext);
//HttpContext.Current.Items["DbContext"] = dbContext;
//Application["UnityContainer"] = container;
//***********INCLUDE BELOW?
//var container = new UnityContainer();
//container.RegisterType<IUserRepository, UserRepository>(
//    new InjectionFactory(c => new UserRepository(ConnectionHelper.CreateConnection()))
//);
//IUnityContainer container = UnityConfig.InitializeContainer();

            // Register the Unity container with ConnectionHelper
        }
    }
}