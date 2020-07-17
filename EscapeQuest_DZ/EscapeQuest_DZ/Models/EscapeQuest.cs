using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EscapeQuest_DZ.Models
{
    public class EscapeQuest
    {
        public EscapeQuest()
        {
            Galleries = new List<Gallery>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CountPlayer { get; set; }
        public int MinAge { get; set; }
        [StringLength(13)]
        public string Phone { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public int Price { get; set; }
        [Range(1, 5)]
        public int LevelFear { get; set; }
        [Range(1, 5)]
        public int LevelDifficulty { get; set; }
        public string Email { get; set; }

        /*Navigation Properties*/
        public Address Address { get; set; }
        public ICollection<Gallery> Galleries { get; set; }
    }
}