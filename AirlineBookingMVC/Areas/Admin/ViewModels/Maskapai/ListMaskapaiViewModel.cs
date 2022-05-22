namespace AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;

public class ListMaskapaiViewModel : BaseViewModel
{
    public List<DetailsMaskapaiViewModel> Maskapais { get; set; } = new List<DetailsMaskapaiViewModel>();
}