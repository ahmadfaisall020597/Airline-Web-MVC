using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.AppConfig;
using AirlineBookingMVC.Areas.Admin.ViewModels.AdminUser;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminUserController : BaseController
{
    public AdminUserController(AirlineBookingDbContext db) : base(db)
    {
    }
    
    public IActionResult Edit(string id, EditAdminUserViewModel pEditAdminUserVM)
    {
        try
        {
            _setLoginID();
            id = _decodeUrl(id);
            AdminUserService _adminUserService = new AdminUserService(_db, _loginID);
            var _adminUser = _adminUserService.FindByEmail(id, false);
            if (_adminUser != null)
            {
                var _editAdminUserVM = new EditAdminUserViewModel()
                {
                    Email = _adminUser.Email,
                    Username = _adminUser.Username,
                    Active = _adminUser.Active,
                    t = pEditAdminUserVM.t
                };
                return View("Edit", _editAdminUserVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }
        return View("Edit", pEditAdminUserVM);
    }
    
    public IActionResult Create(CreateAdminUserViewModel pCreateAdminUserVM)
    {
        if (DebugMode.Debug)
        {
            pCreateAdminUserVM.Email = "faisal@gmail.com";
            pCreateAdminUserVM.Username = "Faisal";
            pCreateAdminUserVM.Active = true;
            pCreateAdminUserVM.Password = "123456";
            pCreateAdminUserVM.ConfirmPassword = "123456";
            
        }
        return View("Create", pCreateAdminUserVM);
    }
    
    [HttpPost]
    public IActionResult Update(EditAdminUserViewModel pEditAdminUserVM)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                AdminUserService _adminUserService = new AdminUserService(_db, _loginID);
                _adminUserService.UpdateAdminUser(pEditAdminUserVM.Email,
                    pEditAdminUserVM.Username,
                    pEditAdminUserVM.Active);

                var _listAdminUserVM = new ListAdminUserViewModel()
                {
                    Message = "Data sudah diubah",
                    t = pEditAdminUserVM.t,
                };
                return RedirectToAction("List", _listAdminUserVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Edit", pEditAdminUserVM);
    }
    
    
    [HttpPost]
    public IActionResult Insert(CreateAdminUserViewModel pCreateAdminUserVM)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                AdminUserService _adminUserService = new AdminUserService(_db, _loginID);
                _ = _adminUserService.AddAdminUser(pCreateAdminUserVM.Email, 
                    pCreateAdminUserVM.Password,
                    pCreateAdminUserVM.ConfirmPassword,
                    pCreateAdminUserVM.Username,
                    pCreateAdminUserVM.Active);

                pCreateAdminUserVM.Message = "Data sudah tersimpan";
                
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pCreateAdminUserVM);
    }

    
    [HttpPost]
    public IActionResult Delete(DeleteAdminUserViewModel pDeleteAdminUserVM)
    {
        ListAdminUserViewModel _listAdminUserVM = new ListAdminUserViewModel();
        _listAdminUserVM.t = pDeleteAdminUserVM.t;
        
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                AdminUserService _adminUserService = new AdminUserService(_db, _loginID);
                _adminUserService.DeleteAdminUser(pDeleteAdminUserVM.Email);

                _listAdminUserVM.Message = "Data sudah dihapus";
                return RedirectToAction("List", _listAdminUserVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("List", _listAdminUserVM);
        
    }
    
    public IActionResult List(ListAdminUserViewModel pListAdminUserVM)
    {
        try
        {
            _setLoginID();
            AdminUserService _adminUserService = new AdminUserService(_db, _loginID);
            var _adminUsers = _adminUserService.FindList();

            var _listAdminUserVM = new ListAdminUserViewModel();
            _listAdminUserVM.UpdateTokenAndMessage(pListAdminUserVM.t, pListAdminUserVM.Message);
                
            if (_adminUsers != null && _adminUsers.Count > 0)
            {
                foreach (var _adminUser in _adminUsers)
                {
                    _listAdminUserVM.AdminUsers.Add(
                        new DetailsAdminUserViewModel()
                        {
                            Email = _adminUser.Email,
                            Username = _adminUser.Username,
                            Active = (_adminUser.Active ? "Aktif" : "Tidak Aktif"),
                            CreatedAt = _adminUser.CreatedAt,
                            CreatedBy = _adminUser.CreatedBy,
                            UpdatedAt = _adminUser.UpdatedAt,
                            UpdatedBy = _adminUser.UpdatedBy,
                        }
                    );
                }
            }
            
            

            return View("List", _listAdminUserVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("List", pListAdminUserVM);
    }
    
}