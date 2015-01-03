using System.Web.Mvc;
using MVC5Platform.Models;

namespace MVC5Platform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(HttpContext.Application["events"]);
        }

        
        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View(HttpContext.Application["events"]);
        }
    }
}