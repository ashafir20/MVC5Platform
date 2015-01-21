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
            CreateTimeStamp();
        }

        //Recording the life-cycle events with regular c# events

        public MvcApplication()
        {
            //BeginRequest += RecordEvent;
            //AuthenticateRequest += RecordEvent;
            //PostAuthenticateRequest += RecordEvent;
            PostAcquireRequestState += (src, args) => CreateTimeStamp();
        }

//The new method, called CreateTimeStamp, aims to reduce code duplication by dealing with application-level
//and request-level timestamps with the same set of statements. This code will throw an exception as soon as the
//application is started because it attempts to read the Session property for an instance of the global application class
//that has been created to deal with the Application_Start method being called.
        private void CreateTimeStamp()
        {
            string stamp = Context.Timestamp.ToLongTimeString();
            //if (Session != null) //throws exception when called from application_start method
            if (Context.Session != null) //bypassing the security check and no exception thrown
            {
                Session["request_timestamp"] = stamp;
            }
            else
            {
                Application["app_timestamp"] = stamp;
            }
        }

        //Recording the life-cycle events with methods

        //protected void Application_BeginRequest()
        //{
        //    RecordEvent("BeginRequest");
        //}
        //protected void Application_AuthenticateRequest()
        //{
        //    RecordEvent("AuthenticateRequest");
        //}
        //protected void Application_PostAuthenticateRequest()
        //{
        //    RecordEvent("PostAuthenticateRequest");
        //}
        private void RecordEvent(object src, EventArgs args) 
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            string name = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                name = "Post" + name;
            }

            eventList.Add(name);
        }

        //The Most Commonly Used HttpContext Members

/*      Application - Returns the HttpApplicationState object used to manage application state data (see Chapter 10).
        ApplicationInstance - Returns the HttpApplication object associated with the current request (described later in this chapter).
        Cache - Returns a Cache object used to cache data. See Chapter 11 for details.
        Current - (Static.) Returns the HttpContext object for the current request.
        CurrentHandler - Returns the IHttpHandler instance that will generate content for the request. See Chapter 5 for details of handlers and Chapter 6 for information about how to preempt the handler selection process used by the ASP.NET platform.
        IsDebuggingEnabled - Returns true if the debugger is attached to the ASP.NET application. You can use this to perform debug-specific activities, but if you do, take care to test thoroughly without the debugger before deployment.
        Items - Returns a collection that can be used to pass state data between ASP.NET framework components that participate in processing a request.
        GetSection(name) - Gets the specified configuration section from the Web.config file. I show you how to work with the Web.config files in Chapter 9.
        Request - Returns an HttpRequest object that provides details of the request being processed. I describe the HttpRequest class later in this chapter.
        Response - Returns an HttpResponse object that provides details of the response that is being constructed and that will be sent to the browser. I describe the HttpResponse object later in this chapter.
        Session - Returns an HttpSession state object that provides access to the session state. This property will return null until the PostAcquireRequestState application event has been triggered. See Chapter 10 for details.
        Server - Returns an HttpServerUtility object that can contain utility functions, the most useful being the ability to control request handler execution (see Chapter 6).
        Timestamp -  Returns a DateTime object that contains the time at which the HttpContext object was created.
        Trace - Used to record diagnostic information. See Chapter 8.
*/
    }
}
