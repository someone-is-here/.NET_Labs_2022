using Microsoft.AspNetCore.Mvc;

namespace WEB_053501_Tatsiana_Shurko.Models {
    public class CartItem {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
