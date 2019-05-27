using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineLibrary.Models
{
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        [Range(0, 6)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public int BookId { get; set; }
        public virtual Book Books { get; set; }
    }
}