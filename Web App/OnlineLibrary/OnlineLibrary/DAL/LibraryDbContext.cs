using Microsoft.AspNet.Identity.EntityFramework;
using OnlineLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineLibrary.DAL
{
    public class LibraryDbContext : IdentityDbContext
    {

        public LibraryDbContext() : base("LibraryDbContext")
        {
        }

        public static LibraryDbContext Create()
        {
            return new LibraryDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Book>().HasRequired
                (x => x.User).WithMany(x => x.Books)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}