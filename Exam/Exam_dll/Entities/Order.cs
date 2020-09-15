using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class Order
    {
        public Order()
        {
            BeautyServiceDates = new List<BeautyServiceDate>();
        }
        
        [Key]
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<BeautyServiceDate> BeautyServiceDates { get; set; }
    }
}
