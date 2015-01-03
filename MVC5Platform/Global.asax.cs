using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Platform
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            RecordEvent("BeginRequest");
        }
        protected void Application_AuthenticateRequest()
        {
            RecordEvent("AuthenticateRequest");
        }
        protected void Application_PostAuthenticateRequest()
        {
            RecordEvent("PostAuthenticateRequest");
        }
        private void RecordEvent(string name)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            eventList.Add(name);
        }
    }
}
