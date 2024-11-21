namespace Lab3.DiscountSystem
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount) => totalAmount;
    }
}
