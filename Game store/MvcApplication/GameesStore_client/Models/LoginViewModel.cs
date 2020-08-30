using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameesStore_client.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, enter login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Please, enter password")]
        public string Password { get; set; }
    }
}