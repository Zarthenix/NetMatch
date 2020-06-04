using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Boeking
    {
        public int Id { get; set; }
        public int TravelId { get; set; }
        public DateTime Datum { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string VoornaamReisgezel { get; set; }
        public string AchternaamReisgezel { get; set; }
    
    }
}
