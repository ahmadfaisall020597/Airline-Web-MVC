using System.Text.Encodings.Web;
using System.Web;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.AppConfig;
using AirlineBookingMVC.Areas.Admin.ViewModels.JenisPesawat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class JenisPesawatController : BaseController
{
    public JenisPesawatController(AirlineBookingDbContext db) : base(db)
    {
    }

    public IActionResult Edit(string id, CreateJenisPesawatViewModel pEditJenisPesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Edit";
            _setLoginID();
            id = _decodeUrl(id);
            
            JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
            var _maskapai = _jenisPesawatService.FindJenisPesawatByKodeJenisPesawat(id, false);
            if (_maskapai != null)
            {
                var _editJenisPesawatVM = new CreateJenisPesawatViewModel()
                {
                    KodeJenisPesawat = _maskapai.KodeJenisPesawat,
                    TahunPesawat = _maskapai.TahunPesawat,
                    t = pEditJenisPesawatVM.t
                };
                return View("Edit", _editJenisPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }
        return View("Edit", pEditJenisPesawatVM);
    }
    
    public IActionResult Create(CreateJenisPesawatViewModel pCreateJenisPesawatVM)
    {
        ViewBag.FormMode = "Create";
        return View("Edit", pCreateJenisPesawatVM);
    }

    
    [HttpPost]
    public IActionResult Update(CreateJenisPesawatViewModel pEditJenisPesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Edit";
            if (ModelState.IsValid)
            {
                _setLoginID();
                JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
                _jenisPesawatService.UpdateJenisPesawat(pEditJenisPesawatVM.KodeJenisPesawat,
                    pEditJenisPesawatVM.TahunPesawat);

                var _listJenisPesawatVM = new ListJenisPesawatViewModel()
                {
                    Message = "Data sudah diubah",
                    t = pEditJenisPesawatVM.t,
                };
                return RedirectToAction("List", _listJenisPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Edit", pEditJenisPesawatVM);
    }
    
    [HttpPost]
    public IActionResult Insert(CreateJenisPesawatViewModel pCreateJenisPesawatVM)
    {
        try
        {
            ViewBag.FormMode = "Create";
            if (ModelState.IsValid)
            {
                _setLoginID();
                JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
                _jenisPesawatService.AddJenisPesawat(pCreateJenisPesawatVM.KodeJenisPesawat,
                    pCreateJenisPesawatVM.TahunPesawat);

                var _listJenisPesawatVM = new ListJenisPesawatViewModel()
                {
                    Message = "Data sudah tersimpan",
                    t = pCreateJenisPesawatVM.t,
                };
                return RedirectToAction("List", _listJenisPesawatVM);
                
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Edit", pCreateJenisPesawatVM);
    }

    
    [HttpPost]
    public IActionResult Delete(DeleteJenisPesawatViewModel pDeleteJenisPesawatVM)
    {
        ListJenisPesawatViewModel _listJenisPesawatVM = new ListJenisPesawatViewModel();
        _listJenisPesawatVM.t = pDeleteJenisPesawatVM.t;
        
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
                _jenisPesawatService.DeleteJenisPesawat(pDeleteJenisPesawatVM.KodeJenisPesawat);

                _listJenisPesawatVM.Message = "Data sudah dihapus";
                return RedirectToAction("List", _listJenisPesawatVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("List", _listJenisPesawatVM);
        
    }
    
    public IActionResult List(ListJenisPesawatViewModel pListJenisPesawatVM)
    {
        try
        {
            _setLoginID();
            JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
            var _maskapais = _jenisPesawatService.FindList();

            var _listJenisPesawatVM = new ListJenisPesawatViewModel();
            _listJenisPesawatVM.UpdateTokenAndMessage(pListJenisPesawatVM.t, pListJenisPesawatVM.Message);
                
            if (_maskapais != null && _maskapais.Count > 0)
            {
                foreach (var _maskapai in _maskapais)
                {
                    _listJenisPesawatVM.JenisPesawats.Add(
                        new DetailsJenisPesawatViewModel()
                        {
                            KodeJenisPesawat = _maskapai.KodeJenisPesawat,
                            TahunPesawat = _maskapai.TahunPesawat,
                            CreatedAt = _maskapai.CreatedAt,
                            CreatedBy = _maskapai.CreatedBy,
                            UpdatedAt = _maskapai.UpdatedAt,
                            UpdatedBy = _maskapai.UpdatedBy,
                        }
                    );
                }
            }
            
            return View("List", _listJenisPesawatVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("List", pListJenisPesawatVM);
    }
    
    
    public IActionResult Lookup(ListJenisPesawatViewModel pListJenisPesawatVM)
    {
        try
        {
            _setLoginID();
            JenisPesawatService _jenisPesawatService = new JenisPesawatService(_db, _loginID);
            var _maskapais = _jenisPesawatService.FindList();

            var _listJenisPesawatVM = new ListJenisPesawatViewModel();
            _listJenisPesawatVM.UpdateTokenAndMessage(pListJenisPesawatVM.t, pListJenisPesawatVM.Message);
                
            if (_maskapais != null && _maskapais.Count > 0)
            {
                foreach (var _maskapai in _maskapais)
                {
                    _listJenisPesawatVM.JenisPesawats.Add(
                        new DetailsJenisPesawatViewModel()
                        {
                            KodeJenisPesawat = _maskapai.KodeJenisPesawat,
                            TahunPesawat = _maskapai.TahunPesawat,
                            CreatedAt = _maskapai.CreatedAt,
                            CreatedBy = _maskapai.CreatedBy,
                            UpdatedAt = _maskapai.UpdatedAt,
                            UpdatedBy = _maskapai.UpdatedBy,
                        }
                    );
                }
            }
            
            return PartialView("Lookup", _listJenisPesawatVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return PartialView("Lookup", pListJenisPesawatVM);
        
    }
}