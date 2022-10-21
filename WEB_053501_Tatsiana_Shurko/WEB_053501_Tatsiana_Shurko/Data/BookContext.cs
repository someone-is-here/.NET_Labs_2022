using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Data
{
    public class BookContext:DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<WEB_053501_Tatsiana_Shurko.Models.CartItem> CartItem { get; set; }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BookContext> {
        public BookContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=myLabsDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookContext(optionsBuilder.Options);
        }
    }
}
