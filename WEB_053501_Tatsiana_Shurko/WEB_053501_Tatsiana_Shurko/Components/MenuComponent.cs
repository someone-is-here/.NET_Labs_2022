using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Components {
    public class MenuComponent : ViewComponent {
        private List<MenuItem> _menuItems = new List<MenuItem> {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 2" },
            new MenuItem{ Controller="Book", Action="Index", Text="Catalog" },
            new MenuItem{ Controller="Admin", Action="Index", Text="Administration" },
        };

        public IViewComponentResult Invoke() {
            foreach (MenuItem item in _menuItems) {
                if ((ViewContext.RouteData.Values["Controller"]?.ToString() != null && ViewContext.RouteData.Values["Controller"]?.ToString() == item.Controller) ||
                   (ViewContext.RouteData.Values["Area"]?.ToString() != null && ViewContext.RouteData.Values["Area"]?.ToString() == item.Area) ||
                   (ViewContext.RouteData.Values["Page"]?.ToString() != null && ViewContext.RouteData.Values["Page"]?.ToString() == item.Page)) {
                    item.Active = "active-link";
                }
            }

            return View(_menuItems);
        }
    }
}
