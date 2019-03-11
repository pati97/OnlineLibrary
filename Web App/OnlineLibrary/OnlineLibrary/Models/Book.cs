using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
      
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime YearOfPublication { get; set; }
        
        public virtual ApplicationUser User { get; set; } 
        public virtual ICollection<Comments> Comments { get; set; }
    }
}