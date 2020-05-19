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

        public IActionResult Example()
        {
            HttpContext.Session.SetString("Title", "Test Sessie Title");
            return View();
        }

        public IActionResult Receipt()
        {
            TravelOptionsVm vm = new TravelOptionsVm();

            if (_session.GetObjectFromJson<TravelOptions>("TravelOptions") != null)
            {
                vm = _travelOptionsVmConverter.ModelTViewoModel(_session.GetObjectFromJson<TravelOptions>("TravelOptions"));
            }
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

        public IActionResult TravelOptions(int id)
        {
            TravelOptionsVm vm = new TravelOptionsVm(id);
            if (_session.GetObjectFromJson<TravelOptions>("TravelOptions") != null)
            {
                vm = _travelOptionsVmConverter.ModelTViewoModel(_session.GetObjectFromJson<TravelOptions>("TravelOptions"));
                vm.AccommodationId = id;
            }
            vm.AccommodationId = id;
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult TravelOptions(TravelOptionsVm vm)
        {
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
            TravelOptions to = _travelOptionsVmConverter.ViewModelToModel(vm);
            _session.SetObjectAsJson("TravelOptions", to);

            return RedirectToAction("Receipt");
        }
    }
}