using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using WEB_053501_Tatsiana_Shurko.Data;
using WEB_053501_Tatsiana_Shurko.Entities;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Controllers {
    public class BookController : Controller {
        private BookContext _context;
        private int _amountPerPage=3;
        
        public BookController(BookContext context) {
            _context = context;
        }

        public IActionResult Index(int? group, int currentPage = 1) {
            ViewData["Categories"] = _context.Categories.ToList<Category>();
            ViewData["CurrentCategory"] = group ?? 0;

            return View(ListViewModel<Book>.GetModel(_context.Books, currentPage, _amountPerPage, book => !group.HasValue || book.Category.Id == group.Value));
        }
    }
}
