using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Travel
    {
       

        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ReisagentID { get; set; }
        public int AccomodationID { get; set; }
        public int CustomerID { get; set; }
        public int Rooms { get; set; }
        public int Kids { get; set; }
        public bool Discount { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Transport { get; set; }

        public Travel(int id, int reisagentid,
            decimal price, int accomodationid, int customerid, bool discount, DateTime departuredate, string insurance, string transport)
        {
            Id = id;
            Price = price;
            ReisagentID = reisagentid;
            AccomodationID = accomodationid;
            CustomerID = customerid;
            Discount = discount;
            DepartureDate = departuredate;
            Transport = transport;
        }
        public Travel (int id)
        {
            Id = id;
        }
    }
}
