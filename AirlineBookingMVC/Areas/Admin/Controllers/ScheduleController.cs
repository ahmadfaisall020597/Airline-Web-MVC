using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.Areas.Admin.ViewModels;
using AirlineBookingMVC.Areas.Admin.ViewModels.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ScheduleController : BaseController
{
    
    public ScheduleController(AirlineBookingDbContext db) : base(db)
    {
    }
    
    public IActionResult Index(ListSchedulesViewModel pListScheduleVM)
    {
       
        return View("List", pListScheduleVM);
    }
    
    public IActionResult Create(BaseViewModel pBaseViewModel)
    {
        ViewBag.FormMode = "Create";
        return View("Edit", pBaseViewModel);
    }
    
    public IActionResult Edit(BaseViewModel pBaseViewModel)
    {
        ViewBag.FormMode = "Edit";
        return View("Edit", pBaseViewModel);
    }
    
}