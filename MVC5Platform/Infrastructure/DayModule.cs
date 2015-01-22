using System;
using System.Web;

namespace MVC5Platform.Infrastructure
{
    public class DayModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.PostMapRequestHandler += (src, args) =>
            {
                if (app.Context.Handler is IRequiresDate)
                {
                    app.Context.Items["DayModule_Time"] = DateTime.Now;
                }
            };

        //The module now handles the PostMapRequestHandler event, which is triggered after the handler has been
        //selected to generate content for the request and uses the HttpContext.Handler property to check the type of
        //the selected handler. The module adds a DateTime value to the Items collection if the handler is an instance of
        //DayWeekHandler, but not otherwise.
        }
        public void Dispose()
        {
            // nothing to do
        }
    }
}