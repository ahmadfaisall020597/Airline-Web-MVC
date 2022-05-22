using System.Text.Encodings.Web;
using System.Web;
using AirlineBooking.Models;
using AirlineBooking.Services;
using AirlineBookingMVC.AppConfig;
using AirlineBookingMVC.Areas.Admin.ViewModels.Maskapai;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AirlineBookingMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class MaskapaiController : BaseController
{
    public MaskapaiController(AirlineBookingDbContext db) : base(db)
    {
    }

    public IActionResult Edit(string id, EditMaskapaiViewModel pEditMaskapaiVM)
    {
        try
        {
            _setLoginID();
            id = _decodeUrl(id);
            
            MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
            var _maskapai = _maskapaiService.FindMaskapaiByKodeMaskapai(id, false);
            if (_maskapai != null)
            {
                var _editMaskapaiVM = new EditMaskapaiViewModel()
                {
                    KodeMaskapai = _maskapai.KodeMaskapai,
                    NamaMaskapai = _maskapai.NamaMaskapai,
                    t = pEditMaskapaiVM.t
                };
                return View("Edit", _editMaskapaiVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }
        return View("Edit", pEditMaskapaiVM);
    }
    
    public IActionResult Create(CreateMaskapaiViewModel pCreateMaskapaiVM)
    {
        if (DebugMode.Debug)
        {
            pCreateMaskapaiVM.KodeMaskapai = "LR/LNI";
            pCreateMaskapaiVM.NamaMaskapai = "LION AIR";
            
        }
        return View("Create", pCreateMaskapaiVM);
    }

    
    [HttpPost]
    public IActionResult Update(EditMaskapaiViewModel pEditMaskapaiVM)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
                _maskapaiService.UpdateMaskapai(pEditMaskapaiVM.KodeMaskapai,
                    pEditMaskapaiVM.NamaMaskapai);

                var _listMaskapaiVM = new ListMaskapaiViewModel()
                {
                    Message = "Data sudah diubah",
                    t = pEditMaskapaiVM.t,
                };
                return RedirectToAction("List", _listMaskapaiVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Edit", pEditMaskapaiVM);
    }
    
    
    [HttpPost]
    public IActionResult Insert(CreateMaskapaiViewModel pCreateMaskapaiVM)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
                _maskapaiService.AddMaskapai(pCreateMaskapaiVM.KodeMaskapai,
                    pCreateMaskapaiVM.NamaMaskapai);

                pCreateMaskapaiVM.Message = "Data sudah tersimpan";
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("Create", pCreateMaskapaiVM);
    }

    
    [HttpPost]
    public IActionResult Delete(DeleteMaskapaiViewModel pDeleteMaskapaiVM)
    {
        ListMaskapaiViewModel _listMaskapaiVM = new ListMaskapaiViewModel();
        _listMaskapaiVM.t = pDeleteMaskapaiVM.t;
        
        try
        {
            if (ModelState.IsValid)
            {
                _setLoginID();
                MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
                _maskapaiService.DeleteMaskapai(pDeleteMaskapaiVM.KodeMaskapai);

                _listMaskapaiVM.Message = "Data sudah dihapus";
                return RedirectToAction("List", _listMaskapaiVM);
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return View("List", _listMaskapaiVM);
        
    }
    
    public IActionResult List(ListMaskapaiViewModel pListMaskapaiVM)
    {
        try
        {
            _setLoginID();
            MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
            var _maskapais = _maskapaiService.FindList();

            var _listMaskapaiVM = new ListMaskapaiViewModel();
            _listMaskapaiVM.UpdateTokenAndMessage(pListMaskapaiVM.t, pListMaskapaiVM.Message);
                
            if (_maskapais != null && _maskapais.Count > 0)
            {
                foreach (var _maskapai in _maskapais)
                {
                    _listMaskapaiVM.Maskapais.Add(
                        new DetailsMaskapaiViewModel()
                        {
                            KodeMaskapai = _maskapai.KodeMaskapai,
                            NamaMaskapai = _maskapai.NamaMaskapai,
                            CreatedAt = _maskapai.CreatedAt,
                            CreatedBy = _maskapai.CreatedBy,
                            UpdatedAt = _maskapai.UpdatedAt,
                            UpdatedBy = _maskapai.UpdatedBy,
                        }
                    );
                }
            }
            
            return View("List", _listMaskapaiVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View("List", pListMaskapaiVM);
    }
    
    
    public IActionResult Lookup(ListMaskapaiViewModel pListMaskapaiVM)
    {
        try
        {
            _setLoginID();
            MaskapaiService _maskapaiService = new MaskapaiService(_db, _loginID);
            var _maskapais = _maskapaiService.FindList();

            var _listMaskapaiVM = new ListMaskapaiViewModel();
            _listMaskapaiVM.UpdateTokenAndMessage(pListMaskapaiVM.t, pListMaskapaiVM.Message);
                
            if (_maskapais != null && _maskapais.Count > 0)
            {
                foreach (var _maskapai in _maskapais)
                {
                    _listMaskapaiVM.Maskapais.Add(
                        new DetailsMaskapaiViewModel()
                        {
                            KodeMaskapai = _maskapai.KodeMaskapai,
                            NamaMaskapai = _maskapai.NamaMaskapai,
                            CreatedAt = _maskapai.CreatedAt,
                            CreatedBy = _maskapai.CreatedBy,
                            UpdatedAt = _maskapai.UpdatedAt,
                            UpdatedBy = _maskapai.UpdatedBy,
                        }
                    );
                }
            }
            
            return PartialView("Lookup", _listMaskapaiVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return PartialView("Lookup", pListMaskapaiVM);
    }
}