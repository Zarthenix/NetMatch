using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public Flight(int id, string name, string location, decimal price)
        {
            ID = id;
            Name = name;
            Location = location;
            Price = price;
        }
    }
}
