namespace AirlineBookingMVC.Areas.Admin.ViewModels.JenisPesawat;

public class ListJenisPesawatViewModel : BaseViewModel
{
    public List<DetailsJenisPesawatViewModel> JenisPesawats { get; set; } = new List<DetailsJenisPesawatViewModel>();
}