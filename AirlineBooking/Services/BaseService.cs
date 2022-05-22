using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Services
{
    public class BaseService
    {
        protected Models.AirlineBookingDbContext _db;
        protected string _loginEmail = string.Empty;


        public BaseService(Models.AirlineBookingDbContext db)
        {
            _db = db;
        }
        public BaseService(Models.AirlineBookingDbContext db,
            string loginEmail)
        {
            _db = db;
            _loginEmail = loginEmail;   
        }
    }
}
