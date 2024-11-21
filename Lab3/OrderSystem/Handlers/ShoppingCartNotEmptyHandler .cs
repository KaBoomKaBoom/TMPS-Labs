using Lab3.OrderSystem;
namespace Lab3.OrderSystem.Handlers
{
    public class ShoppingCartNotEmptyHandler : OrderValidationHandler
    {
        public override void Handle(OrderContext context)
        {
            if (context.ShoppingCart.Products.Count == 0)
            {
                throw new Exception("Shopping cart is empty.");
            }

            NextHandler?.Handle(context);
        }
    }
}
