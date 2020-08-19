﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Entities
{
    public class Developer
    {
        public Developer()
        {
            Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Company { get; set; }

        // Navigation props
        public virtual ICollection<Game> Games { get; set; }
    }
}
