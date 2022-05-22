using AirlineBookingMVC.Areas.Admin.ViewModels.Error;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult Index(ErrorViewModel indexVM)
        {
            return View("Error", indexVM);
        }
    }
}
