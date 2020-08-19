using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planner.Entity
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection")
        {}
        public DbSet<Event> Events { get; set; }
    }
}