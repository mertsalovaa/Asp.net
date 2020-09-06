using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameesStore_client.Models
{
    public class RegisterViewModel
    {
        //[Required(ErrorMessage = "Please, enter login")]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public string Image { get; set; }
        //[Required(ErrorMessage = "Please, enter email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Please, enter password")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}