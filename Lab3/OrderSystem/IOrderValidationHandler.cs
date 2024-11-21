namespace Lab3.OrderSystem
{
    public interface IOrderValidationHandler
    {
        void SetNext(IOrderValidationHandler nextHandler);
        void Handle(OrderContext context);
    }
}
