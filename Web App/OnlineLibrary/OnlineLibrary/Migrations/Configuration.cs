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

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineLibrary.DAL.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineLibrary.DAL.LibraryDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            //SeedRoles(context);
            //SeedUsers(context);
            //SeedBooks(context);
            //SeedCategories(context);
            //SeedComments(context);
        }

        //private void SeedRoles(LibraryDbContext context)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        var role = new IdentityRole()
        //        {
        //            Name = "Admin"
        //        };
        //        roleManager.Create(role);
        //    }

        //    if (!roleManager.RoleExists("U¿ytkownik"))
        //    {
        //        var role = new IdentityRole()
        //        {
        //            Name = "U¿ytkownik"
        //        };
        //        roleManager.Create(role);
        //    }
        //}

        //private void SeedUsers(LibraryDbContext context)
        //{
        //    var store = new UserStore<ApplicationUser>(context);
        //    var manager = new UserManager<ApplicationUser>(store);

        //    if (!context.Users.Any(u => u.UserName == "Admin"))
        //    {
        //        var user = new ApplicationUser { UserName = "Admin" };
        //        var adminresult = manager.Create(user, "12345678");
        //        if (adminresult.Succeeded)
        //        {
        //            manager.AddToRole(user.Id, "Admin");
        //        }
        //    }

        //    if (!context.Users.Any(u => u.UserName == "Marek"))
        //    {
        //        var user = new ApplicationUser { UserName = "marek@AspNetMvc.pl" };
        //        var adminresult = manager.Create(user, "12345678");
        //        if (adminresult.Succeeded)
        //        {
        //            manager.AddToRole(user.Id, "U¿ytkownik");
        //        }
        //    }
        //}
        //private void SeedBooks(LibraryDbContext context)
        //{
        //    var idUser = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
        //    for(int i = 1; i <= 10; i++)
        //    {
        //        var book = new Book()
        //        {
        //            ID = i,
        //            UserId = idUser,
        //            Title = "A Book Title " + i.ToString(),
        //            Description = "A Description of Book " + i.ToString(),
        //            Author = "An Author of Book " + i.ToString(),
        //            YearOfPublication = DateTime.Now.AddYears(-i)
        //        };
        //        context.Set<Book>().AddOrUpdate(book);
        //    }
        //    context.SaveChanges();
        //}
        //private void SeedCategories(LibraryDbContext context)
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        var categories = new Category()
        //        {
        //            ID = i,
        //            Name = "The Name of Category " + i.ToString(),
        //        };
        //        context.Set<Category>().AddOrUpdate(categories);
        //    }
        //    context.SaveChanges();
        //}

        //private void SeedComments(LibraryDbContext context)
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        var comment = new Comments()
        //        {
        //            ID = i,
        //            BookId = i,
        //            Comment = "A Comment of Book " + i.ToString(),
        //        };
        //        context.Set<Comments>().AddOrUpdate(comment);
        //    }
        //    context.SaveChanges();
        //}

    }
}
