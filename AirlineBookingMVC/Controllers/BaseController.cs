using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Controllers
{
    public class BaseController : Controller
    {
        public static bool IsLogin = false;

        protected bool _isLogin()
        {
           
            if (!BaseController.IsLogin)
            {   
                return false;
            }
            return true;
        }
    }
}
