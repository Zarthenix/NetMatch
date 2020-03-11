using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models.Enums;

namespace NetMatch_PT.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public TravelTypes Traveltype { get; set; }
        public Countries Countries { get; set; }
        public List<AccommodationDate> DateList { get; set; }

        public Accommodation(int id, string title,
            decimal price, byte[] image, string description)
        {
            Id = id;
            Title = title;
            Price = price;
            Image = image;
            Description = description;
        }
        public Accommodation(int id)
        {
            Id = id;
        }
    }

}
