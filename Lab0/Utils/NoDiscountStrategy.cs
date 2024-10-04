// OCP: Implementing a no-discount strategy.
public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal total)
    {
        return total; // No discount applied.
    }
}