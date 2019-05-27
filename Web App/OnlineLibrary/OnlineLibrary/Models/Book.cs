using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Models
{
    public class Book
    {
        private readonly DAL.LibraryDbContext _db = new DAL.LibraryDbContext();

        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        [Remote("IsUserExists", "Books", ErrorMessage ="The Title already exists !")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int YearOfPublication { get; set; }
        [Remote("IsCategoryExists", "Books", ErrorMessage = "The CategoryId not exists !")]
        public int CategoryID { get; set; }
        public string FilePath { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; } 
        public virtual ICollection<Comments> Comments { get; set; }

        public IQueryable<Book> GetPage(int? page, int? pageSize)
        {
            var book = _db.Books.OrderByDescending(o => o.Title).Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            return book;
        }
    }
}