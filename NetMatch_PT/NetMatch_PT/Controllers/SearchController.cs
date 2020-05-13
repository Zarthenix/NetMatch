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

        public IActionResult FullSearch(FullSearchVm fsvm)
        {
            List<Accommodation> accommodations = _accRepo.GetAll();
            AccommodationVm vm = new AccommodationVm();

            if (fsvm.SearchTerm == string.Empty)
            {
                vm.SelectedAccommodations = _accConverter.ModelsToViewModels(accommodations);
                return View(vm);
            }

            List<Accommodation>[] filteredAccommodations = GetSearchResultLists(accommodations, fsvm);
            vm.SelectedAccommodations = _accConverter.ModelsToViewModels(filteredAccommodations[0]);
            vm.UnselectedAccommodations = _accConverter.ModelsToViewModels(filteredAccommodations[1]);
            return View(vm);
        }

        private List<Accommodation>[] GetSearchResultLists(List<Accommodation> accommodations, SearchVm viewModel)
        {
            List<Accommodation>[] results = new List<Accommodation>[2];
            List<Accommodation> tempSelectedAccommodations = new List<Accommodation>();

            if (viewModel is FullSearchVm)
            {
                //Voeg alle accommodaties toe waarvan de zoekopdracht in de landnaam zit
                tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Country.ToString().Contains(viewModel.SearchTerm)));

                //Voeg alle accommodaties toe waarvan de zoekopdracht in de titel zit
                tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Title.Contains(viewModel.SearchTerm)));

                //Voeg alle accommodaties toe waarvan de zoekopdracht in de omschrijving zit
                tempSelectedAccommodations.AddRange(accommodations.Where(n => n.Description.Contains(viewModel.SearchTerm)));
                
                
            }
            else if (viewModel is SortSearchVm)
            {
                SortSearchVm vm = (SortSearchVm)viewModel;

                if (vm.Month != null) //voeg alle accommodaties toe met reisdatums waarvan een maand overeenkomt met de opgegeven maand
                    tempSelectedAccommodations.AddRange(accommodations.FindAll(n => n.DatePrices.Count(p => p.Date.Month - 1 == (int)vm.Month) != 0));

                if (vm.Country != null) //voeg alle accommodaties toe waar het land overeenkomt met het opgegeven land
                    tempSelectedAccommodations.AddRange(accommodations.Where(n=>n.Country == vm.Country));

                if (vm.TravelType != null)
                { //check welke maanden er in de reisdata zit voor de accommodaties en voeg deze toe in de lijst als dit overeenkomt met het opgegeven seizoen
                    if (vm.TravelType == TravelTypes.Zomer)
                    {
                        tempSelectedAccommodations.AddRange(accommodations.FindAll(n => n.DatePrices.Count(p => p.Date.Month >= 3 || p.Date.Month <= 9) != 0));
                    }
                    else if (vm.TravelType == TravelTypes.Winter)
                    {
                        tempSelectedAccommodations.AddRange(accommodations.FindAll(n => n.DatePrices.Count(p => p.Date.Month < 3 || p.Date.Month > 9) != 0));
                    }
                }
            }
            results[0] = tempSelectedAccommodations.Distinct().ToList();

            List<Accommodation> tempUnselectedAccommodations = new List<Accommodation>();

            foreach (Accommodation a in accommodations)
            {
                if (!results[0].Contains(a))
                {
                    tempUnselectedAccommodations.Add(a);
                }
            }

            results[1] = tempUnselectedAccommodations;

            return results;
        }
    }
}