using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asp_01_intro.Models
{
    public class Genre
    {
        public Genre()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /*Navigation props*/
        public ICollection<Book> Books { get; set; }
    }
}