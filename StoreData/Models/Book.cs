using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    [Table("Book")]
    public class Book
    {
        public Book()
        {
            KeyWords = new List<Keyword>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public decimal Price { get; set; }
        
        public List<Keyword>? KeyWords { get; set; }
        public virtual Author Author { get; set; }
        
    }
}
