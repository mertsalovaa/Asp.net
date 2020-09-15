using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class BeautyService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public int? EmployeeId { get; set; }
        public int? ServiceTypeiId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ServiceType ServiceType { get; set; }
    }
}
