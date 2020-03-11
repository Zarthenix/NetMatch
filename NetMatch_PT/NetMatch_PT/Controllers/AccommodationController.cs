using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AccommodationController(AccommodationRepo accRepo)
        {
            _accommodationRepo = accRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            IActionResult returnValue = View();
            Accommodation ac = _accommodationRepo.Detail(id);
            if (ac == null)
            {
                //redirect naar error-page
            }
            else
            {
                AccommodationDetailVmConverter converter = new AccommodationDetailVmConverter();
                AccommodationDetailVm vm = converter.ConvertToViewModel(ac);
                returnValue = View(vm);
            }
            return returnValue;
        }
    }
}