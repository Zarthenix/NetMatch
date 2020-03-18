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
    public class TravelAgentController : Controller
    {
        private readonly TravelAgentRepository _travelAgentRepo;
        public TravelAgentController(TravelAgentRepository taRepo)
        {
            _travelAgentRepo = taRepo;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            TravelAgent ta = _travelAgentRepo.GetById(id);

            TravelAgentDetailVmConverter converter = new TravelAgentDetailVmConverter();
            TravelAgentDetailVm vm = converter.ModelToViewModel(ta);

            return View(vm);
        }
    }
}
