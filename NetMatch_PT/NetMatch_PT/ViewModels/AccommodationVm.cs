using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class AccommodationVm : SearchVm
    {
        public List<AccommodationDetailVm> AccommodationDetailViewModels { get; set; } = new List<AccommodationDetailVm>();
    }
}
