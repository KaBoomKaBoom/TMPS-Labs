namespace Lab3.Payment
{
    public class ApplePayPayment : Payment
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("Processing Apple Pay payment...");
        }
    }
}