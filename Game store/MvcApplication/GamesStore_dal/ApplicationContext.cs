namespace GamesStore_dal
{
    using GamesStore_dal.Entities;
    using GamesStore_dal.Initializer;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {
            //Database.SetInitializer(new GameInitializer());
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}