using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Components {
    public class CartComponent : ViewComponent {
        private List<Cart> _cart = new List<Cart> {
            new Cart{ Controller="Cart", Action="Index", Cost=13.24F,
                CostClassStyle="navbar-text ml-auto", Amount=2,
                AmountClassStyle="fas fa-shopping-cart nav-color", AmountStyle="margin-left: 10px;"
                }
        };

        public IViewComponentResult Invoke() {
            return View(_cart);
        }
    }
}