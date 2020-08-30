using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameesStore_client.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter name")]
        public string Company { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please, enter description")]
        public string Description { get; set; }

        [Display(Name = "Logo photo")]
        [Required(ErrorMessage = "Please, enter path to photo")]
        public string Image { get; set; }
    }
}