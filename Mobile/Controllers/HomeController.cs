using System.Web.Mvc;
using Mobile.Models;

namespace Mobile.Controllers
{
    public class HomeController : Controller
    {
        private readonly Programmer[] _progs = 
        {
            new Programmer("Alice", "Smith", "Lead Developer", "Paris", "France", "C#"),
            new Programmer("Joe", "Dunston", "Developer", "London", "UK", "Java"),
            new Programmer("Peter", "Jones", "Developer", "Chicago", "USA", "C#"),
            new Programmer("Murray", "Woods", "Jnr Developer", "Boston", "USA", "C#")
        };

        public ActionResult Index()
        {
            return View(_progs);
        }
    }
}