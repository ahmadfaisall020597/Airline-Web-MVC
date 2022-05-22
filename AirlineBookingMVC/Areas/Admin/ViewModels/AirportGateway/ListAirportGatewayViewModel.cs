using AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway
{
    public class ListAirportGatewayViewModel : BaseViewModel
    {
        public List<DetailsAirportGatewayViewModel> Airports { get; set; } = new List<DetailsAirportGatewayViewModel>();
    }
}
