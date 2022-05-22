using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Airport
{
    public class DeleteAirportViewModel : BaseViewModel
    {
        [Display(Name ="Kode Bandara")]
        public string KodeAirport { get; set; } = string.Empty;

    }
}
