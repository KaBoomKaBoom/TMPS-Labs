namespace Lab2.Payment
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
                case "ApplePay":
                    return new ApplePayPayment();
                case "GooglePay":
                    return new GooglePayPayment();
                default:
                    throw new Exception("Payment method not supported.");
            }
        }
    }
}