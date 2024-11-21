namespace Lab3.DiscountSystem
{
    public class SeasonalDiscount : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public SeasonalDiscount(decimal percentage) => _percentage = percentage;

        public decimal ApplyDiscount(decimal totalAmount) => totalAmount - (totalAmount * _percentage / 100);
    }
}