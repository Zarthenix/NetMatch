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
        public Countries Country { get; set; }
        public List<AccommodationPrices> DatePrices { get; set; } = new List<AccommodationPrices>();

        public Accommodation(int id, string title, byte[] image, string description)
        {
            Id = id;
            Title = title;
            Image = image;
            Description = description;
        }
        public Accommodation(int id)
        {
            Id = id;
        }
    }

}
