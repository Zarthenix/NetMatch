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
        [Required(ErrorMessage = "Vul uw Emailadres in.")]
        [Display(Name = "Vul uw gebruiksnaam in :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vul uw wachtwoord in.")]
        [Display(Name = "Vul uw wachtwoord in :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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
