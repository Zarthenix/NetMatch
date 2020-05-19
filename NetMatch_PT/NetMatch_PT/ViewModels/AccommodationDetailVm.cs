using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models.Enums;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels
{
    public class AccommodationDetailVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public TravelTypes Traveltype { get; set; }
        public Countries Country { get; set; }
        public List<AccommodationPrices> DatePrices { get; set; }

    }
}
