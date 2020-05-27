using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class AccommodationVm : SearchVm
    {
        public List<AccommodationDetailVm> SelectedAccommodations { get; set; } = new List<AccommodationDetailVm>();

        public List<AccommodationDetailVm> UnselectedAccommodations { get; set; } = new List<AccommodationDetailVm>();
        public List<AccommodationDetailVm> AccommodationDetailViewmodels { get; set; } = new List<AccommodationDetailVm>();
    }
}
