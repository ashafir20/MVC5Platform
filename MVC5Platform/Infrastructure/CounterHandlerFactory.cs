using System.Collections.Concurrent;
using System.Web;

namespace MVC5Platform.Infrastructure
{
    public class CounterHandlerFactory : IHttpHandlerFactory
    {
        private int _counter = 0;
        private readonly int handlerMaxCount = 3;
        private int _handlerCount = 0;
        private readonly BlockingCollection<CounterHandler> _pool = new BlockingCollection<CounterHandler>();

        public IHttpHandler GetHandler(HttpContext context, string verb, string url, string path)
        {
            CounterHandler handler;
            if (!_pool.TryTake(out handler))
            {
                if (_handlerCount < handlerMaxCount)
                {
                    _handlerCount++;
                    handler = new CounterHandler(++_counter);
                    _pool.Add(handler);
                }
                else
                {
                    handler = _pool.Take();
                }
            }
            return handler;
        }
        public void ReleaseHandler(IHttpHandler handler)
        {
            if (handler.IsReusable)
            {
                _pool.Add((CounterHandler)handler);
            }
            else
            {
                _handlerCount--;
            }
        }
    }
}