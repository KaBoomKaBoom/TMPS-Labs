// SRP: ShoppingCart handles product operations and calculates the total price.
public class ShoppingCart
{
    private List<Product> _products = new List<Product>();
    private IDiscountStrategy _discountStrategy;

    public ShoppingCart(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotal()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.Price;
        }

        // OCP: Apply discount strategy without modifying ShoppingCart.
        return _discountStrategy.ApplyDiscount(total);
    }
}