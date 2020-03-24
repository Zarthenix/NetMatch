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
    public class TravelCompanyController : Controller
    {
        private readonly TravelCompanyRepository _tcRepo;
        TravelCompanyDetailVmConverter Converter = new TravelCompanyDetailVmConverter();

        public TravelCompanyController(TravelCompanyRepository repo)
        {
            _tcRepo = repo;
        }
        public IActionResult index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            TravelCompany tc = _tcRepo.GetById(id);
            TravelCompanyDetailVm vm = Converter.ModelToViewModel(tc);

            return View(vm);
        }
    }
}
