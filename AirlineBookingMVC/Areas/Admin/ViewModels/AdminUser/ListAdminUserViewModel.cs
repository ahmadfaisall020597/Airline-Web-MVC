namespace AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;

public class ListAdminUserViewModel : BaseViewModel
{
    public List<DetailsAdminUserViewModel> AdminUsers { get; set; } = new List<DetailsAdminUserViewModel>();
}