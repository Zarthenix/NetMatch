using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class CustomerDetailVm
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

        public CustomerDetailVm(int id)
        {
            Id = id;
        }
    }
}
