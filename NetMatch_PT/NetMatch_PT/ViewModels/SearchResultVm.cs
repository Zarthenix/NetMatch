using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels
{
    public class SearchResultVm
    {
        public List<AccommodationDetailVm> results { get; set; }
        public SearchVm SearchVm { get; set; } = new SearchVm();
    }
}
