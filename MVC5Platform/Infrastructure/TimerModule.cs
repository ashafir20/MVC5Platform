using System;
using System.Diagnostics;
using System.Web;

namespace MVC5Platform.Infrastructure
{
    public class RequestTimerEventArgs : EventArgs
    {
        public float Duration { get; set; }
    }

    public class TimerModule : IHttpModule
    {
        public event EventHandler<RequestTimerEventArgs> RequestTimed;
        private Stopwatch _timer;

        public void Init(HttpApplication app)
        {
            app.BeginRequest += HandleEvent;
            app.EndRequest += HandleEvent;
        }
        private void HandleEvent(object src, EventArgs args)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest)
            {
                _timer = Stopwatch.StartNew();
            }
            else
            {
                float duration = ((float)_timer.ElapsedTicks) / Stopwatch.Frequency;
                //Receiving the EndRequest event tells me that the request has been marshaled through the request life cycle and the
                //MVC framework has generated a response that will be sent to the browser. The response has not been sent when the
                //EndRequest event is triggered, which allows me to manipulate it through the HttpResponse context object. In this
                //example, I append a message to the end of the response that reports the elapsed time between the BeginRequest and
                //EndRequest, as follows:
                ctx.Response.Write(string.Format(
                    "<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>",
                    duration));
                //I use the HttpResponse.Write method to add a string to the response. I format the string as HTML and use the
                //Bootstrap alert and alert-success CSS classes to style the content as an inline alert box.
                if (RequestTimed != null)
                {
                    RequestTimed(this,  new RequestTimerEventArgs { Duration = duration });
                }
            }
        }
        public void Dispose()
        {
            // do nothing - no resources to release
        }
    }
}