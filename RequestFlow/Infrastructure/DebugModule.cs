using System.Collections.Generic;
using System.Web;

namespace RequestFlow.Infrastructure
{
    public class DebugModule : IHttpModule
    {
        private static readonly List<string> RequestUrls = new List<string>();
        private static readonly object LockObject = new object();

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                lock (LockObject)
                {
                    if (app.Request.RawUrl == "/Stats")
                    {
                        app.Response.Write(string.Format("<div>There have been {0} requests</div>",
                            RequestUrls.Count));

                        app.Response.Write("<table><tr><th>ID</th><th>URL</th></tr>");

                        for (int i = 0; i < RequestUrls.Count; i++)
                        {
                            app.Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td></tr>", i, RequestUrls[i]));
                        }
                        app.CompleteRequest();
                    }
                    else
                    {
                        RequestUrls.Add(app.Request.RawUrl);
                    }
                }
            };
        }
        public void Dispose()
        {
            // do nothing
        }
    }
}