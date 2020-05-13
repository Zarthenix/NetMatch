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

        public IActionResult Result(string SearchTerm)
        {
            List <Accommodation> accommodations = _accommodationRepo.GetAll();
            AccommodationVm vm = new AccommodationVm();

            if (SearchTerm == string.Empty)
            {
                vm.SelectedAccommodations = _accommodationDetailVmConverter.ModelsToViewModels(accommodations);
                return View(vm);
            }

            List<Accommodation>[] filteredAccommodations = GetSearchResultLists(accommodations, SearchTerm);
            vm.SelectedAccommodations = _accommodationDetailVmConverter.ModelsToViewModels(filteredAccommodations[0]);
            vm.UnselectedAccommodations = _accommodationDetailVmConverter.ModelsToViewModels(filteredAccommodations[1]);
            
            return View(vm);
        }

        private List<Accommodation>[] GetSearchResultLists(List<Accommodation> accommodations, string search)
        {
            List<Accommodation>[] results = new List<Accommodation>[2];

            List<Accommodation> tempSelectedAccommodations = new List<Accommodation>();
            tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Country.ToString().Contains(search)));
            tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Title.Contains(search)));
            tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Description.Contains(search)));

            results[0] = tempSelectedAccommodations;

            List<Accommodation> tempUnselectedAccommodations = new List<Accommodation>();

            foreach (Accommodation a in accommodations)
            {
                if (!tempSelectedAccommodations.Contains(a))
                {
                    tempUnselectedAccommodations.Add(a);
                }
            }

            results[1] = tempUnselectedAccommodations;

            return results;
        }

        public IActionResult Example()
        {
            return View();
        }


        public IActionResult DatePicker()
        {
            return PartialView();
        }

        public IActionResult TravelCompanyPicker()
        {
            return PartialView();
        }

        public IActionResult Receipt()
        {
            return PartialView();
        }
    }
}