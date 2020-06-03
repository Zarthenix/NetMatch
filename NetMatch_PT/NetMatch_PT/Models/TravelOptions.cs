using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class TravelOptions
    {
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }
        public DateTime Date { get; set; }
        public int TravelPartners { get; set; }
        public int Rooms { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }


        public TravelOptions(int id, int adults, int children, int rooms)
        {
            AccommodationId = id;
            Adults = adults;
            Children = children;
            Rooms = rooms;
            TravelPartners = adults + children;
        }
    }
}
