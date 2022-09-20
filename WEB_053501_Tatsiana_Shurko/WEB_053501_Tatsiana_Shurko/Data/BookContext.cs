using Microsoft.EntityFrameworkCore;
using WEB_053501_Tatsiana_Shurko.Entities;

namespace WEB_053501_Tatsiana_Shurko.Data {
    public class BookContext:DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
    }
}
