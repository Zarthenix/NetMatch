using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public Accommodation(int id, string title, DateTime date,
            decimal price, byte[] image, string description)
        {
            Id = id;
            Title = title;
            Date = date;
            Price = price;
            Image = image;
            Description = description;
        }
    }

}
