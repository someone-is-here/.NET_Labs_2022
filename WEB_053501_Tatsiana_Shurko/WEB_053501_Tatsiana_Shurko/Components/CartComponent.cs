using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WEB_053501_Tatsiana_Shurko.Models;
using Newtonsoft.Json;

namespace WEB_053501_Tatsiana_Shurko.Components {
    public class CartComponent : ViewComponent {
        private Cart _cart = new Cart { };

        public CartComponent(Cart cart) {
            _cart = cart;
            ViewBag.CostClassStyle = "navbar-text ml-auto";
            ViewBag.AmountClassStyle = "fas fa-shopping-cart nav-color";
            ViewBag.AmountStyle = "margin-left: 10px;";
        }

        public IViewComponentResult Invoke() {
            if (HttpContext.Session.GetString("cart") != null) {
                _cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("cart"));
            }
            return View(_cart);
        }
    }
}