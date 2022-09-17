using Microsoft.AspNetCore.Mvc;
using WEB_053501_Tatsiana_Shurko.Entities;

namespace WEB_053501_Tatsiana_Shurko.Controllers {
    public class BookController : Controller {
        private List<Book>? _books;
        private List<Category>? _categories;

        public BookController() {
            Initialize();
        }

        public void Initialize() {
            _books = new List<Book> {
                new Book{ Id=1, Title="Harry potter and the philosopher's stone", Discription="J. K. Rowling, 1997", Price=13.45,ImagePath="images/books/1.jpg"},
                new Book{ Id=2, Title="Harry potter and the chamber of secrets", Discription="J. K. Rowling, 1998", Price=13.45,ImagePath="images/books/2.jpg"},
                new Book{ Id=3, Title="Harry potter and the prisoner of azkaban", Discription="J. K. Rowling, 1999", Price=13.45,ImagePath="images/books/3.jpg"},
                new Book{ Id=4, Title="Harry potter and the goblet of fire", Discription="J. K. Rowling, 2000", Price=13.45,ImagePath="images/books/4.jpg"},
                new Book{ Id=5, Title="Harry potter and the order of the phoenix", Discription="J. K. Rowling, 2003", Price=13.45,ImagePath="images/books/5.jpg"},
                new Book{ Id=6, Title="Harry potter and the half-blood prince", Discription="J. K. Rowling, 2005", Price=13.45,ImagePath="images/books/6.jpg"},
                new Book{ Id=7, Title="Harry potter and the deathly hallows", Discription="J. K. Rowling, 2007", Price=13.45,ImagePath="images/books/7.jpg"},
                new Book{ Id=8, Title="The Alchemist's Secret", Discription="Scott Mariani, 2007", Price=13.45,ImagePath="images/books/8.jpg"},
                new Book{ Id=9, Title="The Mozart Conspiracy", Discription="Scott Mariani, 2008", Price=13.45,ImagePath="images/books/9.jpg"},

            };
            _categories = new List<Category> { 
            new Category{ Id=1, Title="Thrillers", Books=_books.FindAll(book => book.Discription.Contains("Scott Mariani"))},
            new Category{ Id=2, Title="Detectives"},
            new Category{ Id=3, Title="Adventures"},
            new Category{ Id=4, Title="Fantasy", Books=_books.FindAll(book => book.Discription.Contains("J. K. Rowling"))}
            };
           
        }

        public IActionResult Index() {
            return View(_books);
        }
    }
}
