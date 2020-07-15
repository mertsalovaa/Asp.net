using System.ComponentModel.DataAnnotations;

namespace Asp_01_intro.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        [Required]
        public string Img { get; set; }

        /*Navigation Properties*/

        public Author Author { get; set; }
        public Genre Genre { get; set; }

    }
}
