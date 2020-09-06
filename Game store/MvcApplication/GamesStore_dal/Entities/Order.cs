using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Entities
{
    public class Order
    {
        public Order()
        {
            Games = new List<Game>();
        }
        
        [Key]
        public int Id { get; set; }
        public int TotalPrice { get; set; }

        public int? UserId { get; set; }
        public virtual CustomUser User { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
