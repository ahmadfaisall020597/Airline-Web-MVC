using AirlineBooking.Models;
using AirlineBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.ApiControllers
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : BaseApiController
    {
        
        public AirportController(AirlineBookingDbContext db) : base(db)
        {   
        }
        
        [Route("list")]
        [HttpGet]
        public List<AirportModel> Index()
        {
            AirportService _airportService = new AirportService(_db, "");
            return _airportService.FindList();
        }
    }
}
