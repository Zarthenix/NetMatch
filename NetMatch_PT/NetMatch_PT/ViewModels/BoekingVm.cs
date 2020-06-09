using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class BoekingVm
    {
        public TravelOptionsVm TravelOptions { get; set; }
        public List<TravelCompanionVm> TravelCompanions { get; set; } = new List<TravelCompanionVm>();

        [Display(Name="5% korting reisagent")]
        public bool AgentKorting { get; set; }

        public string Vervoer { get; set; }

        [Display(Name="Annuleringsverzekering")]
        public bool AnnuleringsVerzekering { get; set; }
        [Display(Name = "Reisverzekering")]
        public bool ReisVerzekering { get; set; }

        public int Tickets { get; set; }

        [Required(ErrorMessage = "Voornaam is vereist")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Achternaam is vereist")]
        public string Achternaam { get; set; }
        [Required(ErrorMessage = "Geboortedatum is vereist")]
        [Display(Name = "Geboortedatum")]
        public DateTime GeboorteDatum { get; set; }
        [Required(ErrorMessage = "Adres is vereist")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Tel. nummer is vereist")]
        [Display(Name = "Telefoonnummer")]
        public string TelefoonNummer { get; set; }
        [Required(ErrorMessage = "Email is vereist")]
        public string Email { get; set; }

        public double TotalePrijs { get; set; }
    }
}
