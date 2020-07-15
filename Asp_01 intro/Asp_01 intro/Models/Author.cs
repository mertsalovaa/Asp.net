using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asp_01_intro.Models
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /*Nav props*/
        public ICollection<Book> Books { get; set; }
    }
}