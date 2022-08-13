using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    [Table("BookHasKeyword")]
    public class Keyword
    {
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Name { get; set; }
    }
}
