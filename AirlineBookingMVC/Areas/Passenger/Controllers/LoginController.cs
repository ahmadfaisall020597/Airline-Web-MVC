using Microsoft.AspNetCore.Mvc;
using AirlineBookingMVC;


namespace AirlineBookingMVC.Passenger.Controllers
{
    [Area("Passenger")]
    public class LoginController : BaseController
    {
        private ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            _logger.Log(LogLevel.Debug, "Log message in the Index() method");

            if (!_isLogin())
            {
                var _loginViewModel = new ViewModels.Login.LoginViewModel();
                return View(_loginViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }           

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email, Password")] ViewModels.Login.LoginViewModel _loginVM) 
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (_loginVM.Email == "abc@gmail.com" && _loginVM.Password == "123456")
                    {
                        BaseController.IsLogin = true;
                        return RedirectToAction("Table", "Bootstrap");
                    }
                    else
                    {
                        throw new Exception("Login tidak valid");
                    }
                }

            }catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(_loginVM);
        }

        public IActionResult Logout()
        {
            BaseController.IsLogin = false;
            return RedirectToAction("Login", "Login");
        }
    }

}
