namespace OnlineLibrary.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineLibrary.DAL;
    using OnlineLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineLibrary.DAL.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(OnlineLibrary.DAL.LibraryDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            SeedRoles(context);
            SeedUsers(context);
            SeedBooks(context);
            SeedCategories(context);
            SeedComments(context);
        }

        private void SeedRoles(LibraryDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole()
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole()
                {
                    Name = "User"
                };
                roleManager.Create(role);
            }
        }

        private void SeedUsers(LibraryDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new ApplicationUser { UserName = "Admin@mail.com" };
                var adminresult = manager.Create(user, "123456789");
                if (adminresult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }

            if (!context.Users.Any(u => u.UserName == "user1"))
            {
                var user = new ApplicationUser { UserName = "user@mail.com" };
                var adminresult = manager.Create(user, "123456789");
                if (adminresult.Succeeded)
                {
                    manager.AddToRole(user.Id, "User");
                }
            }

            if (!context.Users.Any(u => u.UserName == "Prezes"))
            {
                var user = new ApplicationUser { UserName = "admin@mail.com" };
                var adminresult = manager.Create(user, "123456789");
                if (adminresult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }
        private void SeedBooks(LibraryDbContext context)
        {
            var idUser = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            context.Set<Book>().AddOrUpdate(
                b => b.Title, 
                new Book { ID = 1, UserId = idUser, Title = "Hamlet", Description = "A description of Hamlet", Author = "William Shakespeare", YearOfPublication = 1599, CategoryID = 7 },
                new Book { ID = 2, UserId = idUser, Title = "It", Description = "A description of It", Author = "Stephen King", YearOfPublication = 1986, CategoryID = 3},
                new Book { ID = 3, UserId = idUser, Title = "MacBeth", Description = "A description of MacBeth", Author = "William Shakespeare", YearOfPublication = 1606, CategoryID = 7}
            );
            //context.Books.AddRange(books);
            context.SaveChanges();
        }
        private void SeedCategories(LibraryDbContext context)
        {
            context.Set<Category>().AddOrUpdate(
                c => c.Name,
                    new Category { ID = 1, Name = "Arts & Music" },
                    new Category { ID = 2, Name = "Biographies" },
                    new Category { ID = 3, Name = "Fantasy" },
                    new Category { ID = 4, Name = "Cooking" },
                    new Category { ID = 5, Name = "History" },
                    new Category { ID = 6, Name = "Romance" },
                    new Category { ID = 7, Name = "Poetry" });
            //context.Categories.AddRange(categories);
            context.SaveChanges();
            
        }

        private void SeedComments(LibraryDbContext context)
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    var comment = new Comments()
            //    {
            //        ID = i,
            //        BookId = i,
            //        Comment = "A Comment of Book " + i.ToString(),
            //    };
            //    context.Set<Comments>().AddOrUpdate(comment);
            //}
            context.SaveChanges();
        }

    }
}
