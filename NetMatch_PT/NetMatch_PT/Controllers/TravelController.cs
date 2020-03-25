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
    public class TravelController : Controller
    {
        private readonly TravelRepo _TravelRepo;
        public TravelController(TravelRepo travRepo)
        {
            _TravelRepo = travRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Travel tr = _TravelRepo.GetById(id);

            TravelDetailVmConverter converter = new TravelDetailVmConverter();
            TravelDetailVm vm = converter.ConvertToViewModel(tr);

            return View(vm);
        }
    }
}
