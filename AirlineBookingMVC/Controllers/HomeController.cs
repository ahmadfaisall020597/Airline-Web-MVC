using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Login", new {area = "Admin"});
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
