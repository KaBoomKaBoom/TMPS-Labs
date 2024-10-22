namespace Lab1.Payment
{
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment...");
        }
    }
}