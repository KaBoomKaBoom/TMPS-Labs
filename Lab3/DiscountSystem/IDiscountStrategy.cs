//Strategy pattern interface for discounting products based on a strategy pattern

namespace Lab3.DiscountSystem
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalAmount);
    }
}