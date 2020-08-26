namespace GamesStore_dal
{
    using GamesStore_dal.Entities;
    using GamesStore_dal.Initializer;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {
            Database.SetInitializer(new GameInitializer());
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}