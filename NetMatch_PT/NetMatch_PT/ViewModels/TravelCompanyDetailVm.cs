using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class TravelCompanyDetailVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public TravelCompanyDetailVm(int id)
        {
            Id = id;
        }

        public TravelCompanyDetailVm(int id, string firstname, DateTime birthdate, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
        }
    }
}
