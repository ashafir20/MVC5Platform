using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC5Platform.Infrastructure;

namespace MVC5Platform
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //route to handlers by web.config or here by adding a route
            //routes.Add(new Route("handler/{*path}", new CustomRouteHandler { HandlerType = typeof(DayOfWeekHandler) }));

//stop the URL routing feature from intercepting requests that I want to go to my custom handler
//The RouteCollection.IgnoreRoute method tells the routing system to ignore a URL pattern. In the listing, I used
//the IgnoreRoute method to exclude any URL whose first segment is /handler. When a URL pattern is excluded, the
//routing system won’t try to match routes for it or generate an error when there is no route available, allowing the ASP.
//NET platform to locate a handler from the Web.config file.
            routes.IgnoreRoute("handler/{*path}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        class CustomRouteHandler : IRouteHandler
        {
            public Type HandlerType { get; set; }
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return (IHttpHandler)Activator.CreateInstance(HandlerType);
            }
        }
    }
}
