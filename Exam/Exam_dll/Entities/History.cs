using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class History
    {
        public History()
        {
            Orders = new List<Order>();
        }
        
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    } 
}
