    using EscapeQuest_DZ.DacaAccess.Initialezer;
    using EscapeQuest_DZ.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

namespace EscapeQuest_DZ.DacaAccess
{
    public class EscapeContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EscapeQuest> EscapeQuests { get; set; }

        public EscapeContext()
            : base("name=EscapeContext")
        { Database.SetInitializer(new CustomInitializer()); }
    }
}