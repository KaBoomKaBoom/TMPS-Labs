namespace Lab3.ShoppingCart
{
    public class ShoppingCart
    {
        private static ShoppingCart? _instance;
        private ShoppingCart() { }

        public static ShoppingCart Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShoppingCart();
                }
                return _instance;
            }
        }

        public List<Product.Product> Products { get; set; } = new List<Product.Product>();
    }
}