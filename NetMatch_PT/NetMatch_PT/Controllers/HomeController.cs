﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private AccommodationDetailVmConverter accoConverter = new AccommodationDetailVmConverter();

        public HomeController(ILogger<HomeController> logger, AccommodationRepo accoRepo)
        {
            _logger = logger;
            _accoRepo = accoRepo;
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
                    accommodations.Add(accoConverter.ConvertToViewModel(_accoRepo.GetById(i)));
                }
            }
            return View(accommodations);
        }

        public IActionResult Privacy()
        {
            return View();
        }public IActionResult ReisBoeken()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
