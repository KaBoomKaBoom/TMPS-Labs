namespace Lab3.DiscountSystem
{
    public class MemberDiscount : IDiscountStrategy
    {
        private readonly decimal _memberDiscount;

        public MemberDiscount(decimal memberDiscount) => _memberDiscount = memberDiscount;

        public decimal ApplyDiscount(decimal totalAmount) => totalAmount - _memberDiscount;
    }
}