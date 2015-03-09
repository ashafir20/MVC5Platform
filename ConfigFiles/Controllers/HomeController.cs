using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using ConfigFiles.Infrastructure;

namespace ConfigFiles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
/*           Dictionary<string, string> configData = new Dictionary<string, string>();
            foreach (string key in WebConfigurationManager.AppSettings)
            {
                configData.Add(key, WebConfigurationManager.AppSettings[key]);
            }
            foreach (ConnectionStringSettings cs in WebConfigurationManager.ConnectionStrings)
            {
                configData.Add(cs.Name, cs.ProviderName + " " + cs.ConnectionString);
            }
            return View(configData);*/

/*         Dictionary<string, string> configData = new Dictionary<string, string>();
            NewUserDefaultsSection nuDefaults = WebConfigurationManager
            .GetWebApplicationSection("newUserDefaults") as NewUserDefaultsSection;
            if (nuDefaults != null)
            {
                configData.Add("City", nuDefaults.City);
                configData.Add("Country", nuDefaults.Country);
                configData.Add("Language", nuDefaults.Language);
                configData.Add("Region", nuDefaults.Region.ToString());
            };*/

/*            Dictionary<string, string> configData = new Dictionary<string, string>();
            PlaceSection section = WebConfigurationManager
                .GetWebApplicationSection("places") as PlaceSection;
            foreach (Place place in section.Places)
            {
                configData.Add(place.Code, string.Format("{0} ({1})",
                place.City, place.Country));
            }*/

            Dictionary<string, string> configData = new Dictionary<string, string>();
            CustomDefaults cDefaults = (CustomDefaults)WebConfigurationManager.OpenWebConfiguration("/")
                .GetSectionGroup("customDefaults");
            foreach (Place place in cDefaults.Places.Places)
            {
                configData.Add(place.Code, string.Format("{0} ({1})", place.City, place.Country));
            }

            return View(configData);
        }
        public ActionResult DisplaySingle1()
        {
            PlaceSection section = WebConfigurationManager.GetWebApplicationSection("customDefaults/places") as PlaceSection;
/*            PlaceSection section = WebConfigurationManager
                .GetWebApplicationSection("places") as PlaceSection;*/
            Place defaultPlace = section.Places[section.Default];
            return View((object)string.Format("The default place is: {0}", defaultPlace.City));
            //return View((object)WebConfigurationManager.AppSettings["defaultLanguage"]);
            //return View((object)WebConfigurationManager.ConnectionStrings["EFDbContextPlatformDemo"].ConnectionString);
        }
    }
}