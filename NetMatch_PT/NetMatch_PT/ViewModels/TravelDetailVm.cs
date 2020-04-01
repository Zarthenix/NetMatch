using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models.Enums;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels
{
    public class TravelDetailVm
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ReisagentID { get; set; }
        public int AccomodationID { get; set; }
        public int CustomerID { get; set; }
        public bool Discount { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Insurance { get; set; }
        public string Transport { get; set; }
    }
}
