using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class TravelOptionsVm
    {
        [Required]
        public int AccommodationId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = System.DateTime.Today;
        public int TravelPartners { get; set; }
        [Required]
        [Range(1, 1, ErrorMessage = "Reisgezelschap moet altijd uit 2 volwassenen bestaan")]
        public int Adults { get; set; } = 1;
        [Required]
        [Range(0, 2, ErrorMessage = "Reisgezalschap bestaat uit 0, 1 of 2 kinderen")]
        public int Children { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "Een reis beschikt over 1, 2 of 3 kamers")]
        public int Rooms { get; set; }


        public TravelOptionsVm(int id)
        {
            AccommodationId = id;
        }

        public TravelOptionsVm()
        {

        }

        public TravelOptionsVm(int id, DateTime date, int adults, int children, int rooms)
        {
            AccommodationId = id;
            Date = date;
            Adults = adults;
            Children = children;
            Rooms = rooms;
        }
    }
}
