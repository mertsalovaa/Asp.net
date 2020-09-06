using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Entities
{
    public class Game
    {

        public Game()
        {
            Orders = new List<Order>();
            Carts = new List<Cart>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        public int Count { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Image { get; set; }

        public int? GenreId { get; set; }
        public int? DeveloperId { get; set; }

        // Navigation props

        public virtual Genre Genre { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
