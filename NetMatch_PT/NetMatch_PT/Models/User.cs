using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NetMatch_PT.Models
{
    public class User
    {
       
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<User> Users = new List<User>();
        public bool ValidatePassword(string givenPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(givenPassword, Password);
        }

        public void HashPassword()
        {
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(Password);
        }
    }
}
