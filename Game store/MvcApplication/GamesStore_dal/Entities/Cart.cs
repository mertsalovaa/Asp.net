using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Entities
{
    public class Cart
    {
        public Cart()
        {
            Games = new List<Game>();
        }

        public int Id { get; set; }

        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
