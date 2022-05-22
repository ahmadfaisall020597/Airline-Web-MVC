using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Controllers
{
    public class BootstrapController : BaseController
    {

        public BootstrapController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Container()
        {
            return View();
        }
        public IActionResult Grid()
        {
            return View();

        }
        public IActionResult Table()
        {
            return View();
        }
    }
}
