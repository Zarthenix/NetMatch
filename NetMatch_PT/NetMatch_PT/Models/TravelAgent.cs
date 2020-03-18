using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Models
{
    public class TravelAgent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TravelAgent(int id)
        {
            Id = id;
        }
        public TravelAgent(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
