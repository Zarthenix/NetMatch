﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class AccommodationDetailVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public  string Image { get; set; }
    }
}
