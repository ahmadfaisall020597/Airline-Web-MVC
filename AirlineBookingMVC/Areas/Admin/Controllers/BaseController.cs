using System.Web;
using AirlineBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        
        protected AirlineBookingDbContext _db;
        protected string _loginID = string.Empty;

        public BaseController(AirlineBookingDbContext db)
        {
            _db = db;
            
        }

        protected void _setLoginID()
        {
            var id = HttpContext.Items["LoginID"];
            if (id != null)
            {
                _loginID = id.ToString();
            }
        }

        protected string _decodeUrl(string p)
        {
            return HttpUtility.UrlDecode(p);
        }
    }
}
