using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WEB_053501_Tatsiana_Shurko.Data;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Controllers {
    public class CartController : Controller {
        private BookContext _context;
        private Cart _cart = new Cart();

        public CartController(BookContext context, Cart cart) {
            _context = context;
            _cart = cart;  
        }

        public IActionResult Index() {
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl) {
            if (HttpContext.Session.GetString("cart") != null) {
                _cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cart"));
            }
            var book = _context.Books.Find(id);
            if (book != null) {
                _cart.AddToCart(book);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(_cart));
            }
            return Redirect(returnUrl);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id) {
            if (id == null || _context.Books == null) {
                return NotFound();
            }

            CartItem? item;
            _cart.Items.TryGetValue(id, out item);

            if (item == null) {
                return NotFound();
            }

            return View(item);
        }

        // POST: Admin/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (HttpContext.Session.GetString("cart") != null) {
                _cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cart"));
            }


            _cart.RemoveFromCart(id);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(_cart));

            return RedirectToAction(nameof(Index));
        }

    }
}
