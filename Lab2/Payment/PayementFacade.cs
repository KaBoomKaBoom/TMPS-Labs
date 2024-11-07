//Facade class that uses the factory to create the payment method and process the payment
//Better, because of moving the below logic to a separate class.
//  IPayment payment = PaymentFactory.CreatePayment("PayPal");
//  payment.ProcessPayment();

namespace Lab2.Payment
{
    public class PaymentFacade
    {
        public void ProcessPayment(string paymentType, decimal amount)
        {
            IPayment paymentMethod = PaymentFactory.CreatePayment(paymentType);
            paymentMethod.ProcessPayment();
            Console.WriteLine($"Payment of {amount:C} processed successfully using {paymentType}.");
        }
    }
}