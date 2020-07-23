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

        public string RoomName { get; set; }

        /*Navigation Properties*/
        public virtual EscapeQuest EscapeQuest { get; set; }
    }
}