//Chain of Responsibility pattern for placing and order and verifying order details

using Lab3.OrderSystem.Handlers;
namespace Lab3.OrderSystem
{
    public class OrderService
    {
        public void PlaceOrder(OrderContext context)
        {
            var cartHandler = new ShoppingCartNotEmptyHandler();
            var stockHandler = new StockAvailabilityHandler();
            var deliveryHandler = new DeliveryInfoHandler();
            var paymentHandler = new PaymentDetailsHandler();

            // Chain the handlers
            cartHandler.SetNext(stockHandler);
            stockHandler.SetNext(deliveryHandler);
            deliveryHandler.SetNext(paymentHandler);

            // Start the chain
            cartHandler.Handle(context);

            Console.WriteLine("Order placed successfully!");
        }
    }
}
