using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.AppConfig;
using AirlineBookingMVC.Areas.Admin.ViewModels.Home;
using AirlineBookingMVC.Areas.Admin.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : BaseController
    {
        private ILogger<LoginController> _logger;
        
        public LoginController(ILogger<LoginController> logger,
            AirlineBookingDbContext db) : base(db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {   
            var _loginViewModel = new LoginViewModel();
            if (DebugMode.Debug)
            {
                _loginViewModel.Email = "admin@airline.com";
                _loginViewModel.Password = "123456";
            }
            return View(_loginViewModel);        

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email, Password")] LoginViewModel _loginVM) 
        {
            try
            {
                if(ModelState.IsValid)
                {
                    AdminLoginService _adminLoginService = new AdminLoginService(_db, "");
                    var _login = _adminLoginService.Login(_loginVM.Email,
                        _loginVM.Password);

                    var _homeViewModel = new HomeViewModel()
                    {
                        t = _login.LoginID
                    };
                    return RedirectToAction("Index", "Home", _homeViewModel);

                }

            }catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View("Index", _loginVM);
        }
       
        public IActionResult Logout(string t)
        {
            try
            {
                AdminLoginService _adminLoginService = new AdminLoginService(_db, "");
                _adminLoginService.Logout(t);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            
            return RedirectToAction("Index", "Login");

        }
    }

}
