// OCP: Implementing a percentage-based discount strategy.
public class PercentageDiscountStrategy : IDiscountStrategy
{
    private decimal _percentage;

    public PercentageDiscountStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal total)
    {
        return total - (total * _percentage / 100);
    }
}