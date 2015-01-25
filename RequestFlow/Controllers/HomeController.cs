﻿using System.Web.Mvc;

namespace RequestFlow.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}