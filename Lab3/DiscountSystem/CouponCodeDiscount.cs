namespace Lab3.DiscountSystem
{
    public class CouponCodeDiscount : IDiscountStrategy
    {
        private readonly Dictionary<string, decimal> _validCoupons;

        public CouponCodeDiscount(Dictionary<string, decimal> validCoupons) => _validCoupons = validCoupons;

        public decimal ApplyDiscount(decimal totalAmount)
        {
            Console.Write("Enter your coupon code: ");
            string? couponCode = Console.ReadLine();

            if (!string.IsNullOrEmpty(couponCode) && _validCoupons.TryGetValue(couponCode, out var discount))
            {
                Console.WriteLine("Coupon applied successfully!");
                return totalAmount - discount;
            }

            Console.WriteLine("Invalid or expired coupon code.");
            return totalAmount;
        }
    }
}
