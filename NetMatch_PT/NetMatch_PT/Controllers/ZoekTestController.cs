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
    public class ZoekTestController : Controller
    {

        private readonly AccommodationRepo _accommodationRepo;
        private readonly AccommodationDetailVmConverter _accommodationDetailVmConverter = new AccommodationDetailVmConverter();

        public ZoekTestController(AccommodationRepo accRepo)
        {
            _accommodationRepo = accRepo;
        }
        public IActionResult Index()
        {
            Accommodation ac1 = _accommodationRepo.GetById(1);
            Accommodation ac2 = _accommodationRepo.GetById(2);
            Accommodation ac3 = _accommodationRepo.GetById(3);

            AccommodationDetailVmConverter converter = new AccommodationDetailVmConverter();
            AccommodationDetailVm vm1 = converter.ModelToViewModel(ac1);
            AccommodationDetailVm vm2 = converter.ModelToViewModel(ac2);
            AccommodationDetailVm vm3 = converter.ModelToViewModel(ac3);

            List<AccommodationDetailVm> vms = new List<AccommodationDetailVm>();
            vms.Add(vm1);
            vms.Add(vm2);
            vms.Add(vm3);

            return View(vms);
        }
    }
}