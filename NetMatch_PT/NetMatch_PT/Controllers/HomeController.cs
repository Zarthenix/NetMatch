using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetMatch_PT.Models;
using NetMatch_PT.Repositories;
using NetMatch_PT.ViewModels;
using NetMatch_PT.ViewModels.Converters;

namespace NetMatch_PT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AccommodationRepo _accoRepo;
        private AccommodationDetailVmConverter _accoConverter = new AccommodationDetailVmConverter();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public HomeController(ILogger<HomeController> logger, AccommodationRepo accoRepo, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accoRepo = accoRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            int[] popularAccommodations = (int[])ContentHandler.GetJson<int[]>("popularAccommodations");
            List<AccommodationDetailVm> accommodations = new List<AccommodationDetailVm>();
            foreach (int i in popularAccommodations)
            {
                Accommodation ac = _accoRepo.GetById(i);
                if (ac != null)
                {
                    accommodations.Add(_accoConverter.ModelToViewModel(_accoRepo.GetById(i)));
                }
            }

            HomepageVm vm = new HomepageVm
            {
                Accommodations = accommodations,
                SearchVm = new SearchVm()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReisBoeken()
        {
            if (_session.GetObjectFromJson<TravelOptionsVm>("TravelOptions") == null)
            {
                TempData["failed"] = "Graag eerst een accommodatie en bijbehorende reisopties te selecteren.";
                return RedirectToAction("FullSearch", "Search", new {searchTerm = ""});
            }
            BoekingVm boeking = new BoekingVm();
            boeking.TravelOptions = _session.GetObjectFromJson<TravelOptionsVm>("TravelOptions");
            boeking.TravelCompanions = new List<TravelCompanionVm>((boeking.TravelOptions.Adults - 1) + boeking.TravelOptions.Children);
            return View(boeking);
        }

        //[HttpPost]
        //public IActionResult ReisBoeken(BoekingVm vm)
        //{

        //}

        public IActionResult PDFboeking()
        {
            return View();
        }

        public IActionResult Contactpagina()
        {
            return View();
        }

        public IActionResult Overonspagina()
        {
            return View();
        }

        public IActionResult Partnerpagina()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
