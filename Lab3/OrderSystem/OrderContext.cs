
namespace Lab3.OrderSystem
{
    public class OrderContext
    {
        public ShoppingCart.ShoppingCart ShoppingCart { get; set; }
        public string DeliveryInformation { get; set; }
        public string PaymentDetails { get; set; }

        public OrderContext(ShoppingCart.ShoppingCart shoppingCart, string deliveryInformation, string paymentDetails)
        {
            ShoppingCart = shoppingCart;
            DeliveryInformation = deliveryInformation;
            PaymentDetails = paymentDetails;
        }
    }
}
