using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class BooksFromCategoryViewModels
    {
        public IList<Book> Books { get; set; }
        public string CategoryName { get; set; }
    }
}