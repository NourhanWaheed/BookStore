using StoreData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    [Table("Author")]
    public class Author:IBase
    {
        public Author()
        {
            BookList = new List<Book>();
        }
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? URL { get; set; }
        [DataType(DataType.MultilineText)]
        public string? About{ get; set; }
        public virtual List<Book> BookList { get; set; }

    }
}
