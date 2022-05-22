namespace AirlineBookingMVC.Areas.Admin.ViewModels.Schedule;

public class ListSchedulesViewModel : BaseViewModel
{
    public List<DetailsScheduleViewModel> Schedules { get; set; } = new List<DetailsScheduleViewModel>();
    
}