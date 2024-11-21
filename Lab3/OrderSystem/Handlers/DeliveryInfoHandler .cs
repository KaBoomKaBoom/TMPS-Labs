using Lab3.OrderSystem;
namespace Lab3.OrderSystem.Handlers
{
    public class DeliveryInfoHandler : OrderValidationHandler
    {
        public override void Handle(OrderContext context)
        {
            if (string.IsNullOrWhiteSpace(context.DeliveryInformation))
            {
                throw new Exception("Delivery information is missing or invalid.");
            }

            NextHandler?.Handle(context);
        }
    }
}
