using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class TravelOptionsVm
    {
        [Required]
        public int AccommodationId { get; set; }
        public AccommodationDetailVm Accommodation { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SelectDate { get; set; }
        [Required]
        public int Adults { get; } = 2;
        [Required]
        [DisplayName("Aantal Kinderen")]
        [Range(0, 2, ErrorMessage = "Reisgezalschap bestaat uit 0, 1 of 2 kinderen")]
        public int Children { get; set; }
        [Required]
        [DisplayName("Aantal Kamers")]
        [Range(1, 3, ErrorMessage = "Een reis beschikt over 1, 2 of 3 kamers")]
        public int Rooms { get; set; }


        public TravelOptionsVm(int id)
        {
            AccommodationId = id;
        }

        public TravelOptionsVm(int id, DateTime date)
        {
            AccommodationId = id;
            SelectDate = date;
            Adults = 2;
        }
        public TravelOptionsVm()
        {

        }

        public TravelOptionsVm(int id, int children, int rooms, DateTime date)
        {
            AccommodationId = id;
            Children = children;
            Rooms = rooms;
            SelectDate = date;
        }
    }
}
