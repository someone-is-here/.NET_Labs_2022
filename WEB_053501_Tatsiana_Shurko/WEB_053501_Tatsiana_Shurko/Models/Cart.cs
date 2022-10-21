namespace WEB_053501_Tatsiana_Shurko.Models {
    public class Cart {
        public Dictionary<int, CartItem> Items { get; set; }

        public Cart() {
            Items = new Dictionary<int, CartItem>();
        }
        public int Count {
            get {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        public decimal Price {
            get {
                return Items.Sum(item => (decimal)item.Value.Quantity * (decimal)item.Value.Book.Price);
            }
        }
        public virtual void AddToCart(Book book) {
            foreach (var items in Items) {
                if (items.Value.Book.Id == book.Id) {
                    items.Value.Quantity += 1;
                    return;
                }
            }
            
            Items.Add(book.Id, new CartItem { Book=book, Quantity = 1});
            return;
        }

        public virtual void RemoveFromCart(int id) {
            Items.Remove(id);
        }

        public virtual void ClearAll() {
            Items.Clear();
        }
        /*        public bool IsPage { get; set; }
                public float? Cost { get; set; }
                public uint? Amount { get; set; }
                public string? Controller { get; set; }
                public string? Action { get; set; }
                public string? Page { get; set; }
                public string? Area { get; set; }
                public string? CostClassStyle { get; set; }
                public string? AmountClassStyle { get; set; }
                public string? AmountStyle { get; set; }*/
    }
}
