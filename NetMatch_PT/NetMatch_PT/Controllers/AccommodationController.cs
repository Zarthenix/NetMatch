using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Memory;
using NetMatch_PT.Models;
using NetMatch_PT.Repositories;
using NetMatch_PT.ViewModels;
using NetMatch_PT.ViewModels.Converters;

namespace NetMatch_PT.Controllers
{
    public class AccommodationController : Controller
    {
        private readonly AccommodationRepo _accommodationRepo;
        private readonly AccommodationDetailVmConverter _accommodationDetailVmConverter;
        private readonly TravelOptionsVmConverter _travelOptionsVmConverter = new TravelOptionsVmConverter();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AccommodationController(AccommodationRepo accRepo, AccommodationDetailVmConverter vmConverter, IHttpContextAccessor httpContextAccessor)
        {
            _accommodationRepo = accRepo;
            _accommodationDetailVmConverter = vmConverter;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            Accommodation ac = _accommodationRepo.GetById(id);

            AccommodationDetailVmConverter converter = new AccommodationDetailVmConverter();
            AccommodationDetailVm vm = converter.ModelToViewModel(ac);

            return View(vm);
        }


        public IActionResult Receipt()
        {
            TravelOptionsVm to = new TravelOptionsVm();

            if (_session.GetObjectFromJson<TravelOptionsVm>("TravelOptions") != null)
            {
                to = (_session.GetObjectFromJson<TravelOptionsVm>("TravelOptions"));
                to.Accommodation = _accommodationDetailVmConverter.ModelToViewModel(_accommodationRepo.GetById(to.AccommodationId));
            }

            return PartialView(to);
        }

        [HttpGet]
        public IActionResult TravelOptions(int id, DateTime bookingsdate)
        {
            ViewData["Description"] = (string)ContentHandler.GetJson<string>("TravelCompanyPickerDescription");
            TravelOptionsVm vm = new TravelOptionsVm(id, bookingsdate);
            if (_session.GetObjectFromJson<TravelOptionsVm>("TravelOptions") != null)
            {
                vm = (_session.GetObjectFromJson<TravelOptionsVm>("TravelOptions"));
                vm.SelectDate = bookingsdate;
            }
            vm.Accommodation = _accommodationDetailVmConverter.ModelToViewModel(_accommodationRepo.GetById(id));
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult TravelOptions(TravelOptionsVm vm)
        {
            vm.Accommodation = _accommodationDetailVmConverter.ModelToViewModel(_accommodationRepo.GetById(vm.AccommodationId));

            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            if (vm.Children == 0 && vm.Rooms > 1)
            {
                ModelState.AddModelError("Volwassenen in een kamer", "Volwassenen moeten een kamer delen");
                return PartialView(vm);
            }
            else if (vm.Children == 1 && vm.Rooms != 2)
            {
                ModelState.AddModelError("Volwassenen met een kind", "Volwassenen moeten een kamer delen en een kind moet op een aparte kamer");
                return PartialView(vm);
            }
            else if (vm.Children == 2 && vm.Rooms < 2)
            {
                ModelState.AddModelError("Volwassenen met een kind", "Volwassenen moeten een kamer delen en een kind moet op een aparte kamer");
                return PartialView(vm);
            }

            _session.SetObjectAsJson("TravelOptions", vm);
            return RedirectToAction("Receipt", vm);
        }
    }
}