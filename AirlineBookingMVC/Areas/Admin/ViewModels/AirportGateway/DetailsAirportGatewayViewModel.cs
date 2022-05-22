using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.AirportGateway
{
    public class DetailsAirportGatewayViewModel : BaseViewModel
    {
        [Display(Name = "ID Gateway")]
        public long IDGateway { get; set; }
        
        [Display(Name = "Nomor Gate")]
        public string NomorGate { get; set; }= string.Empty;

        [Display(Name = "Nomor Pintu")]
        public string NomorPintu { get; set; }= string.Empty;

        [Display(Name = "Dibuat pada")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Dibuat oleh")]
        public string CreatedBy { get; set; } = string.Empty;

        
    }
}
