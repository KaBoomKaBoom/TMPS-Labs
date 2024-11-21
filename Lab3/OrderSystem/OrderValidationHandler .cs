namespace Lab3.OrderSystem
{
    public abstract class OrderValidationHandler : IOrderValidationHandler
    {
        protected IOrderValidationHandler? NextHandler;

        public void SetNext(IOrderValidationHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void Handle(OrderContext context);
    }
}
