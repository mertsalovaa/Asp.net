using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_dal.Entities
{
    public class CustomUser : IdentityUser
    {
        public CustomUser()
        {
            Orders = new List<Order>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Image { get; set; }
        public ICollection<Order> Orders { get; set; }

        //[ForeignKey("Cart")]
        //public int? CartId { get; set; }
        public  Cart Cart { get; set; }
    }
}
