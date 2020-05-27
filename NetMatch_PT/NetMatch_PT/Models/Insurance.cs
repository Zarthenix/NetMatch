using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Insurance
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Insurance()
        {

        }
        public Insurance(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
    }
}
