namespace Lab1.Payment
{
    public class PaymentFactory
    {
        public static IPayment CreatePayment(string type)
        {
            switch (type)
            {
                case "CreditCard":
                    return new CreditCardPayment();
                case "PayPal":
                    return new PayPalPayment();
                default:
                    throw new Exception("Payment method not supported.");
            }
        }
    }
}