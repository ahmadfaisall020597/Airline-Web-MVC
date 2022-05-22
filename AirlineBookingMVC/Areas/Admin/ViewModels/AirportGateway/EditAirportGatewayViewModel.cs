using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway
{
    public class EditAirportGatewayViewModel : BaseViewModel
    {
        [Display(Name = "Nomor Gate")]
        public string NomorGate { get; set; }= string.Empty;

        [Display(Name = "Nomor Pintu")]
        public string NomorPintu { get; set; }= string.Empty;


    }
}
