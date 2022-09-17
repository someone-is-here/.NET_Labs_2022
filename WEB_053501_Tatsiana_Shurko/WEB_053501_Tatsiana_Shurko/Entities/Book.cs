using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WEB_053501_Tatsiana_Shurko.Entities {
    public class Book {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Title { get; set; }

        public string? Discription { get; set; }

        [Required]
        public double? Price { get; set; }
        public string? ImagePath { get; set; }
        public string? MimeType { get; set; }

    }
    public class Category {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public string? Title { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
