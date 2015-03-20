using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessFirstForm(string name)
        {
            SessionStateHelper.Set(SessionStateKeys.NAME, name);
            return View("SecondForm");
        }

        [HttpPost]
        public ActionResult CompleteForm(string country)
        {
            ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);
            ViewBag.Country = country;
            return View();
        }
    }
}