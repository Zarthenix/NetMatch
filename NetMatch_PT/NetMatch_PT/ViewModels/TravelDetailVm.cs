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
        public AccommodationDetailVm Accommodation { get; set; }
        public int CustomerID { get; set; }
        public int Rooms { get; set; }
        public int Kids { get; set; }
        public bool Discount { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Transport { get; set; }
        public int Tickets { get; set; }
        public FlightDetailVm FlightDetailVm { get; set; }
        public List<InsuranceDetailVm> Insurances { get; set; }
        public List<TravelCompanyDetailVm> TravelCompany { get; set; }
        public List<FlightDetailVm> Airports { get; set; }
    }
}
