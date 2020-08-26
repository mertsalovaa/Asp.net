using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameesStore_client.Models
{
    public class GameViewModel
    {
        private static readonly int Now = DateTime.Now.Year;
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage = "Please, enter name")]
        public string Name { get; set; }

        [Display(Name="Year")]
        [Range(1980, 2020, ErrorMessage = "Year is out of range (1980-2020)")]
        [Required(ErrorMessage = "Please, enter year")]
        public int Year { get; set; }

        [Display(Name= "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please, enter price")]
        [Display(Name= "Price")]
        public float Price { get; set; }

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Please, enter rating")]
        [Range(1,5, ErrorMessage = "Rating is out of range (1-5)")]
        public int Rating { get; set; }

        [Display(Name= "Photo")]
        public string Image { get; set; }

        [Display(Name= "Genre")]
        [Required(ErrorMessage = "Please, select genre")]
        public string Genre { get; set; }

        [Display(Name= "Developer")]
        [Required(ErrorMessage = "Please, select developer")]
        public string Developer { get; set; }
    }
}