//Decorator Pattern
//Add additional functionality: ability to calculate the final price 
//after applying discounts or taxes, without modifying the core functionality

namespace Lab3.Product
{
    public class DiscountDecorator : IProduct
    {
        private readonly IProduct _product;
        private readonly decimal _discountPercentage;

        public DiscountDecorator(IProduct product, decimal discountPercentage)
        {
            _product = product;
            _discountPercentage = discountPercentage;
        }

        public string Name => _product.Name;
        public decimal Price => _product.Price * (1 - _discountPercentage);
        public string Category => _product.Category;
        public string Description => _product.Description;
        public string SKU => _product.SKU;
        public int Stock => _product.Stock;

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price:C}, Category: {Category}, Description: {Description}, SKU: {SKU}, Stock: {Stock}");
        }
    }
}