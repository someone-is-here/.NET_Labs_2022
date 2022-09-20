using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WEB_053501_Tatsiana_Shurko.Entities {
    public class Book {
        public int Id { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Title")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Title { get; set; }

        public string? Discription { get; set; }

        [Required]
        public float? Price { get; set; }
        public string? ImagePath { get; set; }
        public string? MimeType { get; set; }

    }
    public class Category {
        public int Id { get; set; }
        public string? Title { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
