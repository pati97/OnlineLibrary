using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Category
    {
        private readonly DAL.LibraryDbContext _db = new DAL.LibraryDbContext();

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfBooks { get; set;}

        public virtual ICollection<Book> Books { get; set; }
         
        public IQueryable<Book> GetBooksFromCategory(int id)
        {
            var books = from b in _db.Books
                        where b.CategoryID == id
                        select b;
            return books;
        }

        public int GetNumberOfBooksInCategory(int id)
        {
            var number = from b in _db.Books
                         where b.CategoryID == id
                         select b;
            return number.Count();                 
        }

        public string NameForCategory(int id)
        {
            var name = _db.Categories.Find(id).Name;
            return name;
        }
    }
}