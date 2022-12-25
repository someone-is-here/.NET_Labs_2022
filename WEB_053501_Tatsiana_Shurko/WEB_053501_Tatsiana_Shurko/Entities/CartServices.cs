using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WEB_053501_Tatsiana_Shurko.Models;

namespace WEB_053501_Tatsiana_Shurko.Entities {
    public class CartService : Cart {

        private string sessionKey = "cart";

/*        [JsonIgnore]*/
        ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider sp) {
            // получить объект сессии
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            // получить CartService из сессии
            // или создать новый для возможности тестирования
            CartService cartService;
            if (session.GetString("cart") != null) {
                cartService = JsonConvert.DeserializeObject<CartService>(session.GetString("cart"));
            } else {
                cartService = new CartService();
            }
            // var cart = JsonConvert.DeserializeObject<CartService>(session?.GetString("cart")) ?? new CartService();

            cartService.Session = session;
            return cartService;
        }
        // переопределение методов класса Cart
        // для сохранения результатов в сессии
        public override void AddToCart(Book dish) {
            base.AddToCart(dish);
            Session?.SetString(sessionKey, JsonConvert.SerializeObject(this));
        }
        public override void RemoveFromCart(int id) {
            base.RemoveFromCart(id);
            Session?.SetString(sessionKey, JsonConvert.SerializeObject(this));
        }
        public override void ClearAll() {
            base.ClearAll();
            Session?.SetString(sessionKey, JsonConvert.SerializeObject(this));
        }
    }
}
