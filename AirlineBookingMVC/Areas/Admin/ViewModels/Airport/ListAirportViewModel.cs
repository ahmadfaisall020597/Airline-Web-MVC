namespace AirlineBookingMVC.Areas.Admin.ViewModels.Airport
{
    public class ListAirportViewModel : BaseViewModel
    {
        public List<DetailsAirportViewModel> Airports { get; set; } = new List<DetailsAirportViewModel>();
    }
}
