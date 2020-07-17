using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EscapeQuest_DZ.Models
{
    public class Gallery
    {       
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }

        /*Navigation Properties*/
        public EscapeQuest EscapeQuest { get; set; }
    }
}