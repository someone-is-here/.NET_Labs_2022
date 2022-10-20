using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using WEB_053501_Tatsiana_Shurko.Data;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Controllers
{
    public class BookController : Controller {
        private BookContext _context;
        private decimal _amountPerPage = 3;

        public BookController(BookContext context) {
            _context = context;
            ListViewModel<Book>.AmountPerPage = (int)_amountPerPage;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{currentPage:int}/{group:int?}")]
        public IActionResult Index(int? group, int currentPage = 1) {
            group = group ?? 0;
            ListViewModel<Book>.GroupId = group ?? 0;
            ListViewModel<Book>.CurrentPage = currentPage;

            ViewData["Categories"] = _context.Categories.ToList<Category>();
            ViewData["CurrentCategory"] = group ?? 0;
            var res = ListViewModel<Book>.GetModel(_context.Books, currentPage, book => !group.HasValue || book.Category.Id == group.Value || group == 0);
            ListViewModel<Book>.TotalPages = Math.Ceiling(_context.Books.Where(book => (book != null && book.Category.Id == group) || group == 0).ToList<Book>().Count / _amountPerPage);


            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial", res);
            
            return View(res);
        }
    }
}
