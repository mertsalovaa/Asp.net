using Asp_01_intro.DataBase.Initializer;
using Asp_01_intro.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Asp_01_intro.DataBase
{
    public class BooksContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BooksContext()
            : base("name=BooksConnectionString")
        {
            Database.SetInitializer(new CustomInitializer());
        }

    }
}