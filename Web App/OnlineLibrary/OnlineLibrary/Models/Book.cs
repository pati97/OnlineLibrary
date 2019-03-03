using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int YearOfPublication { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; } 

    }
}