﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class HomepageVm
    {
        public List<AccommodationDetailVm> Accommodations { get; set; }

        public SearchVm SearchVm { get; set; }
    }
}
