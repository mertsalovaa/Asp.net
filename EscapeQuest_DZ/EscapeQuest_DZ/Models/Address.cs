using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EscapeQuest_DZ.Models
{
    public class Address
    {
        public Address()
        {
            EscapeQuests = new List<EscapeQuest>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        /*Navigation Properties*/
        public ICollection<EscapeQuest> EscapeQuests { get; set; }
    }
}