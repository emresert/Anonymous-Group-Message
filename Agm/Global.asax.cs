using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;

namespace Agm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["MsgConnection"].ConnectionString);
        }
        public void Application_End()
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["MsgConnection"].ConnectionString);
        }
    }
}