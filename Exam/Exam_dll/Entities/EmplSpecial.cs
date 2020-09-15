using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class EmplSpecial
    {
        public int? EmployeeId { get; set; }
        public int? SpecialityId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
