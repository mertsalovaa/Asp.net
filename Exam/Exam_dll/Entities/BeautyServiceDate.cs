using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class BeautyServiceDate
    {       
        [Key]
        public int Id { get; set; }
        public int? BServiceId { get; set; }
        public DateTime Date { get; set; }

        public virtual BeautyService BeautyService { get; set; }
    }
}
