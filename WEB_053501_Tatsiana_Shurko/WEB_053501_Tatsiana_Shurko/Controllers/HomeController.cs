using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB_053501_Tatsiana_Shurko.Controllers {
    public class HomeController : Controller {
        private List<ListDemo> _listDemo;

        [ViewData]
        public string? Text { get; set; }

        public HomeController() {
            _listDemo = new ();
            _listDemo.Add(new ListDemo { ListItemValue = 1, ListItemText = "Item 1" });
            _listDemo.Add(new ListDemo { ListItemValue = 2, ListItemText = "Item 2" });
            _listDemo.Add(new ListDemo { ListItemValue = 3, ListItemText = "Item 3" });
        }

        public IActionResult Index() {
            Text = "Laboratory work 2";
            ViewData["SelectedList"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");

            return View();
        }
    }
    public class ListDemo { 
        public int ListItemValue { get; set; }
        public string? ListItemText { get; set; }
    }
}
