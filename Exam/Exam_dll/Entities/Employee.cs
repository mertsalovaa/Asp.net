using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public int? SpecialityId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
