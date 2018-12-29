using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CityCore
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

            log4net.Config.XmlConfigurator.Configure();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Login", "Login", "~/Modules/Login.aspx", false);
            routes.MapPageRoute("Home", "", "~/Modules/Home.aspx", false);

            routes.MapPageRoute("Projects", "Projects", "~/Modules/Projects/List.aspx");
            routes.MapPageRoute("ProjectAdd", "Project", "~/Modules/Projects/AddEdit.aspx");
            routes.MapPageRoute("ProjectEdit", "Project/{id}", "~/Modules/Projects/AddEdit.aspx");
        }
    }
}