using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class ServiceType
    {
        public ServiceType()
        {
            BeautyServices = new List<BeautyService>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<BeautyService> BeautyServices { get; set; }
    }
}
