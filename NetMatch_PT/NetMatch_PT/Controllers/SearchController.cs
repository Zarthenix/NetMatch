using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Models.Enums;
using NetMatch_PT.Repositories;
using NetMatch_PT.ViewModels;
using NetMatch_PT.ViewModels.Converters;
using Newtonsoft.Json;

namespace NetMatch_PT.Controllers
{
    public class SearchController : Controller
    {
        private AccommodationRepo _accRepo;
        private AccommodationDetailVmConverter _accConverter;

        public SearchController(AccommodationRepo repo, AccommodationDetailVmConverter conv)
        {
            _accRepo = repo;
            _accConverter = conv;
        }

        [HttpGet]
        public IActionResult FullSearch(string searchTerm)
        {
            List<Accommodation> results = string.IsNullOrEmpty(searchTerm) ? 
                _accRepo.GetAll() : _accRepo.Search(searchTerm);

            if (results.Count == 0)
            {
                ViewData["result"] = (string) ContentHandler.GetJson<string>("searchResultNotFound");
            }
            else
            {
                string resultText = (string)ContentHandler.GetJson<string>("searchResultFound");
                ViewData["result"] = resultText.Replace('/', (char)results.Count);
            }

            return View("Result", _accConverter.ModelsToViewModels(results));
        }

        [HttpGet]
        public IActionResult QuickSearch(HomepageVm svm)
        {
            List<Accommodation> accommodations = new List<Accommodation>();
            if (svm.SearchVm == null)
            {
                accommodations = _accRepo.GetAll();
            }
            else { 
                accommodations = _accRepo.QuickSearch(svm.SearchVm);
            }

            if (accommodations.Count == 0)
            {
                ViewData["result"] = (string)ContentHandler.GetJson<string>("searchResultNotFound");
            }
            else
            {
                string resultText = (string)ContentHandler.GetJson<string>("searchResultFound");
                ViewData["result"] = resultText.Replace('/', (char)accommodations.Count);
            }

            return View("Result", _accConverter.ModelsToViewModels(accommodations));
        }


    }
}