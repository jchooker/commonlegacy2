using CommonLegacy.Services;
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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}