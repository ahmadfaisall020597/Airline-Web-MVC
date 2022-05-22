

using System.Net;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.Areas.Admin.ViewModels;
using AirlineBookingMVC.Areas.Admin.ViewModels.Schedule;
using Microsoft.AspNetCore.Mvc;


namespace AirlineBookingMVC.Areas.Admin.ApiControllers;


[Microsoft.AspNetCore.Mvc.Route("api/schedule")]
public class ScheduleApiController : BaseApiController
{
    public ScheduleApiController(AirlineBookingDbContext db) : base(db)
    {       
    }
    
    [Microsoft.AspNetCore.Mvc.Route("list")]    
    [Microsoft.AspNetCore.Mvc.HttpGet(Name = "FindSchedules")]
    public IEnumerable<ScheduleModel> Index()
    {
        ScheduleService _scheduleService = new ScheduleService(_db, _loginID);
        return _scheduleService.FindSchedules();
    }

    [Route("insert")]
    [HttpPost]
    public BaseViewModel  Insert([FromBody] ScheduleModel scheduleVM)
    {  
        try
        {
            _setLoginID();
            ScheduleService _scheduleService = new ScheduleService(_db, _loginID);
            _scheduleService.TambahSchedule(scheduleVM.KodeMaskapai,
                scheduleVM.KodePenerbangan,
                scheduleVM.KodeAirportAsal,
                scheduleVM.KodeAirportTujuan,
                scheduleVM.StrTglKeberangkatan,
                scheduleVM.StrTglKedatangan,
                scheduleVM.BatasBagasi,
                scheduleVM.BatasBagasiKabin,
                scheduleVM.HargaTiket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e;
        }

        return new BaseViewModel();
    }


}