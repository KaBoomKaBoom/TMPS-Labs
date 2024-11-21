namespace Lab3.Payment
{
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment...");
        }
    }
}