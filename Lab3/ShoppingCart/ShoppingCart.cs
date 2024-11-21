using Lab3.DiscountSystem;

namespace Lab3.ShoppingCart
{
    public class ShoppingCart
    {
        private static ShoppingCart? _instance;
        private IDiscountStrategy _discountStrategy;
        private ShoppingCart()
        {
            _discountStrategy = new NoDiscount();
        }

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

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal CalculateTotal()
        {
            decimal totalAmount = Products.Sum(p => p.Price);
            return _discountStrategy.ApplyDiscount(totalAmount);
        }


        public List<Product.Product> Products { get; set; } = new List<Product.Product>();
    }
}