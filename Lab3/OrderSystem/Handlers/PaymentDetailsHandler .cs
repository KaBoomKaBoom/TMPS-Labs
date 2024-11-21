using Lab3.OrderSystem;
namespace Lab3.OrderSystem.Handlers
{
    public class PaymentDetailsHandler : OrderValidationHandler
    {
        public override void Handle(OrderContext context)
        {
            if (string.IsNullOrWhiteSpace(context.PaymentDetails))
            {
                throw new Exception("Payment details are missing or invalid.");
            }

            NextHandler?.Handle(context);
        }
    }
}
