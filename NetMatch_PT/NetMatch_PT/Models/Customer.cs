using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Woonplaats { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Telefoonnummer { get; set; }

        public Customer(int id, string firstname, string lastname, string address, string woonplaats,
            string postcode, string email, DateTime geboortedatum, string telefoonnummer)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            Woonplaats = woonplaats;
            Postcode = postcode;
            Email = email;
            Geboortedatum = geboortedatum;
            Telefoonnummer = telefoonnummer;
        }
        public Customer(int id)
        {
            Id = id;
        }
    }
}
