using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class Speciality
    {
        public Speciality()
        {
            Employees = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Nav props
        public ICollection<Employee> Employees { get; set; }
    }
}
