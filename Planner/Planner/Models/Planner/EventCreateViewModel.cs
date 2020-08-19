﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planner.Models.Planner
{
    public class EventCreateViewModel
    {
        [Required(ErrorMessage = "Title is required!")]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Image is required!")]
        [Display(Name = "Image URL:")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        [Display(Name = "Date event:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
    }
}