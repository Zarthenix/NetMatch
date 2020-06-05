using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.ViewModels;

namespace NetMatch_PT.Contexts.Interfaces
{
    public interface IAccommodationContext
    {
        Accommodation GetById(int id);
        List<Accommodation> GetAll();
        List<Accommodation> Search(string searchTerm);
        Accommodation GetPrices(Accommodation a);
        List<Accommodation> QuickSearch(SearchVm search);
    }
}
