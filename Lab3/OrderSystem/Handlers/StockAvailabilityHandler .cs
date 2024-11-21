using Lab3.OrderSystem;
namespace Lab3.OrderSystem.Handlers
{
    public class StockAvailabilityHandler : OrderValidationHandler
    {
        public override void Handle(OrderContext context)
        {
            foreach (var product in context.ShoppingCart.Products)
            {
                if (product.Stock <= 0)
                {
                    throw new Exception($"Product {product.Name} is out of stock.");
                }
            }

            NextHandler?.Handle(context);
        }
    }
}
