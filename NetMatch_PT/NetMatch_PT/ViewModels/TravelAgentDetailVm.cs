using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels
{
    public class TravelAgentDetailVm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public TravelAgentDetailVm(int id)
        {
            Id = id;
        }
    }
}
