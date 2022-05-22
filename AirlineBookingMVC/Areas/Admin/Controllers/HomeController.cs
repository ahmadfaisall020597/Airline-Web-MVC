using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index(ViewModels.Home.HomeViewModel homeViewModel)
        {   
            return View(homeViewModel);
        }

    }
}
