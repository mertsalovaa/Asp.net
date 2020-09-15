namespace Exam_dll
{
    using Exam_dll.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {
        }

        public DbSet<UserData> UserDatas { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cart>().HasOptional(x => x.CustomUser).WithOptionalPrincipal(y => y.Cart);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}