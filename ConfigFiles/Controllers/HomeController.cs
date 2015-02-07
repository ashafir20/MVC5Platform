using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ConfigFiles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            Dictionary<string, string> configData = new Dictionary<string, string>();
            foreach (string key in WebConfigurationManager.AppSettings)
            {
                configData.Add(key, WebConfigurationManager.AppSettings[key]);
            }
            foreach (ConnectionStringSettings cs in WebConfigurationManager.ConnectionStrings)
            {
                configData.Add(cs.Name, cs.ProviderName + " " + cs.ConnectionString);
            }
            return View(configData);
        }
        public ActionResult DisplaySingle1()
        {
            return View((object)WebConfigurationManager.AppSettings["defaultLanguage"]);
            //return View((object)WebConfigurationManager.ConnectionStrings["EFDbContextPlatformDemo"].ConnectionString);
        }
    }
}