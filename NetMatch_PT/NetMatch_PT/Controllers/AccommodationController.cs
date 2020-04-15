using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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

        public AccommodationController(AccommodationRepo accRepo, AccommodationDetailVmConverter vmConverter)
        {
            _accommodationRepo = accRepo;
            _accommodationDetailVmConverter = vmConverter;
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
        public IActionResult Search(string SearchTerm)
        {
            return RedirectToAction("Result", new { SearchTerm });
        }
        public IActionResult Result(string SearchTerm)
        {
            if(SearchTerm == null)
            {
                return RedirectToAction("Detail", "Home");
            }
            AccommodationVm vm = new AccommodationVm();
            List<Accommodation> Accommodations = new List<Accommodation>();
            Accommodations = _accommodationRepo.Search(SearchTerm);
            vm.AccommodationDetailViewModels = _accommodationDetailVmConverter.ModelsToViewModels(Accommodations);
            return View(vm);
        }
    }
}