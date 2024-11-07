//Decorator Pattern
//Add additional functionality: ability to calculate the final price 
//after applying discounts or taxes, without modifying the core functionality

namespace Lab2.Product
{
    public class TaxDecorator : IProduct
    {
        private readonly IProduct _product;
        private readonly decimal _taxPercentage;

        public TaxDecorator(IProduct product, decimal taxPercentage)
        {
            _product = product;
            _taxPercentage = taxPercentage;
        }

        public string Name => _product.Name;
        public decimal Price => _product.Price * (1 + _taxPercentage);
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