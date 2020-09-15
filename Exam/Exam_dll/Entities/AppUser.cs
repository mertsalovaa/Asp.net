using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Entities
{
    public class AppUser : IdentityUser
    {
        public int? UserDataId { get; set; }

        public virtual UserData UserData { get; set; }
    }
}
