using System.Web;

namespace MVC5Platform.Infrastructure
{
    public class CounterHandler : IHttpHandler
    {
        private readonly int _handlerCounter;
        private int _requestCounter = 0;

        public CounterHandler(int counter)
        {
            _handlerCounter = counter;
        }

        public void ProcessRequest(HttpContext context)
        {
            _requestCounter++;
            context.Response.ContentType = "text/plain";
            context.Response.Write(
                string.Format("The counter value is {0} (Request {1} of 3)",
                _handlerCounter, _requestCounter));
        }
        public bool IsReusable
        {
            get { return _requestCounter < 2; }
        }
    }
}